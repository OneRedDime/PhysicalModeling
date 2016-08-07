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

namespace ThinFilmOptics
{
    public partial class Form1 : Form
    {
        private const double N1 = 1;
        private const double N3 = 3.5;

        private double theta1, theta2, theta3, n2;
        int d;

        string prev_n2, prev_d, prev_theta;

        Color error_color, warning_color;

        public Form1()
        {
            InitializeComponent();

            pictureBox1.Image = Image.FromFile("help.png");

            error_color = Color.Red;
            warning_color = Color.HotPink;

            string info = "X: #VALX\nY: #VALY\nMinimum: #MIN{N2}\nMaximum: #MAX{N2}";

            chart1.Series[0].ToolTip = info;
            chart1.Series[1].ToolTip = info;

            chart1.Series[0].BorderWidth = 2;
            chart1.Series[1].BorderWidth = 2;

            chart1.ChartAreas[0].AxisX.Title = "Wavelength (nm)";
            chart1.ChartAreas[0].AxisX.Minimum = 300;
            chart1.ChartAreas[0].AxisX.Maximum = 900;
            chart1.ChartAreas[0].AxisX.Interval = 50;

            chart1.ChartAreas[0].AxisY.Title = "% reflectance";
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Interval = 10;

            // Set initial value for text box n2
            text_box_n2.Text = "1.5";
            prev_n2 = text_box_n2.Text;

            // Set initial value for text box theta
            text_box_theta.Text = "0";
            prev_theta = text_box_theta.Text;

            // Set initial value for text box d
            text_box_d.Text = "10";
            prev_d = text_box_d.Text;

            // Convert the thetas to radians before updating the graph
            theta1 = convertToRadians(theta1);
            theta2 = Math.Asin(N1 * Math.Sin(theta1) / n2);
            theta3 = Math.Asin(n2 * Math.Sin(theta2) / N3);

            updateGraphs();
        }

