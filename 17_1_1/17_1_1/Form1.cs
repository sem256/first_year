using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace _17_1_1
{
    public partial class Form1 : Form
    {
        private double a = 6;// значення які задані формулою(можна змінювати)
        private double b = 1;
        private double max_x = 5;
        private double min_x = -1;
        private double max_y = 4;
        private double min_y = -2;
        private double s = 0.05;// крок для малювання точок но графику
        private double n = 2;// розмір сітки
        ChartArea my_chart;
        public Form1()
        {
            InitializeComponent();
            my_chart = chart1.ChartAreas[0];
        }
        // розраховуємо за формулою F(x)
        private double F(double x, double a, double b)
        {
            double y = Math.Sin(x * x / (x - a)) + b;
            return y;
        }
        //малюємо функцію F(x)
        private void Draw()
        {
            double x = min_x;
            double y;
            double i = 0;
            while (i <= (max_x - min_x) / s)
            {
                y = F(x, a, b);
                chart1.Series[0].Points.AddXY(x, y);// додаємо точку на графіку
                x += s;
                i++;
            }
        }
        private void Locationn()// розташування елементів в на формі
        {
            chart1.Height = this.Height - 79;
            chart1.Width = this.Width - this.Width / 6;
            a_element.Left = (this.Width - this.Width / 10);
            b_element.Left = (this.Width - this.Width / 10);
            maxx_element.Left = (this.Width - this.Width / 10);
            n_element.Left = maxx_element.Left;
            minx_element.Left = maxx_element.Left;
            maxy_element.Left = maxx_element.Left;
            miny_element.Left = maxx_element.Left;
            label1.Left = a_element.Left - 13;
            label2.Left = label1.Left;
            label3.Left = a_element.Left - 40;
            label4.Left = label1.Left;
            label5.Left = label3.Left;
            label6.Left = label3.Left;
            label7.Left = label3.Left;
            button1.Left = label3.Left;
            button2.Left = label3.Left;
            button3.Left = label3.Left;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Name = "";//sin(x^2/(x-a)) - b
            chart1.Series[0].ChartType = SeriesChartType.Line;// зєдную точки но графіку 
            Locationn();
            my_chart.AxisX.Interval = n;// задаємо інтервал по X
            my_chart.AxisY.Interval = n;// задаємо інтервал по Y

            my_chart.AxisX.Maximum = max_x;	//початкові значення осей
            my_chart.AxisX.Minimum = min_x;
            my_chart.AxisY.Maximum = max_y;
            my_chart.AxisY.Minimum = min_y;
            my_chart.AxisX.Title = "X";	//підписи осей
            my_chart.AxisY.Title = "Y";
            Draw();
        }
        private void ReDraw()// перемалювання
        {
            my_chart.AxisX.Interval = n;// задаємо інтервал по X
            my_chart.AxisY.Interval = n;// задаємо інтервал по Y

            my_chart.AxisX.Maximum = max_x;	//початкові значення осей
            my_chart.AxisX.Minimum = min_x;
            my_chart.AxisY.Maximum = max_y;
            my_chart.AxisY.Minimum = min_y;
            Draw();
        }

        private void Form1_Resize(object sender, EventArgs e)// при зміні розмірів форми
        {
            Locationn();
        }

        // кнопки на StripMenu
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help n = new Help();
            n.Show();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Show();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            my_chart.AxisX.MajorGrid.Enabled = false;
            my_chart.AxisY.MajorGrid.Enabled = false;
            button1.Hide();
            button2.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            my_chart.AxisX.MajorGrid.Enabled = true;
            my_chart.AxisY.MajorGrid.Enabled = true;
            button2.Hide();
            button1.Show();
        }

        private void a_element_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                a = Convert.ToDouble(a_element.Text);
                errorProvider1.Clear();
            }
            catch
            {
                errorProvider1.SetError(a_element, "Not corect");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            if ((max_x < a) || (min_x > a))
            {
                chart1.Series[0].Points.Clear();
                errorProvider1.Clear();
                ReDraw();
            }
            else
            {
                errorProvider1.SetError(maxx_element, "a is in the range [min X; max X]");
                errorProvider1.SetError(minx_element, "a is in the range [min X; max X]");
            }
           
        }
        private void b_element_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                b = Convert.ToInt32(b_element.Text);
                errorProvider1.Clear();
            }
            catch
            {
                errorProvider1.SetError(b_element, "Not corect");
            }
        }

        private void n_element_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                double m = n;
                n = Convert.ToDouble(n_element.Text);
                if (n > 0)
                    errorProvider1.Clear();
                else
                {
                    errorProvider1.SetError(n_element, "must be greater than zero");
                    n = m;
                }
            }
            catch
            {
                errorProvider1.SetError(n_element, "Not corect");
            }
        }

        private void x_element_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                double m = max_x;
                max_x = Convert.ToDouble(maxx_element.Text);
                if (max_x > min_x)
                {
                        errorProvider1.Clear();
                }
                else
                {
                    errorProvider1.SetError(maxx_element, "min X > max X");
                    max_x = m;
                }
            }
            catch
            {
                errorProvider1.SetError(maxx_element, "Not corect");
            }
        }
   
        private void minx_element_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                double m = min_x;
                min_x = Convert.ToDouble(minx_element.Text);
                if (max_x > min_x)
                {
                    errorProvider1.Clear();
                }
                else
                {
                    errorProvider1.SetError(minx_element, "min X > max X");
                    min_x = m;
                }
            }
            catch
            {
                errorProvider1.SetError(minx_element, "Not corect");
            }
        }

        private void maxy_element_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                double m = max_y;
                max_y = Convert.ToDouble(maxy_element.Text);
                if (max_y > min_y)
                    errorProvider1.Clear();
                else
                {
                    errorProvider1.SetError(maxy_element, "max Y < min Y");
                    max_y = m;
                }
            }
            catch
            {
                errorProvider1.SetError(maxy_element, "Not corect");
            }
        }

        private void miny_element_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                double m = min_y;
                min_y = Convert.ToDouble(miny_element.Text);
                if (max_y > min_y)
                    errorProvider1.Clear();
                else
                {
                    errorProvider1.SetError(miny_element, "max Y < min Y");
                    min_y = m;
                }
            }
            catch
            {
                errorProvider1.SetError(miny_element, "Not corect");
            }
        }

    }
}
