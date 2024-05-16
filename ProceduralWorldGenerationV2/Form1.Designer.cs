namespace ProceduralWorldGenerationV2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            display = new Panel();
            progressBar1 = new ProgressBar();
            display.SuspendLayout();
            SuspendLayout();
            // 
            // display
            // 
            display.Controls.Add(progressBar1);
            display.Location = new Point(0, 0);
            display.Name = "display";
            display.Size = new Size(1000, 1000);
            display.TabIndex = 0;
            display.Paint += display_Paint;
            // 
            // progressBar1
            // 
            progressBar1.ForeColor = Color.FromArgb(124, 176, 56);
            progressBar1.Location = new Point(100, 500);
            progressBar1.Maximum = 250000;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(800, 25);
            progressBar1.Step = 1;
            progressBar1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 961);
            Controls.Add(display);
            MaximizeBox = false;
            MaximumSize = new Size(1000, 1000);
            MinimizeBox = false;
            MinimumSize = new Size(1000, 1000);
            Name = "Form1";
            Text = "Form1";
            display.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel display;
        private ProgressBar progressBar1;
    }
}