using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto__Snake
{
    public class Comida
    {
        private int x, y, width, height;
        private SolidBrush pincel;
        public Rectangle comidaRec;

        public Comida(Random randComida)
        {
            x = randComida.Next(0, 29) * 10;
            y = randComida.Next(0, 29) * 10;
            pincel = new SolidBrush(Color.Black);

            width = 10;
            height = 10;

            comidaRec = new Rectangle(x, y, width, height);
        }
        public void comidalugar(Random randComida)
        { 
        x = randComida.Next(0,29) * 10;
        y = randComida.Next(0,29) * 10;

        }
        public void dibujoComida(Graphics papel)
        {
            comidaRec.X = x;
            comidaRec.Y = y;

            papel.FillRectangle(pincel, comidaRec);
        
        }
    }
}
