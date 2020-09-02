using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Practice.RestrictCharactersInDataGridView
{
    /// 限制 DataGridView 輸入字元 
    /// 資料來源: https://dotblogs.com.tw/yc421206/2010/10/15/18370 
    public partial class Form1 : DockContent
    {
        public Form1()
        {
            InitializeComponent();
            IniTitle();

            this.dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
            this.dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
        }

        private void IniTitle() 
        {
            string[] sAData = new string[] { "ID", "Nmae", "Phone" };
            DataTable dt = new DataTable();

            foreach (string item in sAData)
            {
                DataColumn column = new DataColumn();
                column.Caption = item;
                column.ColumnName = item;
                dt.Columns.Add(column);
            }

            dt.Rows.Add("1", "Coco", "12345");
            this.dataGridView1.DataSource = dt;
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);

        }

        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            int value = (int)key;
            
            if (value >= 48 && value <= 57 || value == 8 || value == 43 || value == 45 || value == 46)
                e.Handled = false;
            else
                e.Handled = true;   // 表示已處理事件
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (e.RowIndex == dgv.RowCount - 1)
                return;

            string sValue = string.Empty;
            float fData = 0;
            switch (e.ColumnIndex)
            {
                case 0:
                    sValue = dgv.CurrentCell.Value.ToString();
                    if (sValue.Trim() == "")
                    {
                        dgv.CurrentCell.ErrorText = "欄位不可為空";
                        break;
                    }
                    break;
            }
        }
    }
}
