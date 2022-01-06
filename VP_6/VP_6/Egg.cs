using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_6
{
    class Egg
    {
        public int Basket { get; set; }
        public int Position { get; set; }
        public Egg()
        {
            Random rnd = new Random();
            Basket = rnd.Next(0,3);
            Position = 0;
        }
        public void NextPosition()
        {
            Position++;
        }
    }
}
