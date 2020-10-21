using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Practice.FormTransfer
{
    public partial class Form2 : DockContent
    {
        // 宣告委派
        public delegate void ReturnValueDelegate(string value);
        // 宣告委派事件
        public event ReturnValueDelegate ReturnValueCallback;

        public Form2()
        {
            InitializeComponent();

            this.button1.Click += new EventHandler(button1_Click);
        }

        public void ReceiveValueCallBack(string value) 
        {
            this.textBox1.Text = value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReturnValueCallback(this.textBox1.Text);    
        }

    }
}
