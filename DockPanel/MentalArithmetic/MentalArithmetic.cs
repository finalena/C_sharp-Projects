using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Practice
{
    public partial class MentalArithmetic : DockContent
    {
        private int iTxtNum;
                
        public MentalArithmetic()
        {
            InitializeComponent();

            this.btnAdd.Click += new EventHandler(btnSubmit_Click);
            this.btnSubmit.Click +=new EventHandler(btnSubmit_Click);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (sender.Equals(this.btnAdd))
            {
                bool isNumber = int.TryParse(this.txtNum.Text,out iTxtNum);

                if (this.txtNum.Text.Length != 0 && isNumber)
                {
                    this.panel1.Controls.Clear();
                    this.panel1.AutoScroll = true;
                    AddControl(Math.Abs(iTxtNum));
                }
                else
	            {
                    MessageBox.Show("請輸入數值",this.Text);
	            }
            }
            else if (sender.Equals(this.btnSubmit))
            {
                for (int intA = 0; intA < iTxtNum; intA++)
                {
                    TextBox[] txtBox = new TextBox[3];
                    for (int intB = 0; intB < 3; intB++)
                    {
                        txtBox[intB] = ((TextBox)this.panel1.Controls.Find("txtBox" + intA.ToString(), true)[intB]);
                    }
                    Label label = ((Label)this.panel1.Controls.Find("lblResult" + Convert.ToString(intA), true)[0]);
                    int iQ1, iQ2, iAns;
                    bool bQ1 = int.TryParse(txtBox[0].Text, out iQ1);
                    bool bQ2 = int.TryParse(txtBox[1].Text, out iQ2);
                    bool bAns = int.TryParse(txtBox[2].Text, out iAns);
                    if (iQ1+iQ2 == iAns)
                    {
                        label.Text = "V";
                    }
                    else
                    {
                        label.Text = "X";
                    }
                }
                
            }
        }

        private void AddControl(int iTxtNum) 
        {
            Random rand = new Random();

            for (int intA = 0; intA < iTxtNum; intA++)
            {
                for (int intB = 0; intB < 3; intB++)
                {
                    TextBox txtBox = new TextBox();
                    txtBox.Location = new Point(10 + 70 * intB, intA * 30);
                    txtBox.Size = new Size(50, 50);
                    txtBox.Name = "txtBox" + intA.ToString();
                    txtBox.TextAlign = HorizontalAlignment.Center;

                    if (intB < 2)
                    {
                        txtBox.ReadOnly = true;
                        txtBox.Text = rand.Next(100).ToString();
                        txtBox.TabStop = false;
                    }
                    this.panel1.Controls.Add(txtBox);

                    Label label = new Label();
                    label.Location = new Point(60 + 70 * intB, intA * 30);
                    label.Size = new Size(20, 20);
                    label.TextAlign = ContentAlignment.MiddleCenter;

                    switch (intB)
                    {
                        case 0: label.Text = "+"; break;
                        case 1: label.Text = "="; break;
                        case 2: label.Name = "lblResult" + intA.ToString(); break;
                    }
                    this.panel1.Controls.Add(label);
                }            
            }
        }
    }
}
