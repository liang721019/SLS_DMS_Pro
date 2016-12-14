namespace DMS_ii
{
    partial class DMS_main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件管理ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.需求單查詢ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.其他ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件管理ToolStripMenuItem,
            this.其他ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1084, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件管理ToolStripMenuItem
            // 
            this.文件管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件管理ToolStripMenuItem1,
            this.需求單查詢ToolStripMenuItem});
            this.文件管理ToolStripMenuItem.Name = "文件管理ToolStripMenuItem";
            this.文件管理ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.文件管理ToolStripMenuItem.Text = "功能";
            // 
            // 文件管理ToolStripMenuItem1
            // 
            this.文件管理ToolStripMenuItem1.Name = "文件管理ToolStripMenuItem1";
            this.文件管理ToolStripMenuItem1.Size = new System.Drawing.Size(174, 24);
            this.文件管理ToolStripMenuItem1.Text = "文件管理查詢";
            this.文件管理ToolStripMenuItem1.Click += new System.EventHandler(this.文件管理ToolStripMenuItem1_Click);
            // 
            // 需求單查詢ToolStripMenuItem
            // 
            this.需求單查詢ToolStripMenuItem.Name = "需求單查詢ToolStripMenuItem";
            this.需求單查詢ToolStripMenuItem.Size = new System.Drawing.Size(174, 24);
            this.需求單查詢ToolStripMenuItem.Text = "需求單查詢";
            this.需求單查詢ToolStripMenuItem.Click += new System.EventHandler(this.需求單查詢ToolStripMenuItem_Click);
            // 
            // 其他ToolStripMenuItem
            // 
            this.其他ToolStripMenuItem.Name = "其他ToolStripMenuItem";
            this.其他ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.其他ToolStripMenuItem.Text = "其他";
            // 
            // DMS_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1084, 762);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DMS_main";
            this.Text = "DMS_main";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件管理ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 需求單查詢ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 其他ToolStripMenuItem;
    }
}