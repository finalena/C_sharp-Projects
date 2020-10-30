using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Practice.Practice4
{
    /// 統計字串出現的次數
    /// 參考資料: http://www.webapp.com.tw/EBook5/view.aspx?a=1&TreeNodeID=72&id=252
    public partial class Form1 : DockContent
    {
        public Form1()
        {
            InitializeComponent();

            string[] sArrDefult = { "台新", "台新", "金控", "１２月", "３日", "將召開", "股東", "臨時會", "進行", "董監", "改選", "。" };
            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach (string item in sArrDefult)
            {
                if (dic.ContainsKey(item)) 
                {
                    dic[item]++;
                }
                else
                {
                    dic.Add(item, 1);
                }
            }

            ShowAllInDictionary(dic);
            ShowAllInIEnumerator(dic);
        }

        private void ShowAllInDictionary(Dictionary<string,int> dic) 
        {
            foreach (KeyValuePair<string,int> item in dic)
            {
                this.textBox1.Text += item.Key + " " + item.Value + Environment.NewLine;
            }
        }

        private void ShowAllInIEnumerator(Dictionary<string, int> dic) 
        {
            IEnumerator<KeyValuePair<string, int>> enumerator = dic.GetEnumerator();
            while (enumerator.MoveNext())
            {
                KeyValuePair<string, int> item = enumerator.Current;
                this.textBox2.Text += item.Key + " " + item.Value + Environment.NewLine;
            }
        }
    }
}
