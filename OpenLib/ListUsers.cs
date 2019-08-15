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
    public partial class ListUsers : Form
    {
        private DBHandler db_handler;
        public ListUsers(DBHandler handler)
        {
            this.db_handler = handler;
            InitializeComponent();
        }

        private void PopulateListView()
        {
            List<User> users = db_handler.GetAllUsers();

            foreach (User u in users)
            {
                string[] items = {u.Id.ToString(),
                u.FirstName, u.LastName,
                u.Birthday.ToString().Split(' ')[0]};

                ListViewItem itm = new ListViewItem(items);
                this.listView1.Items.Add(itm);
            }
        }

        private void ListUsers_Load(object sender, EventArgs e)
        {
            PopulateListView();
        }

        public void EditUser()
        {
            if(this.listView1.SelectedItems.Count > 0 )
            {
                ModifyUser dlg = new ModifyUser();

                User u = User.FromListView(this.listView1.SelectedItems[0]);

                dlg.firstName.Text = u.FirstName;
                dlg.lastName.Text = u.LastName;
                dlg.birthday.Value = u.Birthday;

                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    User u2 = new User(u.Id,
                        dlg.firstName.Text,
                        dlg.lastName.Text,
                        dlg.birthday.Value);

                    db_handler.UpdateUser(u2);

                    this.listView1.Items.Clear();
                    PopulateListView();
                }
            }
        }

        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            EditUser();
        }
    }
}
