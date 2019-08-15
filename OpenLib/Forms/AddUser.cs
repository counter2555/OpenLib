using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenLib
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(this.firstName.Text.Length > 0 && this.lastName.Text.Length > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Check the input fields again!",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void AddUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.DialogResult = DialogResult.Abort;
        }
    }
}
