using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Practice.DictionaryAndForeach
{
    /// Dictionary與foreach        
    /// 參考資料: https://dotblogs.com.tw/h091237557/2014/05/22/145219
    public partial class Form1 : DockContent
    {
        Dictionary<int, Student> ClassA;
        public Form1()
        {
            InitializeComponent();
            Inititle();
            printForeach();
            printIEnumerator();

            this.cmbNum.SelectedIndexChanged += new EventHandler(cmbNum_SelectedIndexChanged);
        }

        private void cmbNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            //將資料從Numbers Dictionary中取出。
            Student A = ClassA[(int)this.cmbNum.SelectedItem];
            this.txtName.Text = A.Name;
            this.txtHeight.Text = A.Height.ToString();
        }
        private void printForeach() 
        {
            this.txtForeach.Text = "Foreach";
            foreach (KeyValuePair<int, Student> item in ClassA)
            {
                this.txtForeach.Text += Environment.NewLine + "索引值為: " + item.Key.ToString() + " 值為: " + item.Value.Name + Environment.NewLine;
            }
        }
        private void printIEnumerator() 
        {
            this.txtIEnumeraor.Text = "IEnumerator";
            //建立IEnumerator類別的物件enumerator 用來存放使用GetEnumeraotr()方法抓取回來的『可逐一查看集合的列舉程式』
            IEnumerator<KeyValuePair<int, Student>> enumerator = ClassA.GetEnumerator();
            while (enumerator.MoveNext())
            {
                //enumerator.Current為KeyValuePair<TKey, TValue> 型別的屬性。
                //所以才要產生一個KeyValuePair<TKey, TValue>型別的Numbers來當接收端。
                KeyValuePair<int, Student> number = enumerator.Current;
                this.txtIEnumeraor.Text += Environment.NewLine + "索引值為: " + number.Key + " 值為: " + number.Value.Name + Environment.NewLine;
            }
        }
        private void Inititle()
        {
            ClassA = new Dictionary<int, Student>() 
            {
                {101, new Student("曉東", 169)},
                {103, new Student("大明", 179)},
                {104, new Student("阿華", 165)},
                {106, new Student("櫻木", 170)}
            };
            
            foreach (int key in ClassA.Keys)
            {
                this.cmbNum.Items.Add(key);
            }
        }
    }

    public class Student 
    {
        public string Name;
        public int Height;

        public Student(string sName, int iHeight) 
        {
            Name = sName;
            Height = iHeight;
        }
    }
}
