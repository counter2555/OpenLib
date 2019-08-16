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
    public partial class FindUser : Form
    {
        private DBHandler db_handler;
        public int UserId = -1;
        public FindUser(DBHandler handler)
        {
            this.db_handler = handler;
            InitializeComponent();
        }

        private void Search()
        {
            this.listView1.Items.Clear();

            string query = "SELECT * FROM dbo.Users WHERE LOWER(FirstName) LIKE LOWER(@sc) "
                + "OR LOWER(LastName) LIKE LOWER(@sc)";

            DBHandler.SQLParameter par = new DBHandler.SQLParameter();
            par.name = "@sc";
            par.value = "%" + this.textBox1.Text + "%";

            List<User> users = db_handler.UserQuery(query, new DBHandler.SQLParameter[] { par });

            foreach (User u in users)
            {
                string[] items =
                {
                    u.Id.ToString(),
                    u.FirstName, u.LastName,
                    u.Birthday.ToString().Split(' ')[0]
                };

                ListViewItem itm = new ListViewItem(items);
                this.listView1.Items.Add(itm);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TextBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(this.listView1.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(this.listView1.SelectedItems[0].SubItems[0].Text);
                this.UserId = id;


                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
