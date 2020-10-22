using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WeifenLuo.WinFormsUI.Docking;
using System.Configuration;

namespace Practice.Practice2
{
    public partial class Form1 : DockContent
    {
        private static string DefaultPath = ConfigurationManager.AppSettings["Practice.DefaultPath.Setting"].ToString();
        Dictionary<string, string> Club = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();

            Club.Add("日文社", "日文週四班");

            this.linkLabel1.Text = DefaultPath + @"Practice2\TestData\便當費用test.xlsx";
            this.txtDate.Mask = TLC.TLMaskDefine.MaskDA;

            this.btnBrowse.Click += new EventHandler(Button_Click);
            this.btnUpload.Click += new EventHandler(Button_Click);
            this.linkLabel1.Click += new EventHandler(linkLabel1_Click);
        }
        
        private void linkLabel1_Click(object sender, EventArgs e)
        {
            Process.Start(DefaultPath + @"Practice2\TestData");
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(this.btnUpload))
            {
                if (this.txtDate.Value.Trim() == "")
                {
                    MessageBox.Show("請輸入日期", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtDate.Focus();
                    return;
                }
                else if (this.txtFilePath.Value.Trim() == "")
                {
                    MessageBox.Show("請選擇檔案", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtFilePath.Focus();
                    return;
                }
                else if (!File.Exists(this.txtFilePath.Value.Trim()))
                {
                    MessageBox.Show("檔案不存在，請重新選擇檔案", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtFilePath.Focus();
                    return;
                }
                else if (!File.Exists(this.linkLabel1.Text.Trim()))
                {
                    MessageBox.Show("請檢查上傳位置是否有誤", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable dt = ReadExcel(this.txtFilePath.Value.Trim());

                if (dt == null)
                {
                    MessageBox.Show("上傳的檔案格式需為「按人統計」，請重新上傳", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtFilePath.Focus();
                    return;
                }

                ToExcel(dt);
            }
            else if (sender.Equals(this.btnBrowse))
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "開啟Excel檔案";
                openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.txtFilePath.Value = openFileDialog1.FileName;
                }
            }
        }

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int ProcessId);

        private DataTable ReadExcel(string sPath)
        {
            Excel.Application MyExcel = new Excel.Application();
            Excel.Workbook MyBook = MyExcel.Workbooks.Open(sPath);
            Excel.Worksheet MySheet = MyBook.Worksheets.get_Item(1);

            int lpdwProcessId;
            GetWindowThreadProcessId(new IntPtr(MyExcel.Hwnd), out lpdwProcessId);

            if (MySheet == null) 
            {
                Process.GetProcessById(lpdwProcessId).Kill();
                return null;
            }

            if (MySheet.Cells[1, 1].Text.Trim() != "訂購人 排序 : 名字 訂購先後" || MySheet.Cells[1, 3].Text.Trim() != "總共") 
            {
                Process.GetProcessById(lpdwProcessId).Kill();
                return null; 
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("orderer");
            dt.Columns.Add("value", System.Type.GetType("System.Int16"));
            
            for (int intA = 2; intA <= MySheet.UsedRange.Rows.Count; intA++)
            {
                if (MySheet.Cells[intA, 1].Value == null) break;

                dt.Rows.Add(MySheet.Cells[intA, 1].Value.Trim(), MySheet.Cells[intA, 3].Value);
            }

            Process.GetProcessById(lpdwProcessId).Kill();

            return dt;
        }

        private void ToExcel(DataTable dt)
        {
            DateTime Date = DateTime.Parse(this.txtDate.Value);
            string sDate = Date.ToString("M月d日");
            
            Excel.Application MyExcel = new Excel.Application();
            Excel.Workbook MyBook = MyExcel.Workbooks.Open(this.linkLabel1.Text.Trim());
            Excel.Worksheet MySheet = null;
            
            foreach (Excel.Worksheet sheet in MyBook.Worksheets)
            {
                if (sheet.Name.Contains("-")) 
                {
                    string[] sPara = sheet.Name.Split('-');
                    
                    DateTime dTime1;
                    DateTime dTime2;
                    if (!DateTime.TryParseExact(sPara[0].Trim(), "dd MMM, yy", new System.Globalization.CultureInfo("en-US", false).DateTimeFormat, DateTimeStyles.AllowWhiteSpaces, out dTime1)) continue;
                    if (!DateTime.TryParseExact(sPara[1].Trim(), "dd MMM, yy", new System.Globalization.CultureInfo("en-US", false).DateTimeFormat, DateTimeStyles.AllowWhiteSpaces, out dTime2)) continue;

                    if (Date.CompareTo(dTime1) >= 0 && Date.CompareTo(dTime2) <= 0)
                    {
                        MySheet = sheet;
                        break;
                    }   
                }
            }

            if (MySheet == null)
            {
                MySheet = MyBook.Worksheets.Add();
                
                string startWeek = Date.AddDays(0 - Convert.ToInt32(Date.DayOfWeek.ToString("d"))).ToString("dd MMM, yy", new System.Globalization.CultureInfo("en-US", false).DateTimeFormat);  //本周周日
                string endWeek = Date.AddDays(6 - Convert.ToInt32(Date.DayOfWeek.ToString("d"))).ToString("dd MMM, yy", new System.Globalization.CultureInfo("en-US", false).DateTimeFormat);  //本周周六
                MySheet.Name = startWeek + " - " + endWeek;
                MySheet.Cells[1, 1].Value = "訂購人";
                MySheet.Cells[1, 2].Value = "總金額";
                MySheet.Cells[2, 1].Value = "每日總計";
            }
            
            int iRow = 1;
            int iCol = 1;

            //尋找該日有無資料
            Excel.Range rngDate = (Excel.Range)MySheet.Cells[1, MySheet.UsedRange.Columns.Count];
            Excel.Range currentFind = rngDate.Find(sDate);
            if (currentFind != null)
            {
                if (MessageBox.Show(this.txtDate.Value + "已有資料，是否要複寫?", "訊息", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
                
                MySheet.Range[MySheet.Cells[2, currentFind.Column], MySheet.Cells[MySheet.UsedRange.Rows.Count, currentFind.Column]].ClearContents();
                iCol = currentFind.Column;
            }
            else
            {
                MySheet.Columns[MySheet.UsedRange.Columns.Count].Insert(Excel.XlInsertShiftDirection.xlShiftToRight);
                iCol = MySheet.UsedRange.Columns.Count - 1;
            }

            MySheet.Cells[1, iCol].NumberFormat = "@";
            MySheet.Cells[1, iCol].Value = sDate;

            //尋找訂購人
            Excel.Range rngName = (Excel.Range)MySheet.Cells[MySheet.UsedRange.Rows.Count, 1];
            for (int intA = 0; intA < dt.Rows.Count; intA++)
            {
                bool IsClub = false;
                string sOrderer = dt.Rows[intA]["orderer"].ToString();
                double dValue = 0;
                double.TryParse(dt.Rows[intA]["value"].ToString(),out dValue);

                foreach (KeyValuePair<string, string> item in Club)
                {
                    if (sOrderer.Contains(item.Value))
                    {
                        IsClub = true;
                        sOrderer = item.Key;
                        break;
                    }
                }
                
                currentFind = rngName.Find(sOrderer);
                if (currentFind == null)
                {//新增一列並填入姓名
                    MySheet.Rows[MySheet.UsedRange.Rows.Count].Insert();
                    iRow = MySheet.UsedRange.Rows.Count - 1;
                    MySheet.Cells[iRow, 1].Value = sOrderer;
                }
                else
                {
                    iRow = currentFind.Row;
                }

                double dCell = 0;
                dCell = (MySheet.Cells[iRow, iCol].Value != null) ? MySheet.Cells[iRow, iCol].Value : 0;
                
                MySheet.Cells[iRow, iCol].NumberFormat = "G/通用格式";
                MySheet.Cells[iRow, iCol].Value = IsClub ? (dValue + dCell) : dValue;
            }

            //計算總金額
            for (int intA = 2; intA <= MySheet.UsedRange.Rows.Count; intA++)
            {
                MySheet.Cells[intA, MySheet.UsedRange.Columns.Count].Value = string.Format("=SUM({0}:{1})", MySheet.Cells[intA, 2].Address, MySheet.Cells[intA, MySheet.UsedRange.Columns.Count - 1].Address);
            }
            //計算每日總計 
            MySheet.Cells[MySheet.UsedRange.Rows.Count, iCol].Value = dt.Compute("SUM(value)", string.Empty).ToString();

            SetExcelStyle(MySheet);

            ((Excel._Worksheet)MySheet).Activate();
            MySheet.Cells[1, 1].Select();
            MyExcel.Visible = true; 
            MyExcel.ActiveWindow.SplitRow = 1;
            MyExcel.ActiveWindow.FreezePanes = true;
            MyExcel.ActiveWindow.Zoom = 60;
            

            System.Runtime.InteropServices.Marshal.ReleaseComObject(MyExcel);
            MyExcel = null;
            MyBook = null;
            MySheet = null;
        }
        
        private void SetExcelStyle(Excel.Worksheet MySheet) 
        {
            //儲存格公式轉數值，避免排序跑掉
            //MySheet.UsedRange.Value = MySheet.UsedRange.Value;
            //排序
            //MySheet.Sort.SetRange(MySheet.Range[MySheet.Cells[1, 1], MySheet.Cells[MySheet.UsedRange.Rows.Count - 1, MySheet.UsedRange.Columns.Count]]);
            //MySheet.Sort.Header = Excel.XlYesNoGuess.xlYes;
            //MySheet.Sort.SortFields.Add(MySheet.UsedRange.Columns[1], Excel.XlSortOn.xlSortOnValues, Excel.XlSortOrder.xlAscending);
            //MySheet.Sort.Apply();

            MySheet.UsedRange.Font.Size = 15;
            MySheet.UsedRange.Font.Name = "微軟正黑體";
            MySheet.UsedRange.Font.Bold = true;
            MySheet.UsedRange.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            MySheet.UsedRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            MySheet.UsedRange.Rows[1].Interior.ColorIndex = 36;
            MySheet.UsedRange.Columns[MySheet.UsedRange.Columns.Count].Interior.ColorIndex = 36;
            MySheet.UsedRange.EntireColumn.AutoFit();
        }
    }
}
