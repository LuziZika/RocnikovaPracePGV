namespace ProceduralWorldGenerationV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Globální promìnné
        int grid = 500;
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
                RGB = 2;
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
                            barva = Color.FromArgb(47, 50, 215);
                            break;
                        case 1:
                            barva = Color.FromArgb(64, 63, 252);
                            break;
                        case 2:
                            barva = Color.FromArgb(158, 144, 94);
                            break;
                        case 3:
                            barva = Color.FromArgb(200, 189, 118);
                            break;
                        case 4:
                            barva = Color.FromArgb(200, 189, 118);
                            break;
                        case 5:
                            barva = Color.FromArgb(200, 189, 118);
                            break;
                        case 6:
                            barva = Color.FromArgb(239, 225, 141);
                            break;
                        case 7:
                            barva = Color.FromArgb(239, 225, 141);
                            break;
                        case 8:
                            barva = Color.FromArgb(239, 225, 141);
                            break;
                        case 9:
                            barva = Color.FromArgb(239, 225, 141);
                            break;
                        case 10:
                            barva = Color.FromArgb(239, 225, 141);
                            break;
                    }
                    break;

                case "Snow":
                    switch (urovenPole[y, x])
                    {
                        case 0:
                            barva = Color.FromArgb(140, 139, 205);
                            break;
                        case 1:
                            barva = Color.FromArgb(115, 113, 208);
                            break;
                        case 2:
                            barva = Color.FromArgb(208, 208, 208);
                            break;
                        case 3:
                            barva = Color.FromArgb(208, 208, 208);
                            break;
                        case 4:
                            barva = Color.FromArgb(208, 208, 208);
                            break;
                        case 5:
                            barva = Color.FromArgb(208, 208, 208);
                            break;
                        case 6:
                            barva = Color.FromArgb(163, 163, 163);
                            break;
                        case 7:
                            barva = Color.FromArgb(163, 163, 163);
                            break;
                        case 8:
                            barva = Color.FromArgb(250, 250, 250);
                            break;
                        case 9:
                            barva = Color.FromArgb(250, 250, 250);
                            break;
                        case 10:
                            barva = Color.FromArgb(250, 250, 250);
                            break;
                    }
                    break;
                case "Jungle":
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
                            barva = Color.FromArgb(89, 166, 39);
                            break;
                        case 4:
                            barva = Color.FromArgb(53, 137, 32);
                            break;
                        case 5:
                            if (Random.Shared.Next(2) == 0)
                                barva = Color.FromArgb(53, 137, 32);
                            else barva = Color.FromArgb(18, 62, 6);
                            break;
                        case 6:
                            if (Random.Shared.Next(2) == 0)
                                barva = Color.FromArgb(53, 137, 32);
                            else barva = Color.FromArgb(18, 62, 6);
                            break;
                        case 7:
                            if (Random.Shared.Next(2) == 0)
                                barva = Color.FromArgb(53, 137, 32);
                            else barva = Color.FromArgb(18, 62, 6);
                            break;
                        case 8:
                            if (Random.Shared.Next(2) == 0)
                                barva = Color.FromArgb(53, 137, 32);
                            else barva = Color.FromArgb(18, 62, 6);
                            break;
                        case 9:
                            if (Random.Shared.Next(2) == 0)
                                barva = Color.FromArgb(53, 137, 32);
                            else barva = Color.FromArgb(18, 62, 6);
                            break;
                        case 10:
                            if (Random.Shared.Next(2) == 0)
                                barva = Color.FromArgb(53, 137, 32);
                            else barva = Color.FromArgb(18, 62, 6);
                            break;
                    }
                    break;
                case "Badlands":
                    switch (urovenPole[y, x])
                    {
                        case 0:
                            barva = Color.FromArgb(47, 50, 215);
                            break;
                        case 1:
                            barva = Color.FromArgb(64, 63, 252);
                            break;
                        case 2:
                            barva = Color.FromArgb(198, 103, 42);
                            break;
                        case 3:
                            barva = Color.FromArgb(198, 103, 42);
                            break;
                        case 4:
                            barva = Color.FromArgb(164, 87, 33);
                            break;
                        case 5:
                            barva = Color.FromArgb(164, 87, 33);
                            break;
                        case 6:
                            barva = Color.FromArgb(146, 81, 30);
                            break;
                        case 7:
                            barva = Color.FromArgb(131, 70, 27);
                            break;
                        case 8:
                            barva = Color.FromArgb(129, 69, 24);
                            break;
                        case 9:
                            barva = Color.FromArgb(129, 69, 24);
                            break;
                        case 10:
                            barva = Color.FromArgb(97, 48, 21);
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


                if (barvyPixeluPole[y, x] == Color.FromArgb(2, 2, 2))
                {
                    // Bottom Pixel
                    if (RNG1 == 0 && y != grid - 1 && barvyPixeluPole[y + 1, x] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y + 1, x] = Color.FromArgb(2, 2, 2);
                    }
                    // Top Pixel
                    if (RNG2 == 0 && y != 0 && barvyPixeluPole[y - 1, x] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y - 1, x] = Color.FromArgb(2, 2, 2);
                    }
                    // Right Pixel
                    if (RNG3 == 0 && x != grid - 1 && barvyPixeluPole[y, x + 1] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y, x + 1] = Color.FromArgb(2, 2, 2);
                    }
                    // Left Pixel
                    if (RNG4 == 0 && x != 0 && barvyPixeluPole[y, x - 1] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y, x - 1] = Color.FromArgb(2, 2, 2);
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
        private void uhlazeniTerenu(int barva)
        {
            int x = 0;
            int y = 0;
            foreach (Color pixel in barvyPixeluPole)
            {
                string biome = biomePole[y,x];
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
                        biomePole[y - 1, x] = biome;
                    }
                    // Right Pixel
                    if (x != grid - 1 && barvyPixeluPole[y, x + 1] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y, x + 1] = Color.FromArgb(barva, barva, barva);
                        biomePole[y, x + 1] = biome;
                    }
                    // Left Pixel
                    if (x != 0 && barvyPixeluPole[y, x - 1] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y, x - 1] = Color.FromArgb(barva, barva, barva);
                        biomePole[y, x - 1] = biome;
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
        private void uhlazeniTerenu2(int barva)
        {
            int x = 0;
            int y = 0;
            foreach (Color pixel in barvyPixeluPole)
            {
                string biome = biomePole[y,x];
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
                        biomePole[y+1, x + 1] = biome;
                    }
                    // Bottom Left
                    if (y != grid - 1 && x != 0 && barvyPixeluPole[y + 1, x - 1] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y + 1, x - 1] = Color.FromArgb(barva, barva, barva);
                        biomePole[y+ 1, x - 1] = biome;
                    }
                    // Top Pixel
                    if (y != 0 && barvyPixeluPole[y - 1, x] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y - 1, x] = Color.FromArgb(barva, barva, barva);
                        biomePole[y-1, x] = biome;
                    }
                    // Top Right
                    if (y != 0 && x != grid - 1 && barvyPixeluPole[y - 1, x + 1] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y - 1, x + 1] = Color.FromArgb(barva, barva, barva);
                        biomePole[y- 1, x + 1] = biome;
                    }
                    // Top Left
                    if (y != 0 && x != 0 && barvyPixeluPole[y - 1, x - 1] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y - 1, x - 1] = Color.FromArgb(barva, barva, barva);
                        biomePole[y - 1, x - 1] = biome;
                    }
                    // Right Pixel
                    if (x != grid - 1 && barvyPixeluPole[y, x + 1] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y, x + 1] = Color.FromArgb(barva, barva, barva);
                        biomePole[y, x + 1] = biome;
                    }
                    // Left Pixel
                    if (x != 0 && barvyPixeluPole[y, x - 1] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y, x - 1] = Color.FromArgb(barva, barva, barva);
                        biomePole[y, x - 1] = biome;
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
                if (pixel == Color.FromArgb(2, 2, 2))
                {
                    urovenPole[x, y] = 10;
                }
                // 9
                else if (pixel == Color.FromArgb(4, 4, 4))
                {
                    urovenPole[x, y] = 9;
                }
                // 8
                else if (pixel == Color.FromArgb(6, 6, 6))
                {
                    urovenPole[x, y] = 8;
                }
                // 7
                else if (pixel == Color.FromArgb(8, 8, 8))
                {
                    urovenPole[x, y] = 7;
                }
                // 6
                else if (pixel == Color.FromArgb(10, 10, 10))
                {
                    urovenPole[x, y] = 6;
                }
                // 5
                else if (pixel == Color.FromArgb(12, 12, 12))
                {
                    urovenPole[x, y] = 5;
                }
                // 4
                else if (pixel == Color.FromArgb(14, 14, 14))
                {
                    urovenPole[x, y] = 4;
                }
                // 3
                else if (pixel == Color.FromArgb(16, 16, 16))
                {
                    urovenPole[x, y] = 3;
                }
                // 2
                else if (pixel == Color.FromArgb(18, 18, 18))
                {
                    urovenPole[x, y] = 2;
                }
                // 1
                else if (pixel == Color.FromArgb(20, 20, 20))
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
        private void generaceBiome(int x, int y)
        {
            
            //for (int i = 0; i < biomePole.Length; i++)
            {
                int RNG = Random.Shared.Next(100000);

                barvyPixeluPole[x, y] = Color.FromArgb(1, 1, 1);
                if(RNG == 0 && RNG == 1 && RNG == 2 &&  RNG == 3 && RNG == 4 && RNG == 5)
                {
                    biomePole[x, y] = "Plain";
                    barvyPixeluPole[x, y] = Color.FromArgb(255, 255, 255);
                }

                else if (RNG == 6)
                {
                    biomePole[x, y] = "Desert";
                    barvyPixeluPole[x, y] = Color.FromArgb(1, 1, 1);
                }

                else if (RNG == 7)
                {
                    biomePole[x, y] = "Desert";
                    barvyPixeluPole[x, y] = Color.FromArgb(1, 1, 1);
                }

                else if (RNG == 8)
                {
                    biomePole[x, y] = "Snow";
                    barvyPixeluPole[x, y] = Color.FromArgb(1, 1, 1);
                }

                else if (RNG == 9)
                {
                    biomePole[x, y] = "Jungle";
                    barvyPixeluPole[x, y] = Color.FromArgb(1, 1, 1);
                }

                else if (RNG == 10)
                {
                    biomePole[x, y] = "Jungle";
                    barvyPixeluPole[x, y] = Color.FromArgb(1, 1, 1);
                }

                else if (RNG == 11)
                {
                    biomePole[x, y] = "Badlands";
                    barvyPixeluPole[x, y] = Color.FromArgb(1, 1, 1);
                }

                else
                {
                    biomePole[x, y] = "Plain";
                    barvyPixeluPole[x, y] = Color.FromArgb(255,255, 255);
                }
                    

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
                    uhlazeniTerenu(i * 2);
                else
                    uhlazeniTerenu2(i * 2);
            }
            urovenBarvy();

            Array.Clear(barvyPixeluPole);
            for (int y = 0; y < grid; y++)
            {
                for (int x = 0; x < grid; x++)
                {
                    generaceBiome(x,y);
                    biomePrepsaniPole[x, y] = true;
                }
            }
            int RNG = Random.Shared.Next(20, grid / 10);
                    for (int i = 2; i < RNG; i++)
                    {
                        if (i % 2 == 0)
                            uhlazeniTerenu(i * 2);
                        else
                            uhlazeniTerenu2(i * 2);
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