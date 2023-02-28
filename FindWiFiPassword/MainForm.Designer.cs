namespace FindWiFiPassword
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.WifiList = new System.Windows.Forms.ListBox();
            this.WifiGroupBox = new System.Windows.Forms.GroupBox();
            this.WifiInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.WifiInfo = new System.Windows.Forms.TextBox();
            this.WifiGroupBox.SuspendLayout();
            this.WifiInfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // WifiList
            // 
            this.WifiList.FormattingEnabled = true;
            this.WifiList.ItemHeight = 18;
            this.WifiList.Location = new System.Drawing.Point(6, 31);
            this.WifiList.Name = "WifiList";
            this.WifiList.Size = new System.Drawing.Size(298, 328);
            this.WifiList.TabIndex = 0;
            this.WifiList.Click += new System.EventHandler(this.WifiList_Click);
            // 
            // WifiGroupBox
            // 
            this.WifiGroupBox.Controls.Add(this.WifiList);
            this.WifiGroupBox.Location = new System.Drawing.Point(12, 12);
            this.WifiGroupBox.Name = "WifiGroupBox";
            this.WifiGroupBox.Size = new System.Drawing.Size(310, 370);
            this.WifiGroupBox.TabIndex = 1;
            this.WifiGroupBox.TabStop = false;
            this.WifiGroupBox.Text = "WiFi列表";
            // 
            // WifiInfoGroupBox
            // 
            this.WifiInfoGroupBox.Controls.Add(this.WifiInfo);
            this.WifiInfoGroupBox.Location = new System.Drawing.Point(346, 12);
            this.WifiInfoGroupBox.Name = "WifiInfoGroupBox";
            this.WifiInfoGroupBox.Size = new System.Drawing.Size(420, 370);
            this.WifiInfoGroupBox.TabIndex = 2;
            this.WifiInfoGroupBox.TabStop = false;
            this.WifiInfoGroupBox.Text = "WiFi信息";
            // 
            // WifiInfo
            // 
            this.WifiInfo.Location = new System.Drawing.Point(6, 31);
            this.WifiInfo.Multiline = true;
            this.WifiInfo.Name = "WifiInfo";
            this.WifiInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.WifiInfo.Size = new System.Drawing.Size(408, 328);
            this.WifiInfo.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 394);
            this.Controls.Add(this.WifiInfoGroupBox);
            this.Controls.Add(this.WifiGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查找本机连接过的WIFI密码";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.WifiGroupBox.ResumeLayout(false);
            this.WifiInfoGroupBox.ResumeLayout(false);
            this.WifiInfoGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox WifiList;
        private System.Windows.Forms.GroupBox WifiGroupBox;
        private System.Windows.Forms.GroupBox WifiInfoGroupBox;
        private System.Windows.Forms.TextBox WifiInfo;
    }
}

