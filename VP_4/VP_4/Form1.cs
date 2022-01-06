using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_4
{
    public partial class Form1 : Form
    {
        GenricFEFO<Expire> genticFefo = new GenricFEFO<Expire>();
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            button3.Enabled = false;
        }
        public void UpdateList()
        {
            listBox1.Items.Clear();
            
            if (genticFefo.Count > 0)
            {
                button2.Enabled = true;
                button3.Enabled = true;
                foreach (Expire temp in genticFefo)
                {
                    listBox1.Items.Add(temp.LifeDate.ToString());
                }
            }
            else
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
            textBox1.Text = genticFefo.Count.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                genticFefo.Add(new Expire(dateTimePicker1.Value.Date));
                UpdateList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Извлеченный элемент: " + genticFefo.PopBad().LifeDate);
            UpdateList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Извлеченный элемент: " + genticFefo.PopFresh().LifeDate);
            UpdateList();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateList();
        }
    }
}
