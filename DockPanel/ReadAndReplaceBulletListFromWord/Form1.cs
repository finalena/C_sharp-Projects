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
            Word.Range rngTmp = MyDoc.Range(0, 0);

            //將項目符號取代成指定符號
            foreach (Word.Paragraph p in MyWord.ActiveDocument.Paragraphs)
            {
                if (p.Range.ListFormat.ListType != Word.WdListType.wdListBullet) continue;
                
                //移除項目符號
                p.Range.ListFormat.ApplyBulletDefault(DefaultListBehavior: Word.WdDefaultListBehavior.wdWord9ListBehavior);
               
                p.Range.Select();
                MyWord.Selection.HomeKey(Word.WdUnits.wdLine, Word.WdMovementType.wdMove);
                rngTmp = MyWord.Selection.Range;
                rngTmp.Text = "□";
            }

            //替換指定符號為核取方塊控制
            object strStart = "□";
            Word.Range MyRange = MyDoc.Content;
            MyRange.Find.Text = "□";
            MyRange.Find.Forward = true;
            MyRange.Find.Execute(strStart);

            while (MyRange.Find.Found)
            {
                //選取游標取代
                rngTmp.SetRange(MyRange.Start, MyRange.End);
                rngTmp.Select();
                Word.ContentControl checkbox = rngTmp.ContentControls.Add(Word.WdContentControlType.wdContentControlCheckBox);
                checkbox.SetCheckedSymbol(82, "Wingdings 2");

                //游標移至被加入的核取方塊後
                MyRange.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
                MyRange.Select();
                MyRange.Font.Size = 14;
                MyRange.Find.Execute(strStart);
            }

            MessageBox.Show("處理完成");
        }

    }
}
