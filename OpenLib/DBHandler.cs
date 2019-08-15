using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OpenLib
{
    public class DBHandler
    {
        private string connString;
        private SqlConnection conn;

        public struct SQLParameter
        {
            public string name;
            public object value;
        }

        public DBHandler(string conn_string)
        {
            this.connString = conn_string;

            this.conn = new SqlConnection(this.connString);
            this.conn.Open();
        }

        public void End()
        {
            this.conn.Close();
        }

        public bool InsertUser(User u)
        {
            string query = "INSERT INTO dbo.Users (FirstName, LastName, Birthday) "
                + "VALUES (@fn, @ln, @bd)";

            using (SqlCommand cmd = new SqlCommand(query, this.conn))
            {
                cmd.Parameters.AddWithValue("@fn", u.FirstName);
                cmd.Parameters.AddWithValue("@ln", u.LastName);
                cmd.Parameters.AddWithValue("@bd", u.Birthday);

                int result = cmd.ExecuteNonQuery();

                if (result < 0)
                    return false;
                else
                    return true;
            }
        }

        public List<User> UserQuery(string query, SQLParameter[] parameters)
        {
            using (SqlCommand cmd = new SqlCommand(query, this.conn))
            {

                foreach (SQLParameter p in parameters)
                {
                    cmd.Parameters.AddWithValue(p.name, p.value);
                }

                List<User> users = new List<User>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("Id"));
                            string fname = reader.GetString(reader.GetOrdinal("FirstName"));
                            string lname = reader.GetString(reader.GetOrdinal("LastName"));
                            DateTime bday = reader.GetDateTime(reader.GetOrdinal("Birthday"));

                            User u = new User(id, fname, lname, bday);
                            users.Add(u);
                        }
                    }
                }


                return users;
            }
        }

        public List<User> GetAllUsers()
        {
            string query = "SELECT * FROM dbo.Users ORDER BY LastName";
            return this.UserQuery(query, new SQLParameter[] { });
        }

        public bool UpdateUser(User u)
        {
            string query = "UPDATE dbo.Users SET "+
                "FirstName=@fname, LastName=@lname, Birthday=@bday "
                +"WHERE Id=@Id";

            using (SqlCommand cmd = new SqlCommand(query, this.conn))
            {
                cmd.Parameters.AddWithValue("@fname", u.FirstName);
                cmd.Parameters.AddWithValue("@lname", u.LastName);
                cmd.Parameters.AddWithValue("@bday", u.Birthday);
                cmd.Parameters.AddWithValue("@Id", u.Id);

                int result = cmd.ExecuteNonQuery();

                if (result < 0)
                    return false;
                else
                    return true;
            }

        }

        public List<User> SearchUserByName(string name)
        {
            string query = "SELECT * FROM dbo.Users "+
                "WHERE LOWER(LastName) LIKE LOWER(@ss) "
                +"OR LOWER(FirstName) LIKE LOWER(@ss) "
                +"ORDER BY LastName";
            
            SQLParameter ss = new SQLParameter();
            ss.name = "@ss";
            ss.value = "%"+name+"%";

            return this.UserQuery(query, new SQLParameter[] { ss });

        }
    }
}
