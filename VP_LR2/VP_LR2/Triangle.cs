using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_LR2
{
    public class Triangle
    {
        private double a;
        private double b;
        private double c;

        public double A 
        {
            get
            {
                return a;
            }
            set
            {
                if (value > 0) a = value;
                else a = 0;
            }
        }
        public double B
        {
            get
            {
                return b;
            }
            set
            {
                if (value > 0) b = value;
                else b = 0;
            }
        }
        public double C
        {
            get
            {
                return c;
            }
            set
            {
                if (value > 0) c = value;
                else c = 0;
            }
        }
        public Triangle()
        {

        }
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        /// <summary>
        /// Возвращает булевое значение, существует ли такой треугольник.
        /// </summary>
        public bool IsReal
        {
            get
            {
                return (a + b > c) && (b + c > a) && (c + a > b);
            } 
                
        }
        /// <summary>
        /// Возвращает угол противолежащей стороны.
        /// </summary>
        /// <param name="sideName"></param>
        /// <returns></returns>
        public double OppositeAngle(string sideName)
        {

            if (sideName == "a")
            {
                return 180 / Math.PI * (Math.Acos((Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * c * b)));
            }
            else if (sideName == "b")
            {
                return 180 / Math.PI * (Math.Acos((Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) / (2 * a * c)));
            }
            else if (sideName == "c")
            {
                return 180 / Math.PI * (Math.Acos((Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / (2 * a * b)));
            }
            else return 0;
            
        }
        /// <summary>
        /// Возвращает периметр треугольника.
        /// </summary>
        /// <returns></returns>
        public double GetPerimeter()
        {
            return a+b+c;
        }
        
        /// <summary>
        /// Возвращает площадь треугольника.
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            double halfPerimetr = GetPerimeter() / 2;
            return Math.Sqrt(halfPerimetr*(halfPerimetr-a)*(halfPerimetr-b)*(halfPerimetr-c));
        }

        /// <summary>
        /// Статический метод для получения периметра треугольника.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static double GetPerimetrStatic(double a, double b, double c)
        {
            return a + b + c;
        }
        override public string ToString()
        {
            return "Треугольник со сторонами: " + a + "," + b + "," + c + ". P=" + GetPerimeter();
        }
    }
}
