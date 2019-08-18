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
    public partial class ListAdmins : Form
    {
        private DBHandler db_handler;
        public ListAdmins(DBHandler handler)
        {
            db_handler = handler;
            InitializeComponent();
        }

        private void PopulateAdminView(List<Admin> users)
        {
            this.adminView.Items.Clear();
            foreach (Admin a in users)
            {
                string[] items = {a.Id.ToString(),
                a.Username};

                ListViewItem itm = new ListViewItem(items);
                this.adminView.Items.Add(itm);
            }
        }

        private void EditSelectedAdmin()
        {
            if(this.adminView.SelectedItems.Count > 0)
            {
                Admin a = Admin.FromListView(this.adminView.SelectedItems[0]);
                Forms.EditAdmin dlg = new EditAdmin();
                dlg.username.Text = a.Username;

                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    string pw = dlg.pw1.Text;
                    string salt = CryptoHelper.GenerateSalt();
                    string hash = CryptoHelper.GenerateHash(pw, salt);

                    a.Hash = hash;
                    a.Salt = salt;
                    a.Username = dlg.username.Text;


                    if (!db_handler.UpdateAdmin(a))
                        MessageBox.Show("An error occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    PopulateAdminView();
                }
            }
        }

        private void PopulateAdminView()
        {
            List<Admin> admins = db_handler.GetAllAdmins();
            PopulateAdminView(admins);
        }

        private void ListAdmins_Load(object sender, EventArgs e)
        {
            PopulateAdminView();
        }

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditSelectedAdmin();
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
