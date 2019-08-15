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
        public string LastName, FirstName;
        public int Id;
        public DateTime Birthday;

        public User(int id, string firstname, string lastname,
            DateTime birthday)
        {
            this.LastName = lastname;
            this.FirstName = firstname;
            this.Id = id;
            this.Birthday = birthday;
        }

        public static User FromArray(string[] arr)
        {
            int id = Convert.ToInt32(arr[0]);
            string fn = arr[1];
            string ln = arr[2];
            DateTime bday = DateTime.Parse(arr[3]);

            User u = new User(id, fn, ln, bday);
            return u;
        }

        public static User FromListView(ListViewItem arr)
        {
            int id = Convert.ToInt32(arr.SubItems[0].Text);
            string fn = arr.SubItems[1].Text;
            string ln = arr.SubItems[2].Text;
            DateTime bday = DateTime.Parse(arr.SubItems[3].Text);

            User u = new User(id, fn, ln, bday);
            return u;
        }
    }
}
