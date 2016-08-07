using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThinFilmOptics
{
    public partial class ThinFilmOptics : Form
    {
        public ThinFilmOptics()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            updateGraphs();
        }

        private void updateGraphs()
        {
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            for (int i = 0; i < 1000; i++)
            {
                if (i * trackBar1.Value >= 50000)
                {
                    chart1.Series[0].Points.AddXY(i, 500);
                    chart2.Series[0].Points.AddXY(i, 500);
                }
                else
                {
                    chart1.Series[0].Points.AddXY(i, i * trackBar1.Value);
                    chart2.Series[0].Points.AddXY(i, i * trackBar1.Value);
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            updateGraphs();
        }
    }
}
