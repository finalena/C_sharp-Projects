namespace Practice.MatchingGame
{
    partial class Option
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
            this.grpSpace = new System.Windows.Forms.GroupBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.lblSleep2 = new System.Windows.Forms.Label();
            this.lblStep = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblSleep = new System.Windows.Forms.Label();
            this.chkAdvance = new System.Windows.Forms.CheckBox();
            this.chkStep = new System.Windows.Forms.CheckBox();
            this.chkTime = new System.Windows.Forms.CheckBox();
            this.numSleep = new System.Windows.Forms.NumericUpDown();
            this.numStep = new System.Windows.Forms.NumericUpDown();
            this.numTime = new System.Windows.Forms.NumericUpDown();
            this.chkClear = new System.Windows.Forms.CheckBox();
            this.grpSpace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            this.grpOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSleep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSpace
            // 
            this.grpSpace.Controls.Add(this.Label2);
            this.grpSpace.Controls.Add(this.numY);
            this.grpSpace.Controls.Add(this.numX);
            this.grpSpace.Controls.Add(this.Label1);
            this.grpSpace.Location = new System.Drawing.Point(12, 12);
            this.grpSpace.Name = "grpSpace";
            this.grpSpace.Size = new System.Drawing.Size(190, 50);
            this.grpSpace.TabIndex = 1;
            this.grpSpace.TabStop = false;
            this.grpSpace.Text = "版面大小";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(83, 20);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(17, 12);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "寬";
            // 
            // numY
            // 
            this.numY.Location = new System.Drawing.Point(106, 18);
            this.numY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(39, 22);
            this.numY.TabIndex = 1;
            this.numY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numY.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // numX
            // 
            this.numX.Location = new System.Drawing.Point(29, 18);
            this.numX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(39, 22);
            this.numX.TabIndex = 0;
            this.numX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numX.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(6, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(17, 12);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "長";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(116, 250);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnStartGame
            // 
            this.btnStartGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStartGame.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnStartGame.Location = new System.Drawing.Point(12, 250);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(85, 23);
            this.btnStartGame.TabIndex = 0;
            this.btnStartGame.Text = "確定(&O)";
            this.btnStartGame.UseVisualStyleBackColor = true;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.lblSleep2);
            this.grpOption.Controls.Add(this.lblStep);
            this.grpOption.Controls.Add(this.lblTime);
            this.grpOption.Controls.Add(this.lblSleep);
            this.grpOption.Controls.Add(this.chkClear);
            this.grpOption.Controls.Add(this.chkAdvance);
            this.grpOption.Controls.Add(this.chkStep);
            this.grpOption.Controls.Add(this.chkTime);
            this.grpOption.Controls.Add(this.numSleep);
            this.grpOption.Controls.Add(this.numStep);
            this.grpOption.Controls.Add(this.numTime);
            this.grpOption.Location = new System.Drawing.Point(11, 71);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(190, 165);
            this.grpOption.TabIndex = 6;
            this.grpOption.TabStop = false;
            this.grpOption.Text = "遊戲選項";
            // 
            // lblSleep2
            // 
            this.lblSleep2.AutoSize = true;
            this.lblSleep2.Location = new System.Drawing.Point(167, 133);
            this.lblSleep2.Name = "lblSleep2";
            this.lblSleep2.Size = new System.Drawing.Size(17, 12);
            this.lblSleep2.TabIndex = 10;
            this.lblSleep2.Text = "秒";
            // 
            // lblStep
            // 
            this.lblStep.AutoSize = true;
            this.lblStep.Location = new System.Drawing.Point(167, 50);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(17, 12);
            this.lblStep.TabIndex = 9;
            this.lblStep.Text = "次";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(167, 22);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(17, 12);
            this.lblTime.TabIndex = 8;
            this.lblTime.Text = "秒";
            // 
            // lblSleep
            // 
            this.lblSleep.AutoSize = true;
            this.lblSleep.Location = new System.Drawing.Point(6, 133);
            this.lblSleep.Name = "lblSleep";
            this.lblSleep.Size = new System.Drawing.Size(101, 12);
            this.lblSleep.TabIndex = 7;
            this.lblSleep.Text = "翻牌錯誤畫面暫留";
            // 
            // chkAdvance
            // 
            this.chkAdvance.AutoSize = true;
            this.chkAdvance.Location = new System.Drawing.Point(8, 105);
            this.chkAdvance.Name = "chkAdvance";
            this.chkAdvance.Size = new System.Drawing.Size(72, 16);
            this.chkAdvance.TabIndex = 6;
            this.chkAdvance.Text = "高手模式";
            this.chkAdvance.UseVisualStyleBackColor = true;
            // 
            // chkStep
            // 
            this.chkStep.AutoSize = true;
            this.chkStep.Location = new System.Drawing.Point(8, 49);
            this.chkStep.Name = "chkStep";
            this.chkStep.Size = new System.Drawing.Size(96, 16);
            this.chkStep.TabIndex = 4;
            this.chkStep.Text = "限定翻牌次數";
            this.chkStep.UseVisualStyleBackColor = true;
            // 
            // chkTime
            // 
            this.chkTime.AutoSize = true;
            this.chkTime.Location = new System.Drawing.Point(8, 21);
            this.chkTime.Name = "chkTime";
            this.chkTime.Size = new System.Drawing.Size(96, 16);
            this.chkTime.TabIndex = 3;
            this.chkTime.Text = "限定完成時間";
            this.chkTime.UseVisualStyleBackColor = true;
            // 
            // numSleep
            // 
            this.numSleep.DecimalPlaces = 1;
            this.numSleep.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numSleep.Location = new System.Drawing.Point(110, 131);
            this.numSleep.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSleep.Name = "numSleep";
            this.numSleep.Size = new System.Drawing.Size(51, 22);
            this.numSleep.TabIndex = 2;
            this.numSleep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSleep.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // numStep
            // 
            this.numStep.Location = new System.Drawing.Point(110, 48);
            this.numStep.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStep.Name = "numStep";
            this.numStep.Size = new System.Drawing.Size(51, 22);
            this.numStep.TabIndex = 1;
            this.numStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numStep.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // numTime
            // 
            this.numTime.Location = new System.Drawing.Point(110, 20);
            this.numTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTime.Name = "numTime";
            this.numTime.Size = new System.Drawing.Size(51, 22);
            this.numTime.TabIndex = 0;
            this.numTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTime.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // chkClear
            // 
            this.chkClear.AutoSize = true;
            this.chkClear.Location = new System.Drawing.Point(8, 77);
            this.chkClear.Name = "chkClear";
            this.chkClear.Size = new System.Drawing.Size(132, 16);
            this.chkClear.TabIndex = 5;
            this.chkClear.Text = "翻牌成功後消掉牌面";
            this.chkClear.UseVisualStyleBackColor = true;
            // 
            // Option
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 285);
            this.Controls.Add(this.grpOption);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpSpace);
            this.Controls.Add(this.btnStartGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Option";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "遊戲設定";
            this.grpSpace.ResumeLayout(false);
            this.grpSpace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSleep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox grpSpace;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.NumericUpDown numY;
        internal System.Windows.Forms.NumericUpDown numX;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnStartGame;
        internal System.Windows.Forms.GroupBox grpOption;
        internal System.Windows.Forms.Label lblSleep2;
        internal System.Windows.Forms.Label lblStep;
        internal System.Windows.Forms.Label lblTime;
        internal System.Windows.Forms.Label lblSleep;
        internal System.Windows.Forms.CheckBox chkAdvance;
        internal System.Windows.Forms.CheckBox chkStep;
        internal System.Windows.Forms.CheckBox chkTime;
        internal System.Windows.Forms.NumericUpDown numSleep;
        internal System.Windows.Forms.NumericUpDown numStep;
        internal System.Windows.Forms.NumericUpDown numTime;
        internal System.Windows.Forms.CheckBox chkClear;
    }
}