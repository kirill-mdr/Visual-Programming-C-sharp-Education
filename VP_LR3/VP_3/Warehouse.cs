using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_3
{
    public class Warehouse : Room
    {
        override public int Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value >= 3) height = value;
                else throw new Exception("Значение высоты должно быть больше 3.");
            }
        }
        public Warehouse(int length, int width, int height) : base(length, width, height)
        {
            
        }
    }
}
