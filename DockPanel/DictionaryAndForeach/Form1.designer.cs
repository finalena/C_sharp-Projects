namespace Practice.DictionaryAndForeach
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
            this.cmbNum = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtForeach = new System.Windows.Forms.TextBox();
            this.txtIEnumeraor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbNum
            // 
            this.cmbNum.FormattingEnabled = true;
            this.cmbNum.Location = new System.Drawing.Point(30, 59);
            this.cmbNum.Name = "cmbNum";
            this.cmbNum.Size = new System.Drawing.Size(121, 20);
            this.cmbNum.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "名字";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(202, 59);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 22);
            this.txtName.TabIndex = 4;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(355, 59);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 22);
            this.txtHeight.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "身高";
            // 
            // txtForeach
            // 
            this.txtForeach.Location = new System.Drawing.Point(42, 114);
            this.txtForeach.Multiline = true;
            this.txtForeach.Name = "txtForeach";
            this.txtForeach.Size = new System.Drawing.Size(176, 183);
            this.txtForeach.TabIndex = 9;
            // 
            // txtIEnumeraor
            // 
            this.txtIEnumeraor.Location = new System.Drawing.Point(255, 114);
            this.txtIEnumeraor.Multiline = true;
            this.txtIEnumeraor.Name = "txtIEnumeraor";
            this.txtIEnumeraor.Size = new System.Drawing.Size(176, 183);
            this.txtIEnumeraor.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 330);
            this.Controls.Add(this.txtIEnumeraor);
            this.Controls.Add(this.txtForeach);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbNum);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dictionary與foreach";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtForeach;
        private System.Windows.Forms.TextBox txtIEnumeraor;
    }
}

