using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenLib
{
    public class User
    {
        public string LastName, FirstName, Remarks;
        public int Id;
        public DateTime Birthday;

        /*public User(int id, string firstname, string lastname,
            DateTime birthday)
        {
            this.LastName = lastname;
            this.FirstName = firstname;
            this.Id = id;
            this.Birthday = birthday;
            this.Remarks = string.Empty;
        }*/

        public User(int id, string firstname, string lastname,
            DateTime birthday, string remarks)
        {
            this.LastName = lastname;
            this.FirstName = firstname;
            this.Id = id;
            this.Birthday = birthday;
            this.Remarks = remarks;
        }

        public static User FromArray(string[] arr)
        {
            int id = Convert.ToInt32(arr[0]);
            string fn = arr[1];
            string ln = arr[2];
            DateTime bday = DateTime.Parse(arr[3]);
            string rm = arr[4];

            User u = new User(id, fn, ln, bday, rm);
            return u;
        }

        public static User FromListView(ListViewItem lvi)
        {
            int id = Convert.ToInt32(lvi.SubItems[0].Text);
            string fn = lvi.SubItems[1].Text;
            string ln = lvi.SubItems[2].Text;
            DateTime bday = DateTime.Parse(lvi.SubItems[3].Text);
            string rm = lvi.SubItems[4].Text;

            User u = new User(id, fn, ln, bday, rm);
            return u;
        }
    }
}
