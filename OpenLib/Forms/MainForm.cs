using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace OpenLib.Forms
{
    public partial class MainForm : Form
    {
        private DBHandler db_handler;
        private bool Backup = true;
        public MainForm()
        {
            if(!DBHandler.CheckDB())
            {
                Forms.Setup dlg = new Setup();
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    DBHandler.ClearDB();
                    DBHandler.CreateDBFile(dlg.filename.Text);

                }
                else
                {
                    this.Close();
                }
            }

            db_handler = new DBHandler(Properties.Settings.Default.connect_string);
            InitializeComponent();
        }

        /*
         * BOOK VIEW FUNCTIONS
         */
        

        private void CheckLogin()
        {
            if (db_handler.GetAdminCount() > 0)
            {
                Forms.Login dlg = new Forms.Login();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string uname = dlg.username.Text;
                    string pw = dlg.pw.Text;

                    List<Admin> admins = db_handler.GetAdminsByUsername(uname);

                    bool successful = false;

                    foreach (Admin a in admins)
                    {
                        if (CryptoHelper.CheckPassword(pw, a.Hash, a.Salt))
                        {
                            successful = true;
                            break;
                        }
                    }

                    if (!successful)
                    {
                        MessageBox.Show("Wrong credentials!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CheckLogin();
                    }

                }
                else
                {

                    this.Backup = false;
                    Application.Exit();
                }
            }
        }

        public void PopulateBookView(List<Book> books)
        {
            this.bookView.Items.Clear();
            foreach (Book b in books)
            {
                string[] items =
                {
                    b.Id.ToString(),
                    b.ISBN,
                    b.Quantity.ToString(),
                    b.Borrowed.ToString(),
                    b.Title,
                    b.Author,
                    b.Description,
                    b.Remarks,

                };

                ListViewItem itm = new ListViewItem(items);
                if (b.Borrowed > 0)
                    itm.BackColor = Color.Bisque;
                else
                    itm.BackColor = Color.Transparent;

                this.bookView.Items.Add(itm);
            }
        }

        public void PopulateBookView()
        {
            PopulateBookView(db_handler.GetAllBooks());
        }

        public void AddBook()
        {
            Forms.AddBook dlg = new Forms.AddBook();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string isbn = ISBNApi.CleanISBN(dlg.isbn.Text);
                string title = dlg.title.Text;
                string author = dlg.authors.Text;
                string desc = dlg.desc.Text;
                string rem = dlg.remarks.Text;
                int quant = (int)dlg.quantity.Value;

                Book b = new Book(-1, title, author, isbn, desc, rem, quant);

                if (!db_handler.AddBook(b))
                    MessageBox.Show("An error occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PopulateBookView();
            }
        }

        public void EditBook()
        {
            if (this.bookView.SelectedItems.Count > 0)
            {
                Book b = Book.FromListView(this.bookView.SelectedItems[0]);
                Forms.EditBook dlg = new EditBook();

                dlg.title.Text = b.Title;
                dlg.authors.Text = b.Author;
                dlg.isbn.Text = b.ISBN;
                dlg.quantity.Value = b.Quantity;
                dlg.desc.Text = b.Description;
                dlg.remarks.Text = b.Remarks;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    b.Title = dlg.title.Text;
                    b.Author = dlg.authors.Text;
                    b.ISBN = dlg.isbn.Text;
                    b.Quantity = (int)dlg.quantity.Value;
                    b.Description = dlg.desc.Text;
                    b.Remarks = dlg.remarks.Text;

                    if (!db_handler.UpdateBook(b))
                        MessageBox.Show("An error occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PopulateBookView();
                }
            }
        }

        public void DeleteSelectedBooks()
        {
            int count = this.bookView.SelectedItems.Count;
            if (count > 0)
            {
                if (MessageBox.Show("Are you sure to delete " + count.ToString() + " entries?\nIt cannot be undone.",
                    "Deleting Books", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    List<Book> todel = new List<Book>();
                    foreach (ListViewItem lvi in this.bookView.SelectedItems)
                    {
                        Book b = Book.FromListView(lvi);
                        todel.Add(b);
                    }

                    if (db_handler.DeleteBooks(todel))
                    {
                        MessageBox.Show(count.ToString() + " entries deleted successfully.", "Deleting Books",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("An error occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    PopulateBookView();
                }
            }
        }

        public void SearchBook()
        {
            Forms.SearchBooks dlg = new SearchBooks();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                /*List<Book> finds = db_handler.SearchBooks(dlg.title.Text,
                    dlg.authors.Text,
                    dlg.isbn.Text,
                    (int)dlg.quantity.Value, (int)dlg.quantity_to.Value,
                    dlg.desc.Text,
                    dlg.remarks.Text,
                    dlg.checkTitle.Checked,
                    dlg.checkAuthors.Checked,
                    dlg.checkISBN.Checked,
                    dlg.checkQuant.Checked,
                    dlg.checkDesc.Checked,
                    dlg.checkRem.Checked);*/

                List<Book> finds = db_handler.SearchBooks(dlg.title.Content,
                    dlg.authors.Content,
                    dlg.isbn.Content,
                    -1, int.MaxValue,
                    dlg.description.Content,
                    dlg.remarks.Content,
                    dlg.title.Checked,
                    dlg.authors.Checked,
                    dlg.isbn.Checked,
                    false,
                    dlg.description.Checked,
                    dlg.remarks.Checked);

                if (finds != null)
                {
                    PopulateBookView(finds);
                }
                else
                    this.bookView.Items.Clear();
            }
        }

        public void AddLease()
        {
            if (this.bookView.SelectedItems.Count > 0)
            {
                Book b = Book.FromListView(this.bookView.SelectedItems[0]);
                if (b.Borrowed < b.Quantity)
                {
                    Forms.CreateLease dlg = new CreateLease(db_handler);
                    dlg.bookid.Text = b.Id.ToString();

                    int diff = b.Quantity - b.Borrowed;
                    dlg.quantity.Maximum = diff;

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        int bookId = Convert.ToInt32(dlg.bookid.Text);
                        int userId = Convert.ToInt32(dlg.userid.Text);
                        int quant = (int)dlg.quantity.Value;

                        bool ret = dlg.returned.Checked;

                        Lease l = new Lease(-1, bookId, userId, quant, dlg.from.Value,
                            dlg.to.Value, ret, dlg.remarks.Text,
                            "", "", "", "");

                        if (db_handler.InsertLease(l))
                            MessageBox.Show("Lease successfully creaed.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("An error occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        PopulateBookView();
                        PopulateLeaseView();
                    }
                }
                else
                    MessageBox.Show("All books have already been leased.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteBook()
        {
            int count = this.bookView.SelectedItems.Count;
            if (count > 0)
            {
                if (MessageBox.Show("Are you sure to delete " + count.ToString() + " entries?\nIt cannot be undone.",
                    "Deleting Books", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    List<Book> todel = new List<Book>();
                    foreach (ListViewItem lvi in this.bookView.SelectedItems)
                    {
                        Book l = Book.FromListView(lvi);
                        todel.Add(l);
                    }

                    if (db_handler.DeleteBooks(todel))
                    {
                        MessageBox.Show(count.ToString() + " entries deleted successfully.", "Deleting Books",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("An error occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    PopulateBookView();
                }
            }
        }

        /*
         * USER VIEW FUNCTIONS
         */

        private void PopulateUserView()
        {
            List<User> users = db_handler.GetAllUsers();
            PopulateUserView(users);
        }

        public void SearchUser()
        {
            Forms.SearchDialog dlg = new Forms.SearchDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                List<User> users = db_handler.SearchUserByName(dlg.searchText.Text);

                PopulateUserView(users);
            }
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
            if (this.userView.SelectedItems.Count > 0)
            {
                ModifyUser dlg = new ModifyUser();

                User u = User.FromListView(this.userView.SelectedItems[0]);

                dlg.firstName.Text = u.FirstName;
                dlg.lastName.Text = u.LastName;
                dlg.birthday.Value = u.Birthday;
                dlg.remarks.Text = u.Remarks;

                if (dlg.ShowDialog() == DialogResult.OK)
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

        public void DeleteUser()
        {
            if (this.userView.SelectedItems.Count > 0)
            {
                int count = this.userView.SelectedItems.Count;
                if (MessageBox.Show("Are you sure to delete " + count.ToString()
                    + " users?\nThis cannot be undone afterwards.", "Deleting Users", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    uint succ_count = 0;
                    foreach (ListViewItem lvi in this.userView.SelectedItems)
                    {
                        User u = User.FromListView(lvi);
                        if (db_handler.DeleteUser(u))
                            succ_count++;
                    }

                    PopulateUserView();

                    MessageBox.Show(succ_count.ToString() + " of " + count.ToString() + " users deleted successfully.",
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

        /*
         * LEASE VIEW FUNCTIONS
         */

        void PopulateLeaseView(List<Lease> leases)
        {
            this.leaseView.Items.Clear();

            foreach (Lease l in leases)
            {
                string[] items =
                {
                    l.Id.ToString(),
                    l.ISBN,
                    l.Title,
                    l.Quantity.ToString(),
                    l.LeaseDate.ToString().Split(' ')[0],
                    l.ReturnDate.ToString().Split(' ')[0],
                    l.LastName,
                    l.FirstName
                };

                ListViewItem itm = new ListViewItem(items);

                if (l.Returned == false)
                {
                    DateTime now = DateTime.Now;
                    if (DateTime.Compare(now, l.ReturnDate) > 0)
                    {
                        itm.BackColor = Color.Red;
                    }
                    else
                        itm.BackColor = Color.Green;

                    itm.ForeColor = Color.White;
                }
                else
                {
                    itm.BackColor = Color.LightGray;
                }

                this.leaseView.Items.Add(itm);
            }
        }

        public void SearchLease()
        {
            Forms.SearchLeases dlg = new SearchLeases();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                List<Lease> leases = db_handler.FindLeases(
                    dlg.title.Content, dlg.authors.Content, dlg.isbn.Content, dlg.description.Content,
                    dlg.remarks.Content, dlg.firstname.Content, dlg.lastname.Content,
                    dlg.title.Checked, dlg.authors.Checked, dlg.isbn.Checked,
                    dlg.description.Checked, dlg.remarks.Checked,
                    dlg.firstname.Checked, dlg.lastname.Checked);
                //List<Lease> leases = db_handler.FindLeaseByName(dlg.searchText.Text);
                PopulateLeaseView(leases);
            }
        }

        public void EditLease()
        {
            if (this.leaseView.SelectedItems.Count > 0)
            {
                Lease l = Lease.FromListView(this.leaseView.SelectedItems[0],
                    db_handler);

                Forms.CreateLease dlg = new CreateLease(db_handler);
                dlg.Text = "Edit Lease";

                dlg.bookid.Text = l.BookId.ToString();
                dlg.quantity.Value = l.Quantity;
                dlg.userid.Text = l.UserId.ToString();
                dlg.from.Value = l.LeaseDate;
                dlg.to.Value = l.ReturnDate;
                dlg.remarks.Text = l.Remarks;
                dlg.returned.Checked = l.Returned;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    l.BookId = Convert.ToInt32(dlg.bookid.Text);
                    l.Quantity = (int)dlg.quantity.Value;
                    l.UserId = Convert.ToInt32(dlg.userid.Text);
                    l.LeaseDate = dlg.from.Value;
                    l.ReturnDate = dlg.to.Value;
                    l.Remarks = dlg.remarks.Text;
                    l.Returned = dlg.returned.Checked;


                    db_handler.UpdateLease(l);
                    PopulateLeaseView();
                    PopulateBookView();
                }

            }
        }

        public void DeleteLeases()
        {
            int count = this.leaseView.SelectedItems.Count;
            if (count > 0)
            {
                if (MessageBox.Show("Are you sure to delete " + count.ToString() + " entries?\nIt cannot be undone.",
                    "Deleting Leases", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    List<Lease> todel = new List<Lease>();
                    foreach (ListViewItem lvi in this.leaseView.SelectedItems)
                    {
                        Lease l = Lease.FromListView(lvi, db_handler);
                        todel.Add(l);
                    }

                    if (db_handler.DeleteLeases(todel))
                    {
                        MessageBox.Show(count.ToString() + " entries deleted successfully.", "Deleting Leases",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("An error occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    PopulateLeaseView();
                    PopulateBookView();
                }
            }
        }

        void PopulateLeaseView()
        {
            List<Lease> leases = db_handler.GetAllLeases();
            PopulateLeaseView(leases);
        }

        /*
         * ADMIN VIEW FUNCTIONS
         */

        private void PopulateAdminView(List<Admin> users)
        {
            this.adminView.Items.Clear();
            foreach (Admin a in users)
            {
                string[] items = {a.Id.ToString(),
                a.Username};

                ListViewItem itm = new ListViewItem(items);
                this.adminView.Items.Add(itm);
            }
        }

        private void EditSelectedAdmin()
        {
            if (this.adminView.SelectedItems.Count > 0)
            {
                Admin a = Admin.FromListView(this.adminView.SelectedItems[0]);
                
                Forms.EditAdmin dlg = new EditAdmin();
                dlg.username.Text = a.Username;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string pw = dlg.pw1.Text;
                    string salt = CryptoHelper.GenerateSalt();
                    string hash = CryptoHelper.GenerateHash(pw, salt);

                    a.Hash = hash;
                    a.Salt = salt;
                    a.Username = dlg.username.Text;


                    if (!db_handler.UpdateAdmin(a))
                        MessageBox.Show("An error occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    PopulateAdminView();
                }
            }
        }

        private void PopulateAdminView()
        {
            List<Admin> admins = db_handler.GetAllAdmins();
            PopulateAdminView(admins);
        }

        private void AddAdmin()
        {
            Forms.CreateAdmin dlg = new Forms.CreateAdmin();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string uname = dlg.username.Text;
                string pw = dlg.pw1.Text;
                string salt = CryptoHelper.GenerateSalt();

                string hash = CryptoHelper.GenerateHash(pw, salt);

                Admin a = new Admin(uname, hash, salt);

                db_handler.InsertAdmin(a);

                PopulateAdminView();
            }
        }

        private void DeleteAdmin()
        {
            int count = this.adminView.SelectedItems.Count;
            if (count > 0)
            {
                if (MessageBox.Show("Are you sure to delete " + count.ToString() + " entries?\nIt cannot be undone.",
                    "Deleting Admins", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    List<int> todel = new List<int>();
                    foreach (ListViewItem lvi in this.adminView.SelectedItems)
                    {
                        int l = Convert.ToInt32(lvi.SubItems[0].Text);
                        todel.Add(l);
                    }

                    if (db_handler.DeleteAdmins(todel))
                    {
                        MessageBox.Show(count.ToString() + " entries deleted successfully.", "Deleting Admins",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("An error occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    PopulateAdminView();
                }
            }
        }

        /*
         * 
         *  OTHER
         *  
         *  */

        private static void ClearDB()
        {
            if(MessageBox.Show("Are you sure to delete everything? This can not be undone.", "Clear Database",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                DBHandler.ClearDB();
                MessageBox.Show("Database cleared. The application will close now.",
                    "Clear Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        public void BackupDB()
        {
            if(this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                db_handler.Backup(this.saveFileDialog.FileName);
            }
        }

        public void RestoreDB()
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                db_handler.Restore(this.saveFileDialog.FileName);

                PopulateAdminView();
                PopulateBookView();
                PopulateLeaseView();
                PopulateUserView();
            }
        }

        /*
         * -------------------------
         *         EVENTS
         * -------------------------
         */

        private void ToolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckLogin();
            PopulateBookView();
            PopulateUserView();
            PopulateLeaseView();
            PopulateAdminView();
        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void BookView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditBook();
        }

        private void AddLeaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLease();
        }

        private void EditBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditBook();
        }

        private void AddBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBook();
        }

        private void DeleteBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteBook();   
        }

        private void UserView_DoubleClick(object sender, EventArgs e)
        {
            EditUser();
        }

        private void EditUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditUser();
        }

        private void AddUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser();
        }

        private void DeleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        private void LeaseView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditLease();
        }

        private void EditLeaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditLease();
        }

        private void DeleteLeaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteLeases();
        }

        private void AdminView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AdminView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditSelectedAdmin();
        }

        private void EditAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSelectedAdmin();
        }

        private void AddAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAdmin();
        }

        private void SearchBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBook();
        }

        private void ResetSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopulateBookView();
        }

        private void AdminMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            switch(this.tabControl1.SelectedIndex)
            {
                case 0:
                    SearchBook();
                    break;
                case 1:
                    SearchUser();
                    break;
                case 2:
                    SearchLease();
                    break;

            }
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    PopulateBookView();
                    break;
                case 1:
                    PopulateUserView();
                    break;
                case 2:
                    PopulateLeaseView();
                    break;

            }
        }

        private void SearchUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchUser();
        }

        private void SearchLeaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchLease();
        }

        private void TabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 3)
            {
                this.SearchButton.Enabled = false;
                this.ResetSearchButton.Enabled = false;
            }
            else
            {
                this.SearchButton.Enabled = true;
                this.ResetSearchButton.Enabled = true;
            }

            if (this.tabControl1.SelectedIndex == 2)
            {
                this.AddButton.Enabled = false;
            }
            else
                this.AddButton.Enabled = true;
        }

        private void TabControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void UserView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditUser();
        }

        private void LeaseView_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            EditLease();
        }

        private void AdminView_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            EditSelectedAdmin();
        }

        private void BookView_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            EditBook();
        }

        private void DeleteDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Backup = false;
            ClearDB();
        }

        private void BackupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackupDB();
        }

        private void RestoreDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoreDB();
        }

        void RunWait()
        {
            Forms.Wait dlg = new Wait();
            Application.Run(dlg);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.Backup)
                {
                    System.Threading.ThreadStart ts = new System.Threading.ThreadStart(RunWait);
                    System.Threading.Thread td = new System.Threading.Thread(ts);
                    td.Start();

                    db_handler.Backup(Environment.CurrentDirectory + "\\autobackup.bak");
                    //System.Threading.Thread.Sleep(10000);
                    td.Abort();
                }
            }
            catch
            { }
        }

        private void DeleteAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
                DeleteAdmin();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    AddBook();
                    break;
                case 1:
                    AddUser();
                    break;
                case 3:
                    AddAdmin();
                    break;
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    DeleteBook();
                    break;
                case 1:
                    DeleteUser();
                    break;
                case 2:
                    DeleteLeases();
                    break;
                case 3:
                    DeleteAdmin();
                    break;
            }
        }
    }
}
