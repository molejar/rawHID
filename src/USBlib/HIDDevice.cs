using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;

namespace UsbLibrary
{
	#region Custom exception
	/// <summary>
	/// Generic HID device exception
	/// </summary>
	public class HIDDeviceException : ApplicationException
	{
		public HIDDeviceException(string strMessage) : base(strMessage) { }

		public static HIDDeviceException GenerateWithWinError(string strMessage)
		{
			return new HIDDeviceException(string.Format("Msg:{0} WinEr:{1:X8}", strMessage, Marshal.GetLastWin32Error()));
		}

		public static HIDDeviceException GenerateError(string strMessage)
		{
			return new HIDDeviceException(string.Format("Msg:{0}", strMessage));
		}
	}
	#endregion

	class HIDDevice : Win32Usb, IDisposable
	{
		#region Event Handlers
		/// <summary>
		/// Event handler called when device has send new data
		/// </summary>
		public event DataRecievedEventHandler OnDataRecieved;

		/// <summary>
		/// Event handler called when device has get new data
		/// </summary>
		public event DataSendEventHandler OnDataSend;

		/// <summary>
		/// Event handler called when device has been removed
		/// </summary>
		public event EventHandler OnDeviceRemoved;

		/// <summary>
		/// Event handler called when device has been arrived
		/// </summary>
		public event EventHandler OnDeviceArrived;
		#endregion

		#region Privates variables
		/// <summary>Filestream we can use to read/write from</summary>
		private FileStream m_oFile;
		/// <summary>Length of input report : device gives us this</summary>
		private int m_inputReportLength;
		/// <summary>Length if output report : device gives us this</summary>
		private int m_outputReportLength;
		/// <summary>Handle to the device</summary>
		private IntPtr m_hHandle;

		/// <summary>
		/// Connected device info variables
		/// </summary>
		private string m_manufacturerString;
		private string m_productString;
		private string m_serialNumberString;
		private string m_devicePath;
		private UInt16 m_version;
		private UInt16 m_vendorId;
		private UInt16 m_productId;
		private bool   m_isConnected;

		/// <summary>
		/// Read mode
		/// </summary>
		private bool m_useAsyncReads;

		/// <summary>
		/// On Device Arrived/Removed
		/// </summary>
		private readonly Guid m_deviceClass;
		private IntPtr m_usbEventHandle;
		private IntPtr m_formHandle;
		#endregion

		#region Initialization

		public HIDDevice()
		{
			m_hHandle = IntPtr.Zero;
			m_isConnected = false;
			m_deviceClass = HIDGuid;
		}

		#endregion

