namespace OpenLib.Forms
{
    partial class ListLeases
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListLeases));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.leaseView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editLeaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteLeaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.leaseView);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1260, 701);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1324, 726);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // leaseView
            // 
            this.leaseView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader5,
            this.columnHeader8});
            this.leaseView.ContextMenuStrip = this.contextMenuStrip1;
            this.leaseView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leaseView.FullRowSelect = true;
            this.leaseView.GridLines = true;
            this.leaseView.HideSelection = false;
            this.leaseView.Location = new System.Drawing.Point(0, 0);
            this.leaseView.Name = "leaseView";
            this.leaseView.Size = new System.Drawing.Size(1260, 701);
            this.leaseView.TabIndex = 0;
            this.leaseView.UseCompatibleStateImageBehavior = false;
            this.leaseView.View = System.Windows.Forms.View.Details;
            this.leaseView.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            this.leaseView.DoubleClick += new System.EventHandler(this.ListView1_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ISBN";
            this.columnHeader2.Width = 140;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Title";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Quantity";
            this.columnHeader4.Width = 132;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "From";
            this.columnHeader6.Width = 172;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "To";
            this.columnHeader7.Width = 144;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Lastname";
            this.columnHeader5.Width = 220;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Firstname";
            this.columnHeader8.Width = 184;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editLeaseToolStripMenuItem,
            this.deleteLeaseToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(284, 80);
            // 
            // editLeaseToolStripMenuItem
            // 
            this.editLeaseToolStripMenuItem.Name = "editLeaseToolStripMenuItem";
            this.editLeaseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.editLeaseToolStripMenuItem.Size = new System.Drawing.Size(283, 38);
            this.editLeaseToolStripMenuItem.Text = "Edit Lease";
            this.editLeaseToolStripMenuItem.Click += new System.EventHandler(this.EditLeaseToolStripMenuItem_Click);
            // 
            // deleteLeaseToolStripMenuItem
            // 
            this.deleteLeaseToolStripMenuItem.Name = "deleteLeaseToolStripMenuItem";
            this.deleteLeaseToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteLeaseToolStripMenuItem.Size = new System.Drawing.Size(283, 38);
            this.deleteLeaseToolStripMenuItem.Text = "Delete Lease";
            this.deleteLeaseToolStripMenuItem.Click += new System.EventHandler(this.DeleteLeaseToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 6);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(64, 142);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(61, 36);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Search Lease";
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(61, 36);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Reset Search";
            this.toolStripButton2.Click += new System.EventHandler(this.ToolStripButton2_Click);
            // 
            // ListLeases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 726);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "ListLeases";
            this.Text = "ListLeases";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ListLeases_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ListView leaseView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editLeaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteLeaseToolStripMenuItem;
    }
}