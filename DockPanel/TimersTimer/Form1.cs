using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using WeifenLuo.WinFormsUI.Docking;

namespace Practice.TimersTimer
{
    public partial class Form1 : DockContent
    {
        System.Timers.Timer aTimer;
        public delegate void UpdateControl(string sMsg);
        object objLock = new object();
        int iCnt;

        public Form1()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
            this.btnStart.Click += new EventHandler(this.Button_Click);
            this.btnStop.Click += new EventHandler(this.Button_Click);
            this.btnReset.Click += new EventHandler(this.Button_Click);

            iCnt = 0;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(this.btnReset))
            {
                aTimer.Stop();
                iCnt = 0;
                aTimer.Start();
            }
            else if (sender.Equals(this.btnStart))
            {
                aTimer = new System.Timers.Timer();
                aTimer.Interval = 1000;
                aTimer.Enabled = true;
                aTimer.Elapsed += Timer_Tick;
                aTimer.Start();
            }
            else if (sender.Equals(this.btnStop))
            {
                aTimer.Stop();
            }
        }

        private void Timer_Tick(object sender, System.Timers.ElapsedEventArgs e) 
        {
            aTimer.Stop();
            iCnt++;
            this.BeginInvoke(new UpdateControl(ShowMsg), new object[] { iCnt.ToString() });
            aTimer.Start();
        }

        private void ShowMsg(string sMsg) 
        {
            lock (objLock)
            {
                this.label1.Text = sMsg;
            }
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            aTimer.Stop();
        }
    }
}
