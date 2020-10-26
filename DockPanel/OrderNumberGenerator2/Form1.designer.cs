namespace Practice.OrderNumberGenerator2
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
            this.btnNewNumber = new System.Windows.Forms.Button();
            this.cmbSerNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbZeroSet = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblshow = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFormat = new System.Windows.Forms.ComboBox();
            this.btnGetNumber = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewNumber
            // 
            this.btnNewNumber.Location = new System.Drawing.Point(34, 188);
            this.btnNewNumber.Name = "btnNewNumber";
            this.btnNewNumber.Size = new System.Drawing.Size(92, 23);
            this.btnNewNumber.TabIndex = 0;
            this.btnNewNumber.Text = "產生流水號(&S)";
            this.btnNewNumber.UseVisualStyleBackColor = true;
            // 
            // cmbSerNo
            // 
            this.cmbSerNo.FormattingEnabled = true;
            this.cmbSerNo.Location = new System.Drawing.Point(144, 62);
            this.cmbSerNo.Name = "cmbSerNo";
            this.cmbSerNo.Size = new System.Drawing.Size(121, 20);
            this.cmbSerNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "顯示幾碼的流水號";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "流水號何時歸零";
            // 
            // cmbZeroSet
            // 
            this.cmbZeroSet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbZeroSet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbZeroSet.FormattingEnabled = true;
            this.cmbZeroSet.Location = new System.Drawing.Point(144, 99);
            this.cmbZeroSet.Name = "cmbZeroSet";
            this.cmbZeroSet.Size = new System.Drawing.Size(121, 20);
            this.cmbZeroSet.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "最新的編碼";
            // 
            // lblshow
            // 
            this.lblshow.AutoSize = true;
            this.lblshow.Location = new System.Drawing.Point(142, 31);
            this.lblshow.Name = "lblshow";
            this.lblshow.Size = new System.Drawing.Size(11, 12);
            this.lblshow.TabIndex = 6;
            this.lblshow.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "傳回的格式";
            // 
            // cmbFormat
            // 
            this.cmbFormat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFormat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbFormat.FormattingEnabled = true;
            this.cmbFormat.Location = new System.Drawing.Point(144, 136);
            this.cmbFormat.Name = "cmbFormat";
            this.cmbFormat.Size = new System.Drawing.Size(121, 20);
            this.cmbFormat.TabIndex = 7;
            // 
            // btnGetNumber
            // 
            this.btnGetNumber.Location = new System.Drawing.Point(140, 188);
            this.btnGetNumber.Name = "btnGetNumber";
            this.btnGetNumber.Size = new System.Drawing.Size(125, 23);
            this.btnGetNumber.TabIndex = 9;
            this.btnGetNumber.Text = "查詢最新的流水號(&Q)";
            this.btnGetNumber.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 252);
            this.Controls.Add(this.btnGetNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbFormat);
            this.Controls.Add(this.lblshow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbZeroSet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSerNo);
            this.Controls.Add(this.btnNewNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "OrderNumberGenerator2";
            this.Text = "OrderNumberGenerator2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewNumber;
        private System.Windows.Forms.ComboBox cmbSerNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbZeroSet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblshow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbFormat;
        private System.Windows.Forms.Button btnGetNumber;
    }
}

