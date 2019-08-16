using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OpenLib
{
    public static class DBHelpers
    {
        public static string SafeGetString(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }
    }
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
            string query = "INSERT INTO dbo.Users (FirstName, LastName, Birthday, Remarks) "
                + "VALUES (@fn, @ln, @bd, @rm)";

            using (SqlCommand cmd = new SqlCommand(query, this.conn))
            {
                cmd.Parameters.AddWithValue("@fn", u.FirstName);
                cmd.Parameters.AddWithValue("@ln", u.LastName);
                cmd.Parameters.AddWithValue("@bd", u.Birthday);
                cmd.Parameters.AddWithValue("@rm", u.Remarks);

                int result = cmd.ExecuteNonQuery();

                if (result < 0)
                    return false;
                else
                    return true;
            }
        }

        public bool InsertAdmin(Admin a)
        {
            string query = "INSERT INTO dbo.Administrators (Username, Salt, Hash) "
                + "VALUES (@un, @slt, @hash)";

            using (SqlCommand cmd = new SqlCommand(query, this.conn))
            {
                cmd.Parameters.AddWithValue("@un", a.Username);
                cmd.Parameters.AddWithValue("@slt", a.Salt);
                cmd.Parameters.AddWithValue("@hash", a.Hash);

                int result = cmd.ExecuteNonQuery();

                if (result < 0)
                    return false;
                else
                    return true;
            }
        }

        public List<Admin> AdminQuery(string query, SQLParameter[] parameters)
        {
            using (SqlCommand cmd = new SqlCommand(query, this.conn))
            {

                foreach (SQLParameter p in parameters)
                {
                    cmd.Parameters.AddWithValue(p.name, p.value);
                }

                List<Admin> admins = new List<Admin>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("Id"));
                            string uname = reader.SafeGetString(reader.GetOrdinal("Username"));
                            string salt = reader.SafeGetString(reader.GetOrdinal("Salt"));
                            string hash = reader.SafeGetString(reader.GetOrdinal("Hash"));

                            Admin a = new Admin(id, uname, hash, salt);
                            admins.Add(a);
                        }
                    }
                }


                return admins;
            }
        }

        public int IntAdminQuery(string query, SQLParameter[] parameters)
        {
            using (SqlCommand cmd = new SqlCommand(query, this.conn))
            {

                foreach (SQLParameter p in parameters)
                {
                    cmd.Parameters.AddWithValue(p.name, p.value);
                }

                int z = (int)cmd.ExecuteScalar();
                return z;
            }
        }

        public int GetAdminCount()
        {
            string query = "SELECT COUNT(*) FROM dbo.Administrators";
            return IntAdminQuery(query, new SQLParameter[] { });
        }

        public List<Admin> GetAdminsByUsername(string username)
        {
            string query = "SELECT * FROM dbo.Administrators WHERE Username = @un";

            SQLParameter un = new SQLParameter();
            un.name = "@un";
            un.value = username;

            return AdminQuery(query, new SQLParameter[] { un });
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
                            string fname = reader.SafeGetString(reader.GetOrdinal("FirstName"));
                            string lname = reader.SafeGetString(reader.GetOrdinal("LastName"));
                            DateTime bday = reader.GetDateTime(reader.GetOrdinal("Birthday"));
                            string remarks = reader.SafeGetString(reader.GetOrdinal("Remarks"));

                            User u = new User(id, fname, lname, bday, remarks);
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

        public List<Admin> GetAllAdmins()
        {
            string query = "SELECT * from dbo.Administrators ORDER BY Id";
            return this.AdminQuery(query, new SQLParameter[] { });
        }

        public bool UpdateUser(User u)
        {
            string query = "UPDATE dbo.Users SET " +
                "FirstName=@fname, LastName=@lname, Birthday=@bday, Remarks=@rem "
                + "WHERE Id=@Id";

            using (SqlCommand cmd = new SqlCommand(query, this.conn))
            {
                cmd.Parameters.AddWithValue("@fname", u.FirstName);
                cmd.Parameters.AddWithValue("@lname", u.LastName);
                cmd.Parameters.AddWithValue("@bday", u.Birthday);
                cmd.Parameters.AddWithValue("@rem", u.Remarks);
                cmd.Parameters.AddWithValue("@Id", u.Id);

                int result = cmd.ExecuteNonQuery();

                if (result < 0)
                    return false;
                else
                    return true;
            }

        }

        public bool UpdateAdmin(Admin a)
        {
            string query = "UPDATE dbo.Administrators SET " +
                         "Username=@un, Hash=@hsh, Salt=@slt "
                            + "WHERE Id=@Id";

            using (SqlCommand cmd = new SqlCommand(query, this.conn))
            {
                cmd.Parameters.AddWithValue("@un", a.Username);
                cmd.Parameters.AddWithValue("@Id", a.Id);
                cmd.Parameters.AddWithValue("@hsh", a.Hash);
                cmd.Parameters.AddWithValue("@slt", a.Salt);

                int result = cmd.ExecuteNonQuery();

                if (result < 0)
                    return false;
                else
                    return true;
            }
        }

        public List<User> SearchUserByName(string name)
        {
            string query = "SELECT * FROM dbo.Users " +
                "WHERE LOWER(LastName) LIKE LOWER(@ss) "
                + "OR LOWER(FirstName) LIKE LOWER(@ss) "
                + "ORDER BY LastName";

            SQLParameter ss = new SQLParameter();
            ss.name = "@ss";
            ss.value = "%" + name + "%";

            return this.UserQuery(query, new SQLParameter[] { ss });

        }
        public bool DeleteUser(User u)
        {
            string query = "DELETE FROM dbo.Users WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(query, this.conn))
            {
                cmd.Parameters.AddWithValue("@Id", u.Id);

                int result = cmd.ExecuteNonQuery();

                if (result < 0)
                    return false;
                else
                    return true;
            }
        }

        public bool DeleteUsers(List<User> users)
        {
            bool successful = true;
            foreach (User u in users)
            {
                if (this.DeleteUser(u) == false)
                    successful = false;
            }
            return successful;
        }
    }
    
}
