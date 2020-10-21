using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Practice.Print_form
{
    public partial class Form1 : DockContent
    {
        public Form1()
        {
            InitializeComponent();

            this.btnPrint.Click += new EventHandler(this.ButtonClick);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (sender.Equals(this.btnPrint))
            {
                Bitmap[] bFloor = new Bitmap[4];
                bFloor[0] = GetFloor(this.tabPage1, 0);
                bFloor[1] = GetFloor(this.tabPage2, 1);
                bFloor[2] = GetFloor(this.tabPage3, 2);
                bFloor[3] = GetFloor(this.tabPage4, 3);
                frmPrePrint frmA = new frmPrePrint(this.tabControl1.SelectedTab.Text, bFloor);
                frmA.ShowDialog();
            }
        }

        private Bitmap GetFloor(Panel panFloor, int iSelected) 
        {   
            Bitmap BitMapSource = new Bitmap(panFloor.Width, panFloor.Height);
            TabPage tabPage = this.tabControl1.TabPages[iSelected];
            tabPage.Show();
            panFloor.DrawToBitmap(BitMapSource, new Rectangle(0, 0, panFloor.Width, panFloor.Height));

            return BitMapSource;
        }
    }
}
