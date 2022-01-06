using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_LR2
{
    public partial class Form1 : Form
    {
        Triangle triangle;
        List<Triangle> triangles = new List<Triangle>();
        public Form1()
        {
            InitializeComponent();
            

        }
        private bool SetSides()
        {
            try
            {
                triangle = new Triangle(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text));
                //triangle.A = Convert.ToDouble(textBox1.Text);
                //triangle.B = Convert.ToDouble(textBox2.Text);
                //triangle.C = Convert.ToDouble(textBox3.Text);
                if (triangle.IsReal)
                {
                    triangles.Add(triangle);
                    return true;
                }
                else
                {
                    MessageBox.Show("Такой треугольник не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                
            }
            catch
            {
                MessageBox.Show("Стороны указаны неверно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void ResetResult()
        {
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ResetResult();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ResetResult();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            ResetResult();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SetSides())
            {
                textBox4.Text = triangle.GetArea().ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SetSides())
            {
                textBox5.Text = triangle.GetPerimeter().ToString();
                //textBox5.Text = Triangle.GetPerimetrStatic(triangle.A, triangle.B, triangle.C).ToString();
            }
               
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (SetSides())
            {
                if (radioButton1.Checked) textBox6.Text = triangle.OppositeAngle("a").ToString();
                if (radioButton2.Checked) textBox6.Text = triangle.OppositeAngle("b").ToString();
                if (radioButton3.Checked) textBox6.Text = triangle.OppositeAngle("c").ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (SetSides())
            {
                MessageBox.Show("Треугольник добавлен в список");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var querry =
                from Triangle in triangles
                where Triangle.GetArea() > 5
                where Triangle.GetPerimeter() < 5
                orderby Triangle.GetArea()
                select Triangle;
            foreach (Triangle temp in querry)
            {
                MessageBox.Show(temp.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var querry =
                from triangle in triangles
                group triangle by triangle.GetPerimeter();          
               
                
            foreach (var temp in querry)
            {
                foreach (Triangle tr in temp)
                {
     
                    listBox1.Items.Add(tr.ToString());

                }
                
            }
        }
    }
}
