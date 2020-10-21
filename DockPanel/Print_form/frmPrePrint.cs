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
    public partial class frmPrePrint : DockContent
    {
        Bitmap[] bAllFloor;

        public frmPrePrint(string sSelect, Bitmap[] bFloors)
        {
            InitializeComponent();
            bAllFloor = bFloors;

            switch (sSelect)
            {
                case "姓名":
                    this.chkName.Checked = true;
                    break;
                case "電話":
                    this.chkPhone.Checked = true;
                    break;
                case "生日":
                    this.chkBirthday.Checked = true;
                    break;
                case "地址":
                    this.chkAddress.Checked = true;
                    break;
            }

            this.btnSubmit.Click += new EventHandler(this.ButtonClick);
            this.btnExit.Click += new EventHandler(this.ButtonClick);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (sender.Equals(this.btnSubmit))
            {
                List<string> listTemp = new List<string>();
                List<Bitmap> bChoose = new List<Bitmap>();

                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is CheckBox)
                    {
                        CheckBox chkItem = ctrl as CheckBox;
                        if (chkItem.Checked == true) listTemp.Add(chkItem.Text.ToString());                
                    }
                }

                string[] sArrFloor = listTemp.ToArray();
                if (sArrFloor.Length != 0)
                {
                    for (int intA = 0; intA < sArrFloor.Length; intA++)
                    {
                        switch (sArrFloor[intA].Trim())
                        {
                            case "姓名":
                                bChoose.Add(bAllFloor[0]); 
                                break;
                            case "電話":
                                bChoose.Add(bAllFloor[1]); 
                                break;
                            case "生日":
                                bChoose.Add(bAllFloor[2]); 
                                break;
                            case "地址":
                                bChoose.Add(bAllFloor[3]); 
                                break;
                        }
                    }
                    bChoose.Reverse();
                }
                else
                {
                    MessageBox.Show("必須勾選至少一個項目", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                listTemp.Reverse();
                frmPrint frm2 = new frmPrint(bChoose.ToArray(), listTemp.ToArray());
                frm2.ShowDialog();
                this.Close();
            }
            else if (sender.Equals(this.btnExit))
            {
                this.Close();
            }
        }
    }
}
