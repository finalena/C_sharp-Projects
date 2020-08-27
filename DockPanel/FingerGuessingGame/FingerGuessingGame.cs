using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using WeifenLuo.WinFormsUI.Docking;

namespace Practice
{
    
    public partial class FingerGuessingGame : DockContent
    {
        Dictionary<int, string> Finger = new Dictionary<int, string>();
 
        public FingerGuessingGame()
        {
            InitializeComponent();

            Finger.Add(1, "剪刀");
            Finger.Add(2, "石頭");
            Finger.Add(3, "布");

            this.btnJiandao.Click += new EventHandler(Button_Click);
            this.btnShitou.Click += new EventHandler(Button_Click);
            this.btnBu.Click += new EventHandler(Button_Click);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string sPlayer = button.Text;
            this.lblPlayer.Text = sPlayer;
            int iPlayer = 0;

            foreach (KeyValuePair<int,string> item in Finger)
            {
                if (sPlayer == item.Value)
                {
                    iPlayer = item.Key;
                    break;
                }
            }

            PC(iPlayer);
        }

        private void PC(int iPlayer) 
        {
            Random rnd = new Random();
            int iPC = rnd.Next(1, 4);

            foreach (KeyValuePair<int, string> item in Finger)
            {
                if (iPC == item.Key)
                {
                    this.lblPC.Text = item.Value;
                    break;
                }
            }

            int iTemp = iPlayer - iPC;
            if ((iTemp == 1) || iTemp == -2)
            {
                this.lblResult.Text = "You Win!";
            }
            else if (iTemp == 0)
            {
                this.lblResult.Text = "平手";
            }
            else 
            {
                this.lblResult.Text = "You lose!";
            }
        }
    }
}
