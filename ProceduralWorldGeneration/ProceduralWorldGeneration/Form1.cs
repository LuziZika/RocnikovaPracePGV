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
        int poziceX = 100, poziceY = 100;
        int sirkaVyska = 10;
        Color barva;

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
                barva = Color.FromArgb(8, 8, 8);
            else
                barva = Color.FromArgb(255, 255, 255);

            pictureBox.BackColor = barva;

            // Pøidání PictureBoxu do Form1
            this.Controls.Add(pictureBox);
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
        }
    }
}