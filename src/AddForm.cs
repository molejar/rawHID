using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace rawhid
{
    public partial class AddForm : Form
    {
        private const int m_buffSize = 64;
        private Command m_cmd;

        public AddForm(Command cmd=null)
        {
            m_cmd = cmd;

            InitializeComponent();

            if (cmd == null)
            {
                m_cmd = new Command("TEST0", "-", Keys.None, new byte[m_buffSize]);
            }

            NameTextBox.Text = m_cmd.Name;
            DescTextBox.Text = m_cmd.Desc;
            IdNumUpDown.Value = m_cmd.RID;
            TypeComboBox.SelectedIndex = m_cmd.RType;
            SetKey(m_cmd.Key);
            SetRawData(m_cmd.RData);
        }

        private void AddForm_Load(object sender, EventArgs e)
        {

        }

        private void SetRawData(byte[] data)
        {
            int i, n = data.Length;
            string[] d = new string[16];

            for (i = 0; i < 16; i++)
            {
                var cell = new DataGridViewTextBoxColumn();
                cell.HeaderText = i.ToString("X");
                cell.MinimumWidth = 26;
                cell.Width = 26;
                cell.Resizable = DataGridViewTriState.False;
                cell.SortMode = DataGridViewColumnSortMode.NotSortable;
                DataGridView.Columns.Add(cell);
            }

            if (data.Length / 16 > 4)
            {
                DataGridView.RowHeadersWidth = 30;
            } else {
                DataGridView.RowHeadersWidth = 30;
            }

            i = 0;

            while (n >= 0)
            {
                if ((i > 0) && (i % 16) == 0)
                {
                    DataGridView.Rows.Add(d);
                    DataGridView.Rows[i / 16 - 1].HeaderCell.Value = (i / 16 - 1).ToString();
                    d = new string[16];
                }

                if (i < data.Length)
                {
                    d[i % 16] = data[i].ToString("X2");
                }

                n--;
                i++;
            }
        }

        private byte[] GetRawData()
        {
            var ret = new byte[m_buffSize];

            for (int i = 0; i < m_buffSize; i++) {
                ret[i] = Convert.ToByte(DataGridView.Rows[i / 16].Cells[i % 16].Value.ToString(), 16);
            }

            return ret;
        }

        private Keys GetKey()
        {
            Keys k = (Keys)Enum.Parse(typeof(Keys), KeyComboBox2.Text);

            switch (KeyComboBox1.SelectedIndex)
            {
                case 0:
                    break;
                case 1: k |= Keys.Alt;
                    break;
                case 2: k |= Keys.Shift;
                    break;
                case 3: k |= Keys.Control;
                    break;
                case 4: k |= (Keys.Control | Keys.Alt);
                    break;
                case 5: k |= (Keys.Control | Keys.Shift);
                    break;
                case 6: k |= (Keys.Control | Keys.Alt | Keys.Shift);
                    break;
            }

            return k;
        }

        private void SetKey(Keys val)
        {
            int vkc = 0;
            KeysConverter kc = new KeysConverter();
            KeyComboBox2.Text = kc.ConvertToString(val & Keys.KeyCode);

            switch (val & ~Keys.KeyCode)
            {
                case Keys.Alt:
                    vkc = 1;
                    break;
                case Keys.Shift:
                    vkc = 2;
                    break;
                case Keys.Control:
                    vkc = 3;
                    break;
                case (Keys.Control | Keys.Alt):
                    vkc = 4;
                    break;
                case (Keys.Control | Keys.Shift):
                    vkc = 5;
                    break;
                case (Keys.Control | Keys.Alt | Keys.Shift):
                    vkc = 6;
                    break;
            }

            KeyComboBox1.SelectedIndex = vkc;
        }

        private void m_OkButton_Click(object sender, EventArgs e)
        {
            m_cmd.Name  = NameTextBox.Text;
            m_cmd.Desc  = DescTextBox.Text;
            m_cmd.RID   = (byte)IdNumUpDown.Value;
            m_cmd.RType = TypeComboBox.SelectedIndex;
            m_cmd.Key   = GetKey();
            m_cmd.RData = GetRawData();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void m_CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void KeyComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (KeyComboBox2.SelectedIndex == 0) {
                KeyComboBox1.SelectedIndex = 0;
                KeyComboBox1.Enabled = false;
            } else {
                KeyComboBox1.Enabled = true;
            }
        }

        private void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            byte x;
            var cell = DataGridView[e.ColumnIndex, e.RowIndex];
            var old_val = m_cmd.RData[e.ColumnIndex + e.RowIndex * 16].ToString("X2");
            var new_val = cell.Value.ToString();
            if (byte.TryParse(new_val, NumberStyles.HexNumber, null as IFormatProvider, out x)) {
                if (new_val.Length == 1) { new_val = string.Format("0{0:s}", new_val); }
                new_val = new_val.ToUpper();
                cell.Value = new_val;
                if (old_val != new_val) {
                    cell.Style.Font = new Font(DataGridView.Font, FontStyle.Bold);
                }
            } else {
                MessageBox.Show("Use hex value in range: 00 - FF", "ERROR");
                cell.Value = old_val;
            }
        }
    }
}
