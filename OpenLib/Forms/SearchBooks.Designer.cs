namespace OpenLib.Forms
{
    partial class SearchBooks
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.remarks = new OpenLib.Forms.CheckedTextBox();
            this.description = new OpenLib.Forms.CheckedTextBox();
            this.isbn = new OpenLib.Forms.CheckedTextBox();
            this.authors = new OpenLib.Forms.CheckedTextBox();
            this.title = new OpenLib.Forms.CheckedTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(288, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 47);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(433, 252);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 47);
            this.button2.TabIndex = 7;
            this.button2.Text = "Abort";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // remarks
            // 
            this.remarks.Checked = false;
            this.remarks.Content = "";
            this.remarks.Label = "Remarks";
            this.remarks.Location = new System.Drawing.Point(12, 204);
            this.remarks.Name = "remarks";
            this.remarks.Size = new System.Drawing.Size(810, 42);
            this.remarks.TabIndex = 5;
            this.remarks.TextBackColor = System.Drawing.SystemColors.Window;
            // 
            // description
            // 
            this.description.Checked = false;
            this.description.Content = "";
            this.description.Label = "Description";
            this.description.Location = new System.Drawing.Point(12, 156);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(810, 42);
            this.description.TabIndex = 4;
            this.description.TextBackColor = System.Drawing.SystemColors.Window;
            // 
            // isbn
            // 
            this.isbn.Checked = false;
            this.isbn.Content = "";
            this.isbn.Label = "ISBN";
            this.isbn.Location = new System.Drawing.Point(12, 108);
            this.isbn.Name = "isbn";
            this.isbn.Size = new System.Drawing.Size(810, 42);
            this.isbn.TabIndex = 2;
            this.isbn.TextBackColor = System.Drawing.SystemColors.Window;
            // 
            // authors
            // 
            this.authors.Checked = false;
            this.authors.Content = "";
            this.authors.Label = "Author";
            this.authors.Location = new System.Drawing.Point(12, 60);
            this.authors.Name = "authors";
            this.authors.Size = new System.Drawing.Size(810, 42);
            this.authors.TabIndex = 1;
            this.authors.TextBackColor = System.Drawing.SystemColors.Window;
            // 
            // title
            // 
            this.title.Checked = false;
            this.title.Content = "";
            this.title.Label = "Title";
            this.title.Location = new System.Drawing.Point(12, 12);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(810, 42);
            this.title.TabIndex = 0;
            this.title.TextBackColor = System.Drawing.SystemColors.Window;
            // 
            // SearchBooks
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(848, 318);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.remarks);
            this.Controls.Add(this.description);
            this.Controls.Add(this.isbn);
            this.Controls.Add(this.authors);
            this.Controls.Add(this.title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchBooks";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SearchBooks";
            this.ResumeLayout(false);

        }

        #endregion
        public CheckedTextBox title;
        public CheckedTextBox authors;
        public CheckedTextBox isbn;
        public CheckedTextBox description;
        public CheckedTextBox remarks;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
    }
}