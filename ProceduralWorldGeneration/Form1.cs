namespace ProceduralWorldGeneration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Globální promìnné
        int grid = 50;
        int sirkaVyska = 10;
        int poziceSumu = 100;
        Color barva;
        int RGB;

        PictureBox[,] pictureBoxPole = new PictureBox[50, 50];

        // Funkce pro generaci PictureBoxù
        private void novyPixel(int y, int x, Point location)
        {
            // nový PictureBox
            PictureBox pictureBox = new PictureBox();
            
            // Vlastnosti PictureBox
            pictureBox.Name = x + "x" + y;
            pictureBox.Width = sirkaVyska;
            pictureBox.Height = sirkaVyska;
            pictureBox.Tag = "pixel";
            pictureBox.Location = location;

            // Generace nejvyšších bodù
            int RNG = Random.Shared.Next(20); //5%

            if (RNG == 0)
                RGB = 32;
            else
                RGB = 255;

            barva = Color.FromArgb(RGB, RGB, RGB);
            pictureBox.BackColor = barva;

            // Uložení hodnot do Pole
            pictureBoxPole[x,y] = pictureBox;

            // Pøidání PictureBoxu do Form1
            this.Controls.Add(pictureBox);
        }

        // Funkce pro vytvoøení Gridu
        private void vytvoreniGridu(int grid, int pozice)
        {
            int poziceX = pozice;
            int poziceY = pozice;
            // Vybudovaní Gridu
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




        // Funkce pro uhlazení terénu
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














        private void Form1_Load(object sender, EventArgs e)
        {
            // Vytvoøení Mapy ve Form1
            vytvoreniGridu(grid, poziceSumu);

            // 8krat uhladit terén
            for (int i = 2; i < 10; i++)
                uhlazeniTerenu(i*25);








        }
    }
}