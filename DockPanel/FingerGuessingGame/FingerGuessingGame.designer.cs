namespace Practice
{
    partial class FingerGuessingGame
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.btnJiandao = new System.Windows.Forms.Button();
            this.btnShitou = new System.Windows.Forms.Button();
            this.btnBu = new System.Windows.Forms.Button();
            this.lblPC = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "玩家:";
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Location = new System.Drawing.Point(87, 27);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(14, 12);
            this.lblPlayer.TabIndex = 1;
            this.lblPlayer.Text = "...";
            // 
            // btnJiandao
            // 
            this.btnJiandao.Location = new System.Drawing.Point(36, 191);
            this.btnJiandao.Name = "btnJiandao";
            this.btnJiandao.Size = new System.Drawing.Size(75, 23);
            this.btnJiandao.TabIndex = 2;
            this.btnJiandao.Text = "剪刀";
            this.btnJiandao.UseVisualStyleBackColor = true;
            // 
            // btnShitou
            // 
            this.btnShitou.Location = new System.Drawing.Point(150, 191);
            this.btnShitou.Name = "btnShitou";
            this.btnShitou.Size = new System.Drawing.Size(75, 23);
            this.btnShitou.TabIndex = 3;
            this.btnShitou.Text = "石頭";
            this.btnShitou.UseVisualStyleBackColor = true;
            // 
            // btnBu
            // 
            this.btnBu.Location = new System.Drawing.Point(260, 191);
            this.btnBu.Name = "btnBu";
            this.btnBu.Size = new System.Drawing.Size(75, 23);
            this.btnBu.TabIndex = 4;
            this.btnBu.Text = "布";
            this.btnBu.UseVisualStyleBackColor = true;
            // 
            // lblPC
            // 
            this.lblPC.AutoSize = true;
            this.lblPC.Location = new System.Drawing.Point(302, 27);
            this.lblPC.Name = "lblPC";
            this.lblPC.Size = new System.Drawing.Size(14, 12);
            this.lblPC.TabIndex = 6;
            this.lblPC.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "電腦:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(170, 96);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(29, 12);
            this.lblResult.TabIndex = 7;
            this.lblResult.Text = "出拳";
            // 
            // FingerGuessingGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 233);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblPC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBu);
            this.Controls.Add(this.btnShitou);
            this.Controls.Add(this.btnJiandao);
            this.Controls.Add(this.lblPlayer);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FingerGuessingGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "猜拳遊戲";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.Button btnJiandao;
        private System.Windows.Forms.Button btnShitou;
        private System.Windows.Forms.Button btnBu;
        private System.Windows.Forms.Label lblPC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblResult;
    }
}

