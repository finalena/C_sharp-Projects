using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Resources;
using System.Reflection;

namespace Practice.SlotMachine
{
    /// 拉Bar遊戲
    /// 資料來源: https://dotblogs.com.tw/joe_ziqiao_wang/2017/09/12/135022
    public partial class SlotMachine : DockContent
    {
        int a, b, c = 0;

        public SlotMachine()
        {
            InitializeComponent();
            this.timer1.Enabled = false;

            this.timer1.Tick += new EventHandler(this.TimerTick);
            this.btnRotate.Click += new EventHandler(this.ButtonClick);
            this.btnExit.Click += new EventHandler(this.ButtonClick);
        }

        private void TimerTick(object sender, EventArgs e)
        {

            Random random = new Random();
            a = random.Next(1, 4);
            b = random.Next(1, 4);
            c = random.Next(1, 4);

            switch (a)
            {
                case 1:
                    this.pictureBox1.Image = Practice.SlotMachine.Resource_SlotMachine.one;
                    break;
                case 2:
                    this.pictureBox1.Image = Practice.SlotMachine.Resource_SlotMachine.Snoopy;
                    break;
                case 3:
                    this.pictureBox1.Image = Practice.SlotMachine.Resource_SlotMachine.JailRabbit;
                    break;
            }
            switch (b)
            {
                case 1:
                    this.pictureBox2.Image = Practice.SlotMachine.Resource_SlotMachine.one;
                    break;
                case 2:
                    this.pictureBox2.Image = Practice.SlotMachine.Resource_SlotMachine.Snoopy;
                    break;
                case 3:
                    this.pictureBox2.Image = Practice.SlotMachine.Resource_SlotMachine.JailRabbit;
                    break;
            }
            switch (c)
            {
                case 1:
                    this.pictureBox3.Image = Practice.SlotMachine.Resource_SlotMachine.one;
                    break;
                case 2:
                    this.pictureBox3.Image = Practice.SlotMachine.Resource_SlotMachine.Snoopy;
                    break;
                case 3:
                    this.pictureBox3.Image = Practice.SlotMachine.Resource_SlotMachine.JailRabbit;
                    break;
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (sender.Equals(this.btnRotate))
            {
                if (this.btnRotate.Text == "Rotate")
                {
                    this.timer1.Enabled = true;
                    this.btnRotate.Text = "Stop";
                }
                else
                {
                    this.timer1.Enabled = false;
                    this.btnRotate.Text = "Rotate";

                    if (a == b && b == c && a == c)
                        MessageBox.Show("You win!", this.Text);
                }
            }
            else if (sender.Equals(this.btnExit))
            {
                this.Close();
            }
        }
    }
}
