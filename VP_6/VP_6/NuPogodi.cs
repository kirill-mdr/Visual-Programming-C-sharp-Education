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
    public partial class NuPogodi : UserControl
    {
        public delegate void RedButtonHandler(object sender, RedButtonEventArgs e);
        public event RedButtonHandler RedButtonClick;
        Random rnd = new Random();
        List<Egg> listEggs = new List<Egg>();
        bool[,] Eggs = new bool [4,5];
        int[,] EggsX = { { 311, 329, 344, 361, 376 }, { 309, 328, 340, 361, 378 }, { 691, 675, 658, 641, 625 }, { 693, 678, 659, 643, 629 } };
        int[,] EggsY = { { 247, 255, 268, 277, 290 }, { 317, 323, 336, 346, 356 }, { 318, 324, 336, 350, 356 }, { 248, 255, 267, 281, 291 } };
        public int EggGeneratorCounter { get; set; } = 5;
        public int EggGeneratorMax { get; set; } = 5;
        public int Score { get; set; } = 0;
        public bool Am { get; set; } = false;
        public bool Pm { get; set; } = false;
        public bool GameA { get; set; } = true;
        public bool GameB { get; set; } = false;
        public bool Time { get; set; } = true;
        public int BasketPosition { get; set; } = -1;
        public int Faults { get; set; } = 0;
        public bool IsStart { get; set; } = false;
        public bool CrashLeft { get; set; } = false;
        public bool CrashRight { get; set; } = false;



        public NuPogodi()
        {
            InitializeComponent();
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsStart)
            {
                CrashLeft = false;
                CrashRight = false;
                if (Score > 5) EggGeneratorMax = 4;
                if (Score > 15) EggGeneratorMax = 3;

                if (listEggs.Count > 0)
                {
                    if (listEggs[0].Position == 5)
                    {
                        if (listEggs[0].Basket == BasketPosition)
                        {
                            Score++;
                            label1.Text = Score.ToString();
                        }
                        else
                        {
                            if (listEggs[0].Basket <= 1)
                            {
                                CrashLeft = true;
                            }
                            else
                            {
                                CrashRight = true;
                            }
                            Faults++;
                        }
                        listEggs.RemoveAt(0);
                    }
                }
                if (Faults != 3)
                {
                    foreach (Egg item in listEggs)
                    {
                        Eggs[item.Basket, item.Position] = false;
                        item.NextPosition();
                    }
                    foreach (Egg item in listEggs)
                    {
                        if (item.Position <= 4)
                        {
                            Eggs[item.Basket, item.Position] = true;

                        }

                    }
                    if (EggGeneratorCounter == EggGeneratorMax)
                    {
                        listEggs.Add(new Egg());
                        Eggs[listEggs[listEggs.Count - 1].Basket, listEggs[listEggs.Count - 1].Position] = true;
                        EggGeneratorCounter = 0;
                    }
                    EggGeneratorCounter++;
                    Invalidate();
                }
                else
                {
                    Invalidate();
                    listEggs.Clear();
                    IsStart = false;
                    Faults = 0;
                    Score = 0;
                    EggGeneratorMax = 5;
                    label1.Text = "0";
                    MessageBox.Show("Вы проиграли");
                }

                
            }
            
        }

        private void NuPogodi_Load(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour < 12)
            {
                Am = true;
                Pm = false;
            }
            else
            {
                Am = false;
                Pm = true;
            }
            label1.Text = "0";
        }



        private void NuPogodi_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (GameA)
            {
                Bitmap temp1 = Properties.Resources.Игра_А;
                g.DrawImage(temp1, new Rectangle(299, 430, temp1.Width, temp1.Height));
            }
            if (GameB)
            {
                Bitmap temp1 = Properties.Resources.Игра_Б;
                g.DrawImage(temp1, new Rectangle(666, 433, temp1.Width, temp1.Height));
            }
            if (Time)
            {
                Bitmap temp2 = Properties.Resources.Часы;
                g.DrawImage(temp2, new Rectangle(507, 177, temp2.Width, temp2.Height));
                if (Am)
                {
                    Bitmap temp1 = Properties.Resources.ДП;
                    g.DrawImage(temp1, new Rectangle(462, 177, temp1.Width, temp1.Height));              
                }
                if (Pm)
                {
                    Bitmap temp1 = Properties.Resources.ПП;
                    g.DrawImage(temp1, new Rectangle(462, 201, temp1.Width, temp1.Height));
                }
            }           
            if (BasketPosition == 0)
            {
                Bitmap temp1 = Properties.Resources.Волк_Л;
                g.DrawImage(temp1, new Rectangle(431,277,temp1.Width,temp1.Height));
                Bitmap temp2 = Properties.Resources.Корзина_ЛВ;
                g.DrawImage(temp2, new Rectangle(385, 275, temp2.Width, temp2.Height));
            }
            if (BasketPosition == 1)
            {
                Bitmap temp1 = Properties.Resources.Волк_Л;
                g.DrawImage(temp1, new Rectangle(431, 277, temp1.Width, temp1.Height));
                Bitmap temp2 = Properties.Resources.Корзина_ЛН;
                g.DrawImage(temp2, new Rectangle(381, 343, temp2.Width, temp2.Height));
            }
            if (BasketPosition == 2)
            {
                Bitmap temp1 = Properties.Resources.Волк_П;
                g.DrawImage(temp1, new Rectangle(507, 285, temp1.Width, temp1.Height));
                Bitmap temp2 = Properties.Resources.Корзина_ПН;
                g.DrawImage(temp2, new Rectangle(567, 347, temp2.Width, temp2.Height));
            }
            if (BasketPosition == 3)
            {
                Bitmap temp1 = Properties.Resources.Волк_П;
                g.DrawImage(temp1, new Rectangle(507, 285, temp1.Width, temp1.Height));
                Bitmap temp2 = Properties.Resources.Корзина_ПВ;
                g.DrawImage(temp2, new Rectangle(576, 288, temp2.Width, temp2.Height));
            }
            if (Faults >= 1)
            {
                Bitmap temp1 = Properties.Resources.Штраф_1;
                g.DrawImage(temp1, new Rectangle(524, 237, temp1.Width, temp1.Height));
            }
            if (Faults >= 2)
            {
                Bitmap temp1 = Properties.Resources.Штраф_2;
                g.DrawImage(temp1, new Rectangle(559, 237, temp1.Width, temp1.Height));
            }
            if (Faults >= 3)
            {
                Bitmap temp1 = Properties.Resources.Штраф_3;
                g.DrawImage(temp1, new Rectangle(595, 237, temp1.Width, temp1.Height));
            }
            if (CrashLeft)
            {
                Bitmap temp1 = Properties.Resources.Разбитое_Л;
                g.DrawImage(temp1, new Rectangle(362, 410, temp1.Width, temp1.Height));
            }
            if (CrashRight)
            {
                Bitmap temp1 = Properties.Resources.Разбитое_П;
                g.DrawImage(temp1, new Rectangle(580, 414, temp1.Width, temp1.Height));
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Eggs[i,j] == true)
                    {
                        string name = "Яйцо_" + i + "_" + j;
                        Bitmap temp1 = Properties.Resources.ResourceManager.GetObject(name) as Bitmap;
                        g.DrawImage(temp1, new Rectangle(EggsX[i,j], EggsY[i,j], temp1.Width, temp1.Height));
                    }
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            IsStart = true;
            BasketPosition = 0;
        }

        private void NuPogodi_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Location.X > 84 && e.Location.Y > 355 && e.Location.X < 184 && e.Location.Y < 460)
            {
                RedButtonClick(this, new RedButtonEventArgs(0));
            }
            if (e.Location.X > 84 && e.Location.Y > 465 && e.Location.X < 184 && e.Location.Y < 560)
            {
                RedButtonClick(this, new RedButtonEventArgs(1));
            }
            if (e.Location.X > 854 && e.Location.Y > 355 && e.Location.X < 954 && e.Location.Y < 460)
            {
                RedButtonClick(this, new RedButtonEventArgs(3));
            }
            if (e.Location.X > 854 && e.Location.Y > 465 && e.Location.X < 954 && e.Location.Y < 560)
            {
                RedButtonClick(this, new RedButtonEventArgs(2));
            }
        }



    }
}
