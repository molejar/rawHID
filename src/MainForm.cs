using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using UsbLibrary;
using System.Xml.Serialization;

namespace rawhid
{
    public partial class MainForm : Form
    {
        enum FT {
            BIN = 0,
            XML = 1
        };

        private const string     m_confName = "rawhid.conf";

        private HIDDevice        m_usb;
        private List<HIDInfoSet> m_connList;
        private List<Command>    m_cmds;
        private AppSettings      m_settings;

        private DataGridViewCellEventHandler m_tclk;

        public MainForm()
        {
            m_usb = new HIDDevice();
            m_cmds = new List<Command>();
            m_connList = new List<HIDInfoSet>();

            try
            {
                m_settings = LoadFromFile(typeof(AppSettings), m_confName) as AppSettings;
            }
            catch
            {
                m_settings = new AppSettings();
            }

            InitializeComponent();

            m_usb.OnDeviceRemoved += usb_OnDeviceRemoved;
            m_usb.OnDeviceArrived += usb_OnDeviceArrived;
            m_usb.OnDataRecieved  += usb_OnDataReceived;

            LogDataGridView.Enabled = false;
            EditToolStripButton.Enabled = false;
            RemoveToolStripButton.Enabled = false;
            SaveToolStripButton.Enabled = false;

            m_tclk = new DataGridViewCellEventHandler(TxDataGridView_CellClick);
        }

        #region General Methods
        private void ScanConnection()
        {
            m_connList = HIDDevice.GetInfoSets(m_settings.USB_VID, m_settings.USB_PID);
            m_ToolStripComboBox.Items.Clear();

            foreach (var hidInfoSet in m_connList)
            {
                if (hidInfoSet.ProductString == "")
                {
                    m_ToolStripComboBox.Items.Add("Unknovn HID device");
                }
                else
                {
                    m_ToolStripComboBox.Items.Add(hidInfoSet.GetInfo());
                }
            }

            if (m_ToolStripComboBox.Items.Count > 0)
            {
                m_ToolStripComboBox.Enabled = true;
                ConnectToolStripButton.Text = "Connect";
                ConnectToolStripButton.Image = Properties.Resources.Connect;
                ConnectToolStripButton.Enabled = true;
                m_ToolStripComboBox.SelectedIndex = 0;
                m_ToolStripStatusIcon.Enabled = true;
                m_ToolStripStatusIcon.Image = Properties.Resources.USB_Disable;
                m_ToolStripStatusIcon.ToolTipText = "USB Device Disconnected";

                m_ToolStripStatusString.Text = "USB Device is ready for connecting";
                m_ToolStripStatusString.ForeColor = Color.DarkSlateGray;
            }
            else
            {
                m_ToolStripComboBox.Enabled = false;
                ConnectToolStripButton.Text = "Connect";
                ConnectToolStripButton.Image = Properties.Resources.Connect;
                ConnectToolStripButton.Enabled = false;
                m_ToolStripStatusIcon.Enabled = false;
                m_ToolStripStatusIcon.Image = Properties.Resources.USB;
                m_ToolStripStatusIcon.ToolTipText = string.Empty;

                m_ToolStripStatusString.Text = "USB Device not found, check the HW connection on PC side !";
                m_ToolStripStatusString.ForeColor = Color.FromArgb(255, 204, 0, 0);
            }
        }

        private void Disconnect()
        {
            m_usb.Disconnect();
            LogDataGridView.Enabled = false;
            ConnectToolStripButton.Text = "Connect";
            ConnectToolStripButton.Image = Properties.Resources.Connect;
            m_ToolStripComboBox.Enabled = true;
            m_ToolStripStatusIcon.Image = Properties.Resources.USB_Disable;
            m_ToolStripStatusIcon.ToolTipText = "USB Device Disconnected";

            m_ToolStripStatusString.Text = "USB Device is ready for connecting";
            m_ToolStripStatusString.ForeColor = Color.DarkSlateGray;
        }

