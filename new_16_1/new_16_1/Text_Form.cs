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

    public partial class Text_Form : Form
    {

        public Text_Form()
        {
            InitializeComponent();
        }
        private void Comments_Click(object sender, EventArgs e)
        {
            string s = richTextBox1.Text;// текст який знаходиться в richtextbox
            int start = 0, end = 0;
            bool n = true;
            bool m = true;
            for (int i = 0; i < s.Length; i++)// перевіряємо на багато строковий коментар
            {
                if ((s[i] == '/') && (s[i + 1] == '*') && (m == true) && (n == true))
                {
                    start = i;
                    m = false;
                }
                if ((s[i] == '*') && (s[i + 1] == '/') && (m == false) && (n == true))// перевіряємо де закінчується багатостроковий коментар
                {
                    end = i;
                    m = true;
                    string coment = s.Substring(start, end - start + 2);
                    s = s.Replace(coment, "");
                    i = start + 2;
                }
                if ((s[i] == '/') && (s[i + 1] == '/') && (n == true) && (m == true))// перевіряємо на однорядковий коментар
                {
                    start = i;
                    n = false;
                }
                if (((s[i] == '\n') || (i == s.Length - 1)) && (n == false) && (m == true))// перевіряємо на закінчення рядка
                {
                    end = i;
                    n = true;
                    string coment = s.Substring(start, end - start);
                    s = s.Replace(coment, "");
                    i = start + 2;
                }
            }
            richTextBox1.Text = s;
        }
        private void Open_file()
        {// відкриваємо файл
            openFileDialog1.Filter = "Text File |*.txt";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName, Encoding.GetEncoding(1251));
            }
        }
        private void Search_Click(object sender, EventArgs e)
        {
            Open_file();
        }
        private void Cut_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }
        private void text_form_Load(object sender, EventArgs e)
        {
            Open_file();
            this.WindowState = FormWindowState.Maximized;
        }
        private void Save_Click(object sender, EventArgs e)
        {// зберігаємо відредактованій файл
            saveFileDialog1.Filter = "Text File |*.txt";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] split = richTextBox1.Text.Split(new Char[] { '\n' });// позбіваємо текст по рядкакм
                StreamWriter save_file = new StreamWriter(saveFileDialog1.FileName);
                for (int i = 0; i < split.Length; i++)// записуємо по рядкам текст в файл
                    save_file.WriteLine(split[i]);
                save_file.Close();// закриваємо файл
            }
        }

    }
}