        private void updateGraphs()
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            for (int i = 300; i <= chart1.ChartAreas[0].AxisX.Maximum; i++)
            {
                chart1.Series[0].Points.AddXY(i, refp(i) * 100);
                chart1.Series[1].Points.AddXY(i, refs(i) * 100);
            }
        }
        double refp(double lambda)
        {
            double a = r12p() * Math.Pow(r23p(), 2) * Math.Pow(Math.Sin(2 * beta(lambda)), 2) 
                + r12p() 
                + Math.Pow(r12p(), 2) * r23p() * Math.Cos(2 * beta(lambda))
                + r23p() * Math.Cos(2 * beta(lambda)) 
                + r12p() * Math.Pow(r23p(), 2) * Math.Pow(Math.Cos(2 * beta(lambda)), 2);
            double b = Math.Pow(r12p(), 2) * r23p() * Math.Sin(2 * beta(lambda))
                + r12p() * Math.Pow(r23p(), 2) * Math.Sin(2 * beta(lambda)) * Math.Cos(2 * beta(lambda))
                - r23p() * Math.Sin(2 * beta(lambda))
                - r12p() * Math.Pow(r23p(), 2) * Math.Sin(2 * beta(lambda)) * Math.Cos(2 * beta(lambda));
            double denom = Math.Pow(1 + r12p() * r23p() * Math.Cos(2 * beta(lambda)), 2)
                + Math.Pow(r12p(), 2) * Math.Pow(r23p(), 2) * Math.Pow(Math.Sin(2 * beta(lambda)), 2);

            return (Math.Pow(a, 2) + Math.Pow(b, 2)) / denom;
        }
        double r12p()
        {
            double top = n2 * Math.Cos(theta1) - N1 * Math.Cos(theta2);
            double bot = n2 * Math.Cos(theta1) + N1 * Math.Cos(theta2);
            return top / bot;
        }
        double r23p()
        {
            double top = N3 * Math.Cos(theta2) - n2 * Math.Cos(theta3);
            double bot = N3 * Math.Cos(theta2) + n2 * Math.Cos(theta3);
            return top / bot;
        }
        double refs(double lambda)
        {
            double a = r12s() * Math.Pow(r23s(), 2) * Math.Pow(Math.Sin(2 * beta(lambda)), 2)
                + r12s()
                + Math.Pow(r12s(), 2) * r23s() * Math.Cos(2 * beta(lambda))
                + r23s() * Math.Cos(2 * beta(lambda))
                + r12s() * Math.Pow(r23s(), 2) * Math.Pow(Math.Cos(2 * beta(lambda)), 2);
            double b = Math.Pow(r12s(), 2) * r23s() * Math.Sin(2 * beta(lambda))
                + r12s() * Math.Pow(r23s(), 2) * Math.Sin(2 * beta(lambda)) * Math.Cos(2 * beta(lambda))
                - r23s() * Math.Sin(2 * beta(lambda))
                - r12s() * Math.Pow(r23s(), 2) * Math.Sin(2 * beta(lambda)) * Math.Cos(2 * beta(lambda));
            double denom = Math.Pow(1 + r12s() * r23s() * Math.Cos(2 * beta(lambda)), 2)
                + Math.Pow(r12s(), 2) * Math.Pow(r23s(), 2) * Math.Pow(Math.Sin(2 * beta(lambda)), 2);

            return (Math.Pow(a, 2) + Math.Pow(b, 2)) / denom;

        }
        double r12s()
        {
            double top = N1 * Math.Cos(theta1) - n2 * Math.Cos(theta2);
            double bot = N1 * Math.Cos(theta1) + n2 * Math.Cos(theta2);
            return top / bot;
        }
        double r23s()
        {
            double top = n2 * Math.Cos(theta2) - N3 * Math.Cos(theta3);
            double bot = n2 * Math.Cos(theta2) + N3 * Math.Cos(theta3);
            return top / bot;
        }
        double beta(double lambda)
        {
            return 2 * Math.PI * (d / lambda) * N1 * Math.Cos(theta1);
        }
        double convertToRadians(double theta)
        {
            return (Math.PI / 180) * theta;
        }
        private void button_submit_Click(object sender, EventArgs e)
        {
            bool valid_input = true;

            label_error_n2.Text = "";
            label_error_theta.Text = "";
            label_error_d.Text = "";
           
            // Check input for text box n2
            if (double.TryParse(text_box_n2.Text, out n2)
                && n2 >= 1
                && n2 <= 10)
            {
                prev_n2 = text_box_n2.Text;
            }
            else if (double.TryParse(text_box_n2.Text, out n2)
                && n2 <= 1
                && n2 >= 0)
            {
                label_error_n2.ForeColor = warning_color;
                label_error_n2.Text = "Warning: Refraction index restricted to minimum value 1";

                text_box_n2.Text = "1";
                prev_n2 = text_box_n2.Text;
                n2 = 1;
            }
            else if (double.TryParse(text_box_n2.Text, out n2)
                && n2 > 10)
            {
                label_error_n2.ForeColor = warning_color;
                label_error_n2.Text = "Warning: Refraction index restricted to maximum value 10";
                
                text_box_n2.Text = "10";
                prev_n2 = text_box_n2.Text;
                n2 = 10;
            }
            else
            {
                label_error_n2.ForeColor = error_color;
                label_error_n2.Text = "Error: Refractive index must be a positive numeric between 1 and 3 inclusive";
                
                text_box_n2.Text = prev_n2;
                valid_input = false;
            }

            // Check input for text box d
            if (int.TryParse(text_box_d.Text, out d)
                && d >= 10
                && d <= 5000)
            {
                prev_d = text_box_d.Text;
                track_bar_d.Value = d;
            }
            else if (int.TryParse(text_box_d.Text, out d)
                && d < 10
                && d >= 0)
            {
                label_error_d.ForeColor = warning_color;
                label_error_d.Text = "Warning: Thickness restricted to minimum value 10nm";
                text_box_d.Text = "10";
                prev_d = text_box_d.Text;
                d = 10;
                track_bar_d.Value = d;
            }
            else if (int.TryParse(text_box_d.Text, out d)
                && d > 5000)
            {
                label_error_d.ForeColor = warning_color;
                label_error_d.Text = "Warning: Thickness restricted to maximum value 5,000nm";
                text_box_d.Text = "5000";
                prev_d = text_box_d.Text;
                d = 5000;
                track_bar_d.Value = d;
            }
            else
            {
                label_error_d.ForeColor = error_color;
                label_error_d.Text = "Error: Thickness must be integer between 10 and 5,000 inclusive";
                
                text_box_d.Text = prev_d;
                valid_input = false;
            }

            // Check input for text box theta
            if (double.TryParse(text_box_theta.Text, out theta1)
                && theta1 >= 0
                && theta1 <= 45)
            {
                prev_theta = text_box_theta.Text;
            }
            else if (double.TryParse(text_box_theta.Text, out theta1)
                && theta1 > 45)
            {
                label_error_theta.ForeColor = warning_color;
                label_error_theta.Text = "Warning: Incident angle restricted to maximum value of 45 degrees";
                text_box_theta.Text = "45";
                prev_theta = text_box_theta.Text;
                theta1 = 45;
            }
            else
            {
                label_error_theta.ForeColor = error_color;
                label_error_theta.Text = "Error: Incident angle must be numeric value between 0 and 45 degrees inclusive";
                
                text_box_theta.Text = prev_theta;
                valid_input = false;
            }

            // If all input fields were valid, or just a little out of range
            if (valid_input)
            {
                // Convert the thetas to radians before updating the graph
                theta1 = convertToRadians(theta1);
                theta2 = Math.Asin(N1 * Math.Sin(theta1) / n2);
                theta3 = Math.Asin(n2 * Math.Sin(theta2) / N3);

                updateGraphs();
            }
        }

        private void track_bar_d_Scroll(object sender, EventArgs e)
        {
            text_box_d.Text = track_bar_d.Value.ToString();
            button_submit_Click(sender, e);
        }
        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult result = chart1.HitTest(e.X, e.Y);
            System.Drawing.Point p = new System.Drawing.Point(e.X, e.Y);

            chart1.ChartAreas[0].CursorX.Interval = 0;
            chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(p, true);
            chart1.ChartAreas[0].CursorY.SetCursorPixelPosition(p, true);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
