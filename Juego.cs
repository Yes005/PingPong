using System;
using System.Drawing;
using System.Windows.Forms;

namespace PingPong
{
    public partial class Juego : Form
    {
        public Juego()
        {
            InitializeComponent();
        }

        int velocidad = 10;
        int cont = 0;
        int puntaje = 0;

        bool arriba;
        bool izquierda;

        private void Juego_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }

        private void Juego_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.Top = e.Y;
        }

        private void Juego_Load(object sender, EventArgs e)
        {
            this.Text = "Puntaje: 0";
            Random random = new Random();
            pictureBox1.Location = new Point(0, random.Next(this.Height));
            arriba = true;
            izquierda = true;
            timer1.Enabled = true;
            puntaje = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pictureBox1.Left > pictureBox2.Left)
            {
                timer1.Enabled = false;
                MessageBox.Show("Puntaje: " + puntaje + " veces!!");
                puntaje = 0;
                velocidad = 10;
                cont = 0;
            }

            //Rebote de la pelota
            if(pictureBox1.Left + pictureBox1.Width >= pictureBox2.Left && 
                pictureBox1.Left + pictureBox1.Width <= pictureBox2.Left + pictureBox2.Width &&
                pictureBox1.Top + pictureBox1.Height >= pictureBox2.Top &&
                pictureBox1.Top + pictureBox1.Height <= pictureBox2.Top + pictureBox2.Height)
            {
                izquierda = false;
                puntaje += 1;
                this.Text = "Puntaje: " + puntaje;
                cont += 1;
                if(cont > 5)
                {
                    velocidad += 1;
                    cont = 0;
                }
            }

            #region Movimiento Pelota

            if (izquierda)
            {
                pictureBox1.Left += velocidad;
            }
            else
            {
                pictureBox1.Left -= velocidad;
            }

            if (arriba)
            {
                pictureBox1.Top += velocidad;
            }
            else
            {
                pictureBox1.Top -= velocidad;
            }

            if(pictureBox1.Top >= this.Height - 50) //Si pega en la pared de abajo
            {
                arriba = false;
            }
            if (pictureBox1.Top <= 0) arriba = true; //Si pega en la pared de arriba

            if (pictureBox1.Left <= 0) izquierda = true; //Si pega en la pared de la izquierda





            #endregion
        }
    }
}
