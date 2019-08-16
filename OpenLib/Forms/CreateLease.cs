using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenLib.Forms
{
    public partial class CreateLease : Form
    {
        private DBHandler db_handler;
        public CreateLease(DBHandler handler)
        {
            db_handler = handler;
            InitializeComponent();
        }

        private void ScanISBN()
        {
            Forms.ScanISBN dlg = new ScanISBN(db_handler);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.bookid.Text = dlg.BookId.ToString();
            }
        }

        private void FindUser()
        {
            Forms.FindUser dlg = new FindUser(db_handler);
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                this.userid.Text = dlg.UserId.ToString();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ScanISBN();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FindUser();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.bookid.Text.Length > 0 && this.userid.Text.Length > 0)
                {
                    Convert.ToInt32(this.bookid.Text);
                    Convert.ToInt32(this.userid.Text);

                    this.DialogResult = DialogResult.OK;

                    this.Close();
                }
                else
                    MessageBox.Show("Error - check inputs!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch
            {
                MessageBox.Show("Error - check inputs!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
