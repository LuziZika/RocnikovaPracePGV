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
        int indexRadku = 0;
        int indexSloupcu = 0;
        int poziceX = 100, poziceY = 100;
        int sirkaVyska = 10;
        Color barva;
        int RGB;

        PictureBox[,] pictureBoxPole = new PictureBox[50,50];

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
                RGB = 8;
            else
                RGB = 255;

            barva = Color.FromArgb(RGB, RGB, RGB);
            pictureBox.BackColor = barva;

            // Uložení hodnot do Pole
            pictureBoxPole[x,y] = pictureBox;

            // Pøidání PictureBoxu do Form1
            this.Controls.Add(pictureBox);
        }

        // Funkce pro uhlazení terénu
        private void uhlazeniTerenu()
        {
            int x = 0;
            int y = 0;
            foreach (PictureBox pixel in Controls)
            {
                if(pixel.Tag == "pixel")
                {
                    if (pixel.BackColor != Color.FromArgb(255, 255, 255))
                    {
                        /*try
                        {
                            pictureBoxPole[y + 1, x].BackColor = Color.FromArgb(16, 16, 16);
                        }
                        catch 
                        {
                            Console.WriteLine("hiii");
                        }
                        try
                        {
                            pictureBoxPole[y, x + 1].BackColor = Color.FromArgb(16, 16, 16);
                        }
                        catch
                        {
                            Console.WriteLine("hiii");
                        }
                        try
                        {
                            pictureBoxPole[y, x - 1].BackColor = Color.FromArgb(16, 16, 16);
                        }
                        catch
                        {
                            
                        }*/
                        
                        
                        


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

            // Vybudovaní Gridu
            for (int y = 0; y < grid; y++)
            {
                for (int x = 0; x < grid; x++)
                {
                    Point pozice = new Point(poziceX, poziceY);
                    novyPixel(x, y, pozice);
                    poziceX += 10;
                }
                poziceX = 100;
                poziceY += 10;
            }

            uhlazeniTerenu();





            
        }
    }
}