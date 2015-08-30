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
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }
        private const string my_help = @"E:\file_text\Help.txt";
        private void Help_Load(object sender, EventArgs e)
        {
            StreamReader h = new StreamReader(my_help);
            richTextBox1.Text = h.ReadToEnd();
            h.Close();
        }
    }
}
