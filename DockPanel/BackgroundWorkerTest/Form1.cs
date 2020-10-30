using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;

namespace Practice.BackgroundWorkerTest
{
    public partial class Form1 : DockContent
    {
        BackgroundWorker bw;
        public int iCount = 0;

        public Form1()
        {
            InitializeComponent();
            InitBackgroundWorker();
            InitProgressBar();
            
            this.btnStart.Click += new EventHandler(button_Click);
            this.btnEnd.Click +=new EventHandler(button_Click);
        }
        //完成時要顯示的內容或動作        
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true )
            {
                MessageBox.Show("已取消",this.Text);
            }
            else if (e.Error != null)
            {
                MessageBox.Show("錯誤訊息: " + e.Error.Message, this.Text);
            }
            else
            {
                MessageBox.Show("載入完畢", this.Text);
                this.btnStart.Enabled = true;
                this.btnEnd.Enabled = false;
            }
        }
        //ProgressChanged事件會收到觸發而執行該處理函式裡的程式，如改變ProgressBar的進度值。
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
            this.lblProgressValue.Text = "載入完成率: " + this.progressBar1.Value.ToString() + "%";
        }
        //執行序內要做的事
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                if (bw.CancellationPending == true)
                {
                    e.Cancel = true;
                    //break;
                }
                else
                {
                    //使用sleep模擬運算時的停頓
                    System.Threading.Thread.Sleep(500);
                    bw.ReportProgress(i * 10);
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(this.btnStart))
            {
                if (!bw.IsBusy)
                {
                    this.btnStart.Enabled = false;
                    this.btnEnd.Enabled = true;
                    this.progressBar1.Value = 0;
                    bw.RunWorkerAsync();    //移到執行序執行 
                }
            }
            else if (sender.Equals(this.btnEnd))
            {
                this.btnStart.Enabled = true;
                this.btnEnd.Enabled = false;
                bw.CancelAsync();
            }
        }

        private void InitBackgroundWorker() 
        {
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
        }

        private void InitProgressBar() 
        {
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = 100;
            this.progressBar1.Step = 1;
        }
    }
}
