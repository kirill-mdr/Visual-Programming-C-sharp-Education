using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_3
{
    class Office : Room
    {
        private int toilet;

        public Office (int length, int width, int height, int toilet) : base(length, width, height)
        {
            this.Toilet = toilet;
        }
        public int Toilet
        {
            get
            {
                return toilet;
            }
            set
            {
                if (value >= 1) toilet = value;
                else throw new Exception("Значение площади должно быть больше 1.");
            }
        }
        override public int GetArea()
        {
            return base.GetArea() + Toilet;
        }
        public int GetNoLivedArea()
        {
            return base.GetArea();
        }

    }
}