        private void Connect()
        {
            HIDInfoSet device;

            if (m_connList.Count == 0) return;

            device = m_connList[m_ToolStripComboBox.SelectedIndex];
            if (HIDDevice.GetInfoSets(device.VendorID, device.ProductID, device.SerialNumberString).Count > 0)
            {
                if (m_usb.Connect(device.DevicePath, true))
                {
                    LogDataGridView.Enabled = true;
                    ConnectToolStripButton.Text = "Disconnect";
                    ConnectToolStripButton.Image = Properties.Resources.Disconnect;
                    m_ToolStripComboBox.Enabled = false;
                    m_ToolStripStatusString.Text = "USB Device connected";
                    m_ToolStripStatusString.ForeColor = Color.DarkSlateGray;
                    m_ToolStripStatusIcon.Image = Properties.Resources.USB_OK;
                    m_ToolStripStatusIcon.ToolTipText = "Manufacturer: " + m_usb.ManufacturerString + "\n" +
                                                        "Product Name: " + m_usb.ProductString + "\n" +
                                                        "Serial Number: " + m_usb.SerialNumberString + "\n" +
                                                        "SW Version: " + m_usb.VersionInBCD;
                }
            }
            else
            {
                ScanConnection();
                MessageBox.Show(String.Format("DEVICE: {0} is used in other program !", device.ProductString), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveToFile(object obj, string fname, FT ftype = FT.BIN)
        {
            //first serialize the object to memory stream,
            //in case of exception, the original file is not corrupted
            using (MemoryStream ms = new MemoryStream())
            {
                if (ftype == FT.BIN)
                {
                    var serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    serializer.Serialize(ms, obj);
                }
                else
                {
                    var writer = new StreamWriter(ms);
                    var serializer = new XmlSerializer(obj.GetType());
                    serializer.Serialize(writer, obj);
                    writer.Flush();
                }

                //if the serialization succeed, rewrite the file.
                File.WriteAllBytes(fname, ms.ToArray());
            }
        }

        private object LoadFromFile(Type objType, string fname, FT ftype = FT.BIN)
        {
            using (var stream = File.OpenRead(fname))
            {
                if (ftype == FT.BIN)
                {
                    var serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    return serializer.Deserialize(stream);
                }
                else
                {
                    var serializer = new XmlSerializer(objType);
                    return serializer.Deserialize(stream);
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ScanConnection();

            if (m_settings.USB_AutoConnect)
            {
                Connect();
            }
        }
#endregion

        #region USB Event Handlers
        private void usb_OnDeviceRemoved(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(usb_OnDeviceRemoved), new object[] { sender, e });
            }
            else
            {
                if (m_usb.IsConnected)
                {
                    if (HIDDevice.GetInfoSets(m_usb.VendorID, m_usb.ProductID, m_usb.SerialNumberString).Count == 0)
                    {
                        Disconnect();
                    }
                }

                ScanConnection();
            }
        }

        private void usb_OnDeviceArrived(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(usb_OnDeviceArrived), new object[] { sender, e });
            }
            else
            {
                System.Threading.Thread.Sleep(600);
                ScanConnection();
                if (m_settings.USB_AutoConnect)
                {
                    Connect();
                }
            }
        }

        private void usb_OnDataReceived(object sender, HIDReport args)
        {
            if (InvokeRequired)
            {
                Invoke(new DataRecievedEventHandler(usb_OnDataReceived), new object[] { sender, args });
            }
            else
            {
                ShowData("RX", 0, args);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            m_usb.RegisterHandle(Handle);
            base.OnHandleCreated(e);
        }

        protected override void WndProc(ref Message m)
        {
            m_usb.ParseMessages(ref m);
            base.WndProc(ref m);	// pass message on to base form
        }
#endregion

        #region Tool Strip Buttons
        private void ConnectToolStripButton_Click(object sender, EventArgs e)
        {
            if (m_usb.IsConnected)
            {
                Disconnect();
            }
            else
            {
                Connect();
            }
        }

        private void AddToolStripButton_Click(object sender, EventArgs e)
        {
            Command cmd = new Command("CMD 0", "-", Keys.None, new byte[64]);

            var additem = new AddForm(cmd);
            var res = additem.ShowDialog();
            if (res == DialogResult.OK)
            {

                m_cmds.Add(cmd);
                TxDataGridView.Rows.Add(cmd.Name, cmd.GetTypeAsStr(), cmd.Desc, cmd.GetShortKeyAsStr(), "Send");
                if (EditToolStripButton.Enabled) return;
                EditToolStripButton.Enabled = true;
                RemoveToolStripButton.Enabled = true;
                SaveToolStripButton.Enabled = true;
                // Add a CellClick handler to handle clicks in the button column.
                TxDataGridView.CellClick += m_tclk;
            }
        }

        private void EditToolStripButton_Click(object sender, EventArgs e)
        {
            if (TxDataGridView.SelectedRows.Count <= 0)
            {
                return;
            }

            if (TxDataGridView.SelectedRows.Count > 1)
            {
                MessageBox.Show("Select just single row !", "Edit Error");
                return;
            }

            DataGridViewRow row = TxDataGridView.SelectedRows[0];
            Command cmd = m_cmds[row.Index];
            var additem = new AddForm(cmd);
            var res = additem.ShowDialog();
            if (res == DialogResult.OK)
            {
                row.SetValues(cmd.Name, cmd.GetTypeAsStr(), cmd.Desc, cmd.GetShortKeyAsStr(), "Send");
            }
        }

        private void RemoveToolStripButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in TxDataGridView.SelectedRows)
            {
                m_cmds.RemoveAt(row.Index);
                TxDataGridView.Rows.Remove(row);
            }

            if (TxDataGridView.SelectedRows.Count <= 0)
            {
                EditToolStripButton.Enabled = false;
                RemoveToolStripButton.Enabled = false;
                SaveToolStripButton.Enabled = false;
                // Add a CellClick handler to handle clicks in the button column.
                TxDataGridView.CellClick -= m_tclk;
            }
        }

