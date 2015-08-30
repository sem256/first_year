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
    public partial class About_Form : Form
    {
        private const string About = @"E:\file_text\About.txt";
        public About_Form()
        {
            InitializeComponent();
        }

        private void About_Form_Load(object sender, EventArgs e)
        {
            StreamReader ab = new StreamReader(About);
            while (!ab.EndOfStream)
            {
                richTextBox1.Text += ab.ReadLine() + "\n";
            }
            ab.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
