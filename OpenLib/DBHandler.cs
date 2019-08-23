using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

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

        public bool DeleteAdmin(int admin)
        {
            string query = "DELETE FROM dbo.Administrators WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(query, this.conn))
            {
                cmd.Parameters.AddWithValue("@Id", admin);

                int result = cmd.ExecuteNonQuery();

                if (result < 0)
                    return false;
                else
                    return true;
            }
        }

        public bool DeleteAdmins(List<int> admins)
        {
            bool successful = true;
            foreach (int u in admins)
            {
                if (this.DeleteAdmin(u) == false)
                    successful = false;
            }
            return successful;
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


        public List<Book> BookQuery(string query, SQLParameter[] parameters)
        {
            using (SqlCommand cmd = new SqlCommand(query, this.conn))
            {

                foreach (SQLParameter p in parameters)
                {
                    cmd.Parameters.AddWithValue(p.name, p.value);
                }

                List<Book> books = new List<Book>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("Id"));
                            string title = reader.SafeGetString(reader.GetOrdinal("Title"));
                            string authors = reader.SafeGetString(reader.GetOrdinal("Author"));
                            string isbn = reader.SafeGetString(reader.GetOrdinal("ISBN"));
                            int quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                            string desc = reader.SafeGetString(reader.GetOrdinal("Description"));
                            string rem = reader.SafeGetString(reader.GetOrdinal("Remarks"));

                            int borrowed = 0;
                            try
                            {
                                int o = reader.GetOrdinal("Leased");
                                borrowed = reader.GetInt32(o);
                            }
                            catch
                            {

                            }

                            Book b = new Book(id, title, authors, isbn, desc, rem, quantity,
                                borrowed);
                            books.Add(b);
                        }
                    }
                }


                return books;
            }
        }

        public Book QueryBookByISBN(string isbn)
        {
            string query = "SELECT * FROM dbo.Books WHERE ISBN = @isbn";

            SQLParameter pm = new SQLParameter();
            pm.name = "@isbn";
            pm.value = isbn;

            List<Book> books = this.BookQuery(query, new SQLParameter[] { pm });
            if (books.Count > 0)
                return books[0];
            else
                return null;

        }

        //inserts new entry for book in DB
        public bool InsertBook(Book b)
        {
            string query = "INSERT INTO dbo.Books (ISBN, Title, Author, Quantity, Description, Remarks) "
                        + "VALUES (@isbn, @title, @auth, @quant, @desc, @rem)";

            using (SqlCommand cmd = new SqlCommand(query, this.conn))
            {
                cmd.Parameters.AddWithValue("@isbn", b.ISBN);
                cmd.Parameters.AddWithValue("@title", b.Title);
                cmd.Parameters.AddWithValue("@auth", b.Author);
                cmd.Parameters.AddWithValue("@quant", b.Quantity);
                cmd.Parameters.AddWithValue("@desc", b.Description);
                cmd.Parameters.AddWithValue("@rem", b.Remarks);

                int result = cmd.ExecuteNonQuery();

                if (result < 0)
                    return false;
                else
                    return true;
            }
        }

        //checks if book exists and creates or adds to entry in DB
        public bool AddBook(Book b)
        {
            Book query = this.QueryBookByISBN(b.ISBN);
            if (query != null)
            {
                query.Quantity += b.Quantity;
                return this.UpdateBook(query);
            }
            else
                return this.InsertBook(b);
        }

        public bool UpdateBook(Book b)
        {
            string query = "UPDATE dbo.Books SET " +
             "ISBN=@isbn, Title=@title, Author=@auth, Quantity=@quant, Description=@desc, Remarks=@rem "
             +"WHERE Id = @id";

            using (SqlCommand cmd = new SqlCommand(query, this.conn))
            {
                cmd.Parameters.AddWithValue("@isbn", b.ISBN);
                cmd.Parameters.AddWithValue("@title", b.Title);
                cmd.Parameters.AddWithValue("@auth", b.Author);
                cmd.Parameters.AddWithValue("@quant", b.Quantity);
                cmd.Parameters.AddWithValue("@desc", b.Description);
                cmd.Parameters.AddWithValue("@rem", b.Remarks);

                cmd.Parameters.AddWithValue("@id", b.Id);

                int result = cmd.ExecuteNonQuery();

                if (result < 0)
                    return false;
                else
                    return true;
            }
        }

        public List<Book> GetAllBooks()
        {
            string query = "SELECT *, "
                + "(SELECT SUM(dbo.Leases.Quantity) FROM dbo.Leases "
                + "WHERE dbo.Leases.BookId = dbo.Books.Id  AND dbo.Leases.Returned = 0) as Leased "
                + "FROM dbo.Books ORDER BY Leased DESC, Title";

            return this.BookQuery(query, new SQLParameter[] { });

            /*
             SELECT *,
	            (SELECT SUM(dbo.Leases.BookId) FROM dbo.Leases
	            WHERE dbo.Leases.BookId = dbo.Books.Id) as Leased 
                FROM dbo.Books ORDER BY Leased DESC, Title 
           */
        }

        public List<Book> GetAllBooksAndRemain()
        {
            string query = "SELECT * FROM dbo.Books ORDER BY Title";
            return this.BookQuery(query, new SQLParameter[] { });

        }

        public bool DeleteBook(Book b)
        {
            string query = "DELETE FROM dbo.Books WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(query, this.conn))
            {
                cmd.Parameters.AddWithValue("@Id", b.Id);

                int result = cmd.ExecuteNonQuery();

                if (result < 0)
                    return false;
                else
                    return true;
            }
        }
        public bool DeleteBooks(List<Book> books)
        {
            bool successful = true;

            foreach(Book b in books)
            {
                if (!this.DeleteBook(b))
                    successful = false;
            }
            return successful;
        }

        public List<Book> SearchBooks(string title, string author, string isbn,
            int lowerQ, int upperQ, string desc, string remarks,
            bool bTitle, bool bAuthor, bool bISBN, bool bQuant, bool bDesc, bool bRem)
        {
            string query = "SELECT * FROM dbo.Books WHERE";

            List<string> query_parts = new List<string>();

            if(bTitle)
                query_parts.Add("LOWER(Title) LIKE LOWER(@title)");
            
            if (bAuthor)
                query_parts.Add("LOWER(Author) LIKE LOWER(@auth)");

            if (bISBN)
                query_parts.Add("LOWER(ISBN) LIKE LOWER(@isbn)");

            if (bQuant)
                query_parts.Add("Quantity BETWEEN @lq AND @uq");

            if (bDesc)
                query_parts.Add("LOWER(Description) LIKE LOWER(@desc)");

            if (bRem)
                query_parts.Add("LOWER(Remarks) LIKE LOWER(@rem)");



            if (query_parts.Count > 0)
            {
                for(int i = 0; i<query_parts.Count; i++)
                {
                    if (i != 0)
                        query += " AND";

                    query += " " + query_parts[i];
                }

                SQLParameter pisbn = new SQLParameter();
                pisbn.name = "@isbn";
                pisbn.value = "%"+isbn+"%";

                SQLParameter ptitle = new SQLParameter();
                ptitle.name = "@title";
                ptitle.value = "%" + title + "%";

                SQLParameter pauth = new SQLParameter();
                pauth.name = "@auth";
                pauth.value = "%" + author + "%";

                SQLParameter plq = new SQLParameter();
                plq.name = "@lq";
                plq.value = lowerQ;

                SQLParameter puq = new SQLParameter();
                puq.name = "@uq";
                puq.value = upperQ;

                SQLParameter pdesc = new SQLParameter();
                pdesc.name = "@desc";
                pdesc.value = "%" + desc + "%";


                SQLParameter prem = new SQLParameter();
                prem.name = "@rem";
                prem.value = "%" + remarks + "%";

                SQLParameter[] pars =
                {
                    pisbn, ptitle, pauth, plq, puq,
                    pdesc, prem
                };

                return this.BookQuery(query, pars);

            
            }
            else
                return null;
        }

        public List<Lease> LeaseQuery(string query, SQLParameter[] parameters)
        {
            using (SqlCommand cmd = new SqlCommand(query, this.conn))
            {

                foreach (SQLParameter p in parameters)
                {
                    cmd.Parameters.AddWithValue(p.name, p.value);
                }

                List<Lease> leases = new List<Lease>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("Id"));
                            int bookid = reader.GetInt32(reader.GetOrdinal("BookId"));
                            int quant = reader.GetInt32(reader.GetOrdinal("Quantity"));
                            int userid = reader.GetInt32(reader.GetOrdinal("UserId"));
                            DateTime from = reader.GetDateTime(reader.GetOrdinal("LeaseDate"));
                            DateTime to = reader.GetDateTime(reader.GetOrdinal("ReturnDate"));
                            bool returned = reader.GetBoolean(reader.GetOrdinal("Returned"));
                            string rem = reader.SafeGetString(reader.GetOrdinal("Remarks"));

                            string isbn = "";
                            string title = "";
                            string fname = "";
                            string lname = "";
                            
                            try
                            {
                                isbn = reader.SafeGetString(reader.GetOrdinal("ISBN"));
                                title = reader.SafeGetString(reader.GetOrdinal("Title"));
                                fname = reader.SafeGetString(reader.GetOrdinal("FirstName"));
                                lname = reader.SafeGetString(reader.GetOrdinal("LastName"));
                            }
                            catch
                            { }

                            Lease l = new Lease(id, bookid, userid, quant,
                                from, to, returned, rem,
                                isbn, title, fname, lname);

                            leases.Add(l);
                        }
                    }
                }


                return leases;
            }
        }

        public List<Lease> GetAllLeases()
        {
            string query = "SELECT "

                            + "DISTINCT(dbo.Leases.Id), dbo.Leases.BookId, dbo.Leases.Quantity, "
                            + "dbo.Leases.UserId, dbo.Leases.LeaseDate, dbo.Leases.ReturnDate, "
                            + "dbo.Leases.Returned, dbo.Leases.Remarks, "

                            + "(SELECT dbo.Books.ISBN FROM dbo.Books WHERE dbo.Books.Id = dbo.Leases.BookId) as ISBN, "
                            + "(SELECT dbo.Books.Title FROM dbo.Books WHERE dbo.Books.Id = dbo.Leases.BookId) as Title, "
                            + "(SELECT dbo.Users.FirstName FROM dbo.Users WHERE dbo.Users.Id = dbo.Leases.UserId) as FirstName, "
                            + "(SELECT dbo.Users.LastName FROM dbo.Users WHERE dbo.Users.Id = dbo.Leases.UserId) as LastName "

                            + "FROM dbo.Leases, dbo.Books ORDER BY dbo.Leases.Returned, dbo.Leases.ReturnDate";

            return this.LeaseQuery(query, new SQLParameter[] { });
        }

        public List<Lease> GetAllActiveLeases()
        {
            string query = "SELECT "

                            + "DISTINCT(dbo.Leases.Id), dbo.Leases.BookId, dbo.Leases.Quantity, "
                            + "dbo.Leases.UserId, dbo.Leases.LeaseDate, dbo.Leases.ReturnDate, "
                            + "dbo.Leases.Returned, dbo.Leases.Remarks, "

                            + "(SELECT dbo.Books.ISBN FROM dbo.Books WHERE dbo.Books.Id = dbo.Leases.BookId) as ISBN, "
                            + "(SELECT dbo.Books.Title FROM dbo.Books WHERE dbo.Books.Id = dbo.Leases.BookId) as Title, "
                            + "(SELECT dbo.Users.FirstName FROM dbo.Users WHERE dbo.Users.Id = dbo.Leases.UserId) as FirstName, "
                            + "(SELECT dbo.Users.LastName FROM dbo.Users WHERE dbo.Users.Id = dbo.Leases.UserId) as LastName "

                            + "FROM dbo.Leases, dbo.Books WHERE dbo.Leases.Returned = 0";

            return this.LeaseQuery(query, new SQLParameter[] { });
        }

        public List<Lease> FindLeases(string title, string author, string isbn, string desc,
            string rem, string firstname, string lastname,
            bool bTitle, bool bAuthor, bool bISBN, bool bDesc, bool bRem, bool bFirstname, bool bLastname)
        {
            string query = "SELECT DISTINCT(dbo.Leases.Id), dbo.Leases.BookId, dbo.Leases.Quantity, "
                          + "dbo.Leases.UserId, dbo.Leases.LeaseDate, dbo.Leases.ReturnDate, "
                          + "dbo.Leases.Returned, dbo.Leases.Remarks, "
                          + "dbo.Books.ISBN, dbo.Books.Title, dbo.Users.FirstName, dbo.Users.LastName "

                          + "FROM(dbo.Leases INNER JOIN dbo.Books ON dbo.Leases.BookId = dbo.Books.Id) "
                          + "INNER JOIN dbo.Users ON dbo.Leases.UserId = dbo.Users.Id "
                          + "WHERE";
                          
                          /*LOWER(dbo.Users.LastName) LIKE LOWER(@ss) OR LOWER(dbo.Users.FirstName) LIKE LOWER(@ss) "
                          + "OR LOWER(dbo.Books.Title) LIKE LOWER(@ss)";*/


            List<string> query_parts = new List<string>();

            if (bTitle)
                query_parts.Add("LOWER(dbo.Books.Title) LIKE LOWER(@title)");

            if (bAuthor)
                query_parts.Add("LOWER(dbo.Books.Author) LIKE LOWER(@auth)");

            if (bISBN)
                query_parts.Add("LOWER(dbo.Books.ISBN) LIKE LOWER(@isbn)");

            if (bDesc)
                query_parts.Add("LOWER(dbo.Books.Description) LIKE LOWER(@desc)");

            if (bRem)
                query_parts.Add("LOWER(dbo.Leases.Remarks) LIKE LOWER(@rem)");


            if (bFirstname)
                query_parts.Add("LOWER(dbo.Users.FirstName) LIKE LOWER(@fname)");

            if (bLastname)
                query_parts.Add("LOWER(dbo.Users.LastName) LIKE LOWER(@lname)");

            if (query_parts.Count > 0)
            {
                for (int i = 0; i < query_parts.Count; i++)
                {
                    if (i != 0)
                        query += " AND";

                    query += " " + query_parts[i];
                }

                SQLParameter pisbn = new SQLParameter();
                pisbn.name = "@isbn";
                pisbn.value = "%" + isbn + "%";

                SQLParameter ptitle = new SQLParameter();
                ptitle.name = "@title";
                ptitle.value = "%" + title + "%";

                SQLParameter pauth = new SQLParameter();
                pauth.name = "@auth";
                pauth.value = "%" + author + "%";

                SQLParameter pdesc = new SQLParameter();
                pdesc.name = "@desc";
                pdesc.value = "%" + desc + "%";

                SQLParameter prem = new SQLParameter();
                prem.name = "@rem";
                prem.value = "%" + rem + "%";

                SQLParameter pfname = new SQLParameter();
                pfname.name = "@fname";
                pfname.value = "%" + firstname + "%";

                SQLParameter plname = new SQLParameter();
                plname.name = "@lname";
                plname.value = "%" + lastname + "%";

                SQLParameter[] pars = { pisbn, ptitle, pauth, pdesc, prem, pfname, plname };

                return this.LeaseQuery(query, pars);
            }
            else
                return null;
        }

        public bool InsertLease(Lease l)
        {
            string query = "INSERT INTO dbo.Leases (BookId, Quantity, UserId, LeaseDate, ReturnDate, Returned," +
                "Remarks) "
                + "VALUES (@bookid, @quant, @userid, @from, @to, @ret, @rem)";

            using (SqlCommand cmd = new SqlCommand(query, this.conn))
            {
                cmd.Parameters.AddWithValue("@bookid", l.BookId);
                cmd.Parameters.AddWithValue("@quant", l.Quantity);
                cmd.Parameters.AddWithValue("@userid", l.UserId);
                cmd.Parameters.AddWithValue("@from", l.LeaseDate);
                cmd.Parameters.AddWithValue("@to", l.ReturnDate);
                cmd.Parameters.AddWithValue("@ret", l.Returned);
                cmd.Parameters.AddWithValue("@rem", l.Remarks);


                int result = cmd.ExecuteNonQuery();

                if (result < 0)
                    return false;
                else
                    return true;
            }
        }

        public bool UpdateLease(Lease l)
        {
            string query = "UPDATE dbo.Leases " +
                "SET BookId = @bookid, Quantity = @quantity, UserId = @userid, "
               +"LeaseDate = @from, ReturnDate = @to, Remarks = @rem, Returned = @ret "
                + "WHERE Id=@Id";

            using (SqlCommand cmd = new SqlCommand(query, this.conn))
            {
                cmd.Parameters.AddWithValue("@Id", l.Id);
                cmd.Parameters.AddWithValue("@bookid", l.BookId);
                cmd.Parameters.AddWithValue("@quantity", l.Quantity);
                cmd.Parameters.AddWithValue("@userid", l.UserId);
                cmd.Parameters.AddWithValue("@from", l.LeaseDate);
                cmd.Parameters.AddWithValue("@to", l.ReturnDate);
                cmd.Parameters.AddWithValue("@rem", l.Remarks);
                cmd.Parameters.AddWithValue("@ret", l.Returned);

                int result = cmd.ExecuteNonQuery();

                if (result < 0)
                    return false;
                else
                    return true;
            }

        }

        public bool DeleteLease(Lease l)
        {
            string query = "DELETE FROM dbo.Leases WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(query, this.conn))
            {
                cmd.Parameters.AddWithValue("@Id", l.Id);

                int result = cmd.ExecuteNonQuery();

                if (result < 0)
                    return false;
                else
                    return true;
            }
        }
        public bool DeleteLeases(List<Lease> leases)
        {
            bool successful = true;

            foreach (Lease l in leases)
            {
                if (!this.DeleteLease(l))
                    successful = false;
            }
            return successful;
        }

        public void Backup(string filename)
        {
            //BACKUP DATABASE [MyDatabase] TO  DISK = 'C:\....\MyDatabase.bak'
            string query = "BACKUP DATABASE [OpenLibDB] TO  DISK = '"+filename+"' WITH INIT, STATS=10";
            using (SqlCommand cmd = new SqlCommand(query, this.conn))
            {
                int result = cmd.ExecuteNonQuery();
            }
        }

        public void Restore(string filename)
        {
            string query = "RESTORE DATABASE [OpenLibDB] FROM  DISK = '" + filename + "'";
            using (SqlCommand cmd = new SqlCommand(query, this.conn))
            {
                int result = cmd.ExecuteNonQuery();
            }
        }

        public static bool CheckDB()
        {
            try
            {
                using (var connection = new SqlConnection(Properties.Settings.Default.connect_string))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM [dbo].[Books]";
                        int s = command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void ClearDB()
        {
            try
            {
                using (var connection = new SqlConnection(Properties.Settings.Default.connect_string))
                {
                    connection.Open();


                    string[] tableCmds =
                    {
                        "DROP TABLE IF EXISTS [dbo].[Administrators]",
                        "DROP TABLE IF EXISTS [dbo].[Books]",
                        "DROP TABLE IF EXISTS [dbo].[Leases]",
                        "DROP TABLE IF EXISTS [dbo].[Users]",
                        "DROP DATABASE IF EXISTS [OpenLibDB]"
                };

                    foreach (string c in tableCmds)
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = c;
                            int l = command.ExecuteNonQuery();
                        }
                    }

                    if(System.IO.File.Exists(Properties.Settings.Default.db_file))
                    {
                        System.IO.File.Delete(Properties.Settings.Default.db_file);
                    }

                    connection.Close();
                }
            }
            catch
            {

            }
        }



        public static void CreateDBFile(string filename)
        {
            try
            {
                using (var connection = new SqlConnection(Properties.Settings.Default.connect_string))
                {
                    connection.Open();


                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "CREATE DATABASE [OpenLibDB] ON PRIMARY (NAME=OpenLibDB,"
                        + "FILENAME='" + filename + "')";
                        command.ExecuteNonQuery();
                    }

                    string[] tableCmds =
                    {
                        "CREATE TABLE [dbo].[Administrators] ( [Id] INT IDENTITY (1, 1) NOT NULL, [Username] VARCHAR (40) NOT NULL, [Salt] VARCHAR (200) NOT NULL, [HASH] VARCHAR (200) NOT NULL, PRIMARY KEY CLUSTERED ([Id] ASC));",
                        "CREATE TABLE [dbo].[Books] ( [Id] INT IDENTITY (1, 1) NOT NULL, [ISBN] VARCHAR (100) NULL, [Title] VARCHAR (300) NULL, [Author] VARCHAR (300) NULL, [Quantity] INT DEFAULT ((1)) NOT NULL, [Description] VARCHAR (MAX) NULL, [Remarks] VARCHAR (MAX) NULL, PRIMARY KEY CLUSTERED ([Id] ASC) ); ",
                        "CREATE TABLE [dbo].[Leases] ( [Id] INT IDENTITY (1, 1) NOT NULL, [BookId] INT NOT NULL, [Quantity] INT DEFAULT ((1)) NOT NULL, [UserId] INT NOT NULL, [LeaseDate] DATE NOT NULL, [ReturnDate] DATE NOT NULL, [Returned] BIT DEFAULT ((0)) NOT NULL, [Remarks] VARCHAR (MAX) NULL, PRIMARY KEY CLUSTERED ([Id] ASC) ); ",
                        "CREATE TABLE [dbo].[Users] ( [Id] INT IDENTITY (1, 1) NOT NULL, [FirstName] VARCHAR (40) NOT NULL, [LastName] VARCHAR (40) NOT NULL, [Birthday] DATE NOT NULL, [Remarks] VARCHAR (MAX) NULL, PRIMARY KEY CLUSTERED ([Id] ASC) ); "
                    };

                    foreach (string c in tableCmds)
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = c;
                            int l = command.ExecuteNonQuery();
                            //MessageBox.Show(c + "\n" + l.ToString());
                        }
                    }
                    Properties.Settings.Default.db_file = filename;
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("An Error occured:\n" + ex.Message + "\n\nDo you want to delete the database?", "Error",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    DBHandler.ClearDB();
                }
            }
        }


    }


}
