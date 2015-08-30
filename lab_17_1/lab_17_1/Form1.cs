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

namespace lab_17_1
{
    public partial class Form1 : Form
    {
        private double a = 1;
        private double b = 1;
        private double max_x = 20;
        private double min_x = 1;
        private double s = 0.05;
        
        public Form1()
        {
            InitializeComponent();
        }
        private double F(double x)
        {
            double y = Math.Sin(x * x / (x - a)) + b;
            return y;
        }
        private void D()
        {
            double x = min_x;
            double y;
            double i = 0;
            while (i<=(max_x-min_x)/2)
            {
                y = F(x);
                chart1.Series[0].Points.AddXY(x, y);
                
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            D();
        }


        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
