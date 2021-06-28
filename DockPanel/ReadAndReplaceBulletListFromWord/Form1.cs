using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using WeifenLuo.WinFormsUI.Docking;
using System.Configuration;

namespace Practice.ReadAndReplaceBulletListFromWord
{
    public partial class Form1 : DockContent
    {
        private static string DefaultPath = ConfigurationManager.AppSettings["Practice.DefaultPath.Setting"].ToString();

        public Form1()
        {
            InitializeComponent();
            this.button1.Click += new EventHandler(button1_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Word.Application MyWord = new Word.Application();
            Word.Document MyDoc = MyWord.Documents.Open(DefaultPath + @"\ReadAndReplaceBulletListFromWord\test.docx");
            MyWord.Visible = true;

            //替換□符號
            object strStart = "□";
            Word.Range MyRange = MyDoc.Content;
            Word.Range rngTmp = MyDoc.Range(0, 0);
            MyRange.Find.Text = "□";
            MyRange.Find.Forward = true;
            MyRange.Find.Execute(strStart);
            while (MyRange.Find.Found)
            {
                //游標處核取方塊控制
                rngTmp.SetRange(MyRange.Start, MyRange.End);
                rngTmp.Select();
                Word.ContentControl checkbox = rngTmp.ContentControls.Add(Word.WdContentControlType.wdContentControlCheckBox);
                checkbox.SetCheckedSymbol(82, "Wingdings 2");
       
                //游標移至被加入的核取方塊後
                MyRange.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
                MyRange.Select();

                MyRange.Find.Execute(strStart);
            }

            //替換項目符號
            foreach (Word.Paragraph p in MyWord.ActiveDocument.Paragraphs)
            {
                if (p.Range.ListFormat.ListType != Word.WdListType.wdListBullet) continue;
                
                //移除項目符號
                p.Range.ListFormat.ApplyBulletDefault(DefaultListBehavior: Word.WdDefaultListBehavior.wdWord9ListBehavior);
                //加入核取方塊控制項
                p.Range.Select();
                MyWord.Selection.HomeKey(Word.WdUnits.wdLine, Word.WdMovementType.wdMove);
                rngTmp = MyWord.Selection.Range;
                Word.ContentControl checkbox2 = rngTmp.ContentControls.Add(Word.WdContentControlType.wdContentControlCheckBox);
                checkbox2.SetCheckedSymbol(82, "Wingdings 2");
            }

            MessageBox.Show("處理完成");
        }

    }
}
