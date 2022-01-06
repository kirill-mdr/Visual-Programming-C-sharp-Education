using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_3
{
    public abstract class Room
    {
        protected int length;
        protected int width;
        protected int height;
        public Room()
        {

        }
        public Room(int length, int width, int height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                if (value >= 1) length = value;
                else throw new Exception("Значение длины должно быть больше 1.");
            }
        }
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value >= 1) width = value;
                else throw new Exception("Значение ширины должно быть больше 1.");
            }
        }
        virtual public int Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value >= 2) height = value;
                else throw new Exception("Значение высоты должно быть больше 2.");
            }
        }

        virtual public int GetArea()
        {
            return length * width;
        }
        public int GetVolume()
        {
            return length * width * height;
        }


    }
}
