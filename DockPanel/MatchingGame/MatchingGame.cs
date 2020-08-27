using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Resources;
using System.Collections;
using System.Reflection;
using WeifenLuo.WinFormsUI.Docking;

namespace Practice
{
    /// 翻牌記憶遊戲
    /// 資料來源: 
    /// https://fgchen.com/wp/%E3%80%90-%E7%A8%8B%E5%BC%8F%E8%A8%AD%E8%A8%88%E3%80%91%E8%A8%98%E6%86%B6%E9%81%8A%E6%88%B2/
    /// https://catchtest.pixnet.net/blog/post/21842200-%E7%B0%A1%E5%96%AE%E7%9A%84%E7%BF%BB%E7%89%8C%E9%81%8A%E6%88%B2
    public partial class MatchingGame : DockContent
    {
        Option frmA;
        List<Control> CtrList;
        System.Timers.Timer aTimer;
        string[] PicNames = { "奇異果", "柳橙", "橘子", "水蜜桃", "芭樂", "葡萄", "蘋果", "西瓜" };
        string[] Cards;
        string sCompare1 = "";
        string sCompare2 = "";  //紀錄翻牌的第一與第二張文字，用來比較用
        int iSteps = 0;
        int iSuccess = 0;
        PictureBox pbFirst = null;
        PictureBox pbSecond = null;
        long lTimeCount = 0;
        public delegate void SetControlValue(long value);

        public MatchingGame()
        {

            InitializeComponent();
         
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += timersTimer_tick;
            this.mnuStart.Click += new EventHandler(this.Menu_Click);
            this.mnuExit.Click += new EventHandler(this.Menu_Click);

        }

        /// <summary>準備卡牌</summary>
        private void PrepareCard(int iTotal) 
        {
            Cards = new string[iTotal];
            int row;
            bool bIsRepeat;
            Random rndNums = new Random();

            ///產生兩副X張牌，共iNum張 
            int iDeck = iTotal / 2;
            for (int intA = 0; intA < iDeck; intA++)
            {
                //抽牌，如果先前有抽到一樣的牌繼續抽
                do
                {
                    bIsRepeat = false;  
                    row = rndNums.Next(0, iDeck);
                    for (int intB = intA - 1; intB >= 0; intB--)
                    {
                        if (Cards[intB].IndexOf(PicNames[row]) > -1)
                        {
                            bIsRepeat = true;
                            break;
                        }
                    }
                } while (bIsRepeat);
                
                Cards[intA] = PicNames[row];
                Cards[intA + iDeck] = PicNames[row];
            }
            
            //打亂牌
            for (int intA = 0; intA < iTotal - 1; intA++)
            {
                string sTemp = Cards[intA];
                int iRnd = rndNums.Next(0, iTotal-1);
                Cards[intA] = Cards[iRnd];
                Cards[iRnd] = sTemp;
            }
        }

        private void PictureBox_Click(object sender, EventArgs e) 
        {
            if (aTimer.Enabled == false) return;
            
            PictureBox pBox = (PictureBox)sender;
            int index = int.Parse(pBox.Tag.ToString());
           
            pBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(Cards[index - 1]);
            
            //翻第一張牌
            if (pbFirst == null)
            {
                pbFirst = pBox;
                pBox.Enabled = false;   //以防止再按該pictureBox
                sCompare1 = Cards[index - 1];
            }
            else
            {//翻第二張牌
                iSteps++;
                this.lblSteps.Text = "翻牌次數 " + iSteps + " 次";
                pbSecond = pBox;
                pbSecond.Enabled = false;
                sCompare2 = Cards[index - 1];

                //比較翻出來的2張牌，若不一樣，則蓋牌，重新啟動二張卡的作用
                if (sCompare1 != sCompare2)
                {
                    System.Threading.Thread.Sleep(Convert.ToInt16(1000 * frmA.numSleep.Value));
                    pbFirst.Image = Properties.Resources.背面;
                    pbSecond.Image = pbFirst.Image;

                    pbFirst.Enabled = true; 
                    pbSecond.Enabled = true;

                    // 高手模式下，選錯將雙方的牌互換
                    if (frmA.chkAdvance.Checked) 
                    {
                        string sTemp = pbFirst.Tag.ToString();
                        pbFirst.Tag = pbSecond.Tag.ToString();
                        pbSecond.Tag = sTemp;
                    }
                }
                else
                {
                    if (frmA.chkClear.Checked)
                    {
                        pbFirst.Visible = false;
                        pbSecond.Visible = false;
                    }

                    iSuccess++;
                    if (iSuccess == CtrList.Count / 2)
                    {
                        aTimer.Stop();
                        MessageBox.Show("恭喜你成功配對了所有牌~" + Environment.NewLine + this.lblPlayTime.Text, "訊息");     
                    }
                }

                //重新進行翻牌
                pbFirst = null; pbSecond = null;
                sCompare1 = null; sCompare2 = null;

                if (frmA.chkStep.Checked && iSteps > frmA.numStep.Value)
                {
                    aTimer.Stop();
                    MessageBox.Show("很抱歉超過預定步數了，遊戲結束", "訊息");
                }
            }
        }

