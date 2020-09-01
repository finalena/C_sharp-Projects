using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Practice.ListViewControl
{
    public partial class ListViewControl : DockContent
    {
        ListViewItem lastSelectedItem = null;

        public ListViewControl()
        {
            InitializeComponent();

            IniTitle();

            this.chkAll.CheckedChanged += new EventHandler(chkAll_CheckedChanged);
            this.listView1.MouseMove += new MouseEventHandler(listView1_MouseMove);
            //this.listView1.ItemMouseHover += new ListViewItemMouseHoverEventHandler(listView1_ItemMouseHover);
        }

        /// <summary>響應慢的方法 </summary>
        private void listView1_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            if (lastSelectedItem != null)
            {
                lastSelectedItem.BackColor = Color.White;
            }
            e.Item.BackColor = Color.LightSeaGreen;
            lastSelectedItem = e.Item;
        }

        /// <summary>響應快的方法 </summary>
        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;
            ListViewItem OldItem = null;
            if (lv.Tag != null)
            {
                OldItem = (ListViewItem)lv.Tag;
            }
            
            //取得滑鼠所在的項目
            ListViewItem CurItem = lv.GetItemAt(e.X, e.Y);
            if (CurItem != null)
            {
                // 還原滑鼠上次所在項目的背景顏色
                if (OldItem != null && OldItem != CurItem)
                {
                    OldItem.BackColor = lv.BackColor;
                }
                CurItem.BackColor = Color.LightPink;
                lv.Tag = CurItem;
            }
            else
            {
                if (OldItem != null && OldItem.BackColor != lv.BackColor)
                {
                    OldItem.BackColor = lv.BackColor;
                }
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem objItem in this.listView1.Items)
            {
                objItem.Checked = ((CheckBox)sender).Checked;
            }
        }

        private void IniTitle() 
        {
            this.listView1.GridLines = true;
            this.listView1.FullRowSelect = true;
            this.listView1.View = View.Details;
            this.listView1.Scrollable = true;
            this.listView1.MultiSelect = false;
            this.listView1.CheckBoxes = true;

            this.listView1.Columns.Add("productName","產品名稱");
            this.listView1.Columns.Add("SN", "型號");
            this.listView1.Columns.Add("number","數量");
            this.listView1.Columns.Add("price", "價格");

            //添加內容
            for (int intA = 0; intA < 6; intA++)
            {
                ListViewItem objItem = new ListViewItem();
                objItem.SubItems.Clear();
                objItem.SubItems[0].Text = "產品" + intA.ToString();
                objItem.SubItems.Add(intA.ToString());
                objItem.SubItems.Add((intA + 8).ToString());
                objItem.SubItems.Add((intA * intA).ToString());

                this.listView1.Items.Add(objItem);
            }

            this.listView1.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.listView1.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
            this.listView1.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
            this.listView1.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize); 
        }
    }
}
