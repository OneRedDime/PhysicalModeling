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

namespace Electron_Orbitals
{
    public partial class Form1 : Form
    {
        private const double MAX_DISTANCE = .3; //Max chartable distance in nm
        private const double ITERATE_BY = 0.0001;
        private double [] riemann;
        private string prev_input;

        Color warning_color, error_color;
        
        public Form1()
        {
            InitializeComponent();

            pictureBox3.Image = Image.FromFile("help.png");

            warning_color = Color.HotPink;
            error_color = Color.Red;

            string info = "X: #VALX\nY: #VALY";

            chart1.Series[0].ToolTip = info;

            chart1.ChartAreas[0].AxisX.Minimum = -MAX_DISTANCE;
            chart1.ChartAreas[0].AxisX.Maximum = MAX_DISTANCE;
            chart1.ChartAreas[0].AxisX.Interval = MAX_DISTANCE / 5;

            chart1.ChartAreas[0].AxisY.Minimum = -MAX_DISTANCE;
            chart1.ChartAreas[0].AxisY.Maximum = MAX_DISTANCE;
            chart1.ChartAreas[0].AxisY.Interval = MAX_DISTANCE / 5;

            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum = (float)(MAX_DISTANCE);
            chart2.ChartAreas[0].AxisX.Interval = MAX_DISTANCE / 4;
            chart2.ChartAreas[0].AxisY.Minimum = 0;
            chart2.ChartAreas[0].AxisY.Maximum = 360;

            riemann = new double[(int)(MAX_DISTANCE/ITERATE_BY)];

            riemann[0] = prob_density(0) * ITERATE_BY;
            for (int i = 1; i < riemann.Length; i++)
            {
                double start = i * ITERATE_BY;
                riemann[i] = riemann[i - 1] + prob_density(start)*ITERATE_BY;
            }

            updateGraphs(1);
            prev_input = "1";
        }

        private void updateGraphs(int num_points)
        {
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();

            double []intervals = new double[100];
            for (int i = 0; i < intervals.Length; i++)
            {
                intervals[i] = 0;
            }
            Random random = new Random();

            for (int i = 0; i < num_points; i++)
            {
                double distance = MAX_DISTANCE, chance = random.NextDouble();
                double theta = random.NextDouble() * 2 * Math.PI;
                double x = calcX(distance, theta);
                double y = calcY(distance, theta);

                for (int j = 0; j < riemann.Length; j++)
                {                    
                    //the electron is located here.
                    if(chance < riemann[j])
                    {
                        distance = j * ITERATE_BY;
                        x = calcX(distance, theta);
                        y = calcY(distance, theta);
                        intervals[(int)(distance / (MAX_DISTANCE / intervals.Length))]++;
                        break;
                    }
                }
                chart1.Series[0].Points.AddXY(x, y);
                if (i % 3 == 0)
                    chart1.Series[0].Points[i].Color = Color.Red;
                else if (i % 2 == 0)
                    chart1.Series[0].Points[i].Color = Color.HotPink;
                else
                    chart1.Series[0].Points[i].Color = Color.Blue;
                chart1.Series[0].Points[i].MarkerSize = 2;
            }

            //plot chart2
            chart2.ChartAreas[0].AxisX.Title = String.Format("nm away from nucleus\nEach interval has width {0}nm", MAX_DISTANCE/100);
                //(MAX_DISTANCE/intervals.Length).ToString() + "nm";;
            for (int i = 0; i < 100; i++)
            {
                chart2.Series[0].Points.AddXY((float)i * MAX_DISTANCE/100, intervals[i]);
            }
        }

        //Returns the probability of a given electron lying closer than r
        //currently returns a value of 1 for r = 0
        private double prob_density(double r)
        {
            double a0 = 0.0529;
            double part1 = Math.Pow(1 / a0, 1.5);
            double part2 = Math.Exp(-r/a0);
            double part3 = Math.Pow(r, 2);
            double interior = 2 * part1 * part2;

            double expression = Math.Pow(interior, 2) * part3;
            return expression;
        }

        private double calcX(double r, double theta)
        {
            return r * Math.Cos(theta);
        }

        private double calcY(double r, double theta)
        {
            return r * Math.Sin(theta);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            int num_points;

            label_error.Text = "";

            if (int.TryParse(text, out num_points)
                && num_points >= 1)
            {
                if (num_points > 10000)
                {
                    label_error.ForeColor = warning_color;
                    label_error.Text = "Warning: Maximum allowed input 10,000";

                    textBox1.Text = "10000";
                    num_points = 10000;
                }

                prev_input = num_points.ToString();
                updateGraphs(num_points);
            }
            else
            {
                label_error.ForeColor = error_color;
                label_error.Text = "Error: Input must be integer between 1 and 10,000 inclusive.";
                
                textBox1.Text = prev_input;
            }
        }
        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult result = chart1.HitTest(e.X, e.Y);
            System.Drawing.Point p = new System.Drawing.Point(e.X, e.Y);

            chart1.ChartAreas[0].CursorX.Interval = 0;
            chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(p, true);
            chart1.ChartAreas[0].CursorY.SetCursorPixelPosition(p, true);
        }
    }
}
