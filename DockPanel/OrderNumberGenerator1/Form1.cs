using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using WeifenLuo.WinFormsUI.Docking;
using System.Configuration;

namespace Practice.OrderNumberGenerator1
{
    /// 訂單編號產生器(1)
    /// 題目來源: http://www.webapp.com.tw/EBook5/view.aspx?a=1&TreeNodeID=73&id=248
    /// 訂單編號的規則是 yyyyMM9999
    public partial class Form1 : DockContent
    {
        OrderNumberGenerator obj;
            
        public Form1()
        {
            InitializeComponent();
            
            obj = new OrderNumberGenerator();
            this.btnAdd.Click += new EventHandler(Button_click);
            UpdatelblOrder();
        }

        private void Button_click(object sender, EventArgs e)
        {
            obj.InsertInto();
            MessageBox.Show("新增一個訂單編號 : " + obj.GetNumber().ToString());
            UpdatelblOrder();
        }

        private void UpdatelblOrder() 
        {
            this.lblOrder.Text = "當月最新的訂單編號 : " + obj.GetNumber().ToString();
        }
    }

    class OrderNumberGenerator 
    {
        int iDateDefult = Convert.ToInt32(DateTime.Now.ToString("yyyyMM"));
        int iLatestNum;
        OleDbConnection conn;

        public OrderNumberGenerator() 
        {
            string dbPath = ConfigurationManager.AppSettings["Practice.DefaultPath.Setting"].ToString() + @"\OrderNumberGenerator1\OrderNumber1.accdb;";
            string ConnDB = @"Provider=Microsoft.ACE.Oledb.12.0 ;Data Source =" + dbPath + "Persist Security Info=True";
            conn = new OleDbConnection(ConnDB);
        }

        public int GetNumber()
        {
            OleDbCommand cmd = new OleDbCommand("Select iif(IsNull(Max(order_no)), 0, Max(order_no)) From OrderHead1 Where order_no like '" + iDateDefult + "%'", conn);
            conn.Open();
            iLatestNum = (int)cmd.ExecuteScalar();
            cmd.Cancel();
            conn.Close();
    
            return iLatestNum;
        }

        public void InsertInto() 
        {
            OleDbCommand cmd = new OleDbCommand("Insert Into OrderHead1(order_no) Values(?)", conn);
            if (iLatestNum == 0)
                cmd.Parameters.AddWithValue("order_no", iDateDefult + "0001");
            else
                cmd.Parameters.AddWithValue("order_no", iLatestNum + 1);

            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Cancel();
            conn.Close();
        }
    }
}
