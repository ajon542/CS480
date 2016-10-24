using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace comb1
{
    public partial class Form1 : Form
    {
        public double t, p, m;
        public Form1()
        {
            InitializeComponent();
        }

        private void Design_Click(object sender, EventArgs e)
        {
            int naca, thick, camb, cambd, front;
            float mask;
            p = 0.0;
            t = 0.0;
            m = 0.0;
            naca = int.Parse(comboBox1.Text);

            mask = (float)naca;
            mask = (float)(mask / 100.0);
            front = naca / 100;
            mask = (float)((mask - front) * 100.0 + 0.001);
            thick = (int)mask;
            MT.Text = thick.ToString() + " %";
            mask = (float)front;
            camb = front / 10;
            MXC.Text = camb.ToString() + " %";
            mask = (float)(mask / 10.0);
            mask = (float)((mask - camb) * 10.0);
            cambd = (int)(mask + 0.01);
            t = (float)(thick / 100.0);
            DtMc.Text = cambd.ToString() + "0%";
            t = (float)(thick / 100.0);
            p = (double)(cambd) / 10;
            m = (double)(camb) / 100.0;
            pictureBox1.BackColor = System.Drawing.Color.White;
            pictureBox1.Invalidate();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            listBox1.Items.Clear();
            Graphics g = e.Graphics;

            // Draw a string on the PictureBox.
            g.DrawString("Y", new Font("Arial", 10), System.Drawing.Brushes.Blue, new Point(0, 0));
            g.DrawString("X", new Font("Arial", 10), System.Drawing.Brushes.Blue, new Point(800, 200));

            g.DrawLine(System.Drawing.Pens.Red, 0, 200, 800, 200);
            g.DrawLine(System.Drawing.Pens.Red, 0, 0, 0, 400);
            float x, c, yt, temp, ts, tt, tf, r, dycdx, theta;
            int i, xl1, yl1, xu1, yu1, yc1, xl2, yl2, xu2, yu2, yc2, xc1, xc2;
            float[] xu, xl, yu, yl, yc;
            xl = new float[101];
            yl = new float[101];
            xu = new float[101];
            yu = new float[101];
            yc = new float[101];
            c = (float)1.0;
            xl1 = 0;
            yl1 = 200;
            xu1 = 0;
            yu1 = 200;
            yc1 = 200;
            xc1 = 0;

            for (i = 0; i <= 100; i++)
            {
                x = i;
                x = x / (float)100.0;
                temp = x / c;
                ts = temp * temp;
                tt = ts * temp;
                tf = tt * temp;
                yt = (float)(5.0 * t * c * (0.2969 * Math.Sqrt(temp) - 0.1260 * (temp) - 0.3516 * ts + 0.2843 * tt - 0.1015 * tf));
                if (p < 0.00001)
                {
                    yc[i] = (float)0.0;
                    dycdx = (float)0.0;
                    theta = (float)0.0;
                }
                else
                {
                    if (x <= p * c)
                    {
                        yc[i] = (float)(m * (x / (p * p)) * (2.0 * p - x / c));
                        dycdx = (float)((2.0 * m) / (p * p) * (p - x / c));
                    }
                    else
                    {
                        yc[i] = (float)(m * (c - x) / ((1 - p) * (1 - p)) * (1.0 + x / c - 2.0 * p));
                        dycdx = (float)((2.0 * m) / ((1 - p) * (1 - p)) * (p - x / c));
                    }
                    theta = (float)Math.Atan(dycdx);
                }
                xl[i] = (float)(x + yt * Math.Sin(theta));
                yl[i] = (float)(yc[i] - yt * Math.Cos(theta));
                xu[i] = (float)(x - yt * Math.Sin(theta));
                yu[i] = (float)(yc[i] + yt * Math.Cos(theta));

                listBox1.Items.Add("XL[" + i + "]=   " + xl[i] + "    YL[" + i + "]=     " + yl[i] + "     XU[" + i + "]=" + xu[i] + "    YU[" + i + "]=  " + yu[i] + "  YC[" + i + "]= " + yc[i]);
            }

            int p0 = 100;
            int p1 = 30;
            int p2 = 0;
            int p3 = 30;
            int p4 = 100;

            // Control points for the curve.
            List<Vector3D> airfoil = new List<Vector3D>
            {
                new Vector3D((800 * xu[p0]), 200 - (800 * yu[p0]), 0),
                new Vector3D((800 * xu[p1]), 200 - (800 * yu[p1]), 0),
                new Vector3D((800 * xu[p2]), 200 - (800 * yu[p2]), 0),
                new Vector3D((800 * xl[p3]), 200 - (800 * yl[p3]), 0),
                new Vector3D((800 * xl[p4]), 200 - (800 * yl[p4]), 0),
            };

            List<Vector3D> camber = new List<Vector3D>
            {
                new Vector3D(8 * 0, 200 - (800 * yc[0]), 0),
                new Vector3D(8 * 5, 200 - (800 * yc[5]), 0),
                new Vector3D(8 * 20, 200 - (800 * yc[20]), 0),
                new Vector3D(8 * 50, 200 - (800 * yc[50]), 0),
                new Vector3D(8 * 100, 200 - (800 * yc[100]), 0),
            };

            GameObject airfoilSpline = new NaturalSpline(airfoil);
            GameObject camberSpline = new NaturalSpline(camber);

            airfoilSpline.Render(g);
            camberSpline.Render(g);

            /*for (i = 0; i <= 100; i++)
            {
                xl2 = (int)(800 * xl[i]);
                yl2 = 200 - (int)(800 * yl[i]);
                g.DrawLine(System.Drawing.Pens.Red, xl1, yl1, xl2, yl2);
                xl1 = xl2;
                yl1 = yl2;

                xu2 = (int)(800 * xu[i]);
                yu2 = 200 - (int)(800 * yu[i]);
                g.DrawLine(System.Drawing.Pens.Red, xu1, yu1, xu2, yu2);
                xu1 = xu2;
                yu1 = yu2;

                xc2 = 8 * i;
                yc2 = 200 - (int)(800 * yc[i]);
                g.DrawLine(System.Drawing.Pens.Blue, xc1, yc1, xc2, yc2);
                xc1 = xc2;
                yc1 = yc2;
            }*/


            r = (float)(1.1019 * t * t);

            CRALE.Text = r.ToString();
        }
    }
}