		#region IDisposable Members
		/// <summary>
		/// Dispose method
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Disposer called by both dispose and finalise
		/// </summary>
		/// <param name="bDisposing">True if disposing</param>
		protected virtual void Dispose(bool bDisposing)
		{
			try
			{
				// if we are disposing, need to close the managed resources
				if (bDisposing)
				{
					if (m_oFile != null)
					{
						m_oFile.Close();
						m_oFile = null;
					}
				}

				// Dispose and finalize, get rid of unmanaged resources
				if (m_hHandle != IntPtr.Zero)
				{
					CloseHandle(m_hHandle);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
		#endregion

		#region Connected Device info

		/// <summary>
		/// Identifies the manufacturer's name
		/// </summary>
		public string ManufacturerString
		{
			get { return m_manufacturerString; }
		}

		/// <summary>
		/// Identifies the product name
		/// </summary>
		public string ProductString
		{
			get { return m_productString; }
		}

		/// <summary>
		/// Serial number
		/// </summary>
		public string SerialNumberString
		{
			get { return m_serialNumberString; }
		}

		/// <summary>
		/// Product Version
		/// </summary>
		public UInt16 Version
		{
			get { return m_version; }
		}

		/// <summary>
		/// Product Version in BCD Format as String
		/// </summary>
		public string VersionInBCD
		{
			get
			{
				if (((byte)(Version >> 24)) == 0)
				{
					return String.Format("{0}.{1}{2}", (byte)(m_version >> 16), (byte)(m_version >> 8), (byte)m_version);
				}

				return String.Format("{0}{1}.{2}{3}", (byte)(m_version >> 24), (byte)(m_version >> 16), (byte)(m_version >> 8), (byte)m_version);
			}
		}

		/// <summary>
		/// Full device file path
		/// </summary>
		public string DevicePath
		{
			get { return m_devicePath; }
		}

		/// <summary>
		/// Vendor ID
		/// </summary>
		public UInt16 VendorID
		{
			get { return m_vendorId; }
		}

		/// <summary>
		/// Product ID
		/// </summary>
		public UInt16 ProductID
		{
			get { return m_productId; }
		}

		/// <summary>
		/// IN Report Byte Length
		/// </summary>
		public short InReportLength
		{
			get { return (short)(m_inputReportLength > 0 ? m_inputReportLength - 1 : m_inputReportLength); }
		}

		/// <summary>
		/// OUT Report Byte Length
		/// </summary>
		public short OutReportLength
		{
			get { return (short)(m_outputReportLength > 0 ? m_outputReportLength - 1 : m_outputReportLength); }
		}

		/// <summary>
		/// Connection stat
		/// </summary>
		public bool IsConnected
		{
			get { return m_isConnected; }
		}

		/// <summary>
		/// Is Async read
		/// </summary>
		public bool IsAsyncRead
		{
			get { return m_useAsyncReads; }
		}

		#endregion

		#region Local_methods

		/// <summary>
		/// Connect to device
		/// </summary>
		public bool Connect(short vid, short pid, bool useAsyncRead)
		{
			var connectedDeviceList = GetInfoSets(vid, pid);

			if (connectedDeviceList.Count > 0)
			{
				return Connect(connectedDeviceList[0].DevicePath, useAsyncRead);
			}

			return false;
		}

		/// <summary>
		/// Connect to device
		/// </summary>
		public bool Connect(string devicePath, bool useAsyncRead)
		{
			if (m_isConnected) return false;

			// Create the file from the device path
			m_hHandle = CreateFile(devicePath, GENERIC_READ | GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, FILE_FLAG_OVERLAPPED, IntPtr.Zero);

			if ( m_hHandle != InvalidHandleValue || m_hHandle == null)	// if the open worked...
			{
				IntPtr lpData;
				if (HidD_GetPreparsedData(m_hHandle, out lpData))	// get windows to read the device data into an internal buffer
				{
					try
					{
						// Get HID device informations
						m_devicePath = devicePath;
						m_manufacturerString = GetManufacturerString(m_hHandle);
						m_productString = GetProductString(m_hHandle);
						m_serialNumberString = GetSerialNumber(m_hHandle);

						HIDD_ATTRIBUTES attributes;
						GetAttr(m_hHandle, out attributes);
						m_version = attributes.VersionNumber;
						m_vendorId = attributes.VendorID;
						m_productId = attributes.ProductID;

						HidP_Caps oCaps;
						HidP_GetCaps(lpData, out oCaps);	// extract the device capabilities from the internal buffer
						m_inputReportLength = oCaps.InputReportByteLength;	// get the input...
						m_outputReportLength = oCaps.OutputReportByteLength;	// ... and output report lengths


						//m_oFile = new FileStream(m_hHandle, FileAccess.Read | FileAccess.Write, true, m_nInputReportLength, true);
						m_oFile = new FileStream(new SafeFileHandle(m_hHandle, false), FileAccess.Read | FileAccess.Write, m_inputReportLength, useAsyncRead);
					}
					catch (Exception ex)
					{
						throw HIDDeviceException.GenerateWithWinError("Failed to get the detailed data from the hid.");
					}
					finally
					{
						HidD_FreePreparsedData(ref lpData);	// before we quit the funtion, we must free the internal buffer reserved in GetPreparsedData
					}
				}
				else	// GetPreparsedData failed? Chuck an exception
				{
					throw HIDDeviceException.GenerateWithWinError("GetPreparsedData failed");
				}
			}
			else	// File open failed? Chuck an exception
			{
				m_hHandle = IntPtr.Zero;
				throw HIDDeviceException.GenerateWithWinError("Failed to create device file");
			}

			m_useAsyncReads = useAsyncRead;
			m_isConnected = true;

			if (m_useAsyncReads) BeginAsyncRead();	// kick off the first asynchronous read

			return true;
		}

		/// <summary>
		/// Disconnect from device
		/// </summary>
		public void Disconnect()
		{
			if (!m_isConnected) return;

			m_isConnected = false;

			m_manufacturerString = String.Empty;
			m_productString = String.Empty;
			m_serialNumberString = String.Empty;
			m_devicePath = String.Empty;
			m_outputReportLength = 0;
			m_inputReportLength = 0;
			m_productId = 0;
			m_vendorId = 0;
			m_version = 0;

			if (m_oFile != null)
			{
				m_oFile.Close();
				m_oFile = null;
			}

			if (m_hHandle != IntPtr.Zero)
			{
				CloseHandle(m_hHandle);
			}
		}

		/// <summary>
		/// Virtual handler for any action to be taken when a device is removed. Override to use.
		/// </summary>
		protected virtual void HandleDataSend(HIDReport report)
		{
			OnDataSend?.Invoke(this, report);
		}

		/// <summary>
		/// Write data into device
		/// </summary>
		public bool Write(HIDReport report)
		{
			if (!m_isConnected)
			{
				return false;
			}

			if (report.Length > m_outputReportLength)
			{
				throw new Exception("Report len must not exceed " +
									m_outputReportLength.ToString(CultureInfo.InvariantCulture) +
                                    " bytes");
			}

			try
			{
				m_oFile.Write(report.ToArray(), 0, report.Length);
				HandleDataSend(report);
			}
			catch
			{
				return false; // The device was removed!
            }

			return true;
		}

        public bool WriteFeature(HIDReport report)
        {
            if (!m_isConnected)
            {
                return false;
            }

            try
            {
                //HidD_SetFeature(m_hHandle, report.ToArray(), report.Length);
            }
            catch
            {
                return false; // The device was removed!
            }

            return true;
        }

		/// <summary>
		/// virtual handler for any action to be taken when data is received. Override to use.
		/// </summary>
		/// <param name="data">The input report that was received</param>
		protected virtual void HandleDataReceived(HIDReport report)
		{
			// Fire the event handler if assigned
			OnDataRecieved?.Invoke(this, report);
		}

		/// <summary>
		/// Kicks off an asynchronous read which completes when data is read or when the device
		/// is disconnected. Uses a callback.
		/// </summary>
		private void BeginAsyncRead()
		{
			var arrInputReport = new byte[m_inputReportLength];
			// put the buff we used to receive the stuff as the async state then we can get at it when the read completes
			m_oFile.BeginRead(arrInputReport, 0, m_inputReportLength, new AsyncCallback(ReadCompleted), arrInputReport);
		}

		/// <summary>
		/// Callback for above. Care with this as it will be called on the background thread from the async read
		/// </summary>
		/// <param name="iResult">Async result parameter</param>
		protected void ReadCompleted(IAsyncResult iResult)
		{
			if (!m_isConnected || (m_oFile == null)) return;

			// retrieve the read buffer
			var arrBuff = (byte[])iResult.AsyncState;

			try
			{
				m_oFile.EndRead(iResult);	// call end read : this throws any exceptions that happened during the read

				try
				{
					HandleDataReceived(new HIDReport(arrBuff));	// pass the new input report on to the higher level handler
				}
				finally
				{
					BeginAsyncRead();	// when all that is done, kick off another read for the next report
				}
			}
			catch (IOException ex)	// if we got an IO exception, the device was removed
			{
				//HandleDeviceRemoved();
				OnDeviceRemoved?.Invoke(this, new EventArgs());

				Dispose();

				// The device was removed!
				//MessageBox.Show(ex.Message, "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			catch (Exception ex)
			{
				// The device was removed!
				MessageBox.Show(ex.Message, "ERROR !", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// This read function is for normal synchronous reads
		/// </summary>
		/// <returns></returns>
		public HIDReport Read()
		{
			if (m_useAsyncReads)
			{
				throw new Exception("A synchonous read cannot be executed when operating in async mode");
			}

			//Call readFile
			var readBuf = new byte[m_inputReportLength];
			m_oFile.Read(readBuf, 0, readBuf.Length);
			return new HIDReport(readBuf);
		}

		#endregion

		#region Static_methods

		/// <summary>
		/// Return a list information of connected USB HID devices
		/// </summary>
		public static List<HIDInfoSet> GetInfoSets()
		{
			return GetInfoSets(null, null);
		}

		/// <summary>
		/// Return a list information of connected USB HID devices
		/// </summary>
		public static List<HIDInfoSet> GetInfoSets(int VendorID)
		{
			return GetInfoSets(VendorID, null, null);
		}

		/// <summary>
		/// Return a list information of connected USB HID devices
		/// </summary>
		public static List<HIDInfoSet> GetInfoSets(int? VendorID, int? ProductID)
		{
			return GetInfoSets(VendorID, ProductID, null);
		}

		/// <summary>
		/// Return a list information of connected USB HID devices
		/// </summary>
		public static List<HIDInfoSet> GetInfoSets(int? VendorID, int? ProductID, string SerialNumber)
		{
			string strSearch;


			if ((VendorID != null) && (ProductID != null))
			{
				strSearch = string.Format("vid_{0:x4}&pid_{1:x4}", VendorID, ProductID); // first, build the path search string
			}
			else if (VendorID != null)
			{
				strSearch = string.Format("vid_{0:x4}&pid_", VendorID); // first, build the path search string
			}
			else
			{
				strSearch = "vid_";
			}

			var connectedDeviceList = new List<HIDInfoSet>();
			var gHid = HIDGuid;     // get the GUID from Windows that it uses to represent the HID USB interface
			var hInfoSet = SetupDiGetClassDevs(ref gHid, null, IntPtr.Zero, DIGCF_DEVICEINTERFACE | DIGCF_PRESENT);

			if (hInfoSet == InvalidHandleValue)
			{
				throw new Win32Exception();
			}

			try
			{
				var oInterface = new DeviceInterfaceData();
				oInterface.Size = Marshal.SizeOf(oInterface);
				int nIndex = 0;

				while (SetupDiEnumDeviceInterfaces(hInfoSet, 0, ref gHid, (uint)nIndex, ref oInterface))
				{
					var strDevicePath = GetDevicePath(hInfoSet, ref oInterface);

					// do a string search, if we find the VID/PID string then we found our device!
					if (strDevicePath.IndexOf(strSearch) >= 0)
					{
						var handle = Open(strDevicePath);
						if (handle != InvalidHandleValue)
						{
							IntPtr ptrToPreParsedData;
							if (HidD_GetPreparsedData(handle, out ptrToPreParsedData))
							{
								HIDD_ATTRIBUTES attributes;
								HidP_Caps caps;

								// check device serial number, if specify
								if (((SerialNumber != null) && (GetSerialNumber(handle) == SerialNumber)) || (SerialNumber == null))
								{
									// Get founded HID device informations
									var manufacturerString = GetManufacturerString(handle);
									var productString = GetProductString(handle);
									var serialNumberString = GetSerialNumber(handle);
									GetAttr(handle, out attributes);
									GetCaps(ptrToPreParsedData, out caps);

									// Add founded HID device to connection list
									connectedDeviceList.Add(new HIDInfoSet(manufacturerString,
																		   productString,
																		   serialNumberString,
																		   strDevicePath,
																		   attributes.VendorID,
																		   attributes.ProductID,
																		   attributes.VersionNumber,
																		   caps.InputReportByteLength,
																		   caps.OutputReportByteLength));
								}

								if (handle != IntPtr.Zero)
								{
									CloseHandle(handle);
								}
							}
						}
					}
					nIndex++;
				}
			}
			catch (Exception ex)
			{
				throw HIDDeviceException.GenerateError(ex.ToString());
			}
			finally
			{
				// Before we go, we have to free up the InfoSet memory reserved by SetupDiGetClassDevs
				SetupDiDestroyDeviceInfoList(hInfoSet);
			}

			return connectedDeviceList;
		}

		/// <summary>
		/// Open USB HID device
		/// </summary>
		private static IntPtr Open(string devicePath)
		{
			return CreateFile(devicePath, GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, FILE_FLAG_OVERLAPPED, IntPtr.Zero);
		}

		/// <summary>
		/// Get USB HID device Caps
		/// </summary>
		private static void GetCaps(IntPtr handle, out HidP_Caps caps)
		{
			if (HidP_GetCaps(handle, out caps) == 0)
			{
				throw new Win32Exception();
			}
		}

		/// <summary>
		/// Get USB HID device Attributes
		/// </summary>
		private static void GetAttr(IntPtr handle, out HIDD_ATTRIBUTES attributes)
		{
			attributes = new HIDD_ATTRIBUTES();
			attributes.Size = Marshal.SizeOf(attributes);
			if (HidD_GetAttributes(handle, ref attributes) == false)
			{
				throw new Win32Exception();
			}
		}

		/// <summary>
		/// Get USB HID device Manufacturer String
		/// </summary>
		private static string GetManufacturerString(IntPtr handle)
		{
			var manufacturerString = new StringBuilder(128);
			if (HidD_GetManufacturerString(handle, manufacturerString, manufacturerString.Capacity) == false)
			{
				throw new Win32Exception();
			}
			return manufacturerString.ToString();
		}

		/// <summary>
		/// Get USB HID device Product String
		/// </summary>
		private static string GetProductString(IntPtr handle)
		{
			var productString = new StringBuilder(128);
			if (HidD_GetProductString(handle, productString, productString.Capacity) == false)
			{
				throw new Win32Exception();
			}
			return productString.ToString();
		}

		/// <summary>
		/// Get USB HID device Serial Number
		/// </summary>
		private static string GetSerialNumber(IntPtr handle)
		{
			var serialNumberString = new StringBuilder(127);
			if (HidD_GetSerialNumberString(handle, serialNumberString, serialNumberString.Capacity) == false)
			{
				//throw new Win32Exception();
				return "";
			}
			return serialNumberString.ToString();
		}

		/// <summary>
		/// Get USB HID device path
		/// </summary>
		private static string GetDevicePath(IntPtr hInfoSet, ref DeviceInterfaceData oInterface)
		{
			uint nRequiredSize = 0;
			if (SetupDiGetDeviceInterfaceDetail(hInfoSet, ref oInterface, IntPtr.Zero, 0, ref nRequiredSize, IntPtr.Zero) == false)
			{
				// TODO: Find a solution
				// Tip: http://stackoverflow.com/questions/1054748/setupdigetdeviceinterfacedetail-unexplainable-error
				//throw new HIDDeviceException();
			}
			var oDetail = new DeviceInterfaceDetailData();
			oDetail.Size = Marshal.SizeOf(typeof(IntPtr)) == 8 ? 8 : 5; // x86/x64 magic...
			if (SetupDiGetDeviceInterfaceDetail(hInfoSet, ref oInterface, ref oDetail, nRequiredSize, ref nRequiredSize, IntPtr.Zero) == false)
			{
				throw new Win32Exception();
			}
			return oDetail.DevicePath;
		}

		#endregion

		#region Publics
		/// <summary>
		/// Registers this application, so it will be notified for usb events.
		/// </summary>
		/// <param name="Handle">a IntPtr, that is a handle to the application.</param>
		/// <example> This sample shows how to implement this method in your form.
		/// <code>
		///protected override void OnHandleCreated(EventArgs e)
		///{
		///    base.OnHandleCreated(e);
		///    usb.RegisterHandle(Handle);
		///}
		///</code>
		///</example>
		public void RegisterHandle(IntPtr Handle)
		{
			m_usbEventHandle = RegisterForUsbEvents(Handle, m_deviceClass);
			m_formHandle = Handle;

			CheckDevicePresent(); //Check if the device is already present.
		}

		/// <summary>
		/// Unregisters this application, so it won't be notified for usb events.
		/// </summary>
		/// <returns>Returns if it wass succesfull to unregister.</returns>
		public bool UnregisterHandle()
		{
			if (m_formHandle != null)
			{
				return UnregisterForUsbEvents(m_formHandle);
			}

			return false;
		}

		/// <summary>
		/// This method will filter the messages that are passed for usb device change messages only.
		/// And parse them and take the appropriate action
		/// </summary>
		/// <param name="m">a ref to Messages, The messages that are thrown by windows to the application.</param>
		/// <example> This sample shows how to implement this method in your form.
		/// <code>
		///protected override void WndProc(ref Message m)
		///{
		///    usb.ParseMessages(ref m);
		///    base.WndProc(ref m);	    // pass message on to base form
		///}
		///</code>
		///</example>
		public void ParseMessages(ref Message m)
		{
			if (m.Msg == WM_DEVICECHANGE)	// we got a device change message! A USB device was inserted or removed
			{
				switch (m.WParam.ToInt32())	// Check the W parameter to see if a device was inserted or removed
				{
					case DEVICE_ARRIVAL:    // inserted
						OnDeviceArrived?.Invoke(this, new EventArgs());
						break;

					case DEVICE_REMOVECOMPLETE: // removed
						OnDeviceRemoved?.Invoke(this, new EventArgs());
						break;
				}
			}
		}

		/// <summary>
		/// Checks the devices that are present at the moment and checks if one of those
		/// is the device you defined by filling in the product id and vendor id.
		/// </summary>
		public void CheckDevicePresent()
		{

		}
		#endregion
	}
}
