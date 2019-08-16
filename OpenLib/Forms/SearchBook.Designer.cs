namespace OpenLib.Forms
{
    partial class SearchBook
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
            this.quantity_to = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.checkTitle = new System.Windows.Forms.CheckBox();
            this.checkAuthors = new System.Windows.Forms.CheckBox();
            this.checkISBN = new System.Windows.Forms.CheckBox();
            this.checkQuant = new System.Windows.Forms.CheckBox();
            this.checkDesc = new System.Windows.Forms.CheckBox();
            this.checkRem = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity_to)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.TextChanged += new System.EventHandler(this.Title_TextChanged);
            // 
            // authors
            // 
            this.authors.TextChanged += new System.EventHandler(this.Authors_TextChanged);
            // 
            // isbn
            // 
            this.isbn.TextChanged += new System.EventHandler(this.Isbn_TextChanged);
            // 
            // desc
            // 
            this.desc.TabIndex = 6;
            this.desc.TextChanged += new System.EventHandler(this.Desc_TextChanged);
            // 
            // remarks
            // 
            this.remarks.TabIndex = 7;
            this.remarks.TextChanged += new System.EventHandler(this.Remarks_TextChanged);
            // 
            // quantity
            // 
            this.quantity.Location = new System.Drawing.Point(212, 170);
            this.quantity.ValueChanged += new System.EventHandler(this.Quantity_ValueChanged);
            // 
            // quantity_to
            // 
            this.quantity_to.Location = new System.Drawing.Point(528, 170);
            this.quantity_to.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.quantity_to.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantity_to.Name = "quantity_to";
            this.quantity_to.Size = new System.Drawing.Size(272, 31);
            this.quantity_to.TabIndex = 5;
            this.quantity_to.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantity_to.ValueChanged += new System.EventHandler(this.Quantity_to_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(468, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "to";
            // 
            // checkTitle
            // 
            this.checkTitle.AutoSize = true;
            this.checkTitle.Location = new System.Drawing.Point(12, 9);
            this.checkTitle.Name = "checkTitle";
            this.checkTitle.Size = new System.Drawing.Size(28, 27);
            this.checkTitle.TabIndex = 17;
            this.checkTitle.UseVisualStyleBackColor = true;
            // 
            // checkAuthors
            // 
            this.checkAuthors.AutoSize = true;
            this.checkAuthors.Location = new System.Drawing.Point(12, 59);
            this.checkAuthors.Name = "checkAuthors";
            this.checkAuthors.Size = new System.Drawing.Size(28, 27);
            this.checkAuthors.TabIndex = 18;
            this.checkAuthors.UseVisualStyleBackColor = true;
            // 
            // checkISBN
            // 
            this.checkISBN.AutoSize = true;
            this.checkISBN.Location = new System.Drawing.Point(12, 114);
            this.checkISBN.Name = "checkISBN";
            this.checkISBN.Size = new System.Drawing.Size(28, 27);
            this.checkISBN.TabIndex = 19;
            this.checkISBN.UseVisualStyleBackColor = true;
            // 
            // checkQuant
            // 
            this.checkQuant.AutoSize = true;
            this.checkQuant.Location = new System.Drawing.Point(12, 174);
            this.checkQuant.Name = "checkQuant";
            this.checkQuant.Size = new System.Drawing.Size(28, 27);
            this.checkQuant.TabIndex = 20;
            this.checkQuant.UseVisualStyleBackColor = true;
            // 
            // checkDesc
            // 
            this.checkDesc.AutoSize = true;
            this.checkDesc.Location = new System.Drawing.Point(12, 234);
            this.checkDesc.Name = "checkDesc";
            this.checkDesc.Size = new System.Drawing.Size(28, 27);
            this.checkDesc.TabIndex = 21;
            this.checkDesc.UseVisualStyleBackColor = true;
            // 
            // checkRem
            // 
            this.checkRem.AutoSize = true;
            this.checkRem.Location = new System.Drawing.Point(12, 430);
            this.checkRem.Name = "checkRem";
            this.checkRem.Size = new System.Drawing.Size(28, 27);
            this.checkRem.TabIndex = 22;
            this.checkRem.UseVisualStyleBackColor = true;
            // 
            // SearchBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.ClientSize = new System.Drawing.Size(1100, 702);
            this.Controls.Add(this.checkRem);
            this.Controls.Add(this.checkDesc);
            this.Controls.Add(this.checkQuant);
            this.Controls.Add(this.checkISBN);
            this.Controls.Add(this.checkAuthors);
            this.Controls.Add(this.checkTitle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.quantity_to);
            this.Name = "SearchBook";
            this.Text = "Search Book";
            this.Controls.SetChildIndex(this.title, 0);
            this.Controls.SetChildIndex(this.authors, 0);
            this.Controls.SetChildIndex(this.isbn, 0);
            this.Controls.SetChildIndex(this.desc, 0);
            this.Controls.SetChildIndex(this.remarks, 0);
            this.Controls.SetChildIndex(this.quantity, 0);
            this.Controls.SetChildIndex(this.quantity_to, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.checkTitle, 0);
            this.Controls.SetChildIndex(this.checkAuthors, 0);
            this.Controls.SetChildIndex(this.checkISBN, 0);
            this.Controls.SetChildIndex(this.checkQuant, 0);
            this.Controls.SetChildIndex(this.checkDesc, 0);
            this.Controls.SetChildIndex(this.checkRem, 0);
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity_to)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.NumericUpDown quantity_to;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.CheckBox checkTitle;
        public System.Windows.Forms.CheckBox checkAuthors;
        public System.Windows.Forms.CheckBox checkISBN;
        public System.Windows.Forms.CheckBox checkQuant;
        public System.Windows.Forms.CheckBox checkDesc;
        public System.Windows.Forms.CheckBox checkRem;
    }
}
