namespace TestAppCSharp
{
    partial class Form1
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
            this.btnGetConnectionStringByName = new System.Windows.Forms.Button();
            this.lblConnectionString = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGetConnectionStringByName
            // 
            this.btnGetConnectionStringByName.Location = new System.Drawing.Point(56, 216);
            this.btnGetConnectionStringByName.Name = "btnGetConnectionStringByName";
            this.btnGetConnectionStringByName.Size = new System.Drawing.Size(170, 23);
            this.btnGetConnectionStringByName.TabIndex = 0;
            this.btnGetConnectionStringByName.Text = "Get Connection String By Name";
            this.btnGetConnectionStringByName.UseVisualStyleBackColor = true;
            this.btnGetConnectionStringByName.Click += new System.EventHandler(this.btnGetConnectionStringByName_Click);
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.AutoSize = true;
            this.lblConnectionString.Location = new System.Drawing.Point(12, 120);
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(35, 13);
            this.lblConnectionString.TabIndex = 1;
            this.lblConnectionString.Text = "label1";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(83, 51);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblConnectionString);
            this.Controls.Add(this.btnGetConnectionStringByName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetConnectionStringByName;
        private System.Windows.Forms.Label lblConnectionString;
        private System.Windows.Forms.TextBox txtName;
    }
}

