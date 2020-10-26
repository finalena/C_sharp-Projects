using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Practice.DataAnalysis
{
    public partial class Form1 : DockContent
    {
        /// <summary>
        /// 依序比對代碼資料連續相同者自動編碼的最大最小值，若只有單一值則最大最小值相同。
        /// 在將彙整完的資料以另外一個Gridview呈現
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            this.tabPage1.Text = "v1";
            this.tabPage2.Text = "v2";

            Load_v1();
            Load_v2();
        }

        private void Load_v1() 
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");

            dt.Rows.Add("M151");
            dt.Rows.Add("M151");
            dt.Rows.Add("A121");
            dt.Rows.Add("M151");
            dt.Rows.Add("B153");
            dt.Rows.Add("B153");
            dt.Rows.Add("B153");
            dt.Rows.Add("A121");

            this.dataGridView1.DataSource = dt;

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("id");
            dt2.Columns.Add("min");
            dt2.Columns.Add("max");

            int iSer = 0;
            int iTemp = 0;
            string sId = "";

            for (int intA = 0; intA < dt.Rows.Count; intA++)
            {
                if (iTemp == 0)
                {
                    sId = dt.Rows[intA]["id"].ToString();
                    dt2.Rows.Add(sId, intA + 1);
                }
                // 與指標相同的計算個數
                if (dt.Rows[intA]["id"].Equals(sId))
                {
                    iTemp++;
                    iSer++;
                }
                else
                {
                    dt2.Rows[dt2.Rows.Count - 1]["max"] = iSer;
                    iTemp = 0;
                    intA--;
                }
            }

            this.dataGridView2.DataSource = dt2;
        }

        private void Load_v2() 
        {
            string[] arr = { "M151", "M151", "M121", "M151", "B157", "B157", "B157", "A121" };
            CodeHelper obj = new CodeHelper();
            int index = 0;

            foreach (string code in arr)
            {
                obj.Add(code, ++index);
            }

            foreach (Info item in obj.ListItems)
            {
                this.textBox1.Text += item.ToString();
            }      
        }
    }

    class CodeHelper
    {
        public List<Info> ListItems = new List<Info>();

        public void Add(string code, int index)
        {
            if (ListItems.Count == 0)
            {
                AppendNewItem(code, index);
            }
            else
            {
                Info lastItem = ListItems[ListItems.Count - 1];
                if (string.Compare(lastItem.Code, code) == 0)
                {
                    lastItem.endIndex = index;
                }
                else
                {
                    AppendNewItem(code, index);
                }
            }
        }

        private void AppendNewItem(string code, int index)
        {
            Info item = new Info
            {
                Code = code,
                startIndex = index,
                endIndex = index
            };

            ListItems.Add(item);
        }
    }

    class Info
    {
        public string Code;
        public int startIndex, endIndex;

        public override string ToString()
        {
            return string.Format("Code={0}, from {1} to {2}" + Environment.NewLine, Code, startIndex, endIndex);
        }
    }
}
