using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Practice.Indexer
{
    /// 輸入任意索引值，會帶出該索引對應的值，如果無對應值則為空白
    /// 資料來源: https://home.gamer.com.tw/creationDetail.php?sn=3808170
    public partial class Form1 : DockContent
    {
        public Form1()
        {
            InitializeComponent();

            this.btnSend.Click += new EventHandler(this.ButtonClick);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Collection<string> collection = new Collection<string>();

            for (int i = 0; i < 10; i++)
            {
                collection[i] = i.ToString();
            }

            this.lblResult.Text = this.txtSelect.Text;
            this.txtResult.Text = collection[int.Parse(this.txtSelect.Text)];
        }
    }

    class Collection<T> 
    {
        private T[] tArr = new T[100];
 
        public T this[int i]
        {
            get { return tArr[i]; }
            set { tArr[i] = value; }
        }

    }
}
