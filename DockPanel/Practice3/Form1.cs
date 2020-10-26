using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Practice.Practice3
{
    /// 找出日期區間內, 符合星期日,二,五的日期清單
    /// 參考資料: http://www.webapp.com.tw/EBook5/view.aspx?a=1&TreeNodeID=72&id=429
    public partial class Form1 : DockContent
    {
        public Form1()
        {
            InitializeComponent();
            this.btnSubmit.Click += new EventHandler(btnSubmit_Click);
        }
        /// 方法1
        /// 用迴圈判斷期限內，符合的條件
        /*private void btnSubmit_Click(object sender, EventArgs e)
        {
            DateTime dt1 = (DateTime)this.dateTimePicker1.Value;
            DateTime dt2 = (DateTime)this.dateTimePicker2.Value;
            string sMsgShow = "";

            foreach (var day in EachDay(dt1, dt2))
            {
                if (day.DayOfWeek.ToString() == "Sunday" || day.DayOfWeek.ToString() == "Tuesday" || day.DayOfWeek.ToString() == "Friday")
                {
                    sMsgShow += day.ToString("yyyy-MM-dd    dddd") + Environment.NewLine;
                }
            }
            MessageBox.Show(sMsgShow);
        }*/

        /// 方法2
        /// 先找出符合星期日的第一天(2008/8/3),並將7天後的日期也陸續加入結果(因為7天後也一定是星期天), 應該速度會快一些
        private void btnSubmit_Click(object sender, EventArgs e) 
        {
            this.txtShow.Text = "";
            DateTime dtStart = (DateTime)this.dateTimePicker1.Value;
            DateTime dtEnd = (DateTime)this.dateTimePicker2.Value;
            int iStartWeekDay = (int)dtStart.DayOfWeek;  // 開始日期是星期幾
            int[] iArrTarget = { 0, 2, 5 };     // 符合星期日,二,五的日期清單
            List<DateTime> Result = new List<DateTime>();

            for (int i = 0; i < iArrTarget.Length; i++)
            {
                DateTime dtTarget;

                if (iArrTarget[i] == iStartWeekDay)  // 找到日期區間內，第一個符合此星期的日期
                {
                    dtTarget = dtStart;
                }
                else
                {
                    dtTarget = (iArrTarget[i] > iStartWeekDay) ? dtStart.AddDays(7 - iStartWeekDay + iArrTarget[i]) : dtStart.AddDays(iArrTarget[i] - iStartWeekDay);
                }

                // 將區間內的星期日都儲存到結果裡
                while (dtTarget < dtEnd)
                {
                    Result.Add(dtTarget);
                    dtTarget = dtTarget.AddDays(7);
                }
            }

            // 輸出結果
            foreach (var day in Result)
            {
                this.txtShow.Text += day.ToString("yyyy/MM/dd  dddd") + Environment.NewLine;
            }
        }

        private static IEnumerable<DateTime> EachDay(DateTime dtFrom, DateTime dtThru)
        {
            for (var i = dtFrom.Date; i.Date < dtThru.Date; i=i.AddDays(1))
			{
               yield return i;
			}
        }
    }
}
