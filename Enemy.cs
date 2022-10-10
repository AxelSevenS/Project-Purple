using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    public class Enemy : IDrawable
    {

        private static SolidBrush enemyBrush = new SolidBrush(Color.Brown);

        public Point position;
        public Size size;

        public Enemy(Point position, Size size)
        {
            this.position = position;
            this.size = size;
        }
        
        public Enemy(int x, int y, int sizeX, int sizeY) : this(new Point(x, y), new Size(sizeX, sizeY)) { }

        public Enemy(Point position, int sizeX, int sizeY) : this(position, new Size(sizeX, sizeY)) { }

        public Enemy(int x, int y, Size size) : this(new Point(x, y), size) { }


        public void Draw(Graphics graphics)
        {
            Rectangle rec = new Rectangle(position, size);
            graphics.FillRectangle(enemyBrush, rec);
        }

    }
}
