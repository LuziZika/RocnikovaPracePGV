namespace ProceduralWorldGeneration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Glob�ln� prom�nn�
        int grid = 50;
        int sirkaVyska = 10;
        int poziceSumu = 100;
        Color barva;
        int RGB;

        PictureBox[,] pictureBoxPole = new PictureBox[50, 50];

        // Funkce pro generaci PictureBox�
        private void novyPixel(int y, int x, Point location)
        {
            // nov� PictureBox
            PictureBox pictureBox = new PictureBox();
            
            // Vlastnosti PictureBox
            pictureBox.Name = x + "x" + y;
            pictureBox.Width = sirkaVyska;
            pictureBox.Height = sirkaVyska;
            pictureBox.Tag = "pixel";
            pictureBox.Location = location;

            // Generace nejvy���ch bod�
            int RNG = Random.Shared.Next(75); // 1.33%

            if (RNG == 0)
                RGB = 40;
            else
                RGB = 255;

            barva = Color.FromArgb(RGB, RGB, RGB);
            pictureBox.BackColor = barva;

            // Ulo�en� hodnot do Pole
            pictureBoxPole[x,y] = pictureBox;

            // P�id�n� PictureBoxu do Form1
            this.Controls.Add(pictureBox);
        }

        // Funkce pro vytvo�en� Gridu
        private void vytvoreniGridu(int grid, int pozice)
        {
            int poziceX = pozice;
            int poziceY = pozice;
            // Vybudovan� Gridu
            for (int y = 0; y < grid; y++)
            {
                for (int x = 0; x < grid; x++)
                {
                    Point pozicePixelu = new Point(poziceX, poziceY);
                    novyPixel(x, y, pozicePixelu);
                    poziceX += sirkaVyska;
                }
                poziceX = poziceSumu;
                poziceY += sirkaVyska;
            }
        }




        // Funkce pro uhlazen� ter�nu
        private void uhlazeniTerenu(int barva)
        {
            int x = 0;
            int y = 0;
            foreach (PictureBox pixel in Controls)
            {
                if(pixel.Tag == "pixel")
                {
                    if (pixel.BackColor != Color.FromArgb(255, 255, 255) && pixel.BackColor != Color.FromArgb(barva,barva,barva))
                    {
                        // Bottom Pixel
                        if (y != grid-1 && pictureBoxPole[y + 1, x].BackColor == Color.FromArgb(255, 255, 255))
                        {
                            pictureBoxPole[y + 1, x].BackColor = Color.FromArgb(barva, barva, barva);
                        }
                        // Top Pixel
                        if (y != 0 && pictureBoxPole[y - 1, x].BackColor == Color.FromArgb(255, 255, 255))
                        {
                            pictureBoxPole[y - 1, x].BackColor = Color.FromArgb(barva, barva, barva);
                        }
                        // Right Pixel
                        if (x != grid-1 && pictureBoxPole[y, x+1].BackColor == Color.FromArgb(255, 255, 255))
                        {
                            pictureBoxPole[y, x+1].BackColor = Color.FromArgb(barva, barva, barva);
                        }
                        // Left Pixel
                        if (x != 0 && pictureBoxPole[y, x - 1].BackColor == Color.FromArgb(255, 255, 255))
                        {
                            pictureBoxPole[y, x - 1].BackColor = Color.FromArgb(barva, barva, barva);
                        }
                    }
                    x++;
                    if(x != 0 && x % grid == 0)
                    {
                        x = 0;
                        y++;
                    }
                }
            }
        }


        private void uhlazeniTerenu2(int barva)
        {
            int x = 0;
            int y = 0;
            foreach (PictureBox pixel in Controls)
            {
                if (pixel.Tag == "pixel")
                {
                    if (pixel.BackColor != Color.FromArgb(255, 255, 255) && pixel.BackColor != Color.FromArgb(barva, barva, barva))
                    {
                        // Bottom Pixel
                        if (y != grid - 1 && pictureBoxPole[y + 1, x].BackColor == Color.FromArgb(255, 255, 255))
                        {
                            pictureBoxPole[y + 1, x].BackColor = Color.FromArgb(barva, barva, barva);
                        }
                        // Bottom Right
                        if (y != grid - 1 && x != grid - 1  && pictureBoxPole[y + 1, x + 1].BackColor == Color.FromArgb(255, 255, 255))
                        {
                            pictureBoxPole[y + 1, x + 1].BackColor = Color.FromArgb(barva, barva, barva);

                        }
                        // Bottom Left
                        if (y != grid - 1 && x != 0 && pictureBoxPole[y + 1, x - 1].BackColor == Color.FromArgb(255, 255, 255))
                        {
                            pictureBoxPole[y + 1, x - 1].BackColor = Color.FromArgb(barva, barva, barva);

                        }
                        // Top Pixel
                        if (y != 0 && pictureBoxPole[y - 1, x].BackColor == Color.FromArgb(255, 255, 255))
                        {
                            pictureBoxPole[y - 1, x].BackColor = Color.FromArgb(barva, barva, barva);
                        }
                        // Top Right
                        if (y != 0 && x != grid - 1 && pictureBoxPole[y - 1, x + 1].BackColor == Color.FromArgb(255, 255, 255))
                        {
                            pictureBoxPole[y - 1, x + 1].BackColor = Color.FromArgb(barva, barva, barva);

                        }
                        // Top Left
                        if (y != 0 && x != 0 && pictureBoxPole[y - 1, x - 1].BackColor == Color.FromArgb(255, 255, 255))
                        {
                            pictureBoxPole[y - 1, x - 1].BackColor = Color.FromArgb(barva, barva, barva);

                        }
                        // Right Pixel
                        if (x != grid - 1 && pictureBoxPole[y, x + 1].BackColor == Color.FromArgb(255, 255, 255))
                        {
                            pictureBoxPole[y, x + 1].BackColor = Color.FromArgb(barva, barva, barva);

                        }
                        // Left Pixel
                        if (x != 0 && pictureBoxPole[y, x - 1].BackColor == Color.FromArgb(255, 255, 255))
                        {
                            pictureBoxPole[y, x - 1].BackColor = Color.FromArgb(barva, barva, barva);
                        }
                    }
                    x++;
                    if (x != 0 && x % grid == 0)
                    {
                        x = 0;
                        y++;
                    }
                }
            }
        }














        private void Form1_Load(object sender, EventArgs e)
        {
            // Vytvo�en� Mapy ve Form1
            vytvoreniGridu(grid, poziceSumu);

            // 8krat uhladit ter�n
            for (int i = 2; i < 10; i++)
            {
                if (i % 2 == 1)
                    uhlazeniTerenu2(i * 25);
                else
                    uhlazeniTerenu(i * 25);
            }











        }
    }
}