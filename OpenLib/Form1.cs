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

        private void ShowUserList()
        {
            ListUsers dlg = new ListUsers(this.db_handler);
            dlg.Show();
        }


        private void AddAdmin()
        {
            Forms.CreateAdmin dlg = new Forms.CreateAdmin();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string uname = dlg.username.Text;
                string pw = dlg.pw1.Text;
                string salt = CryptoHelper.GenerateSalt();

                string hash = CryptoHelper.GenerateHash(pw, salt);

                Admin a = new Admin(uname, hash, salt);

                db_handler.InsertAdmin(a);
            }
        }

        private void CheckLogin()
        {
            if (db_handler.GetAdminCount() > 0)
            {
                Forms.Login dlg = new Forms.Login();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string uname = dlg.username.Text;
                    string pw = dlg.pw.Text;

                    List<Admin> admins = db_handler.GetAdminsByUsername(uname);

                    bool successful = false;

                    foreach(Admin a in admins)
                    {
                        if(CryptoHelper.CheckPassword(pw, a.Hash, a.Salt))
                        {
                            successful = true;
                            break;
                        }
                    }

                    if(!successful)
                    {
                        MessageBox.Show("Wrong credentials!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CheckLogin();
                    }
                        
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ShowUserList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckLogin();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            AddAdmin();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Forms.ListAdmins dlg = new Forms.ListAdmins(db_handler);
            dlg.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Forms.ListBooks dlg = new Forms.ListBooks(db_handler);
            dlg.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Forms.ListLeases dlg = new Forms.ListLeases(db_handler);
            dlg.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            db_handler.End();
        }
    }
}
