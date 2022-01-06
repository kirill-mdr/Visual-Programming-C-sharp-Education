using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WP_LR1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "cm")
            {
                if (radioButton1.Checked)
                {
                    textBox3.Text = "21.0cm";
                    textBox4.Text = "29,7cm";
                }
                else if (radioButton2.Checked)
                {
                    textBox3.Text = "29,7cm";
                    textBox4.Text = "21.0cm";
                }
            }
            else if (comboBox2.SelectedItem.ToString() == "inch")
            {
                if (radioButton1.Checked)
                {
                    textBox3.Text = "8.3inch";
                    textBox4.Text = "11.7inch";
                }
                else if (radioButton2.Checked)
                {
                    textBox3.Text = "11.7inch";
                    textBox4.Text = "8.3inch";
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
