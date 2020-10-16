using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Practice.Practice1
{
    /// 計算列印頁數
    /// 來源: http://www.webapp.com.tw/EBook5/view.aspx?a=1&TreeNodeID=73&id=988
    public partial class Form1 : DockContent
    {
        List<Section> SectionList = new List<Section>();

        public Form1()
        {
            InitializeComponent();
            
            this.btnSubmit.Click += new EventHandler(Button_click);
            this.btnClear.Click += new EventHandler(Button_click);
        }

        private void Button_click(object sender, EventArgs e)
        {
            if (sender.Equals(this.btnSubmit))
            {
                int iStart = 0;
                int iEnd = 0;
                if (!int.TryParse(this.txtStart.Text, out iStart) || !int.TryParse(this.txtEnd.Text, out iEnd))
                {
                    MessageBox.Show("請輸入數值", this.Text);
                    return; 
                }

                if (iStart <= 0 || iEnd <= 0)
                {
                    MessageBox.Show("頁數不可小於0", this.Text);
                    return;
                }

                Section obj = new Section(iStart, iEnd);
                this.txtResult.Text = obj.ToString();

                for (int i = SectionList.Count-1 ; i >= 0 ; i--)
                {
                    Section check = SectionList[i];
                    if (check.MustRemove(ref obj))
                    {
                        SectionList.Remove(check);
                    }
                }

                SectionList.Add(new Section(obj.Start, obj.End));
                ShowResult();
            }
            else if (sender.Equals(this.btnClear))
            {
                SectionList.Clear();
                this.txtStart.Text = "";
                this.txtEnd.Text = "";
                this.txtResult.Text = "";
            }
        }

        private void ShowResult() 
        {
            SectionList.Sort();

            StringBuilder sb = new StringBuilder();
            foreach (Section item in SectionList)
            {
                sb.Append(item.ToString() + ",");
            }
            MessageBox.Show(sb.ToString(), this.Text);
        }
    }

    class Section : IComparable
    {
        private int iStart;
        private int iEnd;       

        public int Start
        {
            get { return iStart; }
            set 
            {
                if (value % 2 == 0)
                    iStart = value - 1;
                else
                    iStart = value; 
            }
        }

        public int End 
        {
            get { return iEnd; }
            set 
            {
                if (value % 2 == 0)
                    iEnd = value;
                else
                    iEnd = value + 1;
            }
        }
            
        public Section(int iStart, int iEnd) 
        {
            int iStartValue = Math.Min(iStart, iEnd);
            int iEndValue = Math.Max(iStart, iEnd);

            this.Start = iStartValue;
            this.End = iEndValue;
        }

        public bool MustRemove(ref Section obj)
        {
            if (obj.End + 1 < this.Start || obj.Start > this.End + 1)
            {
                return false;
            }
            else
            {//二者有重疊, 變動target值後傳回true
                obj.Start = Math.Min(obj.Start, this.Start);
                obj.End = Math.Max(obj.End, this.End);

                return true;
            }
        }

        public int CompareTo(object obj) 
        {
            return this.Start.CompareTo(((Section)obj).Start);
        }
        
        public override string ToString()
        {
            return Start + "-" + End;
        }
    }
}
