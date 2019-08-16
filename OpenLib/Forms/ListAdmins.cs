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

        private void PopulateListView(List<Admin> users)
        {
            this.listView1.Items.Clear();
            foreach (Admin a in users)
            {
                string[] items = {a.Id.ToString(),
                a.Username};

                ListViewItem itm = new ListViewItem(items);
                this.listView1.Items.Add(itm);
            }
        }

        private void EditSelectedAdmin()
        {
            if(this.listView1.SelectedItems.Count > 0)
            {
                Admin a = Admin.FromListView(this.listView1.SelectedItems[0]);
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

                    PopulateListView();
                }
            }
        }

        private void PopulateListView()
        {
            List<Admin> admins = db_handler.GetAllAdmins();
            PopulateListView(admins);
        }

        private void ListAdmins_Load(object sender, EventArgs e)
        {
            PopulateListView();
        }

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditSelectedAdmin();
        }
    }
}
