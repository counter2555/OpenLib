namespace OpenLib.Forms
{
    partial class AddBook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.title = new System.Windows.Forms.TextBox();
            this.authors = new System.Windows.Forms.TextBox();
            this.isbn = new System.Windows.Forms.TextBox();
            this.desc = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.remarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.quantity = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(212, 12);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(876, 31);
            this.title.TabIndex = 0;
            // 
            // authors
            // 
            this.authors.Location = new System.Drawing.Point(212, 61);
            this.authors.Name = "authors";
            this.authors.Size = new System.Drawing.Size(876, 31);
            this.authors.TabIndex = 1;
            this.authors.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // isbn
            // 
            this.isbn.Location = new System.Drawing.Point(212, 110);
            this.isbn.Name = "isbn";
            this.isbn.Size = new System.Drawing.Size(824, 31);
            this.isbn.TabIndex = 2;
            this.isbn.TextChanged += new System.EventHandler(this.TextBox3_TextChanged);
            this.isbn.Leave += new System.EventHandler(this.Isbn_Leave);
            // 
            // desc
            // 
            this.desc.Location = new System.Drawing.Point(212, 231);
            this.desc.Multiline = true;
            this.desc.Name = "desc";
            this.desc.Size = new System.Drawing.Size(876, 183);
            this.desc.TabIndex = 5;
            this.desc.TextChanged += new System.EventHandler(this.TextBox4_TextChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(212, 643);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 47);
            this.button1.TabIndex = 7;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(345, 643);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 47);
            this.button2.TabIndex = 8;
            this.button2.Text = "Abort";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Authors";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "ISBN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Description";
            // 
            // remarks
            // 
            this.remarks.Location = new System.Drawing.Point(212, 432);
            this.remarks.Multiline = true;
            this.remarks.Name = "remarks";
            this.remarks.Size = new System.Drawing.Size(876, 183);
            this.remarks.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 432);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Remarks";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1042, 110);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(46, 31);
            this.button3.TabIndex = 3;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // quantity
            // 
            this.quantity.Location = new System.Drawing.Point(212, 174);
            this.quantity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.quantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(232, 31);
            this.quantity.TabIndex = 4;
            this.quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(97, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Quantity";
            // 
            // AddBook
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(1100, 702);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.quantity);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.remarks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.desc);
            this.Controls.Add(this.isbn);
            this.Controls.Add(this.authors);
            this.Controls.Add(this.title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddBook";
            this.ShowIcon = false;
            this.Text = "Add Book";
            this.Load += new System.EventHandler(this.AddBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox title;
        public System.Windows.Forms.TextBox authors;
        public System.Windows.Forms.TextBox isbn;
        public System.Windows.Forms.TextBox desc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox remarks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.NumericUpDown quantity;
    }
}