        private void LoadGame(int iRow, int iCol) 
        {
            this.panel1.Controls.Clear();

            int iCnt = 0;
            int iTotal = iRow * iCol;
            PictureBox[] pb = new PictureBox[iTotal];
            for (int intA = 0; intA < iRow; intA++)
            {
                for (int intB = 0; intB < iCol; intB++)
                {
                    iCnt++;
                    pb[intA * intB] = new PictureBox();
                    pb[intA * intB].Name = "pictureBox" + iCnt;
                    pb[intA * intB].Tag = iCnt;
                    pb[intA * intB].Location = new Point((12 * (intA * 13 + 1)), (12 * (intB * 13 + 1)));
                    pb[intA * intB].Size = new Size(150, 150);
                    pb[intA * intB].Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
                    pb[intA * intB].SizeMode = PictureBoxSizeMode.CenterImage;
                    pb[intA * intB].Image = Properties.Resources.背面;
                    pb[intA * intB].Cursor = Cursors.Hand;
                    
                    this.panel1.Controls.Add(pb[intA * intB]);             
                }
            }

            this.panel1.Size = new System.Drawing.Size(12 * (iRow * 13) + 25, (12 * (iCol * 13)) + 10);
            this.Size = new System.Drawing.Size(12 * (iRow * 13) + 25, 12 * (iCol * 13) + 100);
            
            IniControl();
            PrepareCard(iTotal);
        }

        private void IniControl() 
        {
            CtrList = GetAllControls(this.panel1);
            foreach (Control ctr in CtrList)
            {
                if (ctr is PictureBox)
                {
                    ctr.Click += new EventHandler(PictureBox_Click);
                }
            }
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            if (sender.Equals(this.mnuStart))
            {
                frmA = new Option();
           
                if (aTimer.Enabled)
                {
                    if (MessageBox.Show("你確定要放棄此局嗎？", "訊息", MessageBoxButtons.OKCancel) == DialogResult.OK) 
                    { 
                        aTimer.Stop();
                    }
                    else
                    {
                        return;
                    }
                }

                if (frmA.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    LoadGame(Convert.ToInt16(frmA.numX.Value), Convert.ToInt16(frmA.numY.Value));
                    aTimer.Interval = 1000;
            
                    if ((MessageBox.Show("遊戲開始!", this.Text)) == DialogResult.OK)
                    {
                        // 清掉前次留下的紀錄
                        lTimeCount = 1;
                        iSuccess = 0;
                        iSteps = 0;
                        this.lblSteps.Text = "翻牌次數 " + iSteps + " 次";
                        aTimer.Enabled = true;        
                    } 
                }
                
            }
            else if (sender.Equals(this.mnuExit))
            {
                this.Close();
            }
        }

        private void timersTimer_tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new SetControlValue(ShowTime), lTimeCount);
            lTimeCount++;

            if (frmA.chkTime.Checked && lTimeCount > int.Parse(frmA.numTime.Text) )
            {
                aTimer.Stop();
                MessageBox.Show("時間到，遊戲結束！", "訊息");
            }
        }

        private void ShowTime(long lTemp) 
        {
            TimeSpan timeSpan = new TimeSpan(0, 0, (int)lTemp);
            this.lblPlayTime.Text = string.Format("遊戲時間 {0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);
       
            //if (this.lblTime.InvokeRequired)
            //{
            //    this.lblTime.Invoke(new SetControlValue(ShowTime), lTemp);
            //}
            //else
            //{
            //    TimeSpan timeSpan = new TimeSpan(0, 0, (int)lTemp);
            //    this.lblTime.Text = string.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);
            //}
        }

        # region GetCtrArray 列舉控制項
        /// <summary>
        /// 遞迴取得Form中控制項
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private List<Control> GetAllControls(object obj) 
        {
            List<Control> CtrList = new List<Control>();

            ToCtrList(obj, ref CtrList); 

            return CtrList;
        }
        
        private void ToCtrList(object obj, ref List<Control> CtrList) 
        {
            if (obj is Form)
            {
                foreach (Control ctr in ((Form)obj).Controls)
                {
                    CtrList.Add(ctr);
                    if (ctr.HasChildren) ToCtrList(ctr, ref CtrList);
                }
            }
            else
            {
                foreach (Control ctr in ((Control)obj).Controls)
                {
                    CtrList.Add(ctr);
                    if (ctr.HasChildren) ToCtrList(ctr, ref CtrList);
                }
            }
        }
        #endregion
    }
}
