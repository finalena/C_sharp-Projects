using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using WeifenLuo.WinFormsUI.Docking;

namespace Practice.Print_form
{
    public partial class frmPrint : DockContent
    {
        PrintDocument objPD = new PrintDocument();
        PictureBox[] pbPrint;   //被選出來要印的pictureBox
        string[] sArrFloor;
        private int printWidth;
        private int printHeight; 
        int iPage = 1;  //紀錄目前所在頁數
        int iCount = 0;

        public frmPrint(Bitmap[] bFloors, string[] sFloors)
        {
            InitializeComponent();
            this.objPD.PrintPage += new PrintPageEventHandler(objPD_PrintPage);
            this.btnLeft.Click += new EventHandler(this.UpDownButton_click);
            this.btnRight.Click +=new EventHandler(this.UpDownButton_click);
            this.btnPrint.Click += new EventHandler(this.Button_click);
            this.btnExit.Click +=new EventHandler(this.Button_click);
            this.textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            sArrFloor = new string[sFloors.Length];
            pbPrint = new PictureBox[bFloors.Length];
            this.sArrFloor = sFloors;

            for (int intA = 0; intA < bFloors.Length; intA++)
            {
                this.pbPrint[intA] = new PictureBox();
                this.pbPrint[intA].Image = bFloors[intA];
                sArrFloor[intA] = sFloors[intA];
            }
            
            //設定列印複本數量
            this.numericUpDown1.Maximum = 100;
            this.numericUpDown1.Minimum = 1;
            SetPrint();
        }

        private void objPD_PrintPage(object sender, PrintPageEventArgs e)
        {
            this.pictureBox1.Image = this.pbPrint[iCount].Image;
            PrintPanel(new Bitmap(this.pictureBox1.Image), e);
            iCount++;
            if (iCount < Convert.ToInt32(this.labMaxPage.Text.Substring(3)))
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }

        private void PrintPanel(Bitmap gNP, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Display;
            Font f = new System.Drawing.Font("標楷體", 10, FontStyle.Bold);
            string text = "日期：" + DateTime.Now.ToString("yyyy/MM/dd") + "   樓層：" + sArrFloor[iCount];
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.DrawString(text, f, Brushes.Black, 0, 0);
            g.DrawImage(gNP, new RectangleF(40, 40, (float)(gNP.Width * 0.75), (float)(gNP.Height * 0.75)));
        }

        /// <summary>設定預設列印</summary>
        private void SetPrint()
        {
            //取得預設印表機名稱
            String DefaultName = objPD.PrinterSettings.PrinterName;
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                if (strPrinter == DefaultName)
                {
                    this.comboBox1.Items.Add("預設：" + strPrinter);
                }
                else
                {
                    this.comboBox1.Items.Add(strPrinter);
                }
            }
            this.comboBox1.Text = "預設：" + DefaultName;
            //預設列印的頁數
            this.labMaxPage.Text = "/  " + pbPrint.Length.ToString();
            this.pictureBox1.Image = this.pbPrint[0].Image;
            this.textBox1.Text = "1";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
            
        private void UpDownButton_click(object sender, EventArgs e)
        {
            if (sender.Equals(this.btnRight))
            {
                if (iPage >= Convert.ToInt16(this.labMaxPage.Text.Substring(3))) return;
                iPage++;
                this.pictureBox1.Image = this.pbPrint[iPage - 1].Image;
                this.textBox1.Text = iPage.ToString();
            }
            else if (sender.Equals(this.btnLeft))
            {
                if (iPage <= 1) return;
                iPage--;
                this.pictureBox1.Image = this.pbPrint[iPage - 1].Image;
                this.textBox1.Text = iPage.ToString();
            }
        }

        private void Button_click(object sender, EventArgs e)
        {
            if (sender.Equals(this.btnPrint))
            {
                //設定紙張大小 - A4
                float A4_Width = 11.7f;
                float A4_Height = 8.27f;
                printWidth = (int)(A4_Width * 96);//793.92
                printHeight = (int)(A4_Height * 96);//1123.2

                //設定間距
                objPD.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
                objPD.OriginAtMargins = true;
                objPD.DefaultPageSettings.PaperSize = new PaperSize("vbPRPSUser", 827, 1192);
                objPD.DefaultPageSettings.Landscape = true;   //設定橫印
                //複印幾份
                objPD.PrinterSettings.Copies = Convert.ToInt16(this.numericUpDown1.Value.ToString());
                //指定印表機
                if (this.comboBox1.Text.Substring(0, 3) != "預設：")
                {
                    objPD.PrinterSettings.PrinterName = this.comboBox1.Text;
                }
                iCount = 0;
                if (objPD.PrinterSettings.IsValid)
                {
                    this.objPD.DocumentName = "個人資料";
                    objPD.Print();
                }
                this.Close();
            }
            else if (sender.Equals(this.btnExit))
            {
                this.Close();
            }
        }
    }
}
