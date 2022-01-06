using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MouseTrajectory
{
    public partial class UserControl1 : UserControl
    {
        Graphics g;
        List<int> xPoints = new List<int>();
        List<int> yPoints = new List<int>();
        int xMin, xMax, yMin, yMax;
        bool first = false;
        bool second = false;
        bool third = false;
        bool fourth = false;
        bool isCircle = false;

        public event EventHandler IsCircle;



        public UserControl1()
        {
            
            InitializeComponent();
            g = panel1.CreateGraphics();
            xMax = 0;
            xMin = panel1.Width;
            yMax = 0;
            yMin = panel1.Height;
        }

        
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

            label1.Text = e.Location.ToString();
            if (e.Button == MouseButtons.Left) //Рисование окружности
            {
                
                g.DrawRectangle(new Pen(Color.Black), e.X, e.Y, 1, 1);
                xPoints.Add(e.X);
                yPoints.Add(e.Y);
                if (e.X < xMin) xMin = e.X;
                if (e.X > xMax) xMax = e.X;
                if (e.Y < yMin) yMin = e.Y;
                if (e.Y > yMax) yMax = e.Y;

            }
            label2.Text = "xMin = " + xMin + "  xMax = " + xMax + "  yMin = " + yMin + "  yMax = " + yMax;


        }
        public void ClearTrajectory()
        {
            g.Clear(SystemColors.Control);
            xPoints.Clear();
            yPoints.Clear();
            xMax = 0;
            xMin = panel1.Width;
            yMax = 0;
            yMin = panel1.Height;

            first = false;
            second = false;
            third = false;
            fourth = false;
            isCircle = false;
        }
        public void CheckCircle()
        {
            if (xMax-xMin > yMax - yMin) //Расширение до квадрата
            {
                int delta = (xMax - xMin) - (yMax - yMin); 
                yMin = yMin - delta / 2;
                yMax = yMax + delta / 2;
            }
            else
            {
                int delta = (yMax - yMin) - (xMax - xMin); //Расширение до квадрата
                xMin = xMin - delta / 2;
                xMax = xMax + delta / 2;

            }
            int yCenter = (yMin+yMax)/2; //Поиск центров по осям
            int xCenter = (xMin+xMax)/2;

            label2.Text = "xMin = " + xMin + "  xMax = " + xMax + "  yMin = " + yMin + "  yMax = " + yMax;

            int radius = (xMax - xMin) / 2;
            int maxRadius = (int)(radius * 1.2); // Допустимый радиус
            int minRadius = (int)(radius * 0.7);

            int tR = radius / 3;

            
            for (int i = 0; i < xPoints.Count; i++) //Перебор всех точек и проверка радиуса
            {
                //Проверка на четверти, чтобы окружность была почти замкнутой
                if (xPoints[i] > xCenter && xPoints[i] < xMax && yPoints[i] > yMin + tR && yPoints[i] < yCenter - tR) first = true;
                if (xPoints[i] > xMin && xPoints[i] < xCenter && yPoints[i] > yMin + tR && yPoints[i] < yCenter - tR) second = true;
                if (xPoints[i] > xMin && xPoints[i] < xCenter && yPoints[i] > yCenter + tR && yPoints[i] < yMax - tR) third = true;
                if (xPoints[i] > xCenter && xPoints[i] < xMax && yPoints[i] > yCenter + tR && yPoints[i] < yMax - tR) fourth = true;


                int tempY = Math.Abs(yCenter - yPoints[i]);
                int tempX  = Math.Abs(xCenter - xPoints[i]);
                //Вычисление радиуса точки
                int tempRadius = (int)Math.Sqrt(tempY * tempY + tempX * tempX);
                if (tempRadius < maxRadius && tempRadius > minRadius)
                {
                    isCircle = true;
                }
                else
                {
                    isCircle = false;
                    break;
                }
            }
            //MessageBox.Show(first.ToString() + " " + second.ToString() + " " + third.ToString() + " " + fourth.ToString());
            if (isCircle && first && second && third && fourth)
            {
                
                IsCircle(this, new EventArgs()); //Отправка события
            }

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CheckCircle();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
