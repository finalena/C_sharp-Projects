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
    /// 委派
    /// 資料來源: http://rfid.ctu.edu.tw/rueychi/CCA/1071Arduino/6_%E5%A7%94%E6%B4%BE%E8%88%87%E5%9F%B7%E8%A1%8C%E7%B7%92.pdf
    public partial class Form1 : DockContent
    {
        public delegate void SendValueDelegate(string value);
        public event SendValueDelegate SendValue;

        public Form1()
        {
            InitializeComponent();
                
            this.button1.Click += new EventHandler(button1_Click);
        }

        // 事件觸發後委派所要執行的方法
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            // 綁定指定的委派事件
            // 將我們的function當成參數，傳到另一個function(ReturnValueCallback)來執行
            // Form2 傳 Form1
            form2.ReturnValueCallback += new Form2.ReturnValueDelegate(this.SetReturnValueCallBackFun);
            // Form1 傳 Form2
            this.SendValue += new SendValueDelegate(form2.ReceiveValueCallBack);
            this.SendValue(this.textBox1.Text);
            form2.Show();
        }

        private void SetReturnValueCallBackFun(string value) 
        {
            this.textBox1.Text = value;
        }
    }
}
