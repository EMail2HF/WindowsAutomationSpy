using WindowsAutomationSpy.UserControls;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace WindowsAutomationSpy.UI
{
    public partial class MainForm : MetroForm
    {
        private LoginPanel _login;

        public MainForm()
        {
            InitializeComponent();

            StyleManager = spyMsmMainForm;

            Shown += MainForm_Shown;

            _login = new LoginPanel(this);
            _login.SettingsClosed += LoginSettingsClosed;
            _login.Swipe();
        }

        private void LoginSettingsClosed(object sender, EventArgs e)
        {
            spyLnkSettings.Visible = true;
            spyLnkClose.Visible = true;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void spyLnkSettings_Click(object sender, EventArgs e)
        {
            spyLnkSettings.Visible = false;
            spyLnkClose.Visible = false;

            _login.ShowSettings();
        }
    }
}
