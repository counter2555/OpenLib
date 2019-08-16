namespace OpenLib
{
    partial class ModifyUser
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
            this.SuspendLayout();
            // 
            // remarks
            // 
            this.remarks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.remarks.Size = new System.Drawing.Size(391, 137);
            // 
            // ModifyUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.ClientSize = new System.Drawing.Size(589, 297);
            this.Name = "ModifyUser";
            this.Text = "Modify User";
            this.Load += new System.EventHandler(this.ModifyUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
