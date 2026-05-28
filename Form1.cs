using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Figuras
{
    public partial class Form1 : Form
    {
        Figura[] figuras;
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            this.ClientSize = new Size(900, 350);
            this.pictureBox1.Size = new Size(750, 280);
            this.dibujarButton.Location = new Point(800, 130);

            figuras = new Figura[5]
            {
                new Circulo(30),
                new Rectangulo(60, 80),
                new Cuadrado(110),
                new TrianguloIsosceles(140, 160),
                new TrianguloEquilatero(180),
            };
        }

        private Color ColorAleatorio()
        {
            Color color;
            int brillo;

            do
            {
                int rojo = random.Next(0, 256);
                int verde = random.Next(0, 256);
                int azul = random.Next(0, 256);

                color = Color.FromArgb(rojo, verde, azul);

                brillo = (int)(0.299 * rojo + 0.587 * verde + 0.114 * azul);
            }
            while (brillo > 180);

            return color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics gr = pictureBox1.CreateGraphics();
            gr.Clear(pictureBox1.BackColor);

            Color[] colores = new Color[figuras.Length];

            for (int i = 0; i < colores.Length; i++)
            {
                colores[i] = ColorAleatorio();
            }

            int separacion = 140;

            for (int i = 0; i < figuras.Length; i++)
            {
                using (Pen pen = new Pen(colores[i]))
                {
                    figuras[i].Dibujar(pen, gr, i * separacion, 50);
                }
            }
        }
    }
}