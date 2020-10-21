namespace Practice.Print_form
{
    partial class frmPrePrint
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.chkName = new System.Windows.Forms.CheckBox();
            this.chkPhone = new System.Windows.Forms.CheckBox();
            this.chkBirthday = new System.Windows.Forms.CheckBox();
            this.chkAddress = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "勾選列印清單";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(85, 95);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "確定(&S)";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(199, 95);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "離開(&E)";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // chkName
            // 
            this.chkName.AutoSize = true;
            this.chkName.Location = new System.Drawing.Point(37, 48);
            this.chkName.Name = "chkName";
            this.chkName.Size = new System.Drawing.Size(48, 16);
            this.chkName.TabIndex = 3;
            this.chkName.Text = "姓名";
            this.chkName.UseVisualStyleBackColor = true;
            // 
            // chkPhone
            // 
            this.chkPhone.AutoSize = true;
            this.chkPhone.Location = new System.Drawing.Point(120, 48);
            this.chkPhone.Name = "chkPhone";
            this.chkPhone.Size = new System.Drawing.Size(48, 16);
            this.chkPhone.TabIndex = 4;
            this.chkPhone.Text = "電話";
            this.chkPhone.UseVisualStyleBackColor = true;
            // 
            // chkBirthday
            // 
            this.chkBirthday.AutoSize = true;
            this.chkBirthday.Location = new System.Drawing.Point(203, 48);
            this.chkBirthday.Name = "chkBirthday";
            this.chkBirthday.Size = new System.Drawing.Size(48, 16);
            this.chkBirthday.TabIndex = 5;
            this.chkBirthday.Text = "生日";
            this.chkBirthday.UseVisualStyleBackColor = true;
            // 
            // chkAddress
            // 
            this.chkAddress.AutoSize = true;
            this.chkAddress.Location = new System.Drawing.Point(286, 48);
            this.chkAddress.Name = "chkAddress";
            this.chkAddress.Size = new System.Drawing.Size(48, 16);
            this.chkAddress.TabIndex = 6;
            this.chkAddress.Text = "地址";
            this.chkAddress.UseVisualStyleBackColor = true;
            // 
            // frmPrePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 143);
            this.Controls.Add(this.chkAddress);
            this.Controls.Add(this.chkBirthday);
            this.Controls.Add(this.chkPhone);
            this.Controls.Add(this.chkName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmPrePrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "勾選列印清單";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox chkName;
        private System.Windows.Forms.CheckBox chkPhone;
        private System.Windows.Forms.CheckBox chkBirthday;
        private System.Windows.Forms.CheckBox chkAddress;
    }
}