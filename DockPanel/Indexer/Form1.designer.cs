namespace Practice.Indexer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSelect = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "All Number :  0 1 2 3 4 5 6 7 8 9 ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select Number ";
            // 
            // txtSelect
            // 
            this.txtSelect.Location = new System.Drawing.Point(125, 59);
            this.txtSelect.Name = "txtSelect";
            this.txtSelect.Size = new System.Drawing.Size(93, 22);
            this.txtSelect.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(234, 59);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(69, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Member";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(80, 113);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(13, 12);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "[]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(107, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "is";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(125, 111);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(93, 22);
            this.txtResult.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 166);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Indexer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSelect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtResult;
    }
}

