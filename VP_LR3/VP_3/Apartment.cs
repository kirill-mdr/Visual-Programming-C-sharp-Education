using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_3
{
    class Apartment : Room 
    {
        private int toilet;
        private int bathroom;
        private int kitchen;
        private int hallway;

        public Apartment(int length, int width, int height, int toilet, int bathroom, int kitchen, int hallway) : base(length, width, height)
        {
            this.Toilet = toilet;
            this.Bathroom = bathroom;
            this.Kitchen = kitchen;
            this.hallway = hallway;
            
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
        public int Bathroom
        {
            get
            {
                return bathroom;
            }
            set
            {
                if (value >= 1) bathroom = value;
                else throw new Exception("Значение площади должно быть больше 1.");
            }
        }
        public int Kitchen
        {
            get
            {
                return kitchen;
            }
            set
            {
                if (value >= 1) kitchen = value;
                else throw new Exception("Значение площади должно быть больше 1.");
            }
        }
        public int Hallway
        {
            get
            {
                return hallway;
            }
            set
            {
                if (value >= 1) hallway = value;
                else throw new Exception("Значение площади должно быть больше 1.");
            }
        }
        override public int GetArea()
        {
            return base.GetArea() + Kitchen + Bathroom + Toilet + Hallway;
        }
        public int GetLivedArea()
        {
            return base.GetArea();
        }
    }
}
