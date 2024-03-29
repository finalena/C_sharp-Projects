﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Reflection;
using System.IO;

namespace Practice
{
    public partial class FormMain : Form
    {
        FormTool frmSide = null;
        private static FormMain frmMain = null;
        public static Dictionary<string, Dictionary<string, string>> dicTool = new Dictionary<string, Dictionary<string, string>>();
        
        public FormMain()
        {
            InitializeComponent();

            this.Load +=new EventHandler(Main_Load);
        }
        public static FormMain GetMain()
        {
            if (frmMain == null)
            {
                frmMain = new FormMain();
            }

            return frmMain;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            IniToolTitle();
            
            frmSide = new FormTool();
            frmSide.CloseButton = false;
            frmSide.Text = "工具窗口";
            frmSide.Show(this.dockPanel1, DockState.DockLeft);

            this.dockPanel1.DockLeftPortion = 0.17;
           
        }
        private void IniToolTitle() 
        {
            Dictionary<string, string> dicWinformBase = new Dictionary<string, string>();
            dicWinformBase.Add("Email解析", "Practice.Test.Form1");
            dicWinformBase.Add("心算訓練", "Practice.MentalArithmetic.MentalArithmetic");
            dicWinformBase.Add("ListViewControl", "Practice.ListViewControl.ListViewControl");
            dicWinformBase.Add("猜拳遊戲", "Practice.FingerGuessingGame.FingerGuessingGame");
            dicWinformBase.Add("翻牌記憶遊戲", "Practice.MatchingGame.MatchingGame");
            dicWinformBase.Add("SlotMachine", "Practice.SlotMachine.SlotMachine");
            dicWinformBase.Add("SearchAndHighlightText", "Practice.SearchAndHighlightText.SearchAndHighlightText");
            dicWinformBase.Add("RestrictCharactersInDataGridView", "Practice.RestrictCharactersInDataGridView.Form1");
            dicWinformBase.Add("計算列印頁數程式練習", "Practice.Practice1.Form1");
            dicWinformBase.Add("上傳便當費用", "Practice.Practice2.Form1");
            dicWinformBase.Add("Print_form", "Practice.Print_form.Form1");
            dicWinformBase.Add("TimersTimer", "Practice.TimersTimer.Form1");
            dicWinformBase.Add("FormTransfer", "Practice.FormTransfer.Form1");
            dicWinformBase.Add("OrderNumberGenerator1", "Practice.OrderNumberGenerator1.Form1");
            dicWinformBase.Add("OrderNumberGenerator2", "Practice.OrderNumberGenerator2.Form1");
            dicWinformBase.Add("DataAnalysis", "Practice.DataAnalysis.Form1");
            dicWinformBase.Add("列出日期區間內, 符合條件的日期", "Practice.Practice3.Form1");
            dicWinformBase.Add("統計字串出現的次數(Dictionary)", "Practice.Practice4.Form1");
            dicWinformBase.Add("BackgroundWorker", "Practice.BackgroundWorkerTest.Form1");
            dicWinformBase.Add("DictionaryAndForeach", "Practice.DictionaryAndForeach.Form1");
            dicWinformBase.Add("HtmlAgilityPackTest", "Practice.HtmlAgilityPackTest.Form1");
            dicWinformBase.Add("ReadAndReplaceBulletListFromWord", "Practice.ReadAndReplaceBulletListFromWord.Form1");

            dicTool.Add("WinForm基礎", dicWinformBase); 
        }
        public void ShowContent(DockContent frm)
        {
            frm.Show(this.dockPanel1);
            frm.Focus();
            frm.BringToFront();
        }
        public DockContent ShowContent(string sTitle) 
        {
            DockContent frm_dock = FindDocument(sTitle);

            if (frm_dock == null)
            {
                string sName = GetToolName(sTitle);
                if (sName == "") return null;

                string[] sArrTitle = sName.Split('.');
                string sAssemblyName = sArrTitle[0];
                
                try
                {
                    Assembly assembly = Assembly.Load(sAssemblyName);
                    Type typForm = assembly.GetType(sName);
                    Object mdiChild = typForm.InvokeMember
                    (
                        null,
                        BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance,
                        null,
                        null,
                        null
                    );

                    if (mdiChild != null)
                    {
                        frm_dock = mdiChild as DockContent;
                        frm_dock.Owner = this;
                        frm_dock.WindowState = FormWindowState.Maximized;
                    }
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Unable to load assembly...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return null;
                }
                catch (NullReferenceException) 
                {
                    MessageBox.Show("The file or directory cannot be found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return null;
                }
            }
            frm_dock.Show(this.dockPanel1);
            frm_dock.Focus();
            frm_dock.BringToFront();
            
            return frm_dock;
        }
        private DockContent FindDocument(string text)
        {
            foreach (DockContent content in this.dockPanel1.Contents)
            {
                if (content.TabText == text)
                {
                    return content;
                }
            }

            return null;
        }
        private string GetToolName(string strName)
        {
            string strTemp = "";
            foreach (string toolModule in FormMain.dicTool.Keys)
            {
                foreach (string item in FormMain.dicTool[toolModule].Keys)
                {
                    if (item == strName)
                    {
                        strTemp = FormMain.dicTool[toolModule][item];
                        break;
                    }
                }
            }
            return strTemp;
        }
    }
}
