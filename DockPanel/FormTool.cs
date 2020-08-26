using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Practice
{
    public partial class FormTool : DockContent
    {
        public FormTool()
        {
            InitializeComponent();

            IniToolSideBar();
            
            this.treeView1.MouseDoubleClick += new MouseEventHandler(treeView1_MouseDoubleClick);
        }

        private void IniToolSideBar() 
        {
            TreeNode nodeRoot = new TreeNode();
            nodeRoot.Text = "Practice";
            this.treeView1.Nodes.Add(nodeRoot);
            
            foreach (string toolModule in FormMain.dicTool.Keys)
            {
                TreeNode nodeModule = new TreeNode();
                nodeModule.Text = toolModule;

                nodeRoot.Nodes.Add(nodeModule);

                foreach (string item in FormMain.dicTool[toolModule].Keys)
                {
                    TreeNode nodeItem = new TreeNode();
                    nodeItem.Text = item;
                    nodeModule.Nodes.Add(nodeItem);    
                }
                
            }
            this.treeView1.ExpandAll();
            this.treeView1.SelectedNode = this.treeView1.TopNode;
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeNode nodeClick = this.treeView1.GetNodeAt(e.X, e.Y);
            if (nodeClick.Text == this.treeView1.TopNode.Text || nodeClick == null || e.Button == MouseButtons.Right) return;

            this.treeView1.SelectedNode = nodeClick;
            FormMain.GetMain().ShowContent(nodeClick.Text);
        }
    }
}
