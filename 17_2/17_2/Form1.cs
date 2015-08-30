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
    public partial class Form1 : Form
    {
        Graphics d;
        Pen pen = new Pen(Color.Gray, 20);// колір та розмір пензля 
        private bool flag = false;//показник який показує чи намалбовано щось на формі
        private double a;
        private delegate void Elements();// масив з елементів які малюються почерзі
        Elements[] mas;
        private int j = 0;
        public Form1()
        {
            InitializeComponent();
        }
        // елементи малювання
        private void Draw_1()
        {
            d.DrawEllipse(pen, 20, 20, this.panel1.Width - 40, this.panel1.Height - 40);
        }
        private void Draw_2()
        {
            int cord = (int)((this.panel1.Width - 40) / 8);
            d.DrawEllipse(pen, cord + 20, 20, cord * 6, (int)((this.panel1.Height - 40) / 2));
        }
        private void Draw_3()
        {
            int cord = (int)((this.panel1.Width - 40) / 8);
            d.DrawEllipse(pen, cord * 3 + 20, 20, cord * 2, this.panel1.Height - 40);
        }
        // малюємо задані елементи
        private void Draw()
        {
            for (int i = 0; i < j; i++)
                mas[i]();
            flag = true;
        }
        //розташування елементів на формві
        private void Locationn()
        {
            d = panel1.CreateGraphics();
            a = this.panel1.Width / 20;
            pen.Width = (float)a;
            //panel1.Width = this.Width;

        }
        // малюємо весь малюнок зразу
        private void drawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Locationn();
            j = mas.Length;
            Draw();
            button1.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            d = panel1.CreateGraphics();
            mas = new Elements[3] { Draw_1, Draw_2, Draw_3 };
        }
        // при зміні розмірів
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (flag)
            {
                d.Clear(panel1.BackColor);
                Locationn();
                Draw();
            }

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
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
        // якщо видаляємо
        private void cleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            d.Clear(panel1.BackColor);
            flag = false;
            button1.Show();
            j = 0;
        }
        // полювання по едементово
        private void button1_Click(object sender, EventArgs e)
        {
            if (j < mas.Length)
            {
                mas[j]();
                j++;
                flag = true;
            }
            if (j >= mas.Length)
                button1.Hide();
        }
    }
}
