using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto__Snake
{
   public  class Snake
    {
        private Rectangle[] snakeRec;
        private SolidBrush pincel;
        private int x, y, width, height;

        public Rectangle[] SnakeRec
        {
            get  {return snakeRec;}
        
        }

        public Snake()
        {
            snakeRec = new Rectangle[3];
            pincel = new SolidBrush(Color.White);

            x = 20;
            y = 0;
           width  = 10;
            height = 10;

            for (int jm = 0; jm < snakeRec.Length; jm++)
            {
                snakeRec[jm] = new Rectangle(x, y, width, height);
                x -= 10;

            }
        
        }
        public void dibujaSnake(Graphics papel)
        {
            foreach (Rectangle rec in snakeRec)
            {
                papel.FillRectangle(pincel, rec);
            }
        
        
        }

        public void dibujaSnake()
        {
            for (int j = snakeRec.Length - 1; j > 0; j--)
            {
                snakeRec[j] = snakeRec[j - 1];
            }
        
        }
        public void mover_abajo()
        {
        dibujaSnake();
        snakeRec[0].Y +=10;
        
        }
        public void mover_arriba()
        {
        dibujaSnake();
        snakeRec[0].Y -=10;
        }

        public void mover_derecha()
        {
        dibujaSnake();
        snakeRec[0].X +=10;
        }
        public void mover_izquierda()
        {
        dibujaSnake();
        snakeRec[0].X -=10;
        }

        public void crecimiento_Snake()
        {
        List<Rectangle> rec = snakeRec.ToList();
            rec.Add(new Rectangle(snakeRec[snakeRec.Length - 1].X, snakeRec[snakeRec.Length -1].Y, width, height));
            snakeRec = rec.ToArray();

        }
    }
}
