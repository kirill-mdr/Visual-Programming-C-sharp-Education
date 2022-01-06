using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            userControl11.IsCircle += new EventHandler(userControl11_IsCircle); //Подписка на событие
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userControl11.ClearTrajectory();
        }




        private void userControl11_IsCircle(object sender, EventArgs e)
        {
            MessageBox.Show("Нарисована окружность");
        }
    }
}
