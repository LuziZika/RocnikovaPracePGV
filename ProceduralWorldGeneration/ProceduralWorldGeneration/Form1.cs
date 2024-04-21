namespace ProceduralWorldGeneration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Glob�ln� prom�nn�
        int y = 0, x = 0;
        int poziceX = 100, poziceY = 100;
        int sirkaVyska = 10;

        // Funkce pro generaci PictureBox�
        private void novyPixel(int y, int x, Point location)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Name = "Pixel" + x + "x" + y;
            pictureBox.Width = sirkaVyska;
            pictureBox.Height = sirkaVyska;
            pictureBox.Tag = "pixel";
            pictureBox.Location = location;

            // Generace nejvy���ch bod�
            int RNG = Random.Shared.Next(10);
            if (RNG == 0)
                pictureBox.BackColor = Color.FromArgb(0, 0, 0);
            else
                pictureBox.BackColor = Color.FromArgb(255, 255, 255);

            this.Controls.Add(pictureBox);

        }














        private void Form1_Load(object sender, EventArgs e)
        {


            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Point pozice = new Point(poziceX, poziceY);
                    novyPixel(x, y, pozice);
                    poziceX += 10;
                    x++;
                }
                poziceX = 100;
                poziceY += 10;
                x = 0;
                y++;
            }
        }
    }
}