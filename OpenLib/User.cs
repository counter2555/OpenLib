using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
