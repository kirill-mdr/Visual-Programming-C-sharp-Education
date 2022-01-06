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
        static readonly object _object = new object();
        int A = 5;
        int W = 2;
        const int N = 800;
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

        }
        public void DPF(int first, int last)
        {
            for (int i = first; i < last; i++)
            {
                for (int j = 0; j < N; j++)
                {

                    double koeff = 2 * Math.PI * i * j / N;
                    Complex e = new Complex(Math.Cos(koeff), -Math.Sin(koeff));
                    x[i] += v[j] * e;
                }
                points[i] = new Point((int)(i), (int)x[i].Magnitude / 3);
                //MessageBox.Show(points[i].ToString());
            }
        }
            
        //public void UnDPF(int first, int last)
        //{
        //    List<Complex> res = new List<Complex>();
        //    for (int i = first; i < last; i++)
        //    {
        //        Complex summa = new Complex();
        //        for (int j = 0; j < N; j++)
        //        {
        //            double koeff = 2 * Math.PI * j * i / N;
        //            Complex e = new Complex(Math.Cos(koeff), Math.Sin(koeff));
        //            summa += (x[i] * e / N);
        //        }
        //        //MessageBox.Show(summa.Magnitude.ToString());
        //        points[i] = new Point((int)(i), (int)(summa.Magnitude));

        //    }
        //}

        public void Draw(Color clr)
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            Pen pen = new Pen(clr, 3f);
            graphics.DrawLines(pen, points);
        }
        public double Func(int i)
        {
            return A * Math.Sin(i * W);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(FirstThread));
            Thread t1 = new Thread(new ThreadStart(SecondThread));
            t.IsBackground = true;
            t1.IsBackground = true;
            t.Start();
            t1.Start();
            Thread.Sleep(100);
            Draw(Color.Blue);
        }


        private void FirstThread()
        {
                DPF(0, 400);          
        }
        private void SecondThread()
        {
                DPF(400, N);
        }
    }
}
