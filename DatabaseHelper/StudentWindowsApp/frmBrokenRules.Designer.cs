namespace StudentWindowsApp
{
    partial class frmBrokenRules
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
            this.gvBrokenRules = new System.Windows.Forms.DataGridView();
            this.BrokenRule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvBrokenRules)).BeginInit();
            this.SuspendLayout();
            // 
            // gvBrokenRules
            // 
            this.gvBrokenRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvBrokenRules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BrokenRule});
            this.gvBrokenRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvBrokenRules.Location = new System.Drawing.Point(0, 0);
            this.gvBrokenRules.Name = "gvBrokenRules";
            this.gvBrokenRules.Size = new System.Drawing.Size(284, 261);
            this.gvBrokenRules.TabIndex = 0;
            // 
            // BrokenRule
            // 
            this.BrokenRule.DataPropertyName = "BrokenRule";
            this.BrokenRule.HeaderText = "";
            this.BrokenRule.Name = "BrokenRule";
            this.BrokenRule.ReadOnly = true;
            this.BrokenRule.Width = 250;
            // 
            // frmBrokenRules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.gvBrokenRules);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBrokenRules";
            this.Text = "Errors";
            ((System.ComponentModel.ISupportInitialize)(this.gvBrokenRules)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvBrokenRules;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrokenRule;
    }
}