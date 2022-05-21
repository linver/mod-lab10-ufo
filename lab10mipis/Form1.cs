using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace lab10mipis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double arctang(double x, int pw)
        {
            double atg = 0;
            if (x >= -1 && x <= 1)
            {
                for (int i = 1; i <= pw; i++)
                {
                    atg += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / (2 * i - 1);
                }
            }
            else
            {
                if (x >= 1)
                {
                    atg += Math.PI / 2;
                }

                else
                {
                    atg -= Math.PI / 2;
                }

                for (int i = 0; i < pw; i++)
                {
                    atg -= Math.Pow(-1, i) / ((2 * i + 1) * Math.Pow(x, 2 * i + 1));
                }
            }
            return atg;
        }

        int factorial(int x)
        {
            if (x <= 0)
                return 1;
            return x * factorial(x - 1);
        }

        double sinus(double x, int pw)
        {
            double sin = 0;
            for (int i = 1; i <= pw; i++)
            {
                sin += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / factorial(2 * i - 1);
            }
            return sin;
        }

        double cosinus(double x, int pw)
        {
            double cos = 0;
            for (int i = 1; i <= pw; i++)
            {
                cos += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 2) / factorial(2 * i - 2);
            }

            return cos;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            GraphicsState gstate;
            graphics.ScaleTransform(0.5f, 0.5f);

            Pen line_ = new Pen(Color.Orange, 5);
            Pen point_ = new Pen(Color.MediumBlue, 10);

            double x1 = 40;
            double y1 = 100;
            double x2 = 600;
            double y2 = 800;

            graphics.DrawEllipse(point_, (int)x1, (int)y1, 2, 2);
            graphics.DrawEllipse(point_, (int)x2, (int)y2, 2, 2);

            double x = Math.Abs(x1 - x2);
            double y = Math.Abs(y1 - y2);

            double sum = x + y;
            double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

            double step = 1;
            double angle = arctang((y2 - y1) / (x1 - x2), 10);

            while (distance <= sum)
            {
                x1 = x1 + step * cosinus(angle, 10);
                y1 = y1 - step * sinus(angle, 10);

                graphics.DrawEllipse(line_, (int)x1, (int)y1, 1, 1);

                x = Math.Abs(x1 - x2);
                y = Math.Abs(y1 - y2);

                distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

                if (distance < sum)
                    sum = distance;
            }

            graphics.DrawString("Погрешность: " + sum.ToString(), new Font("Arial", 28), Brushes.Black, new PointF(40, 800));
            gstate = graphics.Save();
            graphics.Restore(gstate);


            List<double> points = new List<double>();
            for (int i = 2; i <= 10; i++)
            {
                x1 = 40;
                y1 = 100;
                x = Math.Abs(x1 - x2);
                y = Math.Abs(y1 - y2);
                sum = x + y;
                distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
                angle = arctang((y2 - y1) / (x1 - x2), i);

                while (distance <= sum)
                {
                    x1 = x1 + step * cosinus(angle, i);
                    y1 = y1 - step * sinus(angle, i);

                    x = Math.Abs(x1 - x2);
                    y = Math.Abs(y1 - y2);

                    distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

                    if (distance < sum)
                        sum = distance;
                }
                points.Add(sum);
            }

            Form2 f2 = new Form2(points);
            f2.Show();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
