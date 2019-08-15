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
    public partial class Form1 : Form
    {

        private DBHandler db_handler = new DBHandler(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Benedikt\source\repos\OpenLib\OpenLib\OpenLibDB.mdf;Integrated Security=True;Connect Timeout=30");

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AddUser dlg = new AddUser();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                bool done = db_handler.InsertUser(dlg.firstName.Text,
                    dlg.lastName.Text,
                    dlg.birthday.Value);

                if (done)
                {
                    MessageBox.Show("DONE");
                }
                else
                    MessageBox.Show("FAIL");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ListUsers dlg = new ListUsers(this.db_handler);
            dlg.Show();
        }
    }
}
