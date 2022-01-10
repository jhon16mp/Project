using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto__Snake
{
    public partial class Form1 : Form
    {
        
        
        Random randComida = new Random();
        Graphics papel;
        Snake snake = new Snake();
        bool derecha = false;
        bool izquierda = false;
        bool abajo = false;
        bool arriba = false;
        Comida comida;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
            comida = new Comida(randComida);
        }

        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            papel = e.Graphics;
            comida.dibujoComida(papel);
            snake.dibujaSnake(papel);


           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                timer1.Enabled = true;
                abajo = false;
                arriba = false;
                derecha = true;
                izquierda = false;
            
            }
            if (e.KeyData == Keys.Down && arriba == false)
            {
                abajo = true;
                arriba = false;
                derecha = false;
                izquierda = false;
            }
            if (e.KeyData == Keys.Up && abajo == false)
            {
                arriba = true;
                abajo = false;
                derecha = false;
                izquierda = false;
            }
            if (e.KeyData == Keys.Right && izquierda == false)
            {
                derecha = true;
                izquierda = false;
                arriba = false;
                abajo = false;
            }
            if (e.KeyData == Keys.Left && derecha == false)
            {
                izquierda = true;
                derecha = false;
                arriba = false;
                abajo = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (abajo) { snake.mover_abajo();}
            if (arriba) { snake.mover_arriba();}
            if (derecha) { snake.mover_derecha();}
            if (izquierda) { snake.mover_izquierda();}

            for (int jj = 0; jj < snake.SnakeRec.Length; jj++)
            {
                if (snake.SnakeRec[jj].IntersectsWith(comida.comidaRec))
                {
                    score += 1;
                    snake.crecimiento_Snake();
                    comida.comidalugar(randComida);
                }
                SnakeScore.Text = score.ToString();
            }

            colision();
            this.Invalidate();
        }
        public void colision()
        {
            for (int m = 1; m < snake.SnakeRec.Length; m++)
            {
                if (snake.SnakeRec[0].IntersectsWith(snake.SnakeRec[m]))
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Snake is dead");
                    reiniciar();
                }

            }
            if (snake.SnakeRec[0].X < 0 || snake.SnakeRec[0].X > 400)
            {
                timer1.Enabled = false;
                MessageBox.Show("Snake is dead");
                reiniciar();
            }
            if (snake.SnakeRec[0].Y < 0 || snake.SnakeRec[0].Y > 400)
            {
            timer1.Enabled = false;
            MessageBox.Show("Snake is dead");
            reiniciar();
            }
        }
        private void reiniciar()
        {
            timer1.Enabled = false;
            snake = new Snake();
            MessageBox.Show("Game over \n Puntuación:  " + SnakeScore.Text.ToString());
            SnakeScore.Text = "0";
            ultimaPun.Text = score.ToString();
            score = 0;
            spaceLabel.Text = "Preciona Barra espaciadora para comenzar";
            
        
        
        
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            spaceLabel.Text = "     ... Pausa...";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            timer1.Start();
            spaceLabel.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hasta Luego");
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Reglas regla = new Reglas();
            this.Hide();
            regla.Show();
        }
    }
}
