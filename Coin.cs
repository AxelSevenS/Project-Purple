using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    public class Coin : IDrawable
    {

        private static SolidBrush coinBrush = new SolidBrush(Color.Yellow);

        public static Size size = new Size(15, 15);
        public Point position;

        public Coin(Point position)
        {
            this.position = position;
        }

        public Coin(int x, int y)
        {
            this.position = new Point(x, y);
        }

        public void Draw(Graphics graphics)
        {
            Rectangle rec = new Rectangle(position, size);
            graphics.FillRectangle(coinBrush, rec);
        }
    }
}
