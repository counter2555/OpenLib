using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenLib
{
    public class Admin
    {
        public string Username, Salt, Hash;
        public int Id;
        public Admin(int id, string username, string hash, string salt)
        {

            this.Id = id;
            this.Username = username;
            this.Hash = hash;
            this.Salt = salt;
        }

        public Admin(string username, string hash, string salt)
        {

            this.Id = -1;
            this.Username = username;
            this.Hash = hash;
            this.Salt = salt;
        }

        public static Admin FromListView(ListViewItem lvi)
        {
            int id = Convert.ToInt32(lvi.SubItems[0].Text);
            string un = lvi.SubItems[1].Text;
            Admin a = new Admin(id, un, string.Empty, string.Empty);
            return a;
        }
    }
}
