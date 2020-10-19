namespace Practice.Practice2
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
            TLC.TLButton tlButton1 = new TLC.TLButton();
            TLC.TLCaption tlCaption1 = new TLC.TLCaption();
            TLC.TLCombo tlCombo1 = new TLC.TLCombo();
            TLC.TLButton tlButton2 = new TLC.TLButton();
            TLC.TLCaption tlCaption2 = new TLC.TLCaption();
            TLC.TLCombo tlCombo2 = new TLC.TLCombo();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFilePath = new TLC.TLText();
            this.btnUpload = new System.Windows.Forms.Button();
            this.txtDate = new TLC.TLText();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.txtFilePath);
            this.groupBox1.Controls.Add(this.btnUpload);
            this.groupBox1.Location = new System.Drawing.Point(12, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 52);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "請選擇檔案";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(344, 19);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(28, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // txtFilePath
            // 
            this.txtFilePath.BackColor2 = System.Drawing.Color.White;
            this.txtFilePath.BackColor3 = System.Drawing.Color.White;
            tlButton1.BackColor = System.Drawing.SystemColors.Control;
            tlButton1.Enabled = true;
            tlButton1.Font = new System.Drawing.Font("新細明體", 9F);
            tlButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            tlButton1.Text = "...";
            tlButton1.ToolTipText = "";
            tlButton1.Use = false;
            tlButton1.Width = 22;
            this.txtFilePath.Button = tlButton1;
            tlCaption1.Align = System.Drawing.ContentAlignment.TopLeft;
            tlCaption1.AutoSize = true;
            tlCaption1.BackColor = System.Drawing.SystemColors.Control;
            tlCaption1.Font = new System.Drawing.Font("細明體", 9F);
            tlCaption1.ForeColor = System.Drawing.SystemColors.ControlText;
            tlCaption1.Height = 20;
            tlCaption1.Left = 0;
            tlCaption1.Selected = false;
            tlCaption1.SelectedColor = System.Drawing.Color.Yellow;
            tlCaption1.Text = "";
            tlCaption1.ToolTipText = "";
            tlCaption1.Top = 0;
            tlCaption1.Use = true;
            tlCaption1.UseSelect = true;
            tlCaption1.Width = 20;
            this.txtFilePath.Caption = tlCaption1;
            this.txtFilePath.CheckCaption = "";
            this.txtFilePath.CheckChecked = false;
            tlCombo1.AutoComplete = true;
            tlCombo1.AutoDropDown = false;
            tlCombo1.DotIsValue = false;
            tlCombo1.InList = true;
            tlCombo1.OnlyDropDown = false;
            this.txtFilePath.ComboBox = tlCombo1;
            this.txtFilePath.ComboCode = "";
            this.txtFilePath.ComboText = "";
            this.txtFilePath.Enabled2 = true;
            this.txtFilePath.FieldCode = "";
            this.txtFilePath.FieldHelp = "";
            this.txtFilePath.FieldName = "";
            this.txtFilePath.FieldType = "";
            this.txtFilePath.ForeColor2 = System.Drawing.Color.Black;
            this.txtFilePath.ListSource = "";
            this.txtFilePath.Location = new System.Drawing.Point(7, 19);
            this.txtFilePath.Lock = false;
            this.txtFilePath.LockAll = false;
            this.txtFilePath.Mask = TLC.TLMaskDefine.AllowAll;
            this.txtFilePath.MaxLength = 0;
            this.txtFilePath.MultiLine = false;
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.PassDateErrorMessage = false;
            this.txtFilePath.PasswordChar = '\0';
            this.txtFilePath.SelectionLength = 0;
            this.txtFilePath.SelectionStart = 0;
            this.txtFilePath.ShowType = TLC.TLShowType.TextBox;
            this.txtFilePath.Size = new System.Drawing.Size(331, 26);
            this.txtFilePath.TabIndex = 2;
            this.txtFilePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFilePath.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtFilePath.UseBackColor3 = false;
            this.txtFilePath.Value = "";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(378, 20);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(59, 23);
            this.btnUpload.TabIndex = 4;
            this.btnUpload.Text = "上傳(&U)";
            this.btnUpload.UseVisualStyleBackColor = true;
            // 
            // txtDate
            // 
            this.txtDate.BackColor2 = System.Drawing.Color.White;
            this.txtDate.BackColor3 = System.Drawing.Color.White;
            tlButton2.BackColor = System.Drawing.SystemColors.Control;
            tlButton2.Enabled = true;
            tlButton2.Font = new System.Drawing.Font("新細明體", 9F);
            tlButton2.ForeColor = System.Drawing.SystemColors.ControlText;
            tlButton2.Text = "...";
            tlButton2.ToolTipText = "";
            tlButton2.Use = false;
            tlButton2.Width = 22;
            this.txtDate.Button = tlButton2;
            tlCaption2.Align = System.Drawing.ContentAlignment.TopLeft;
            tlCaption2.AutoSize = true;
            tlCaption2.BackColor = System.Drawing.SystemColors.Control;
            tlCaption2.Font = new System.Drawing.Font("細明體", 9F);
            tlCaption2.ForeColor = System.Drawing.SystemColors.ControlText;
            tlCaption2.Height = 20;
            tlCaption2.Left = 0;
            tlCaption2.Selected = false;
            tlCaption2.SelectedColor = System.Drawing.Color.Yellow;
            tlCaption2.Text = "日期";
            tlCaption2.ToolTipText = "";
            tlCaption2.Top = 0;
            tlCaption2.Use = true;
            tlCaption2.UseSelect = true;
            tlCaption2.Width = 20;
            this.txtDate.Caption = tlCaption2;
            this.txtDate.CheckCaption = "";
            this.txtDate.CheckChecked = false;
            tlCombo2.AutoComplete = true;
            tlCombo2.AutoDropDown = false;
            tlCombo2.DotIsValue = false;
            tlCombo2.InList = true;
            tlCombo2.OnlyDropDown = false;
            this.txtDate.ComboBox = tlCombo2;
            this.txtDate.ComboCode = "";
            this.txtDate.ComboText = "";
            this.txtDate.Enabled2 = true;
            this.txtDate.FieldCode = "";
            this.txtDate.FieldHelp = "";
            this.txtDate.FieldName = "";
            this.txtDate.FieldType = "";
            this.txtDate.ForeColor2 = System.Drawing.Color.Black;
            this.txtDate.ListSource = "";
            this.txtDate.Location = new System.Drawing.Point(19, 21);
            this.txtDate.Lock = false;
            this.txtDate.LockAll = false;
            this.txtDate.Mask = TLC.TLMaskDefine.AllowAll;
            this.txtDate.MaxLength = 0;
            this.txtDate.MultiLine = false;
            this.txtDate.Name = "txtDate";
            this.txtDate.PassDateErrorMessage = false;
            this.txtDate.PasswordChar = '\0';
            this.txtDate.SelectionLength = 0;
            this.txtDate.SelectionStart = 0;
            this.txtDate.ShowType = TLC.TLShowType.TextBox;
            this.txtDate.Size = new System.Drawing.Size(150, 26);
            this.txtDate.TabIndex = 1;
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDate.TextBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtDate.UseBackColor3 = false;
            this.txtDate.Value = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(17, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 11);
            this.label1.TabIndex = 7;
            this.label1.Text = "上傳位置:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Font = new System.Drawing.Font("新細明體", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.linkLabel1.Location = new System.Drawing.Point(75, 136);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(385, 47);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 185);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "上傳便當費用";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private TLC.TLText txtFilePath;
        private System.Windows.Forms.Button btnUpload;
        private TLC.TLText txtDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnBrowse;

    }
}

