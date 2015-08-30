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
    public partial class About_Form : Form
    {
        private const string About = @"E:\file_text\About.txt";
        public About_Form()
        {
            InitializeComponent();
        }
        private void About_Form_Load(object sender, EventArgs e)
        {
            StreamReader ab = new StreamReader(About);// зчитуємо з файлу
            richTextBox1.Text = ab.ReadToEnd();
            ab.Close();
        }
    }
}
