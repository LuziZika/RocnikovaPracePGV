namespace ProceduralWorldGenerationV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Globální promìnné
        int grid = 200;
        int sirkaVyska;
        Color barva;
        int RGB;
        bool loading = true;
        Graphics g;

        string[,] biomePole;
        bool[,] biomePrepsaniPole;
        Color[,] barvyPixeluPole;
        int[,] urovenPole;
        #endregion

        #region funkceBarvy() Funkce pro získání barvy
        private SolidBrush funkceBarvy(int x, int y)
        {
            SolidBrush brush = new SolidBrush(barvyPixeluPole[x, y]);
            return brush;
        }
        #endregion

        private string funkceBiome(int x, int y)
        {
            switch (biomePole[y,x])
            {
                
                case "Desert":
                    return "Desert";
                case "Snow":
                    return "Snow";
                default:
                    return "Plain";

            }
        }

        #region generaceBarev() Funkce pro generaci Barev
        private void generaceBarev(int x, int y)
        {

            // Generace nejvyšších bodù
            int RNG = Random.Shared.Next(1000); // 0.1%

            if (RNG == 0)
                RGB = 40;
            else
                RGB = 255;

            barva = Color.FromArgb(RGB, RGB, RGB);
            barvyPixeluPole[x, y] = barva;
        }
        #endregion

        #region prepsaniBarev() Funkce pro generaci Barev
        private void prepsaniBarev(int x, int y)
        {
            // Generace barevného svìta
            switch (biomePole[y, x])
            {

                default:
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
                            barva = Color.FromArgb(124, 176, 56);
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
                    break;

                case "Desert":
                    switch (urovenPole[y, x])
                    {
                        case 0:
                            barva = Color.FromArgb(255, 0, 0);
                            break;
                        case 1:
                            barva = Color.FromArgb(255, 0, 0);
                            break;
                        case 2:
                            barva = Color.FromArgb(255, 0, 0);
                            break;
                        case 3:
                            barva = Color.FromArgb(255, 0, 0);
                            break;
                        case 4:
                            barva = Color.FromArgb(255, 0, 0);
                            break;
                        case 5:
                            barva = Color.FromArgb(255, 0, 0);
                            break;
                        case 6:
                            barva = Color.FromArgb(255, 0, 0);
                            break;
                        case 7:
                            barva = Color.FromArgb(255, 0, 0);
                            break;
                        case 8:
                            barva = Color.FromArgb(255, 0, 0);
                            break;
                        case 9:
                            barva = Color.FromArgb(255, 0, 0);
                            break;
                        case 10:
                            barva = Color.FromArgb(255, 0, 0);
                            break;
                    }
                    break;

                case "Snow":
                    switch (urovenPole[y, x])
                    {
                        case 0:
                            barva = Color.FromArgb(0, 0, 255);
                            break;
                        case 1:
                            barva = Color.FromArgb(0, 0, 255);
                            break;
                        case 2:
                            barva = Color.FromArgb(0, 0, 255);
                            break;
                        case 3:
                            barva = Color.FromArgb(0, 0, 255);
                            break;
                        case 4:
                            barva = Color.FromArgb(0, 0, 255);
                            break;
                        case 5:
                            barva = Color.FromArgb(0, 0, 255);
                            break;
                        case 6:
                            barva = Color.FromArgb(0, 0, 255);
                            break;
                        case 7:
                            barva = Color.FromArgb(0, 0, 255);
                            break;
                        case 8:
                            barva = Color.FromArgb(0, 0, 255);
                            break;
                        case 9:
                            barva = Color.FromArgb(0, 0, 255);
                            break;
                        case 10:
                            barva = Color.FromArgb(0, 0, 255);
                            break;
                    }
                    break;
            }

            barvyPixeluPole[x, y] = barva;
        }
        #endregion

        #region vetsiHory() Funkce pro zvìtšení hor
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
        #endregion

        #region uhlazeniTerenu() Funkce pro uhlazení terénu
        private void uhlazeniTerenu(int barva, string biome)
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
                        biomePole[y + 1, x] = biome;
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
        #endregion

        #region uhlazeniTerenu2() Druhá funkce pro uhlazení terénu
        private void uhlazeniTerenu2(int barva, string biome)
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
                        biomePole[y + 1, x] = biome;
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
        #endregion

        #region urovenBarvy() Funkce pro získání Úrovnì barvy
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
        #endregion

        #region generaceBiome() Funkce pro generaci biomù
        private void generaceBiome()
        {
            
            for (int i = 0; i < biomePole.Length; i++)
            {
                int RNG = Random.Shared.Next(10000);
                int RNGx = Random.Shared.Next(grid);
                int RNGy = Random.Shared.Next(grid);

                barvyPixeluPole[RNGx, RNGy] = Color.FromArgb(40, 40, 40);

                if (RNG == 0)
                {
                    biomePole[RNGx, RNGy] = "Desert";
                    barvyPixeluPole[RNGx, RNGy] = Color.FromArgb(40, 40, 40);
                }
                    
                else if (RNG == 1)
                {
                    biomePole[RNGx, RNGy] = "Snow";
                    barvyPixeluPole[RNGx, RNGy] = Color.FromArgb(40, 40, 40);
                }
                    
                else
                    biomePole[RNGx, RNGy] = "Plain";

            }
        }
        #endregion

        #region zvetseniBiomu() Funkce pro zvìtšení Biomu
        private void zvetseniBiomu()
        {
            
            {
                int x = 0;
                int y = 0;
                foreach (string biome in biomePole)
                {
                    //for (int i = 0; i < grid / 10; i++)
                    {
                        
                        if (biome == "Desert")
                        {
                            biomeHledani("Desert", x, y);
                        }

                        if (biome == "Snow")
                        {
                            biomeHledani("Snow", x, y);
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


            void biomeHledani(string biome, int x, int y)
            {
                if ( biomePrepsaniPole[y, x])
                {
                    for (int i = 0; i < grid / 10; i++)
                    {
                        biomePrepsaniPole[x, y] = false;
                        // Bottom tile
                        if (y != grid - 1 && biomePrepsaniPole[y + 1, x])
                        {
                            biomePole[y + 1, x] = biome;
                            biomePrepsaniPole[y + 1, x] = false;
                        }
                        // Top tile
                        if (y != 0 && biomePrepsaniPole[y - 1, x])
                        {
                            biomePole[y - 1, x] = biome;
                            biomePrepsaniPole[y - 1, x] = false;
                        }
                        // Right tile
                        if (x != grid - 1 && biomePrepsaniPole[y, x + 1])

                        {
                            biomePole[y, x + 1] = biome;
                            biomePrepsaniPole[y, x + 1] = false;
                        }
                        // Left tile
                        if (x != 0 && biomePrepsaniPole[y, x - 1])
                        {
                            biomePole[y, x - 1] = biome;
                            biomePrepsaniPole[y, x - 1] = false;
                        }
                    }
                }
            }

            void biomeHledani2(string biome, int x, int y)
            {
                if (biomePrepsaniPole[y, x])
                {
                    for (int i = 0; i < grid / 10; i++)
                    {
                        biomePrepsaniPole[x, y] = false;
                        // Bottom tile
                        if (y != grid - 1 && biomePrepsaniPole[y + 1, x])
                        {
                            biomePole[y + 1, x] = biome;
                            biomePrepsaniPole[y + 1, x] = false;
                        }
                        // Top tile
                        if (y != 0 && biomePrepsaniPole[y - 1, x])
                        {
                            biomePole[y - 1, x] = biome;
                            biomePrepsaniPole[y - 1, x] = false;
                        }
                        // Right tile
                        if (x != grid - 1 && biomePrepsaniPole[y, x + 1])

                        {
                            biomePole[y, x + 1] = biome;
                            biomePrepsaniPole[y, x + 1] = false;
                        }
                        // Left tile
                        if (x != 0 && biomePrepsaniPole[y, x - 1])
                        {
                            biomePole[y, x - 1] = biome;
                            biomePrepsaniPole[y, x - 1] = false;
                        }
                    }
                }
            }



        }
        #endregion

        #region Start() Funkce zahajující vytvoøení svìta
        public void Start()
        {
            for (int y = 0; y < grid; y++)
            {
                for (int x = 0; x < grid; x++)
                {
                    generaceBarev(x, y);
                    // pøipravení pole pro biomi
                    biomePrepsaniPole[x, y] = true;
                }
            }

            vetsiHory();
            vetsiHory();


            // 8krat uhladit terén
            for (int i = 2; i < 11; i++)
            {
                if (i % 2 == 0)
                    uhlazeniTerenu(i * 25, "Plain");
                else
                    uhlazeniTerenu2(i * 25, "Plain");
            }

            urovenBarvy();
            Array.Clear(barvyPixeluPole);

            generaceBiome();
            
                    for (int i = 2; i < 11; i++)
                    {
                        if (i % 2 == 0)
                            uhlazeniTerenu(i * 25, funkceBiome(0,0));
                        else
                            uhlazeniTerenu2(i * 25, funkceBiome(1,1));
                    }


            
           // zvetseniBiomu();
            loading = false;



            // Vybudovaní Gridu
            int poziceX = 0;
            int poziceY = 0;
            for (int y = 0; y < grid; y++)
            {
                for (int x = 0; x < grid; x++)
                {
                    prepsaniBarev(x, y);
                    g.FillRectangle(funkceBarvy(x, y), poziceX, poziceY, sirkaVyska, sirkaVyska);
                    poziceX += sirkaVyska;
                }
                poziceX = 0;
                poziceY += sirkaVyska;

            }
        }
        #endregion

        #region whiteNoise() Funkce bílého šumu
        public void whiteNoise()
        {
            while (loading)
            {
                int RNG = Random.Shared.Next(2);
                if (RNG == 0)
                    g.FillRectangle(Brushes.Black, Random.Shared.Next(100) * 10, Random.Shared.Next(100) * 10, 5, 5);
                else
                    g.FillRectangle(Brushes.LightGray, Random.Shared.Next(100) * 10, Random.Shared.Next(100) * 10, 5, 5);

            }
        }
        #endregion






        private void Form1_Load(object sender, EventArgs e)
        {
            sirkaVyska = 1000 / grid;
            biomePole = new string[grid, grid];
            biomePrepsaniPole = new bool[grid, grid];
            barvyPixeluPole = new Color[grid, grid];
            urovenPole = new int[grid, grid];
        }

        private void display_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            Task.Run(() =>
            {
                whiteNoise();
            });

            Start();

        }
    }
}