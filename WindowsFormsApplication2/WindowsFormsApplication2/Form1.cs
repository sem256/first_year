using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        Graphics m;
        Pen pen = new Pen(Color.Black, 20);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m = panel1.CreateGraphics();
            m.DrawRectangle(pen, 20, 20, 20, 20);
            Form2 n = new Form2();
            n.Show();
        }

    }
    class Am
    {
        public Am()
        { }
        private string m;
        public string M
        {
            get { return m; }
            set { m = value; }
        }
    }
    class Frog : Am
    {
        public Frog():base(){}
    }
}