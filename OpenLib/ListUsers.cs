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

        private void ListUsers_Load(object sender, EventArgs e)
        {
            List<User> users = db_handler.GetAllUsers();

            foreach(User u in users)
            {
                string[] items = {u.Id.ToString(),
                u.FirstName, u.LastName,
                u.Birthday.ToString().Split(' ')[0]};

                ListViewItem itm = new ListViewItem(items);
                this.listView1.Items.Add(itm);
            }
        }
    }
}
