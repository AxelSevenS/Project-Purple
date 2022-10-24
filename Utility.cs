using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Plateformeur
{
    public static class Utility
    {

        public static double SqrDistance(PointF a, PointF b)
        {
            return Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2);
        }

        public static double Distance(PointF a, PointF b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        public static bool OutOfBounds(this PictureBox picture)
        {
            return picture.Top > Form1.current.Size.Height - picture.Size.Height - 35 || picture.Left > Form1.current.Size.Width - picture.Size.Width - 15 || picture.Left < 0 || picture.Top < 0;; 
        }

        
        public static int MoveTowards(int current, int target, int maxDelta)
        {
            if (Math.Abs(target - current) <= maxDelta)
                return target;
            return current + Math.Sign(target - current) * maxDelta;
        }


        public static CollisionType MovePictureWithCollision(this PictureBox picture, int x, int y, bool collideWithBorders = true)
        {
            CollisionType collisionType = 0;
            Rectangle bounds = picture.Bounds;

            if ( collideWithBorders )
            {
                bounds.X = Math.Min(Math.Max(picture.Left + x, 0), Form1.current.Size.Width - picture.Size.Width - 15);
                bounds.Y = Math.Min(Math.Max(picture.Top + y, 0), Form1.current.Size.Height - picture.Size.Height - 35);

                // if (bounds.Y + y > Form1.current.Size.Height - picture.Size.Height - 35)
                //     collisionType |= CollisionType.Bottom;
            }
            else 
            {
                bounds.X += x;
                bounds.Y += y;
            }
            
            if (collisionType == 0 && y > 0)
            {
                // Collide with ground sprites
                foreach (PictureBox ground in Form1.current.ground)
                {
                    if ((picture.Bottom < ground.Bottom) && ground.Bounds.IntersectsWith(bounds))
                    {
                        bounds.Y = ground.Top - picture.Size.Height;
                        collisionType |= CollisionType.Bottom;
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
                    collisionType |= x > 0 ? CollisionType.Right : CollisionType.Left;
                    break;
                }
            }

            // Collide with ceiling sprites
            foreach (PictureBox ceiling in Form1.current.ceilings)
            {
                if (ceiling.Bounds.IntersectsWith(bounds))
                {
                    bounds.Y = ceiling.Top + ceiling.Size.Height;
                    collisionType |= CollisionType.Top;
                    break;
                }
            }
            

            picture.Bounds = bounds;
            return collisionType;
        }


        public static void MovePicture(this PictureBox picture, int x, int y, bool collideWithBorders = true)
        {
            Rectangle bounds = picture.Bounds;

            if ( collideWithBorders )
            {
                bounds.X = Math.Min(Math.Max(picture.Left + x, 0), Form1.current.Size.Width - picture.Size.Width - 15);
                bounds.Y = Math.Min(Math.Max(picture.Top + y, 0), Form1.current.Size.Height - picture.Size.Height - 35);
            }
            else 
            {
                bounds.X = picture.Left + x;
                bounds.Y = picture.Top + y;
            }

            picture.Bounds = bounds;
        }
    }

    [Flags]
    public enum CollisionType : ushort
    {
        Top = 1,
        Bottom = 2,
        Left = 4,
        Right = 8
    }
}
