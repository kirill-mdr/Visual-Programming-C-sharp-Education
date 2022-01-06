using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_6
{
    public class RedButtonEventArgs : EventArgs
    {
        public int NumberRedButton { get; set; }
        public RedButtonEventArgs(int numberRedButton)
        {
            this.NumberRedButton = numberRedButton;
        }
    }
}
