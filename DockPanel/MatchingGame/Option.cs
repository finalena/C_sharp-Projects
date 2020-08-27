using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Collections;
using System.Reflection;
using WeifenLuo.WinFormsUI.Docking;

namespace Practice
{
    public partial class Option : DockContent
    {
        bool bIsError = false;

        public Option()
        {
            InitializeComponent();
            this.numX.Maximum = 4;
            this.numY.Maximum = 4;

            this.btnStartGame.Click += new EventHandler(this.Button_Click);
            this.FormClosing += new FormClosingEventHandler(Option_FormClosing);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            int iNum = Convert.ToInt16(this.numX.Value) * Convert.ToInt16(this.numY.Value);
            if (iNum % 2 != 0)
            {
                bIsError = true;
                MessageBox.Show("牌數須為偶數！請重新輸入", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Option_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bIsError)
            {
                e.Cancel = true;
                bIsError = false;
            }        
        }
    }
}
