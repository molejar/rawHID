using System;
using System.Windows.Forms;

namespace rawhid
{
    public partial class SettingsForm : Form
    {
        private AppSettings m_settings;

        public AppSettings Values {
            get { return m_settings; }
        }

        public SettingsForm(AppSettings settings)
        {
            m_settings = settings.DeepCopy();

            InitializeComponent();
            PropertyGrid.SelectedObject = m_settings;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DefaultButton_Click(object sender, EventArgs e)
        {
            m_settings.LoadDefault();
            PropertyGrid.Refresh();
        }
    }
}
