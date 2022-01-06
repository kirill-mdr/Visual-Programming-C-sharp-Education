using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_3
{
    public partial class Form1 : Form
    {
        Warehouse warehouse;
        Office office;
        Apartment apartment;

        public Form1()
        {
            InitializeComponent();
        }

        public bool SetWarehouse()
        {
            try
            {
                warehouse = new Warehouse(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Данные указаны неверно. " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
        }
        public bool SetOffice()
        {
            try
            {
                office = new Office(Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox10.Text));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Данные указаны неверно. " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool SetApartment()
        {
            try
            {
                apartment = new Apartment(Convert.ToInt32(textBox9.Text), Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox11.Text), Convert.ToInt32(textBox12.Text), Convert.ToInt32(textBox13.Text), Convert.ToInt32(textBox14.Text));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Данные указаны неверно. " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public void UpdateWarehouse()
        {
            textBox1.Text = warehouse.Length.ToString();
            textBox2.Text = warehouse.Width.ToString();
            textBox3.Text = warehouse.Height.ToString();
        }
        public void UpdateOffice()
        {
            textBox6.Text = office.Length.ToString();
            textBox5.Text = office.Width.ToString();
            textBox4.Text = office.Height.ToString();
            textBox10.Text = office.Toilet.ToString();
        }
        public void UpdateApartment()
        {
            textBox9.Text = apartment.Length.ToString();
            textBox8.Text = apartment.Width.ToString();
            textBox7.Text = apartment.Height.ToString();

            textBox11.Text = apartment.Toilet.ToString();
            textBox12.Text = apartment.Bathroom.ToString();
            textBox13.Text = apartment.Kitchen.ToString();
            textBox14.Text = apartment.Hallway.ToString();
        }
        private void button1_Click(object sender, EventArgs e) //площадь склада
        {
            if (SetWarehouse())
            {
                textBox15.Text = warehouse.GetArea().ToString();
                UpdateWarehouse();
            }
        }

        private void button2_Click(object sender, EventArgs e) // объем склада
        {
            if (SetWarehouse())
            {
                textBox16.Text = warehouse.GetVolume().ToString();
                UpdateWarehouse();
            }
        }

        private void button6_Click(object sender, EventArgs e) //площадь офиса
        {
            if (SetOffice())
            {
                textBox18.Text = office.GetArea().ToString();
                UpdateOffice();
            }
        }

        private void button5_Click(object sender, EventArgs e) //нежилая площадь офиса
        {
            if (SetOffice())
            {
                textBox17.Text = office.GetNoLivedArea().ToString();
                UpdateOffice();
            }
        }

        private void button4_Click(object sender, EventArgs e) //площадь квартиры
        {
            if (SetApartment())
            {
                textBox20.Text = apartment.GetArea().ToString();
                UpdateApartment();
            }
        }

        private void button3_Click(object sender, EventArgs e) //жилая площадь квартиры
        {
            if (SetApartment())
            {
                textBox19.Text = apartment.GetLivedArea().ToString();
                UpdateApartment();
            }
        }
    }
}
