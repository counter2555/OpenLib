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

        private DBHandler db_handler = new DBHandler(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Benedikt\Documents\GitHub\OpenLib\OpenLib\OpenLibDB.mdf;Integrated Security=True;Connect Timeout=30");

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AddUser dlg = new AddUser();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                User u = new User(-1, dlg.firstName.Text,
                    dlg.lastName.Text,
                    dlg.birthday.Value);

                bool done = db_handler.InsertUser(u);

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
