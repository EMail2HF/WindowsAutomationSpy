using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace WindowsAutomationSpy.UserControls
{
    public partial class LoginPanel : SliderPanel
    {
        public event EventHandler SettingsClosed;

        public LoginPanel(Form owner) : base(owner) 
        {
            InitializeComponent();

            for (int i = 3; i < 13; i++)
            {
                MetroTile tile = new MetroTile();
                tile.Size = new Size(30, 30);
                tile.Tag = i;
                tile.Style = (MetroColorStyle) i;
                tile.Click += tile_Click;
                spyFlpSettings.Controls.Add(tile);
            }
        }

        private void tile_Click(object sender, EventArgs e)
        {
            ((MetroForm) Parent).StyleManager.Style = (MetroColorStyle)((MetroTile) sender).Tag;
        }

        public void ShowSettings()
        {
            spyMpSettings.Visible = true;
            spyMpCenter.Enabled = false;
        }

        private void spyMlSettingsBack_Click(object sender, EventArgs e)
        {
            spyMpSettings.Visible = false;
            spyMpCenter.Enabled = true;

            EventHandler handler = SettingsClosed;
            handler?.Invoke(this, e);
        }

        private void spyMrbDark_CheckedChanged(object sender, EventArgs e)
        {
            if (spyMrbDark.Checked)
            {
                ((MetroForm)Parent).StyleManager.Theme = MetroThemeStyle.Dark;
            }
        }

        private void spyMrbLight_CheckedChanged(object sender, EventArgs e)
        {
            if (spyMrbLight.Checked)
            {
                ((MetroForm)Parent).StyleManager.Theme = MetroThemeStyle.Light;
            }
        }
    }
}
