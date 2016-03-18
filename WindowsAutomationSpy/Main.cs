using System;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using WindowsAutomationSpy.Utilities;
using System.Drawing.Text;
using System.Drawing;

namespace WindowsAutomationSpy
{
    public partial class Main : MetroForm
    {
        public Main()
        {
            InitializeComponent();
            //foreach (Control control in this.Controls)
            //{
            //    control.Font = new Font(pfc.Families[0], 15, FontStyle.Regular);
            //}
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult result = MetroMessageBox.Show(this, Constants.CLOSE_FORM_CONFIRMATION_MSG, Constants.CLOSE_FORM_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
                this.Activate();
            }
        }
    }
}
