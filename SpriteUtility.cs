using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Plateformeur
{
    public static class SpriteUtility
    {
        public static bool MovePicture(this PictureBox picture, int x, int y)
        {
            bool collided = false;
            Rectangle bounds = picture.Bounds;

            bounds.X = Math.Min(Math.Max(picture.Left + x, 0), Form1.current.Size.Width - picture.Size.Width - 15);
            bounds.Y = Math.Min(Math.Max(picture.Top + y, 0), Form1.current.Size.Height - picture.Size.Height - 35);

            if (bounds.Y + y > Form1.current.Size.Height - picture.Size.Height - 35)
            {
                collided = true;
            } 
            else if (y > 0)
            {
                // Collide with ground sprites
                foreach (PictureBox ground in Form1.current.ground)
                {
                    if (ground.Bounds.IntersectsWith(bounds))
                    {
                        bounds.Y = ground.Top - picture.Size.Height;
                        collided = true;
                        break;
                    }
                }
            }

            // Collide with wall sprites
            foreach (PictureBox wall in Form1.current.walls)
            {
                if (wall.Bounds.IntersectsWith(bounds))
                {
                    bounds.X = x > 0 ? wall.Left - picture.Size.Width : wall.Left + wall.Size.Width;
                    break;
                }
            }

            picture.Bounds = bounds;
            return collided;
        }
    }
}
