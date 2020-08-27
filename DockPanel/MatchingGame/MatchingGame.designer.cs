namespace Practice
{
    partial class MatchingGame
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStatus = new System.Windows.Forms.StatusStrip();
            this.lblPlayTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSteps = new System.Windows.Forms.ToolStripStatusLabel();
            this.mmuMain = new System.Windows.Forms.MenuStrip();
            this.mnuGame = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStatus.SuspendLayout();
            this.mmuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStatus
            // 
            this.menuStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblPlayTime,
            this.lblSteps});
            this.menuStatus.Location = new System.Drawing.Point(0, 665);
            this.menuStatus.Name = "menuStatus";
            this.menuStatus.Size = new System.Drawing.Size(694, 22);
            this.menuStatus.SizingGrip = false;
            this.menuStatus.TabIndex = 6;
            // 
            // lblPlayTime
            // 
            this.lblPlayTime.Name = "lblPlayTime";
            this.lblPlayTime.Size = new System.Drawing.Size(339, 17);
            this.lblPlayTime.Spring = true;
            this.lblPlayTime.Text = "請先按 [開始] 進行遊戲";
            this.lblPlayTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSteps
            // 
            this.lblSteps.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.lblSteps.Name = "lblSteps";
            this.lblSteps.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSteps.Size = new System.Drawing.Size(339, 17);
            this.lblSteps.Spring = true;
            this.lblSteps.Text = "翻牌次數 0 次";
            this.lblSteps.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mmuMain
            // 
            this.mmuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGame});
            this.mmuMain.Location = new System.Drawing.Point(0, 0);
            this.mmuMain.Name = "mmuMain";
            this.mmuMain.Size = new System.Drawing.Size(694, 24);
            this.mmuMain.TabIndex = 7;
            this.mmuMain.Text = "menuStrip1";
            // 
            // mnuGame
            // 
            this.mnuGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStart,
            this.mnuExit});
            this.mnuGame.Name = "mnuGame";
            this.mnuGame.Size = new System.Drawing.Size(61, 20);
            this.mnuGame.Text = "開始(&G)";
            // 
            // mnuStart
            // 
            this.mnuStart.Name = "mnuStart";
            this.mnuStart.Size = new System.Drawing.Size(152, 22);
            this.mnuStart.Text = "開始(&S)";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(152, 22);
            this.mnuExit.Text = "結束(&E)";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 635);
            this.panel1.TabIndex = 8;
            // 
            // MatchingGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(694, 687);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStatus);
            this.Controls.Add(this.mmuMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.mmuMain;
            this.Name = "MatchingGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "翻牌記憶遊戲";
            this.Text = "翻牌記憶遊戲";
            this.menuStatus.ResumeLayout(false);
            this.menuStatus.PerformLayout();
            this.mmuMain.ResumeLayout(false);
            this.mmuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip menuStatus;
        private System.Windows.Forms.MenuStrip mmuMain;
        private System.Windows.Forms.ToolStripStatusLabel lblPlayTime;
        private System.Windows.Forms.ToolStripStatusLabel lblSteps;
        private System.Windows.Forms.ToolStripMenuItem mnuGame;
        private System.Windows.Forms.ToolStripMenuItem mnuStart;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.Panel panel1;
    }
}

