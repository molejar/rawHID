
using System;

namespace UsbLibrary
{
  /// <summary>
  /// Class containg information about a connected USB HID device
  /// </summary>
  public class HIDInfoSet
  {
    /// <summary>
    /// Identifies the manufacturer's name
    /// </summary>
    public string ManufacturerString { get; private set; }

    /// <summary>
    /// Identifies the product name
    /// </summary>
    public string ProductString { get; private set; }

    /// <summary>
    /// Serial number
    /// </summary>
    public string SerialNumberString { get; private set; }

    /// <summary>
    /// Product Version
    /// </summary>
    public UInt16 Version { get; private set; }

    /// <summary>
    /// Full device file path
    /// </summary>
    public string DevicePath { get; private set; }

    /// <summary>
    /// Vendor ID
    /// </summary>
    public UInt16 VendorID { get; private set; }

    /// <summary>
    /// Product ID
    /// </summary>
    public UInt16 ProductID { get; private set; }

    /// <summary>
    /// IN Report Byte Length
    /// </summary>
    public short InBytesLength { get; private set; }

    /// <summary>
    /// OUT Report Byte Length
    /// </summary>
    public short OutBytesLength { get; private set; }

    /// <summary>
    /// ctor
    /// </summary>
    internal HIDInfoSet(string manufacturerString,
                        string productString,
                        string serialNumberString,
                        string devicePath,
                        UInt16 vid,
                        UInt16 pid,
                        UInt16 version,
                        short  inBytesLength,
                        short  outBytesLength)
    {
      ManufacturerString = manufacturerString;
      ProductString = productString;
      SerialNumberString = serialNumberString;
      Version = version;
      DevicePath = devicePath;
      VendorID = vid;
      ProductID = pid;
      InBytesLength = inBytesLength;
      OutBytesLength = outBytesLength;
    }

    public string VersionInBCD()
    {
        if (((byte)(Version >> 24)) == 0)
        {
            return String.Format("{0}.{1}{2}", (byte)(Version >> 16), (byte)(Version >> 8), (byte)Version);
        }

        return String.Format("{0}{1}.{2}{3}", (byte)(Version >> 24), (byte)(Version >> 16), (byte)(Version >> 8), (byte)Version);
    }

    public string GetInfo()
    {
        return String.Format("[{0:X4}/{1:X4}] {2} {3}", VendorID, ProductID, ManufacturerString, ProductString);
    }
  }
}
