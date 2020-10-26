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

namespace Practice.OrderNumberGenerator2
{
    /// 訂單編號產生器2
    /// 題目來源: http://www.webapp.com.tw/EBook5/view.aspx?a=1&TreeNodeID=73&id=249
    public partial class Form1 : DockContent
    {
        OrderNumberGenerator obj;

        public Form1()
        {
            InitializeComponent();

            this.cmbSerNo.Items.AddRange(new object[] { "1", "2", "3", "4" });
            this.cmbSerNo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSerNo.SelectedIndex = 2;
            this.cmbZeroSet.Items.AddRange(new object[] { "每月", "每年" });
            this.cmbZeroSet.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbZeroSet.SelectedIndex = 0;
            this.cmbFormat.Items.AddRange(new object[] {"yyyyMMSN","yyyy-MM-SN","yyyy/MM/SN","yyyySN"});
            this.cmbFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFormat.SelectedIndex = 0;
            
            obj = new OrderNumberGenerator();

            this.btnNewNumber.Click += new EventHandler(Button_click);
            this.btnGetNumber.Click += new EventHandler(Button_click);
        }

        private void Button_click(object sender, EventArgs e)
        {
            obj.LengthofSN = int.Parse(this.cmbSerNo.Text);
            obj.Rule = this.cmbZeroSet.Text;
            obj.Format = this.cmbFormat.Text;

            if (sender.Equals(this.btnNewNumber))
            {
                if (!obj.InsertDB())
                {
                    MessageBox.Show("更新資料庫失敗", this.Text);
                    return;
                }
                this.lblshow.Text = obj.GetNumber();
            }
            else if (sender.Equals(this.btnGetNumber))
            {
                string sLastestNum = obj.GetNumber();
                if (sLastestNum == "null")
                {
                    MessageBox.Show("所選的格式無流水號", this.Text);
                }
                else
                {
                    MessageBox.Show(sLastestNum, this.Text);
                }
                this.lblshow.Text = sLastestNum;
            }
        }
    }

    class DB
    {
        /// <summary>連線字串</summary>
        private static string dbPath = ConfigurationManager.AppSettings["Practice.DefaultPath.Setting"].ToString() + @"OrderNumberGenerator2\OrderNumber2.accdb;";
        private static string connDB = @"Provider=Microsoft.ACE.Oledb.12.0 ;Data Source =" + dbPath + @"Persist Security Info=True";

        public static string GetData(string sSql)
        {
            string sLatestNum;
            using (OleDbConnection conn = new OleDbConnection(connDB))
            {
                OleDbCommand cmd = new OleDbCommand(sSql, conn);
                conn.Open();
                sLatestNum = (string)cmd.ExecuteScalar();
                cmd.Cancel();     
            }
            return sLatestNum;
        }

        public static bool Update(string sSql) 
        {
            try 
             {	
                int ret = 0;
                OleDbConnection conn = new OleDbConnection(connDB);
                OleDbCommand cmd = new OleDbCommand(sSql, conn);
                conn.Open();
                ret = cmd.ExecuteNonQuery();
                cmd.Cancel();
                conn.Close();
                if (ret == 0)
                {
	                return false;	            
                }
            }
            catch (Exception)
            {
	           return false;
            }
            return true;
        }

        public static bool Insert(string sValue1, string sValue2) 
        {
            try
            {
                int ret = 0;
                OleDbConnection conn = new OleDbConnection(connDB);
                OleDbCommand cmd = new OleDbCommand("Insert Into OrderHead(order_no,rule) Values('" + sValue1 + "', '" + sValue2 + "')", conn);
                conn.Open();
                ret = cmd.ExecuteNonQuery();
                cmd.Cancel();
                conn.Close();
                if (ret == 0)
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }

    class OrderNumberGenerator 
    {   
        /// <summary> 最後要顯示幾碼的流水號, 預設長度是3</summary>
        private int _LengthofSN = 3;
        private string _Rule = "month";
        private string _Format = "";

        public int LengthofSN 
        {
            get { return this._LengthofSN; }
            set 
            {
                if (value > 4) value = 3;
                this._LengthofSN = value; 
            }
        }

        // 流水號 每年、每月 才歸零一次
        public string Rule 
        {
            get { return this._Rule; }
            set 
            {
                if (value == "每年")
                    value = "year";
                else
                    value = "month";
                this._Rule = value;
            }
        }
        /// <summary>指定傳回的格式</summary>
        public string Format 
        {
            get { return _Format; }
            set
            {
                string sFormat = string.Empty;
                sFormat = value.Replace("yyyy", DateTime.Now.ToString("yyyy"));
                if (sFormat.Contains("MM"))
                {
                    sFormat = sFormat.Replace("MM", DateTime.Now.ToString("MM"));
                }

                this._Format = sFormat.Replace("SN", "");
            }
        }

        public OrderNumberGenerator() 
        {
            this._LengthofSN = 3;
            this._Rule = "month";
            this._Format = "";
        }

        public string GetNumber()
        {
            string sLastestNum = DB.GetData(@"Select iif(IsNull(Max(order_no)), 'null', Max(order_no)) 
                                              From OrderHead 
                                              Where order_no like '" + this._Format + "%' and rule = '" + this._Rule + "'");
            return sLastestNum;
        }

        public bool InsertDB()
        {
            string sLastestNum = this.GetNumber();
            string sNumber = string.Empty;
            string sSN = string.Empty;

            switch (LengthofSN)
            {
                case 1: sSN = "1"; break;
                case 2: sSN = "01"; break;
                case 3: sSN = "001"; break;
                case 4: sSN = "0001"; break;
            }

            if (sLastestNum == "null")
            {
                sNumber = this._Format + sSN;
            }
            else
            {
                if (sLastestNum.Contains("/"))
                {
                    string[] sArrNum = sLastestNum.Split('/');
                    sNumber = sArrNum[0] + "/" + sArrNum[1] + "/" + (int.Parse(sArrNum[2]) + 1).ToString().PadLeft(this.LengthofSN, '0');
                }
                else if (sLastestNum.Contains("-"))
                {
                    string[] sArrNum = sLastestNum.Split('-');
                    sNumber = sArrNum[0] + "-" + sArrNum[1] + "-" + (int.Parse(sArrNum[2]) + 1).ToString().PadLeft(this.LengthofSN, '0');
                }
                else
                {
                    sNumber = (int.Parse(sLastestNum) + 1).ToString().PadLeft(this.LengthofSN, '0');
                }
            }

            return DB.Insert(sNumber, this._Rule);
        }
    }
}