namespace OpenLib.Forms
{
    partial class CreateLease
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
            this.bookid = new System.Windows.Forms.TextBox();
            this.quantity = new System.Windows.Forms.NumericUpDown();
            this.userid = new System.Windows.Forms.TextBox();
            this.from = new System.Windows.Forms.DateTimePicker();
            this.to = new System.Windows.Forms.DateTimePicker();
            this.remarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).BeginInit();
            this.SuspendLayout();
            // 
            // bookid
            // 
            this.bookid.Location = new System.Drawing.Point(144, 24);
            this.bookid.Name = "bookid";
            this.bookid.ReadOnly = true;
            this.bookid.Size = new System.Drawing.Size(160, 31);
            this.bookid.TabIndex = 0;
            // 
            // quantity
            // 
            this.quantity.Location = new System.Drawing.Point(500, 25);
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
            this.quantity.Size = new System.Drawing.Size(208, 31);
            this.quantity.TabIndex = 2;
            this.quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // userid
            // 
            this.userid.Location = new System.Drawing.Point(144, 78);
            this.userid.Name = "userid";
            this.userid.ReadOnly = true;
            this.userid.Size = new System.Drawing.Size(208, 31);
            this.userid.TabIndex = 3;
            // 
            // from
            // 
            this.from.Location = new System.Drawing.Point(144, 133);
            this.from.Name = "from";
            this.from.Size = new System.Drawing.Size(248, 31);
            this.from.TabIndex = 5;
            // 
            // to
            // 
            this.to.Location = new System.Drawing.Point(460, 133);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(248, 31);
            this.to.TabIndex = 6;
            // 
            // remarks
            // 
            this.remarks.Location = new System.Drawing.Point(144, 186);
            this.remarks.Multiline = true;
            this.remarks.Name = "remarks";
            this.remarks.Size = new System.Drawing.Size(564, 167);
            this.remarks.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Book Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(402, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Quantity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "User Id";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(373, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(335, 39);
            this.button1.TabIndex = 4;
            this.button1.Text = "Find User";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(144, 382);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 39);
            this.button2.TabIndex = 8;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Location = new System.Drawing.Point(291, 382);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 39);
            this.button3.TabIndex = 9;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Remarks";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "From";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(417, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "To";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(310, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 39);
            this.button4.TabIndex = 1;
            this.button4.Text = "Scan";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // CreateLease
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button3;
            this.ClientSize = new System.Drawing.Size(756, 442);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.remarks);
            this.Controls.Add(this.to);
            this.Controls.Add(this.from);
            this.Controls.Add(this.userid);
            this.Controls.Add(this.quantity);
            this.Controls.Add(this.bookid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateLease";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "New Lease";
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox bookid;
        public System.Windows.Forms.NumericUpDown quantity;
        public System.Windows.Forms.TextBox userid;
        public System.Windows.Forms.DateTimePicker from;
        public System.Windows.Forms.DateTimePicker to;
        public System.Windows.Forms.TextBox remarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
    }
}