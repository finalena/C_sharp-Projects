using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using WeifenLuo.WinFormsUI.Docking;

namespace Practice.SearchAndHighlightText
{
    /// <summary>
    /// Highlight Search Text In DataGridView cell
    /// </summary>
    public partial class SearchAndHighlightText : DockContent
    {
        string KeyWord = "";

        public SearchAndHighlightText()
        {
            InitializeComponent();
            this.dgv.CellPainting += new DataGridViewCellPaintingEventHandler(dgv_CellPainting);
            this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.button1.Click += new EventHandler(button1_Click);
            IniData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KeyWord = this.txtKeyWord.Text.Trim();
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && this.txtKeyWord.Text.Trim() != "")
            {
                //清除線條
                e.Graphics.FillRectangle(new SolidBrush(e.CellStyle.BackColor), e.CellBounds);

                if (e.State == (DataGridViewElementStates.Displayed | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible))
                {
                    e.PaintBackground(e.ClipBounds, true);
                }
                else
                {
                    e.PaintBackground(e.ClipBounds, false);
                }

                //繪製底邊線和右邊線
                e.Graphics.DrawLine(new Pen(new SolidBrush(this.dgv.GridColor)), e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                e.Graphics.DrawLine(new Pen(new SolidBrush(this.dgv.GridColor)), e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);

                if (e.Value != null)
                {
                    string sValue = e.Value.ToString();
                    int Index = 0;
                    List<CharacterRange> Ranges = new List<CharacterRange>();
                    DataTable dtKeyPos = new DataTable();
                    dtKeyPos.Columns.Add("key", typeof(int));
                    dtKeyPos.Columns.Add("value", typeof(string));

                    //取得搜尋關鍵字索引位置
                    if (KeyWord.Trim() == "") return;
                    Index = 0;
                    while ((Index = sValue.IndexOf(KeyWord, Index, StringComparison.OrdinalIgnoreCase)) != -1)
                    {
                        dtKeyPos.Rows.Add(Index, KeyWord);
                        Index += KeyWord.Length;
                    }

                    if (dtKeyPos.Rows.Count == 0) return;
                    DataView dv = new DataView(dtKeyPos);
                    dv.Sort = "key Asc";
                    dtKeyPos = dv.ToTable(true, new string[]{ "key", "value"});
                    for (int intA = 0; intA < dtKeyPos.Rows.Count; intA++)
                    {
                        Console.Write(dtKeyPos.Rows[intA]["key"].ToString() + ":");
                        Console.WriteLine(dtKeyPos.Rows[intA]["value"].ToString());
                    }
                    //依KeyPos測量字符的範圍位置
                    Index = 0;
                    int iLen = 0;
                    int iCnt = 0;
                    while (Index < sValue.Length)
                    {
                        DataRow[] dtRow = dtKeyPos.Select("key = " + Index);
                        if (dtRow.Length >= 1)
                        {
                            iLen = dtKeyPos.Rows[iCnt]["value"].ToString().Length;
                            if (Index > Convert.ToInt16(dtKeyPos.Rows[iCnt]["key"])) iCnt++;
                            iCnt++;
                        }
                        else
                        {
                            iLen = (iCnt < dtKeyPos.Rows.Count) ? (Convert.ToInt16(dtKeyPos.Rows[iCnt]["key"]) - Index) : (sValue.Length - Index);
                        }
                       
                        Ranges.Add(new CharacterRange(Index, iLen));
                        Index += iLen;
                    }

                    StringFormat string_format = new StringFormat();
                    string_format.LineAlignment = StringAlignment.Center;
                    string_format.FormatFlags = StringFormatFlags.NoWrap;
                    string_format.SetMeasurableCharacterRanges(Ranges.ToArray());

                    //繪製儲存格內容
                    Region[] regions = e.Graphics.MeasureCharacterRanges(sValue, e.CellStyle.Font, new RectangleF(e.CellBounds.Location, e.CellBounds.Size), string_format);
                    for (int intA = 0; intA < Ranges.Count; intA++)
                    {
                        string txts = sValue.Substring(Ranges[intA].First, Ranges[intA].Length);
                        Rectangle rect = Rectangle.Round(regions[intA].GetBounds(e.Graphics));
                        Color TextColor = e.CellStyle.ForeColor;

                        if (KeyWord.IndexOf(txts, StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            TextColor = Color.Red;
                        }
                        else if (e.State == (DataGridViewElementStates.Displayed | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible))
                        {
                            TextColor = Color.White;
                        }
                        TextRenderer.DrawText(e.Graphics, txts, e.CellStyle.Font, rect, TextColor, TextFormatFlags.NoPadding);
                    }
                }
                e.Handled = true;
            }
        }

        private void IniData()
        {
            this.txtKeyWord.Text = "day ";

            DataTable dt = new DataTable();
            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2");
            dt.Columns.Add("Column3");

            dt.Rows.Add("In My_ laptop");
            dt.Rows.Add("Welcome to_ the", "Wonderful-", "ONE DAY_ ");
            dt.Rows.Add("This_ is what+ I", "night and day", "In My_ laptop");
            dt.Rows.Add("X_is always+", "this is a test message,to-", "Than_ y");
            dt.Rows.Add("night and day", "old day dawns ", "with each new day.");
            dt.Rows.Add(string.Empty, "raw winter day ", "今天會下雨嗎，明天不會下雨了吧。");
            dt.Rows.Add("明基材料股份有限公司", "BENQ MATERIALS CORP.", string.Empty);
            dt.Rows.Add("FUJIFILM Corporation ", "國王企業股份有限公司", string.Empty); 

            this.dgv.DataSource = dt;
        }

        /// <summary> 每個字元間加空白 </summary>
        private string TraWordB(string SorStr)
        {
            string sConv = "";

            for (int intA = 0; intA < SorStr.Length; intA++)
            {
                if (sConv == "")
                {
                    sConv = SorStr.Substring(intA, 1);
                }
                else
                {
                    sConv += " " + SorStr.Substring(intA, 1);
                }
            }
            return sConv;
        }

        /// <summary>判斷指定字串內的指定位置是否為中文字</summary>
        private bool CheckChineseString(string strInputString, int intIndexNumber)
        {
            int intCode = 0;

            //中文範圍（0x4e00 - 0x9fff）轉換成int（intChineseFrom - intChineseEnd）
            int intChineseFrom = Convert.ToInt32("4e00", 16);
            int intChineseEnd = Convert.ToInt32("9fff", 16);
            if (strInputString != "")
            {
                //取得input字串中指定判斷的index字元的unicode碼
                intCode = Char.ConvertToUtf32(strInputString, intIndexNumber);

                if (intCode >= intChineseFrom && intCode <= intChineseEnd)
                {
                    return true;     //如果是範圍內的數值就回傳true
                }
                else
                {
                    return false;    //如果是範圍外的數值就回傳true
                }
            }
            return false;
        }
        
    }
}
