namespace OpenLib.Forms
{
    partial class ListAdmins
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.adminView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.adminView);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(800, 425);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(800, 450);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // listView1
            // 
            this.adminView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.adminView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminView.FullRowSelect = true;
            this.adminView.GridLines = true;
            this.adminView.HideSelection = false;
            this.adminView.Location = new System.Drawing.Point(0, 0);
            this.adminView.MultiSelect = false;
            this.adminView.Name = "listView1";
            this.adminView.Size = new System.Drawing.Size(800, 425);
            this.adminView.TabIndex = 0;
            this.adminView.UseCompatibleStateImageBehavior = false;
            this.adminView.View = System.Windows.Forms.View.Details;
            this.adminView.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            this.adminView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView1_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 184;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Username";
            this.columnHeader2.Width = 584;
            // 
            // ListAdmins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "ListAdmins";
            this.Text = "ListAdmins";
            this.Load += new System.EventHandler(this.ListAdmins_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ListView adminView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}