        private void OpenToolStripButton_Click(object sender, EventArgs e)
        {
            List<Command> cmds = null;
            var ofd = new OpenFileDialog();

            ofd.Filter = "TxCommands (*.cms)|*.cms";
            //ofd.FilterIndex = 1;
            ofd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    cmds = LoadFromFile(typeof(List<Command>), ofd.FileName, FT.XML) as List<Command>;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Could not read file from disk. Error: " + ex.Message,
                                          "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (cmds == null)
                {
                    return;
                }

                if (m_cmds.Count > 0)
                {
                    var ret = MessageBox.Show(this, "Remove existing commands ?",
                                                    "Question", MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);
                    if (ret == DialogResult.Yes)
                    {
                        m_cmds.Clear();
                        TxDataGridView.Rows.Clear();
                    }
                }

                m_cmds.AddRange(cmds);
                foreach (Command cmd in cmds)
                {
                    TxDataGridView.Rows.Add(cmd.Name, cmd.GetTypeAsStr(), cmd.Desc, cmd.GetShortKeyAsStr(), "Send");
                }

                if (!EditToolStripButton.Enabled)
                {
                    EditToolStripButton.Enabled = true;
                    RemoveToolStripButton.Enabled = true;
                    SaveToolStripButton.Enabled = true;
                    TxDataGridView.CellClick += m_tclk;
                }
            }
        }

        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();

            sfd.Filter = "TxCommands (*.cms)|*.cms";
            //sfd.FilterIndex = 1;
            sfd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveToFile(m_cmds, sfd.FileName, FT.XML);
            }
        }

        private void SettingsToolStripButton_Click(object sender, EventArgs e)
        {
            var cfgForm = new SettingsForm(m_settings);
            var res = cfgForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                m_settings = cfgForm.Values;
                SaveToFile(m_settings, m_confName);

                if (!m_usb.IsConnected)
                {
                    ScanConnection();
                }
            }
        }

        private void InfoToolStripButton_Click(object sender, EventArgs e)
        {
            var info = new AboutForm();
            info.ShowDialog();
        }

#endregion

        private void SendCommand(Command cmd)
        {
            bool status;

            if(cmd.RType == 0)
            {
                status = m_usb.Write(cmd.GetHidReport());
            } else {
                status = m_usb.WriteFeature(cmd.GetHidReport());
            }

            if (status)
            {
                ShowData("TX", cmd.RType, cmd.GetHidReport());
            }
        }

        private void ShowData(string dir, int type, HIDReport report) {
            string[] row = new string[4];

            row[0] = string.Format("{0:d5} ", LogDataGridView.Rows.Count);
            row[1] = dir;
            row[2] = type == 0 ? "S:" : "F:";
            row[2] += report.ID.ToString();

            foreach (byte a in report.Data)
            {
                row[3] += string.Format("{0:X2} ", a);
            }

            LogDataGridView.ClearSelection();
            LogDataGridView.Rows.Add(row);
            LogDataGridView.FirstDisplayedScrollingRowIndex = LogDataGridView.RowCount - 1;
            LogDataGridView.Rows[LogDataGridView.RowCount - 1].Selected = true;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (Command cmd in m_cmds)
            {
                if (e.KeyCode == cmd.Key)
                {
                    SendCommand(cmd);
                    if (m_settings.CMD_Multiple)
                    {
                        System.Threading.Thread.Sleep(m_settings.CMD_Delay);
                        continue;
                    }

                    break;
                }
            }
        }

        private void TxDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells.
            if (e.ColumnIndex != TxDataGridView.Columns["m_button"].Index) return;

            SendCommand(m_cmds[e.RowIndex]);
        }

        private void TxDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SendCommand(m_cmds[e.RowIndex]);
        }

        private void TxDataGridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (TxDataGridView.SelectedRows.Count <= 0)  return;

                if (TxDataGridView.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Select just single row !", "Edit Error");
                    return;
                }

                SendCommand(m_cmds[TxDataGridView.SelectedRows[0].Index]);
            }
        }

        private void LogDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (LogDataGridView.SelectedRows.Count <= 0 ||
                LogDataGridView.SelectedRows.Count > 1) return;

            LogTextBox.Text = LogDataGridView.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            LogDataGridView.Rows.Clear();
            LogTextBox.Text = "";
        }
    }
}
