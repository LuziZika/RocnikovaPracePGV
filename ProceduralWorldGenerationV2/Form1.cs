namespace ProceduralWorldGenerationV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Globální promìnné
        int grid = 1000;
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
                            barva = Color.FromArgb(104, 160, 37);
                            break;
                        case 4:
                            barva = Color.FromArgb(69, 104, 28);
                            break;
                        case 5:
                            barva = Color.FromArgb(83, 125, 33);
                            break;
                        case 6:
                            if (Random.Shared.Next(10) == 0)
                                barva = Color.FromArgb(109, 166, 42);
                            else barva = Color.FromArgb(90, 136, 36);
                            break;
                        case 7:
                            if (Random.Shared.Next(10) == 0)
                                barva = Color.FromArgb(109, 166, 42);
                            else barva = Color.FromArgb(90, 136, 36);
                            break;
                        case 8:
                            if (Random.Shared.Next(10) == 0)
                                barva = Color.FromArgb(109, 166, 42);
                            else barva = Color.FromArgb(90, 136, 36);
                            break;
                        case 9:
                            barva = Color.FromArgb(98, 150, 38);
                            break;
                        case 10:
                            barva = Color.FromArgb(109, 166, 42);
                            break;
                    }
                    break;

                case "Plain2":
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
                            barva = Color.FromArgb(104, 160, 37);
                            break;
                        case 4:
                            barva = Color.FromArgb(69, 104, 28);
                            break;
                        case 5:
                            barva = Color.FromArgb(83, 125, 33);
                            break;
                        case 6:
                            if (Random.Shared.Next(10) == 0)
                                barva = Color.FromArgb(109, 166, 42);
                            else barva = Color.FromArgb(90, 136, 36);
                            break;
                        case 7:
                            if (Random.Shared.Next(10) == 0)
                                barva = Color.FromArgb(109, 166, 42);
                            else barva = Color.FromArgb(90, 136, 36);
                            break;
                        case 8:
                            if (Random.Shared.Next(10) == 0)
                                barva = Color.FromArgb(109, 166, 42);
                            else barva = Color.FromArgb(90, 136, 36);
                            break;
                        case 9:
                            barva = Color.FromArgb(98, 150, 38);
                            break;
                        case 10:
                            barva = Color.FromArgb(109, 166, 42);
                            break;
                    }
                    break;

                case "Tundra":
                    switch (urovenPole[y, x])
                    {
                        case 0:
                            barva = Color.FromArgb(47, 50, 215);
                            break;
                        case 1:
                            barva = Color.FromArgb(64, 63, 252);
                            break;
                        case 2:
                            barva = Color.FromArgb(107, 135, 95);
                            break;
                        case 3:
                            barva = Color.FromArgb(81, 110, 80);
                            break;
                        case 4:
                            barva = Color.FromArgb(70, 99, 69);
                            break;
                        case 5:
                            barva = Color.FromArgb(90, 119, 89);
                            break;
                        case 6:
                            if (Random.Shared.Next(10) == 0)
                                barva = Color.FromArgb(112, 143, 111);
                            else barva = Color.FromArgb(90, 119, 89);
                            break;
                        case 7:
                            if (Random.Shared.Next(10) == 0)
                                barva = Color.FromArgb(112, 143, 111);
                            else barva = Color.FromArgb(90, 119, 89);
                            break;
                        case 8:
                            if (Random.Shared.Next(10) == 0)
                                barva = Color.FromArgb(112, 143, 111);
                            else barva = Color.FromArgb(90, 119, 89);
                            break;
                        case 9:
                            barva = Color.FromArgb(97, 128, 96);
                            break;
                        case 10:
                            barva = Color.FromArgb(112, 143, 111);
                            break;
                    }
                    break;

                case "Savana":
                    switch (urovenPole[y, x])
                    {
                        case 0:
                            barva = Color.FromArgb(47, 50, 215);
                            break;
                        case 1:
                            barva = Color.FromArgb(64, 63, 252);
                            break;
                        case 2:
                            barva = Color.FromArgb(103, 122, 57);
                            break;
                        case 3:
                            barva = Color.FromArgb(113, 118, 56);
                            break;
                        case 4:
                            barva = Color.FromArgb(103, 99, 43);
                            break;
                        case 5:
                            barva = Color.FromArgb(124, 120, 58);
                            break;
                        case 6:
                            if (Random.Shared.Next(10) == 0)
                                barva = Color.FromArgb(149, 145, 72);
                            else barva = Color.FromArgb(124, 120, 58);
                            break;
                        case 7:
                            if (Random.Shared.Next(10) == 0)
                                barva = Color.FromArgb(149, 145, 72);
                            else barva = Color.FromArgb(124, 120, 58);
                            break;
                        case 8:
                            if (Random.Shared.Next(10) == 0)
                                barva = Color.FromArgb(149, 145, 72);
                            else barva = Color.FromArgb(124, 120, 58);
                            break;
                        case 9:
                            barva = Color.FromArgb(144, 137, 65);
                            break;
                        case 10:
                            barva = Color.FromArgb(149, 145, 72);
                            break;
                    }
                    break;

                case "Mountain":
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
                            barva = Color.FromArgb(104, 160, 37);
                            break;
                        case 4:
                            barva = Color.FromArgb(94, 94, 94);
                            break;
                        case 5:
                            barva = Color.FromArgb(94, 94, 94);
                            break;
                        case 6:
                            barva = Color.FromArgb(111, 111, 111);
                            break;
                        case 7:
                            barva = Color.FromArgb(111, 111, 111);
                            break;
                        case 8:
                            barva = Color.FromArgb(134, 134, 134);
                            break;
                        case 9:
                            barva = Color.FromArgb(134, 134, 134);
                            break;
                        case 10:
                            barva = Color.FromArgb(150, 150, 150);
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
                            barva = Color.FromArgb(239, 225, 141);
                            break;
                        case 3:
                            barva = Color.FromArgb(235, 221, 142);
                            break;
                        case 4:
                            barva = Color.FromArgb(173, 160, 115);
                            break;
                        case 5:
                            barva = Color.FromArgb(221, 209, 145);
                            break;
                        case 6:
                            if (Random.Shared.Next(5) != 0)
                                barva = Color.FromArgb(221, 209, 145);
                            else barva = Color.FromArgb(239, 225, 141);
                            break;
                        case 7:
                            if (Random.Shared.Next(5) != 0)
                                barva = Color.FromArgb(221, 209, 145);
                            else barva = Color.FromArgb(239, 225, 141);
                            break;
                        case 8:
                            if (Random.Shared.Next(5) != 0)
                                barva = Color.FromArgb(221, 209, 145);
                            else barva = Color.FromArgb(239, 225, 141);
                            break;
                        case 9:
                            barva = Color.FromArgb(235, 221, 142);
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
                            barva = Color.FromArgb(47, 50, 215);
                            break;
                        case 1:
                            barva = Color.FromArgb(140, 139, 205);
                            break;
                        case 2:
                            barva = Color.FromArgb(140, 139, 205);
                            break;
                        case 3:
                            barva = Color.FromArgb(140, 139, 205);
                            break;
                        case 4:
                            barva = Color.FromArgb(94, 94, 94);
                            break;
                        case 5:
                            barva = Color.FromArgb(94, 94, 94);
                            break;
                        case 6:
                            barva = Color.FromArgb(111, 111, 111);
                            break;
                        case 7:
                            barva = Color.FromArgb(111, 111, 111);
                            break;
                        case 8:
                            barva = Color.FromArgb(134, 134, 134);
                            break;
                        case 9:
                            barva = Color.FromArgb(134, 134, 134);
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
                            barva = Color.FromArgb(104, 160, 37);
                            break;
                        case 4:
                            barva = Color.FromArgb(69, 104, 28);
                            break;
                        case 5:
                            if (Random.Shared.Next(2) != 0)
                                barva = Color.FromArgb(83, 125, 33);
                            else barva = Color.FromArgb(33, 88, 19);
                            break;
                        case 6:
                            if (Random.Shared.Next(2) != 0)
                                barva = Color.FromArgb(90, 136, 36);
                            else barva = Color.FromArgb(33, 88, 19);
                            break;
                        case 7:
                            if (Random.Shared.Next(2) != 0)
                                barva = Color.FromArgb(90, 136, 36);
                            else barva = Color.FromArgb(33, 88, 19);
                            break;
                        case 8:
                            if (Random.Shared.Next(2) != 0)
                                barva = Color.FromArgb(90, 136, 36);
                            else barva = Color.FromArgb(33, 88, 19);
                            break;
                        case 9:
                            if (Random.Shared.Next(2) != 0)
                                barva = Color.FromArgb(98, 150, 38);
                            else barva = Color.FromArgb(33, 88, 19);
                            break;
                        case 10:
                            if (Random.Shared.Next(2) != 0)
                                barva = Color.FromArgb(109, 166, 42);
                            else barva = Color.FromArgb(33, 88, 19);
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
                            barva = Color.FromArgb(131, 70, 28);
                            break;
                        case 5:
                            barva = Color.FromArgb(158, 84, 31);
                            break;
                        case 6:
                            if (Random.Shared.Next(10) == 0)
                                barva = Color.FromArgb(201, 106, 38);
                            else barva = Color.FromArgb(158, 84, 31);
                            break;
                        case 7:
                            if (Random.Shared.Next(10) == 0)
                                barva = Color.FromArgb(201, 106, 38);
                            else barva = Color.FromArgb(158, 84, 31);
                            break;
                        case 8:
                            if (Random.Shared.Next(10) == 0)
                                barva = Color.FromArgb(201, 106, 38);
                            else barva = Color.FromArgb(158, 84, 31);
                            break;
                        case 9:
                            barva = Color.FromArgb(167, 88, 33);
                            break;
                        case 10:
                            barva = Color.FromArgb(201, 106, 38);
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
                string biome = biomePole[y, x];
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
                string biome = biomePole[y, x];
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
                        biomePole[y + 1, x + 1] = biome;
                    }
                    // Bottom Left
                    if (y != grid - 1 && x != 0 && barvyPixeluPole[y + 1, x - 1] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y + 1, x - 1] = Color.FromArgb(barva, barva, barva);
                        biomePole[y + 1, x - 1] = biome;
                    }
                    // Top Pixel
                    if (y != 0 && barvyPixeluPole[y - 1, x] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y - 1, x] = Color.FromArgb(barva, barva, barva);
                        biomePole[y - 1, x] = biome;
                    }
                    // Top Right
                    if (y != 0 && x != grid - 1 && barvyPixeluPole[y - 1, x + 1] == Color.FromArgb(255, 255, 255))
                    {
                        barvyPixeluPole[y - 1, x + 1] = Color.FromArgb(barva, barva, barva);
                        biomePole[y - 1, x + 1] = biome;
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
                else if (pixel == Color.FromArgb(22, 22, 22))
                {
                    urovenPole[x, y] = 1;
                }
                else if (pixel == Color.FromArgb(24, 24, 24))
                {
                    urovenPole[x, y] = 1;
                }
                else if (pixel == Color.FromArgb(26, 26, 26))
                {
                    urovenPole[x, y] = 1;
                }
                else if (pixel == Color.FromArgb(28, 28, 28))
                {
                    urovenPole[x, y] = 1;
                }
                else if (pixel == Color.FromArgb(30, 30, 30))
                {
                    urovenPole[x, y] = 1;
                }
                else if (pixel == Color.FromArgb(32, 32, 32))
                {
                    urovenPole[x, y] = 1;
                }
                else if (pixel == Color.FromArgb(34, 34, 34))
                {
                    urovenPole[x, y] = 1;
                }
                else if (pixel == Color.FromArgb(36, 36, 36))
                {
                    urovenPole[x, y] = 1;
                }
                else if (pixel == Color.FromArgb(38, 38, 38))
                {
                    urovenPole[x, y] = 1;
                }
                else if (pixel == Color.FromArgb(40, 40, 40))
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

            barvyPixeluPole[x, y] = Color.FromArgb(1, 1, 1);
            if (Random.Shared.Next(25000) == 0)
            {
                biomePole[x, y] = "Plain2";
                barvyPixeluPole[x, y] = Color.FromArgb(1, 1, 1);
            }

            else if (Random.Shared.Next(75000) == 0)
            {
                biomePole[x, y] = "Savana";
                barvyPixeluPole[x, y] = Color.FromArgb(1, 1, 1);
            }

            else if (Random.Shared.Next(75000) == 0)
            {
                biomePole[x, y] = "Tundra";
                barvyPixeluPole[x, y] = Color.FromArgb(1, 1, 1);
            }

            else if (Random.Shared.Next(50000) == 0)
            {
                biomePole[x, y] = "Desert";
                barvyPixeluPole[x, y] = Color.FromArgb(1, 1, 1);
            }

            else if (Random.Shared.Next(100000) == 0)
            {
                biomePole[x, y] = "Snow";
                barvyPixeluPole[x, y] = Color.FromArgb(1, 1, 1);
            }

            else if (Random.Shared.Next(50000) == 0)
            {
                biomePole[x, y] = "Jungle";
                barvyPixeluPole[x, y] = Color.FromArgb(1, 1, 1);
            }

            else if (Random.Shared.Next(100000) == 0)
            {
                biomePole[x, y] = "Mountain";
                barvyPixeluPole[x, y] = Color.FromArgb(1, 1, 1);
            }

            else if (Random.Shared.Next(500000) == 0)
            {
                biomePole[x, y] = "Badlands";
                barvyPixeluPole[x, y] = Color.FromArgb(1, 1, 1);
            }

            else
            {
                biomePole[x, y] = "Plain";
                barvyPixeluPole[x, y] = Color.FromArgb(255, 255, 255);
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

            for (int i = 0; i < 5; i++)
            {
                vetsiHory();
            }


            // 20x uhladit terén
            for (int i = 2; i < 23; i++)
            {
                if (Random.Shared.Next(2) == 0)
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
                    generaceBiome(x, y);
                    biomePrepsaniPole[x, y] = true;
                }
            }
            for (int i = 2; i < 100; i++)
            {
                if (Random.Shared.Next(2) == 0)
                    uhlazeniTerenu(i * 2);
                else
                    uhlazeniTerenu2(i * 2);
            }

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
                int RNG = Random.Shared.Next(256);
                SolidBrush brush = new SolidBrush(Color.FromArgb(RNG, RNG, RNG));
                g.FillRectangle(brush, Random.Shared.Next(200) * 5, Random.Shared.Next(200) * 5, 5, 5);

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
            DateTime time = DateTime.Now;


            g = e.Graphics;

            Task.Run(() =>
            {
                whiteNoise();
            });

            Start();

            DateTime time2 = DateTime.Now;
            Console.WriteLine(time2 - time);
        }
    }
}