using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace new_16_1
{
    public partial class Form1 : Form
    {
        private const string help = @"E:\file_text\Help.txt";
        public Form1()
        {
            InitializeComponent();
        }
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text_Form childform = new Text_Form();// створюємо childform
            childform.MdiParent = this;// батько childform 
            childform.Text = string.Format("Code{0}", codeToolStripMenuItem.DropDownItems.Count + 1);// 
            childform.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // відкриваємо  MessageBox
            StreamReader h = new StreamReader(help);
            MessageBox.Show(h.ReadLine(), "Help", MessageBoxButtons.OK);
            h.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();//вийти з програми
        }
        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About_Form abo = new About_Form();
            abo.Show();
        }
    }
}
