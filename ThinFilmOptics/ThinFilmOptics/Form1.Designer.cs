namespace ThinFilmOptics
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label_error_d = new System.Windows.Forms.Label();
            this.label_error_theta = new System.Windows.Forms.Label();
            this.label_error_n2 = new System.Windows.Forms.Label();
            this.button_submit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.track_bar_d = new System.Windows.Forms.TrackBar();
            this.text_box_n2 = new System.Windows.Forms.TextBox();
            this.text_box_theta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.text_box_d = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track_bar_d)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(828, 435);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label_error_d);
            this.tabPage1.Controls.Add(this.label_error_theta);
            this.tabPage1.Controls.Add(this.label_error_n2);
            this.tabPage1.Controls.Add(this.button_submit);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.track_bar_d);
            this.tabPage1.Controls.Add(this.text_box_n2);
            this.tabPage1.Controls.Add(this.text_box_theta);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.text_box_d);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(820, 409);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thin Film Optics";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label_error_d
            // 
            this.label_error_d.AutoSize = true;
            this.label_error_d.Location = new System.Drawing.Point(300, 325);
            this.label_error_d.Name = "label_error_d";
            this.label_error_d.Size = new System.Drawing.Size(0, 13);
            this.label_error_d.TabIndex = 13;
            // 
            // label_error_theta
            // 
            this.label_error_theta.AutoSize = true;
            this.label_error_theta.Location = new System.Drawing.Point(300, 301);
            this.label_error_theta.Name = "label_error_theta";
            this.label_error_theta.Size = new System.Drawing.Size(0, 13);
            this.label_error_theta.TabIndex = 12;
            // 
            // label_error_n2
            // 
            this.label_error_n2.AutoSize = true;
            this.label_error_n2.Location = new System.Drawing.Point(300, 280);
            this.label_error_n2.Name = "label_error_n2";
            this.label_error_n2.Size = new System.Drawing.Size(0, 13);
            this.label_error_n2.TabIndex = 11;
            // 
            // button_submit
            // 
            this.button_submit.Location = new System.Drawing.Point(275, 376);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(75, 23);
            this.button_submit.TabIndex = 10;
            this.button_submit.Text = "Submit";
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(272, 354);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Slider for d (nm)";
            // 
            // track_bar_d
            // 
            this.track_bar_d.Location = new System.Drawing.Point(6, 354);
            this.track_bar_d.Maximum = 5000;
            this.track_bar_d.Minimum = 10;
            this.track_bar_d.Name = "track_bar_d";
            this.track_bar_d.Size = new System.Drawing.Size(191, 45);
            this.track_bar_d.TabIndex = 8;
            this.track_bar_d.Value = 10;
            this.track_bar_d.Scroll += new System.EventHandler(this.track_bar_d_Scroll);
            // 
            // text_box_n2
            // 
            this.text_box_n2.Location = new System.Drawing.Point(58, 273);
            this.text_box_n2.Name = "text_box_n2";
            this.text_box_n2.Size = new System.Drawing.Size(100, 20);
            this.text_box_n2.TabIndex = 7;
            // 
            // text_box_theta
            // 
            this.text_box_theta.Location = new System.Drawing.Point(58, 299);
            this.text_box_theta.Name = "text_box_theta";
            this.text_box_theta.Size = new System.Drawing.Size(100, 20);
            this.text_box_theta.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Enter incident angle theta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Enter thickness d (nm)";
            // 
            // text_box_d
            // 
            this.text_box_d.Location = new System.Drawing.Point(58, 325);
            this.text_box_d.Name = "text_box_d";
            this.text_box_d.Size = new System.Drawing.Size(100, 20);
            this.text_box_d.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter refractive index n2";
            // 
            // chart1
            // 
            this.chart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(6, 7);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chart1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.LabelBackColor = System.Drawing.Color.White;
            series1.LabelBorderColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "P-Polar";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "S-Polar";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(808, 260);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "ITO on Glass JUL22";
            this.chart1.Titles.Add(title1);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(820, 409);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Help";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(5, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(809, 397);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 459);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Thin Film Optics";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track_bar_d)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox text_box_d;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_box_n2;
        private System.Windows.Forms.TextBox text_box_theta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar track_bar_d;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_error_d;
        private System.Windows.Forms.Label label_error_theta;
        private System.Windows.Forms.Label label_error_n2;
    }
}

