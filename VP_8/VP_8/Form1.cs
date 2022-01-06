using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;

namespace VP_8
{
    public partial class Form1 : Form 
    {
        XDocument xdoc = new XDocument();
        Bitmap img = new Bitmap(Properties.Resources.RAL_2);
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int startX = 36;
            int startY = 67;
            XElement colors = new XElement("colors");
            for (int i = 0; i < 8; i++)
            {
                startY = 67;
                for (int j = 0; j < 10; j++)
                {
                    Color clr = img.GetPixel(startX, startY);
                    MessageBox.Show(clr.ToString());
                    XElement color = new XElement("color");
                    XAttribute colorNum = new XAttribute("number", i.ToString() + "_" + j.ToString());
                    XElement colorR = new XElement("R", clr.R);
                    XElement colorG = new XElement("G", clr.G);
                    XElement colorB = new XElement("B", clr.B);
                    color.Add(colorNum);
                    color.Add(colorR);
                    color.Add(colorG);
                    color.Add(colorB);
                    colors.Add(color);
                    startY += 70;
                }
                startX += 72;
            }
            xdoc.Add(colors);
            xdoc.Save("colors.xml");
            MessageBox.Show("xml был создан");
        }
    }
}
