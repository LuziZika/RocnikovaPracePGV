namespace ProceduralWorldGenerationV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Globální promìnnì
        int grid = 1000;
        int sirkaVyska = 1;
        int poziceSumu = 10;
        Color barva;
        int RGB;

        Graphics g;

        Color[,] barvyPixeluPole = new Color[1000, 1000];
        int[,] urovenPole = new int[1000, 1000];

        // Funkce pro získání barvy
        private SolidBrush funkceBarvy(int x, int y)
        {
            SolidBrush brush = new SolidBrush(barvyPixeluPole[x, y]);
            return brush;
        }





        // Funkce pro generaci Barev
        private void generaceBarev(int x, int y)
        {

            // Generace nejvyšších bodù
            int RNG = Random.Shared.Next(500); // 0.5%

            if (RNG == 0)
                RGB = 40;
            else
                RGB = 255;

            barva = Color.FromArgb(RGB, RGB, RGB);
            barvyPixeluPole[x, y] = barva;
        }

        // Funkce pro generaci Barev
        private void prepsaniBarev(int x, int y)
        {
            // Generace barevného svìta
            switch (urovenPole[y, x])
            {
                case 0:
                    barva = Color.FromArgb(47, 50, 215);
                    break;
                case 1:
                    barva = Color.FromArgb(64, 63, 252);
                    break;
                case 2:
                    barva = Color.FromArgb(209, 197, 137);
                    break;
                case 3:
                    barva = Color.FromArgb(88, 123, 39);
                    break;
                case 4:
                    barva = Color.FromArgb(107, 149, 47);
                    break;
                case 5:
                    barva = Color.FromArgb(128, 170, 67);
                    break;
                case 6:
                    barva = Color.FromArgb(124, 176, 56);
                    break;
                case 7:
                    barva = Color.FromArgb(77, 77, 77);
                    break;
                case 8:
                    barva = Color.FromArgb(94, 94, 94);
                    break;
                case 9:
                    barva = Color.FromArgb(111, 111, 111);
                    break;
                case 10:
                    barva = Color.FromArgb(134, 134, 134);
                    break;

            }
            barvyPixeluPole[x, y] = barva;
            Console.WriteLine(barva.ToString());
        }


        private void vetsiHory()
        {
            int sance = 2; // 50%
            int x = 0;
            int y = 0;
            foreach (Color pixel in barvyPixeluPole)
            {
                int RNG1 = Random.Shared.Next(sance);
                int RNG2 = Random.Shared.Next(sance);
                int RNG3 = Random.Shared.Next(sance);
                int RNG4 = Random.Shared.Next(sance);


                
                Console.WriteLine("x : " + x);
                Console.WriteLine("y : " + y);
                if (barvyPixeluPole[y, x] == Color.FromArgb(40, 40, 40))
                {
                    // Bottom Pixel
                    if (RNG1 == 0 && y != grid - 1 && barvyPixeluPole[y + 1, x] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y + 1, x] = Color.FromArgb(40, 40, 40);
                    }
                    // Top Pixel
                    if (RNG2 == 0 && y != 0 && barvyPixeluPole[y - 1, x] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y - 1, x] = Color.FromArgb(40, 40, 40);
                    }
                    // Right Pixel
                    if (RNG3 == 0 && x != grid - 1 && barvyPixeluPole[y, x + 1] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y, x + 1] = Color.FromArgb(40, 40, 40);
                    }
                    // Left Pixel
                    if (RNG4 == 0 && x != 0 && barvyPixeluPole[y, x - 1] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y, x - 1] = Color.FromArgb(40, 40, 40);
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

        // Funkce pro uhlazení terénu
        private void uhlazeniTerenu(int barva)
        {
            int x = 0;
            int y = 0;
            foreach (Color pixel in barvyPixeluPole)
            {
                if (pixel != Color.FromArgb(255, 255, 255) && pixel != Color.FromArgb(barva, barva, barva))
                {
                    // Bottom Pixel
                    if (y != grid - 1 && barvyPixeluPole[y + 1, x] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y + 1, x] = Color.FromArgb(barva, barva, barva);
                    }
                    // Top Pixel
                    if (y != 0 && barvyPixeluPole[y - 1, x] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y - 1, x] = Color.FromArgb(barva, barva, barva);
                    }
                    // Right Pixel
                    if (x != grid - 1 && barvyPixeluPole[y, x + 1] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y, x + 1] = Color.FromArgb(barva, barva, barva);
                    }
                    // Left Pixel
                    if (x != 0 && barvyPixeluPole[y, x - 1] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y, x - 1] = Color.FromArgb(barva, barva, barva);
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

        // Druhá funkce pro uhlazení terénu
        private void uhlazeniTerenu2(int barva)
        {
            int x = 0;
            int y = 0;
            foreach (Color pixel in barvyPixeluPole)
            {

                if (pixel != Color.FromArgb(255, 255, 255) && pixel != Color.FromArgb(barva, barva, barva))
                {
                    // Bottom Pixel
                    if (y != grid - 1 && barvyPixeluPole[y + 1, x] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y + 1, x] = Color.FromArgb(barva, barva, barva);
                    }
                    // Bottom Right
                    if (y != grid - 1 && x != grid - 1 && barvyPixeluPole[y + 1, x + 1] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y + 1, x + 1] = Color.FromArgb(barva, barva, barva);

                    }
                    // Bottom Left
                    if (y != grid - 1 && x != 0 && barvyPixeluPole[y + 1, x - 1] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y + 1, x - 1] = Color.FromArgb(barva, barva, barva);

                    }
                    // Top Pixel
                    if (y != 0 && barvyPixeluPole[y - 1, x] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y - 1, x] = Color.FromArgb(barva, barva, barva);
                    }
                    // Top Right
                    if (y != 0 && x != grid - 1 && barvyPixeluPole[y - 1, x + 1] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y - 1, x + 1] = Color.FromArgb(barva, barva, barva);

                    }
                    // Top Left
                    if (y != 0 && x != 0 && barvyPixeluPole[y - 1, x - 1] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y - 1, x - 1] = Color.FromArgb(barva, barva, barva);

                    }
                    // Right Pixel
                    if (x != grid - 1 && barvyPixeluPole[y, x + 1] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y, x + 1] = Color.FromArgb(barva, barva, barva);

                    }
                    // Left Pixel
                    if (x != 0 && barvyPixeluPole[y, x - 1] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y, x - 1] = Color.FromArgb(barva, barva, barva);
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

        //Funkce pro získání Úrovnì barvy
        private void urovenBarvy()
        {
            int x = 0;
            int y = 0;
            foreach (Color pixel in barvyPixeluPole)
            {


                // 10
                if (pixel == Color.FromArgb(40, 40, 40))
                {
                    urovenPole[x, y] = 10;
                }
                // 9
                else if (pixel == Color.FromArgb(50, 50, 50))
                {
                    urovenPole[x, y] = 9;
                }
                // 8
                else if (pixel == Color.FromArgb(75, 75, 75))
                {
                    urovenPole[x, y] = 8;
                }
                // 7
                else if (pixel == Color.FromArgb(100, 100, 100))
                {
                    urovenPole[x, y] = 7;
                }
                // 6
                else if (pixel == Color.FromArgb(125, 125, 125))
                {
                    urovenPole[x, y] = 6;
                }
                // 5
                else if (pixel == Color.FromArgb(150, 150, 150))
                {
                    urovenPole[x, y] = 5;
                }
                // 4
                else if (pixel == Color.FromArgb(175, 175, 175))
                {
                    urovenPole[x, y] = 4;
                }
                // 3
                else if (pixel == Color.FromArgb(200, 200, 200))
                {
                    urovenPole[x, y] = 3;
                }
                // 2
                else if (pixel == Color.FromArgb(225, 225, 225))
                {
                    urovenPole[x, y] = 2;
                }
                // 1
                else if (pixel == Color.FromArgb(250, 250, 250))
                {
                    urovenPole[x, y] = 1;
                }
                // 0
                else if (pixel == Color.FromArgb(255, 255, 255))
                {
                    urovenPole[x, y] = 0;
                }
                x++;
                if (x != 0 && x % grid == 0)
                {
                    x = 0;
                    y++;
                }

            }
        }





        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void display_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            for (int y = 0; y < grid; y++)
            {
                for (int x = 0; x < grid; x++)
                {
                    generaceBarev(x, y);
                    whiteNoise();

                }
            }

            vetsiHory();
            vetsiHory();
            vetsiHory();

            // 8krat uhladit terén
            for (int i = 2; i < 11; i++)
            {
                if (i % 2 == 0)
                    uhlazeniTerenu(i * 25);
                else
                    uhlazeniTerenu2(i * 25);
            }

            urovenBarvy();

            for (int y = 0; y < grid; y++)
            {
                for (int x = 0; x < grid; x++)
                {
                    prepsaniBarev(x, y);

                }
            }


            // Vybudovaní Gridu
            int poziceX = 100;
            int poziceY = 25;
            for (int y = 0; y < grid; y++)
            {
                for (int x = 0; x < grid; x++)
                {
                    g.FillRectangle(funkceBarvy(x, y), poziceX, poziceY, sirkaVyska, sirkaVyska);
                    poziceX += sirkaVyska;
                }
                poziceX = 100;
                poziceY += sirkaVyska;



            }

        }

        void whiteNoise()
        {
            //display.Refresh();
            int RNG = Random.Shared.Next(2);
            if (RNG == 0)
                g.FillRectangle(Brushes.Black, Random.Shared.Next(grid) + 100, Random.Shared.Next(grid) + 100, sirkaVyska *10, sirkaVyska * 10);
            else
                g.FillRectangle(Brushes.White, Random.Shared.Next(grid) + 100, Random.Shared.Next(grid) + 100, sirkaVyska * 10, sirkaVyska * 10);
        }


    }
}