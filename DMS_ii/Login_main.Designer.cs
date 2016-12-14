namespace DMS_ii
{
    partial class Login_main
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
            this.LB_DMS_Login_ID = new System.Windows.Forms.Label();
            this.DMS_Login_panel = new System.Windows.Forms.Panel();
            this.DMS_Login_Cancel = new System.Windows.Forms.Button();
            this.DMS_Login_ServerCB = new System.Windows.Forms.ComboBox();
            this.LB_DMS_Login_Server = new System.Windows.Forms.Label();
            this.DMS_Login_Button = new System.Windows.Forms.Button();
            this.DMS_Login_PWD_tb = new System.Windows.Forms.TextBox();
            this.LB_DMS_Login_PW = new System.Windows.Forms.Label();
            this.DMS_Login_ID_tb = new System.Windows.Forms.TextBox();
            this.DMS_Login_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LB_DMS_Login_ID
            // 
            this.LB_DMS_Login_ID.AutoSize = true;
            this.LB_DMS_Login_ID.Location = new System.Drawing.Point(42, 82);
            this.LB_DMS_Login_ID.Name = "LB_DMS_Login_ID";
            this.LB_DMS_Login_ID.Size = new System.Drawing.Size(72, 24);
            this.LB_DMS_Login_ID.TabIndex = 0;
            this.LB_DMS_Login_ID.Text = "帳   號 :";
            // 
            // DMS_Login_panel
            // 
            this.DMS_Login_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DMS_Login_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DMS_Login_panel.Controls.Add(this.DMS_Login_Cancel);
            this.DMS_Login_panel.Controls.Add(this.DMS_Login_ServerCB);
            this.DMS_Login_panel.Controls.Add(this.LB_DMS_Login_Server);
            this.DMS_Login_panel.Controls.Add(this.DMS_Login_Button);
            this.DMS_Login_panel.Controls.Add(this.DMS_Login_PWD_tb);
            this.DMS_Login_panel.Controls.Add(this.LB_DMS_Login_PW);
            this.DMS_Login_panel.Controls.Add(this.DMS_Login_ID_tb);
            this.DMS_Login_panel.Controls.Add(this.LB_DMS_Login_ID);
            this.DMS_Login_panel.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DMS_Login_panel.Location = new System.Drawing.Point(12, 12);
            this.DMS_Login_panel.Name = "DMS_Login_panel";
            this.DMS_Login_panel.Size = new System.Drawing.Size(377, 264);
            this.DMS_Login_panel.TabIndex = 1;
            // 
            // DMS_Login_Cancel
            // 
            this.DMS_Login_Cancel.Location = new System.Drawing.Point(46, 184);
            this.DMS_Login_Cancel.Name = "DMS_Login_Cancel";
            this.DMS_Login_Cancel.Size = new System.Drawing.Size(106, 29);
            this.DMS_Login_Cancel.TabIndex = 5;
            this.DMS_Login_Cancel.Text = "取消";
            this.DMS_Login_Cancel.UseVisualStyleBackColor = true;
            this.DMS_Login_Cancel.Click += new System.EventHandler(this.DMS_Login_Cancel_Click);
            // 
            // DMS_Login_ServerCB
            // 
            this.DMS_Login_ServerCB.FormattingEnabled = true;
            this.DMS_Login_ServerCB.Location = new System.Drawing.Point(119, 37);
            this.DMS_Login_ServerCB.Name = "DMS_Login_ServerCB";
            this.DMS_Login_ServerCB.Size = new System.Drawing.Size(188, 32);
            this.DMS_Login_ServerCB.TabIndex = 1;
            // 
            // LB_DMS_Login_Server
            // 
            this.LB_DMS_Login_Server.AutoSize = true;
            this.LB_DMS_Login_Server.Location = new System.Drawing.Point(42, 40);
            this.LB_DMS_Login_Server.Name = "LB_DMS_Login_Server";
            this.LB_DMS_Login_Server.Size = new System.Drawing.Size(71, 24);
            this.LB_DMS_Login_Server.TabIndex = 5;
            this.LB_DMS_Login_Server.Text = "Server:";
            // 
            // DMS_Login_Button
            // 
            this.DMS_Login_Button.Location = new System.Drawing.Point(201, 184);
            this.DMS_Login_Button.Name = "DMS_Login_Button";
            this.DMS_Login_Button.Size = new System.Drawing.Size(106, 29);
            this.DMS_Login_Button.TabIndex = 4;
            this.DMS_Login_Button.Text = "登入";
            this.DMS_Login_Button.UseVisualStyleBackColor = true;
            this.DMS_Login_Button.Click += new System.EventHandler(this.DMS_Login_Button_Click);
            // 
            // DMS_Login_PWD_tb
            // 
            this.DMS_Login_PWD_tb.Location = new System.Drawing.Point(119, 126);
            this.DMS_Login_PWD_tb.Name = "DMS_Login_PWD_tb";
            this.DMS_Login_PWD_tb.PasswordChar = '*';
            this.DMS_Login_PWD_tb.Size = new System.Drawing.Size(188, 33);
            this.DMS_Login_PWD_tb.TabIndex = 3;
            // 
            // LB_DMS_Login_PW
            // 
            this.LB_DMS_Login_PW.AutoSize = true;
            this.LB_DMS_Login_PW.Location = new System.Drawing.Point(42, 129);
            this.LB_DMS_Login_PW.Name = "LB_DMS_Login_PW";
            this.LB_DMS_Login_PW.Size = new System.Drawing.Size(72, 24);
            this.LB_DMS_Login_PW.TabIndex = 2;
            this.LB_DMS_Login_PW.Text = "密   碼 :";
            // 
            // DMS_Login_ID_tb
            // 
            this.DMS_Login_ID_tb.Location = new System.Drawing.Point(119, 79);
            this.DMS_Login_ID_tb.Name = "DMS_Login_ID_tb";
            this.DMS_Login_ID_tb.Size = new System.Drawing.Size(188, 33);
            this.DMS_Login_ID_tb.TabIndex = 2;
            // 
            // Login_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(398, 289);
            this.Controls.Add(this.DMS_Login_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login_main";
            this.Load += new System.EventHandler(this.Login_main_Load);
            this.DMS_Login_panel.ResumeLayout(false);
            this.DMS_Login_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LB_DMS_Login_ID;
        private System.Windows.Forms.Panel DMS_Login_panel;
        private System.Windows.Forms.Label LB_DMS_Login_PW;
        private System.Windows.Forms.TextBox DMS_Login_ID_tb;
        private System.Windows.Forms.ComboBox DMS_Login_ServerCB;
        private System.Windows.Forms.Label LB_DMS_Login_Server;
        private System.Windows.Forms.Button DMS_Login_Button;
        private System.Windows.Forms.TextBox DMS_Login_PWD_tb;
        private System.Windows.Forms.Button DMS_Login_Cancel;
    }
}