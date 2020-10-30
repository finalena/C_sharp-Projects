using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;
using System.Windows.Forms;
using HAP = HtmlAgilityPack;
////using HtmlAgilityPack = HtmlAgilityPack.HAP.HtmlDocument;
//using HapHAP.HtmlDocument = HtmlAgilityPack.HAP.HtmlDocument;
//using WfHAP.HtmlDocument = System.Windows.Forms.HAP.HtmlDocument;
using System.IO;       //使用System.IO.MemoryStream
using System.Net;      //使用System.Net.WebClient

//資料來源：https://wings890109.pixnet.net/blog/post/67905792-c%23-htmlagilitypack
namespace Practice.HtmlAgilityPackTest
{
    public partial class Form1 : DockContent
    {
        private WebClient webClient = new WebClient();
        private MemoryStream memoryStream = null;

        public string UpdateDate = "";
        public DataTable dt = new DataTable();

        public Form1()
        {
            InitializeComponent();

            GetData();
            GetDataLotto();
        }

        private void GetData()
        {
            //HTMLAgilityPack 預設編碼應是法文編碼，所以如果是讀取中文 HTML 內容的話，
            //無法直接使用 HAP.HtmlDocument.LoadHtml() 方法，而要透過 MemoryStream 使用 HAP.HtmlDocument.Load() 方法，才可以指定中文的編碼。
            memoryStream = new MemoryStream(webClient.DownloadData(@"http://www.taifex.com.tw/cht/5/stockMargining"));
            HAP.HtmlDocument doc = new HAP.HtmlDocument();
            //1.使用HAP.HtmlDocument.Load()進行編碼UTF8編譯，取得整份網頁結構
            doc.Load(memoryStream, Encoding.UTF8);
            //2.從doc下取得目標資料的html結構
            HAP.HtmlDocument docData = new HAP.HtmlDocument();  
            docData.LoadHtml(doc.DocumentNode.SelectSingleNode(@"//div[@name='printhere']").InnerHtml);
 
            //3.獲得更新日期
            UpdateDate = docData.DocumentNode.SelectSingleNode(@"/div/p/span").InnerText;
            //4.從docData下取得網頁上目標表格的Html結構
            HAP.HtmlDocument doc_dtHtml = new HAP.HtmlDocument();
            doc_dtHtml.LoadHtml(docData.DocumentNode.SelectSingleNode(@"//table[@class='table_c']").InnerHtml);
            //5.將doc_dtHtml資料存入dt，使用的技巧詳見https://html-agility-pack.net/zh-CN/knowledge-base/18090626/
            HAP.HtmlNodeCollection headers = doc_dtHtml.DocumentNode.SelectNodes(@"//tbody/tr/th");
            //5-1.批次取得th資料，利用這些資料進行IEnumarable創造dt的Column
            foreach (HAP.HtmlNode header in headers)
            {
                dt.Columns.Add(header.InnerText);
            }

            //可用rows取得所有列的資料，也可直接寫在foreach裡面，tr[td]的意思是選取「所有tr之下有td」的tr們
            foreach (HAP.HtmlNode row in doc_dtHtml.DocumentNode.SelectNodes(@"//tr[td]"))
            {
                dt.Rows.Add(row.SelectNodes(@"td").Select(aa => aa.InnerText.Trim()).ToArray());
                
            }

            //6.寫回UI更新
            this.lbUpdateDate.Text = UpdateDate;
            this.dgvCht.DataSource = new BindingSource(dt, null);
            this.dgvCht.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.dgvCht.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void GetDataLotto() 
        {
            DataTable dtLotto = new DataTable();

            memoryStream = new MemoryStream(webClient.DownloadData(@"https://www.taiwanlottery.com.tw/Lotto/Lotto649/history.aspx"));
            HAP.HtmlDocument doc = new HAP.HtmlDocument();
            doc.Load(memoryStream, Encoding.UTF8);

            HAP.HtmlDocument docData = new HAP.HtmlDocument();
            docData.LoadHtml(doc.DocumentNode.SelectSingleNode(@"//table[@id='Lotto649Control_history_dlQuery']").InnerHtml);

            //新增欄位
            HAP.HtmlDocument docTalbeCol = new HAP.HtmlDocument();
            docTalbeCol.LoadHtml(docData.DocumentNode.SelectSingleNode(@"//table[@class='table_org td_hm']").InnerHtml);

            foreach (HAP.HtmlNode col in docTalbeCol.DocumentNode.SelectNodes(@"//tr[1]/td[@class='td_org1']"))
            {
                dtLotto.Columns.Add(col.InnerText.Trim());
            }

            dtLotto.Columns.Add("獎號");
            dtLotto.Columns.Add("特別號");
            
            //新增每期開獎資料
            foreach (HAP.HtmlNode tr in docData.DocumentNode.SelectNodes(@"/tr/td/table/tr[2]")) 
            {
                dtLotto.Rows.Add(tr.SelectNodes(@"td[@class='td_w']").Select(aa => aa.InnerText.Trim()).ToArray());
            }

            HAP.HtmlNodeCollection Data = docData.DocumentNode.SelectNodes(@"/tr/td/table/tr[5]");
            for (int intA = 0; intA < Data.Count; intA++)
            {
                string[] sPara = Data[intA].SelectNodes(@"td[@class='td_w font_black14b_center']").Select(aa => aa.InnerText.Trim()).ToArray();
                string sWinningNumbers = string.Join("　", sPara);//中獎號碼
                string sWinningSpclNumber = Data[intA].SelectSingleNode(@"td[@class='td_w font_red14b_center']").InnerText.Trim();//特別號
                dtLotto.Rows[intA]["獎號"] = sWinningNumbers;
                dtLotto.Rows[intA]["特別號"] = sWinningSpclNumber;
            }

            this.dgvLotto.DataSource = new BindingSource(dtLotto, null);
            this.dgvLotto.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.dgvLotto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
