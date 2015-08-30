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

namespace _17_2
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }
        private const string about = @"E:\file_text\About.txt";
        private void About_Load(object sender, EventArgs e)
        {
            StreamReader ab = new StreamReader(about);
            richTextBox1.Text = ab.ReadToEnd();
            ab.Close();
        }
    }
}
