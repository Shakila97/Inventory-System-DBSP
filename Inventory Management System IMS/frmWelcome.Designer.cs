namespace InventoryManagementSystem
{
    partial class frmWelcome
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
            this.btnProceedToLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProceedToLogin
            // 
            this.btnProceedToLogin.Location = new System.Drawing.Point(302, 288);
            this.btnProceedToLogin.Name = "btnProceedToLogin";
            this.btnProceedToLogin.Size = new System.Drawing.Size(118, 33);
            this.btnProceedToLogin.TabIndex = 0;
            this.btnProceedToLogin.Text = "Welcom";
            this.btnProceedToLogin.UseVisualStyleBackColor = true;
            // 
            // frmWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 585);
            this.Controls.Add(this.btnProceedToLogin);
            this.Name = "frmWelcome";
            this.Text = "IMS";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProceedToLogin;
    }
}

