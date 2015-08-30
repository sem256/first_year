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

namespace lab_16
{
    public partial class Form1 : Form
    {
        private string f;// вміст файлу 
        private string fn;//назва файлу
        public string F// властівість для вмісту файла
        {
            get { return f; }
        }
        public string FN
        {
            get { return fn; }//властівість для назву файла
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // відкриваємо файл
            openFileDialog1.Filter = "Text File |*.txt";//дозволені файли для відкриття
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Text_Form childform = new Text_Form();// створюємо childform
                childform.MdiParent = this;// батько childform 
                childform.Text = string.Format(openFileDialog1.SafeFileName, codeToolStripMenuItem.DropDownItems.Count + 1);//назва childform
                f = File.ReadAllText(openFileDialog1.FileName, Encoding.GetEncoding(1251));// вміст файлу з розширенням для росийскої мови
                fn = openFileDialog1.FileName;// назва файлу
                childform.Show();
            }
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)// закріваємо всі файли
            {
                form.Close();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)// закриваємо файл який активний 
            {
                ActiveMdiChild.Close();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About_Form abo = new About_Form();
            abo.Show();
        }
    }
}
