using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace lab10mipis
{
    public partial class Form2 : Form
    {
        public Form2(List<double> points)
        {
            InitializeComponent();
            chart1.Series.Add(new Series());


            Font my_font = new Font("Arial", 11);
            chart1.ChartAreas[0].AxisX.TitleFont = my_font;
            chart1.ChartAreas[0].AxisY.TitleFont = my_font;

            chart1.ChartAreas[0].AxisY.Title = "Погрешность";
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 100;
            chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 5;

            chart1.ChartAreas[0].AxisX.Title = "Количество членов ряда";
            chart1.ChartAreas[0].AxisX.Minimum = 2;
            chart1.ChartAreas[0].AxisX.Maximum = 10;
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 1;


            chart1.Series[0].Color = Color.Orange;
            chart1.Series[1].Color = Color.MediumBlue;
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series[1].ChartType = SeriesChartType.Point;

            for (int i = 0; i < points.Count; i++)
            {
                chart1.Series[0].Points.AddXY(i + 2, Math.Round(points[i], 2));
                chart1.Series[1].Points.AddXY(i + 2, Math.Round(points[i], 2));
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
