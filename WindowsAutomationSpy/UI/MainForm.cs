using WindowsAutomationSpy.UserControls;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace WindowsAutomationSpy.UI
{
    public partial class MainForm : MetroForm
    {
        private readonly LoginPanel _login;

        public MainForm()
        {
            InitializeComponent();

            /* Setting MetroForm StyleManager to custom spyMsmMainForm style manager*/
            StyleManager = spyMsmMainForm;

            /* 
                Shown : Occurs whenever the form is first displayed 
                Assigning MainForm_Show to Shown EventHandler
            */
            Shown += MainForm_Shown;

            /*
                Creating LoginPanel object
                Assigning SettingsClosed and LoginSuccess event handlers to methods.
                Invoke Swipe method
            */
            _login = new LoginPanel(this);
            _login.SettingsClosed += LoginSettingsClosed;
            _login.LogInSuccess += LoginSuccess;
            _login.Swipe();

            /*
                Assigning Theme and Style to Settings Default values
            */
            //StyleManager.Theme = Settings.Default.Theme;
            //StyleManager.Style = Settings.Default.Style;
        }

        private void LoginSettingsClosed(object sender, EventArgs e)
        {
            /*
                Displaying Settings and Power button after closing Settings panel
            */
            spyLnkSettings.Visible = true;
            spyLnkClose.Visible = true;
        }

        private void LoginSuccess(object sender, EventArgs e)
        {
            /*
                Executing after Login success
            */
            _login.Swipe(false);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            /*
                Shown event handler implementation
            */
            WindowState = FormWindowState.Maximized;
        }

        private void spyLnkSettings_Click(object sender, EventArgs e)
        {
            // Settings links click event
            spyLnkSettings.Visible = false;
            spyLnkClose.Visible = false;

            _login.ShowSettings();
        }

        private void spyLnkClose_Click(object sender, EventArgs e)
        {
            // Power button click event
            Application.Exit();
        }
    }
}
