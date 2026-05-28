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

            figuras = new Figura[3]
            {
                new Circulo(30),
                new Rectangulo(60, 80),
                new Cuadrado(110),
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

            Color[] colores = new Color[3]
            {
                ColorAleatorio(),
                ColorAleatorio(),
                ColorAleatorio(),
            };

            int separacion = 120;

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