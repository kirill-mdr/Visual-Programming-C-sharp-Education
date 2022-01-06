using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Threading;

namespace VP_9
{
    public partial class Form1 : Form
    {
        int A = 5;
        int W = 1;
        const int N = 100;
        double h = Math.PI / 100;
        Point[] points = new Point[N];
        double[] v = new double[N];
        Complex[] x = new Complex[N];
        public Form1()
        {
            
            InitializeComponent();
            for (int i = 0; i < N; i++)
            {
                v[i] = Func(i);
            }
            DPF(0,100);
                MessageBox.Show(points[84].ToString());
            Draw();


        }
        public void DPF(int first, int last)
        {
            for (int i = first; i < last; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    double temp = -2 * Math.PI * i * j / N;

                    x[i] += v[j] * Complex.Exp(new Complex(0, temp));
                   
                }
                points[i] = new Point((int)(i * h * 10), (int)x[i].Magnitude);
                //MessageBox.Show(points[i].ToString());
                listBox1.Items.Add(points[i].ToString());
            }


        }
        public void Draw()
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Black, 3f);
            graphics.DrawLines(pen, points);
        }
        public double Func(int i)
        {
            return A * Math.Sin(i * h * W);
        }
    }
}
