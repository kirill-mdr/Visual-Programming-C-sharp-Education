using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_7
{
    public partial class Form1 : Form
    {
        List<Apartment> apartments = new List<Apartment>();
        public Form1()
        {        
            InitializeComponent();
            apartments.Add(new Apartment(2, 45, 27000, 3, 3, "Центральный", "Волгоградская область, Волгоград, ул. Пархоменко, 2А"));
            apartments.Add(new Apartment(1, 30, 13000, 1, 9, "Советский", "Волгоградская область, Волгоград, ул. Чебышева, 36"));
            apartments.Add(new Apartment(2, 48, 15000, 2, 4, "Кировский", "Волгоградская область, Волгоград, Санаторная ул., 2А"));
            apartments.Add(new Apartment(2, 60, 15000, 3, 4, "Кировский", "Волгоградская область, Волгоград, Санаторная ул., 8А"));
            apartments.Add(new Apartment(1, 38, 18500, 3, 9, "Кировский", "Волгоградская область, Волгоград, ул. 70-летия Победы, 2"));
            apartments.Add(new Apartment(2, 67, 44000, 2, 16, "Ворошиловский", "Волгоградская область, Волгоград, Пугачёвская ул., 20"));
            apartments.Add(new Apartment(3, 120, 100000, 10, 16, "Центральный", "Волгоградская область, Волгоград, Батальонная ул., 11"));
            apartments.Add(new Apartment(1, 47, 23000, 5, 9, "Ворошиловский", "Волгоградская область, Волгоград, ул. Елисеева, 19"));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "Количество комнат";
            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "Район";
            numericUpDown1.Value = numericUpDown1.Minimum;
            numericUpDown2.Value = numericUpDown2.Maximum;
            numericUpDown3.Value = numericUpDown3.Maximum;
            numericUpDown4.Value = numericUpDown4.Minimum;
            numericUpDown5.Value = numericUpDown5.Maximum;
            numericUpDown6.Value = numericUpDown6.Minimum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var querry =
                    from apartment in apartments
                    where apartment.Square > numericUpDown1.Value
                    where apartment.Square < numericUpDown2.Value
                    where apartment.Price > numericUpDown4.Value
                    where apartment.Price < numericUpDown3.Value
                    where apartment.Floor > numericUpDown6.Value
                    select apartment;
            if (comboBox1.SelectedIndex > -1 && comboBox2.SelectedIndex < 0 && !checkBox1.Checked)
            {
                querry =
                from apartment in apartments
                where apartment.Square > numericUpDown1.Value
                where apartment.Square < numericUpDown2.Value
                where apartment.Price > numericUpDown4.Value
                where apartment.Price < numericUpDown3.Value
                where apartment.Floor > numericUpDown6.Value
                where apartment.RoomsCount == Convert.ToInt32(comboBox1.SelectedItem)
                select apartment;
            }
            else if (comboBox2.SelectedIndex > -1 && comboBox1.SelectedIndex < 0 && !checkBox1.Checked)
            {
                querry =
                from apartment in apartments
                where apartment.Square > numericUpDown1.Value
                where apartment.Square < numericUpDown2.Value
                where apartment.Price > numericUpDown4.Value
                where apartment.Price < numericUpDown3.Value
                where apartment.Floor > numericUpDown6.Value
                where apartment.District == comboBox2.SelectedItem
                select apartment;
            }
            else if (comboBox1.SelectedIndex > -1 && comboBox2.SelectedIndex > -1 && !checkBox1.Checked)
            {
                querry =
                from apartment in apartments
                where apartment.Square > numericUpDown1.Value
                where apartment.Square < numericUpDown2.Value
                where apartment.Price > numericUpDown4.Value
                where apartment.Price < numericUpDown3.Value
                where apartment.Floor > numericUpDown6.Value
                where apartment.RoomsCount == Convert.ToInt32(comboBox1.SelectedItem)
                where apartment.District == comboBox2.SelectedItem
                select apartment;
            }
            else if (checkBox1.Checked)
            {
                querry =
                    from apartment in apartments
                    where apartment.Square > numericUpDown1.Value
                    where apartment.Square < numericUpDown2.Value
                    where apartment.Price > numericUpDown4.Value
                    where apartment.Price < numericUpDown3.Value
                    where apartment.Floor > numericUpDown6.Value
                    where apartment.Floor != 1
                    where apartment.Floor != apartment.LastFloor
                    select apartment;
            }

            listBox1.Items.Clear();
            foreach (Apartment temp in querry)
            {
                listBox1.Items.Add(temp.ToString());
            }
        }
    }
}
