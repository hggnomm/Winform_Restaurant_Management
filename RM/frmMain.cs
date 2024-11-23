using System;
using System.Windows.Forms;

namespace RM
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        // Method to add control in Main Frame
        public void AddControls(Form form)
        {
            centerPanel.Controls.Clear();
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            centerPanel.Controls.Add(form);
            form.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AddControls(new frmHome());
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUser.Text = MainClass.USER;
        }
    }
}
