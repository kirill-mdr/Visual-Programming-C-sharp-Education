using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_6
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void nuPogodi1_Load(object sender, EventArgs e)
        {

        }

        private void nuPogodi1_RedButtonClick(object sender, RedButtonEventArgs e)
        {
            nuPogodi1.BasketPosition = e.NumberRedButton;
        }
    }
}
