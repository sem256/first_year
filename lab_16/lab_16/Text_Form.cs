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
    public partial class Text_Form : Form
    {
        public Text_Form()
        {
            InitializeComponent();
        }
        private void Text_Form_Load(object sender, EventArgs e)
        {
            textBox1.Text = ((Form1)MdiParent).FN;// предаємо зназву файлу
            richTextBox1.Text = ((Form1)MdiParent).F;// передаємо що в файлі
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void Comments_Click(object sender, EventArgs e)
        {
            string s = richTextBox1.Text;// текст який знаходиться в richtextbox
            int start = 0, end = 0;
            bool c_short = false;// індикатор однорядкового коментаря
            bool c_long = false;// індикатор багатострокового коментаря
            string coment; 
            for (int i = 0; i < s.Length; i++)
            {
                /* якщо розпізнаеться ідекатором богатостроковий коментар то поки не закінчеться цей коментар програма 
                 * він не зможе розмізнати ніякій інший коментар. Та навпаки.
                 */
                if ((s[i] == '/') && (s[i + 1] == '*') && !c_long && !c_short)// перевіряємо на багато строковий коментар
                {
                    start = i;// елемент з якого починаємо видаляти
                    c_long = true;
                }
                if ((s[i] == '*') && (s[i + 1] == '/') && c_long && !c_short)// перевіряємо де закінчується багатостроковий коментар
                {
                    end = i;// по який елемент видаляємо
                    c_long = false;
                    coment = s.Substring(start, end - start + 2);//строка яку видаляємо
                    s = s.Replace(coment, "");// строку яку потрібно видалити заміняємо не пустрий рядок
                    i = start + 2;
                }
                if ((s[i] == '/') && (s[i + 1] == '/') && !c_short && !c_long)//перевіряємо на однорядковий коментар
                {
                    start = i;// елемент з якого починаємо видаляти
                    c_short = true;
                }
                if (((s[i] == '\n') || (i == s.Length - 1)) && c_short && !c_long)// перевіряємо на закінчення рядка
                {
                    end = i;// по який елемент видаляємо
                    c_short = false;
                    coment = s.Substring(start, end - start);//строка яку видаляємо
                    s = s.Replace(coment, "");// строку яку потрібно видалити заміняємо не пустрий рядок
                    i = start + 1;
                }
            }
            richTextBox1.Text = s;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            // зберігаємо відредактованій файл
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
