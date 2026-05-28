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
                new Circulo(60),
                new Rectangulo(30, 50),
                new Cuadrado(45),
            };
        }

        private Color ColorAleatorio()
        {
            int rojo = random.Next(0, 256);
            int verde = random.Next(0, 256);
            int azul = random.Next(0, 256);
            return Color.FromArgb(rojo, verde, azul);
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

            for (int i = 0; i < figuras.Length; i++)
            {
                using (Pen pen = new Pen(colores[i]))
                {
                    figuras[i].Dibujar(pen, gr, i * 100, 50);
                }
            }
        }
    }
}