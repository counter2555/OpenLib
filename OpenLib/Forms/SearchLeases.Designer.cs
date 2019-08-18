namespace OpenLib.Forms
{
    partial class SearchLeases
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.firstname = new OpenLib.Forms.CheckedTextBox();
            this.lastname = new OpenLib.Forms.CheckedTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(296, 348);
            this.button1.TabIndex = 8;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(441, 348);
            this.button2.TabIndex = 9;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // firstname
            // 
            this.firstname.Checked = false;
            this.firstname.Content = "";
            this.firstname.Label = "Firstname";
            this.firstname.Location = new System.Drawing.Point(12, 252);
            this.firstname.Name = "firstname";
            this.firstname.Size = new System.Drawing.Size(810, 42);
            this.firstname.TabIndex = 6;
            this.firstname.TextBackColor = System.Drawing.SystemColors.Window;
            // 
            // lastname
            // 
            this.lastname.Checked = false;
            this.lastname.Content = "";
            this.lastname.Label = "Lastname";
            this.lastname.Location = new System.Drawing.Point(12, 300);
            this.lastname.Name = "lastname";
            this.lastname.Size = new System.Drawing.Size(810, 42);
            this.lastname.TabIndex = 7;
            this.lastname.TextBackColor = System.Drawing.SystemColors.Window;
            // 
            // SearchLeases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.ClientSize = new System.Drawing.Size(848, 410);
            this.Controls.Add(this.lastname);
            this.Controls.Add(this.firstname);
            this.Name = "SearchLeases";
            this.Load += new System.EventHandler(this.SearchLeases_Load);
            this.Controls.SetChildIndex(this.title, 0);
            this.Controls.SetChildIndex(this.authors, 0);
            this.Controls.SetChildIndex(this.isbn, 0);
            this.Controls.SetChildIndex(this.description, 0);
            this.Controls.SetChildIndex(this.remarks, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.firstname, 0);
            this.Controls.SetChildIndex(this.lastname, 0);
            this.ResumeLayout(false);

        }

        #endregion

        public CheckedTextBox firstname;
        public CheckedTextBox lastname;
    }
}
