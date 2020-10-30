namespace Practice.HtmlAgilityPackTest
{
    partial class Form1
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
            this.lbUpdateDate = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvCht = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvLotto = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCht)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotto)).BeginInit();
            this.SuspendLayout();
            // 
            // lbUpdateDate
            // 
            this.lbUpdateDate.AutoSize = true;
            this.lbUpdateDate.Location = new System.Drawing.Point(22, 13);
            this.lbUpdateDate.Name = "lbUpdateDate";
            this.lbUpdateDate.Size = new System.Drawing.Size(61, 12);
            this.lbUpdateDate.TabIndex = 1;
            this.lbUpdateDate.Text = "[更新時間]";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(806, 392);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvCht);
            this.tabPage1.Controls.Add(this.lbUpdateDate);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(798, 366);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "期交所";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvCht
            // 
            this.dgvCht.AllowUserToAddRows = false;
            this.dgvCht.AllowUserToDeleteRows = false;
            this.dgvCht.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCht.Location = new System.Drawing.Point(24, 32);
            this.dgvCht.Name = "dgvCht";
            this.dgvCht.ReadOnly = true;
            this.dgvCht.RowTemplate.Height = 24;
            this.dgvCht.Size = new System.Drawing.Size(746, 328);
            this.dgvCht.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvLotto);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(798, 366);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "大樂透";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvLotto
            // 
            this.dgvLotto.AllowUserToAddRows = false;
            this.dgvLotto.AllowUserToDeleteRows = false;
            this.dgvLotto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLotto.Location = new System.Drawing.Point(24, 32);
            this.dgvLotto.Name = "dgvLotto";
            this.dgvLotto.ReadOnly = true;
            this.dgvLotto.RowTemplate.Height = 24;
            this.dgvLotto.Size = new System.Drawing.Size(746, 328);
            this.dgvLotto.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 409);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HtmlAgilityPack";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCht)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbUpdateDate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvCht;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvLotto;
    }
}

