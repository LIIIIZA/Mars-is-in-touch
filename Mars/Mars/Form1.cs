using System;
using System.Numerics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Linq;

namespace Mars
{
    public partial class MainForm : Form
    {
        static private double EFT = 187 * 24 * 3600;
        static private double G = 6.67 * 1e-20;
        static private double M = 5.97 * 1e24;
        static private double R = 6371;
        static private double Rho_air = 1.23;
        static private double M_m = 6.4171 * 1e23;
        static private double R_m = 3389.5;
        static private double M_r = 688845;
        static private double d_m = 1744;
        static private double S_r = 43;
        static private double F1 = 10470;
        static private double F2 = 2400;
        static private double t_n = 330;
        static private double F3 = 613.8;
        static private double X_s = 0; // shoueld be 15000000
        static private double X_m = 212996611;
        static private double M_r1 = 31100;
        static private double M_r2 = 11715;
        static private double default_d_t = 1.0;
        static private double default_min_t = 0;
        static private double default_max_t = 250;
        double v1, v2, v3, v4;
        double X1, X2, X3, X4, X5;
        int debugSwitch;

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            labelStatusMessage.Text = "";
            double d_t;
            if (!Double.TryParse(textBoxDT.Text, out d_t) && textBoxDT.Text != "")
            {
                labelStatusMessage.Text += "Warning: cannot parse d_t. Set to default value: " + default_d_t.ToString() + "\n";
            }
            else
            {
                if (textBoxDT.Text == "")
                {
                    labelStatusMessage.Text += "d_t set to default value: " + default_d_t.ToString() + "\n";
                }
                else
                {
                    labelStatusMessage.Text += "d_t parsed successfully.\n";
                }
            }
            if (d_t == 0)
            {
                d_t = default_d_t;
            }
            double min_t;
            if (!Double.TryParse(textBoxMinT.Text, out min_t) && textBoxMinT.Text != "")
            {
                labelStatusMessage.Text += "Warning: cannot parse min_t. Set to default value: " + default_min_t.ToString() + "\n";
            }
            else
            {
                if (textBoxMinT.Text == "")
                {
                    labelStatusMessage.Text += "min_t set to default value: " + default_min_t.ToString() + "\n";
                }
                else
                {
                    labelStatusMessage.Text += "min_t parsed successfully.\n";
                }
            }
            if (min_t == 0)
            {
                min_t = default_min_t;
            }
            double max_t;
            if (!Double.TryParse(textBoxMaxT.Text, out max_t) && textBoxMaxT.Text != "")
            {
                labelStatusMessage.Text += "Warning: cannot parse max_t. Set to default value: " + default_max_t.ToString() + "\n";
            }
            else
            {
                if (textBoxMaxT.Text == "")
                {
                    labelStatusMessage.Text += "max_t set to default value: " + default_max_t.ToString() + "\n";
                }
                else
                {
                    labelStatusMessage.Text += "max_t parsed successfully.\n";
                }
            }
            if (max_t == 0)
            {
                max_t = default_max_t;
            }
            calculateSeries(d_t, min_t, max_t);
        }

        List<(double X, double Y)> points;

        private double pow2(double v)
        {
            return v * v;
        }

        private double pow3(double v)
        {
            return v * v * v;
        }

        private double calculateX(double cur_X, double cur_t)
        {
            double m_r = M_r - d_m * cur_t;
            if (cur_t >= 124)
            {
                m_r -= M_r1;
            }
            if (cur_t >= 330)
            {
                m_r -= M_r2;
            }
            if (cur_X <= X_s + 30)
            {
                double h1 = cur_X - X_s;
                double rho_air = (30 - h1) * Rho_air;
                double A = F1 / m_r - G * M / pow2(R + h1) - (rho_air * pow2(F1) * S_r / (2 * pow3(m_r))) * 0.3;
                v1 = A * cur_t;
                X1 = X_s + v1 * cur_t + A * pow2(cur_t) / 2;
                debugSwitch = 1;
                return X1;
            }
            else if (cur_t <= 124)
            {
                double h1 = cur_X - X_s;
                double B = F1 / m_r - G * M / pow2(R + h1);
                v2 = v1 + B * (cur_t - 37);
                X2 = X_s + v2 * cur_t + B * pow2(cur_t) / 2;
                debugSwitch = 2;
                return X2;
            }
            else if (cur_t <= 330)
            {
                double h1 = cur_X - X_s;
                double C = F2 / m_r - G * M / pow2(R + h1);
                v3 = v2 + C * (cur_t - 124);
                double Xx = X_s + X2 + v3 * cur_t + C * pow2(cur_t - 124) / 2;
                if (Xx < cur_X && cur_X < 212800000 - 15000000)
                {
                    X3 = X_s + Xx + v3 * cur_t;
                    debugSwitch = 3;
                    return X3;
                }
                else if (v3 <= 3.55)
                {
                    double h2 = X_m - 15000000 - cur_X;
                    double D = F3 / m_r + G * M_m / pow2(R_m + h2);
                    v4 = v3 + D * cur_t;
                    X4 = X_s + X3 + v4 * cur_t + D * pow2(cur_t) / 2;
                    debugSwitch = 4;
                    return X4;
                }
                else if (v3 > 3.55)
                {
                    X5 = X_s + X4 + v4 * cur_t;
                    debugSwitch = 5;
                    return X5;
                }
                else
                {
                    debugSwitch = 0;
                    return cur_X;
                }
            }
            else
            {
                debugSwitch = 0;
                return cur_X;
            }
        }

        private void calculateSeries(double d_t, double min_t, double max_t)
        {
            points = new List<(double X, double Y)>();
            X1 = X2 = X3 = X4 = X5 = 0;
            v1 = v2 = v3 = 0;
            double X = X_s;
            double Y;
            double t = 0;
            while (t <= 330)
            {
                t += d_t;
                X = calculateX(X, t);
                Y = 1.85 * (t / EFT);
                if (min_t <= t && t <= max_t)
                {
                    points.Add((X, Y));
                }
            }
            chartTrajectory.Series["Trajectory"].Points.Clear();
            foreach ((double X, double Y) point in points)
            {
                chartTrajectory.Series["Trajectory"].Points.AddXY(point.X, point.Y);
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }
    }
}
