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
namespace BlackBodyRadiationApplication
{
    public partial class Form1 : Form
    {
        double k = 1.3806488e-23 * 1e12;
        double h = 6.62606957e-34 * 1e12;
        double c = 3e8 * 1e6;

        int t1, t2, t3;
        bool use_t1, use_t2, use_t3; //t1 is required, t2 and t3 optional

        Color warning_color, error_color;

        public Form1()
        {
            InitializeComponent();

            pictureBox1.Image = Image.FromFile("help.png");

            warning_color = Color.HotPink;
            error_color = Color.Red;

            label_error.Text = "";
            label_error_t2.Text = "";
            label_error_t3.Text = "";

            t1 = trackBar1.Value;
            t2 = -1;
            t3 = -1;

            use_t1 = true;
            use_t2 = false;
            use_t3 = false;

            string info = "X: #VALX\nY: #VALY\nMinimum: #MIN{N2}\nMaximum: #MAX{N2}";

            chart1.Series[0].ToolTip = info;
            chart1.Series[1].ToolTip = info;
            chart1.Series[2].ToolTip = info;

            chart2.Series[0].ToolTip = info;
            chart2.Series[1].ToolTip = info;
            chart2.Series[2].ToolTip = info;

            chart1.Series[0].BorderWidth = 2;
            chart1.Series[1].BorderWidth = 2;
            chart1.Series[2].BorderWidth = 2;

            chart2.Series[0].BorderWidth = 2;
            chart2.Series[1].BorderWidth = 2;
            chart2.Series[2].BorderWidth = 2;

            chart1.ChartAreas[0].AxisX.Maximum = 3;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Interval = .50;

            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Interval = 1;
            chart1.ChartAreas[0].AxisX.Title = "wavelength (microns)";
            chart1.ChartAreas[0].AxisY.Title = "spectral intensity (W/m^2/uM) * 10^8";

            chart2.ChartAreas[0].AxisX.Maximum = 3;
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Interval = .50;
            chart2.ChartAreas[0].AxisY.Minimum = 0;
            chart2.ChartAreas[0].AxisY.Maximum = 600;
            updateGraphs();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            button_submit_Click(sender, e);
        }

        private void updateGraphs()
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();

            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();
            chart2.Series[2].Points.Clear();

            double total1 = 0;
            double total2 = 0;
            double total3 = 0;

            double I1;
            double I2;
            double I3;
            
            for (double i = 0.01; i < 3; i+=0.01)
            {
                // Check to see if we want to calculate t1
                if (use_t1)
                {
                    I1 = calcRadiation(i, t1);
                    total1 += I1;
                    chart1.Series[0].Points.AddXY(i, I1);
                    chart2.Series[0].Points.AddXY(i, total1);
                }

                // Check to see if we want to calculate t2
                if(use_t2)
                {
                    I2 = calcRadiation(i, t2);
                    total2 += I2;
                    chart1.Series[1].Points.AddXY(i, I2);
                    chart2.Series[1].Points.AddXY(i, total2);
                }

                // Check to see if we want to calculate t3
                if(use_t3)
                {
                    I3 = calcRadiation(i, t3);
                    total3 += I3;
                    chart1.Series[2].Points.AddXY(i, I3);
                    chart2.Series[2].Points.AddXY(i, total3);
                }
            }
        }

        double calcRadiation(double lambda, double T)
        {
            double top = 2 * Math.PI * h * Math.Pow(c, 2);

            double term1 = Math.Pow(lambda, 5);
            double term2 = h * c / (lambda * k * T);
            double bottom = term1 * (Math.Exp(term2) - 1);

            return (top / bottom) / 1e8;
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            label_error.Text = "";
            label_error_t2.Text = "";
            label_error_t3.Text = "";

            // Assume true until proven false
            use_t1 = true;
            use_t2 = true;
            use_t3 = true;

            // Check textBox1
            if (int.TryParse(textBox1.Text, out t1) && t1 >= 0)
            {
                if (t1 > trackBar1.Maximum)
                {
                    label_error.ForeColor = warning_color;
                    label_error.Text = "Warning: Input restricted to 10,000 maximum";

                    t1 = trackBar1.Maximum;
                    textBox1.Text = trackBar1.Maximum.ToString();
                }
                else if (t1 < trackBar1.Minimum)
                {
                    label_error.ForeColor = warning_color;
                    label_error.Text = "Warning: Input restricted to 300 minimum";

                    t1 = trackBar1.Minimum;
                    textBox1.Text = trackBar1.Minimum.ToString();
                }
                trackBar1.Value = t1;
            }
            else
            {
                label_error.ForeColor = error_color;
                label_error.Text = "Error: Text input must be integer between 300 and 10,000 inclusive";

                textBox1.Text = trackBar1.Value.ToString();
                t1 = trackBar1.Value;
            }

            // Check textBox2
            // If it has a positive int
            if(int.TryParse(textBox2.Text, out t2) && t2 >= 0)
            {
                if(t2 > trackBar1.Maximum)
                {
                    label_error_t2.ForeColor = warning_color;
                    label_error_t2.Text = "Warning: Input restricted to 10,000 maximum";

                    t2 = trackBar1.Maximum;
                    textBox2.Text = trackBar1.Maximum.ToString();
                }
                else if(t2 < trackBar1.Minimum)
                {
                    label_error_t2.ForeColor = warning_color;
                    label_error_t2.Text = "Warning: Input restricted to 300 minimum";

                    t2 = trackBar1.Minimum;
                    textBox2.Text = trackBar1.Minimum.ToString();
                }
            }
            // Else if it has non natural number input
            else if(textBox2.Text != "")
            {
                label_error_t2.ForeColor = error_color;
                label_error_t2.Text = "Error: Text input must be integer between 300 and 10,000 inclusive";

                textBox2.Text = "";

                use_t2 = false;
            }
            else // The text box is empty
            {
                use_t2 = false;
            }

            // Check textBox3
            // If it has a positive int
            if (int.TryParse(textBox3.Text, out t3) && t3 >= 0)
            {
                if (t3 > trackBar1.Maximum)
                {
                    label_error_t3.ForeColor = warning_color;
                    label_error_t3.Text = "Warning: Input restricted to 10,000 maximum";

                    t3 = trackBar1.Maximum;
                    textBox3.Text = trackBar1.Maximum.ToString();
                }
                else if (t3 < trackBar1.Minimum)
                {
                    label_error_t3.ForeColor = warning_color;
                    label_error_t3.Text = "Warning: Input restricted to 300 minimum";

                    t3 = trackBar1.Minimum;
                    textBox3.Text = trackBar1.Minimum.ToString();
                }
            }
            // Else if it has non natural number input
            else if (textBox3.Text != "")
            {
                label_error_t3.ForeColor = error_color;
                label_error_t3.Text = "Error: Text input must be integer between 300 and 10,000 inclusive";

                textBox3.Text = "";

                use_t3 = false;
            }
            else // The text box is empty
            {
                use_t3 = false;
            }
            
            // t1 is required
            if(use_t1)
            {
                updateGraphs();
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {
        
        }
    }
}
