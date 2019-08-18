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

        private void PopulateUserView()
        {
            List<User> users = db_handler.GetAllUsers();
            PopulateUserView(users);
        }

        private void PopulateUserView(List<User> users)
        {
            this.userView.Items.Clear();
            foreach (User u in users)
            {
                string[] items = {u.Id.ToString(),
                u.FirstName, u.LastName,
                u.Birthday.ToString().Split(' ')[0],
                u.Remarks};

                ListViewItem itm = new ListViewItem(items);
                this.userView.Items.Add(itm);
            }
        }


        public void EditUser()
        {
            if(this.userView.SelectedItems.Count > 0 )
            {
                ModifyUser dlg = new ModifyUser();

                User u = User.FromListView(this.userView.SelectedItems[0]);

                dlg.firstName.Text = u.FirstName;
                dlg.lastName.Text = u.LastName;
                dlg.birthday.Value = u.Birthday;
                dlg.remarks.Text = u.Remarks;

                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    User u2 = new User(u.Id,
                        dlg.firstName.Text,
                        dlg.lastName.Text,
                        dlg.birthday.Value,
                        dlg.remarks.Text);

                    db_handler.UpdateUser(u2);

                    this.userView.Items.Clear();
                    PopulateUserView();
                }
            }
        }

        public void DeleteSelectedUsers()
        {
            if (this.userView.SelectedItems.Count > 0)
            {
                int count = this.userView.SelectedItems.Count;
                if (MessageBox.Show("Are you sure to delete "+count.ToString()
                    +" users?\nThis cannot be undone afterwards.", "Deleting Users", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    uint succ_count = 0;
                    foreach(ListViewItem lvi in this.userView.SelectedItems)
                    {
                        User u = User.FromListView(lvi);
                        if (db_handler.DeleteUser(u))
                            succ_count++;
                    }

                    PopulateUserView();

                    MessageBox.Show(succ_count.ToString()+" of "+count.ToString()+" users deleted successfully.",
                        "Deleting Users", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    

                }
            }
        }

        public void AddUser()
        {
            AddUser dlg = new AddUser();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                User u = new User(-1, dlg.firstName.Text,
                    dlg.lastName.Text,
                    dlg.birthday.Value, dlg.remarks.Text);

                bool done = db_handler.InsertUser(u);

                if (done)
                    PopulateUserView();
                else
                    MessageBox.Show("An error occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            EditUser();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            Forms.SearchDialog dlg = new Forms.SearchDialog();

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                List<User> users = db_handler.SearchUserByName(dlg.searchText.Text);
                
                PopulateUserView(users);
            }
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EditUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditUser();
        }

        private void DeleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DeleteSelectedUsers();
        }

        private void AddUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            AddUser();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            PopulateUserView();
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            EditUser();
        }

        private void ListUsers_Load(object sender, EventArgs e)
        {
            PopulateUserView();
        }
    }
}
