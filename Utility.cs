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
            return picture.Top > LevelManager.currentLevel.Size.Height - picture.Size.Height - 35 || picture.Left > LevelManager.currentLevel.Size.Width - picture.Size.Width - 15 || picture.Left < 0 || picture.Top < 0;; 
        }

        
        public static int MoveTowards(int current, int target, int maxDelta)
        {
            if (Math.Abs(target - current) <= maxDelta)
                return target;
            return current + Math.Sign(target - current) * maxDelta;
        }


        public static CollisionType MovePictureWithCollision(this PictureBox picture, Level level, int x, int y, bool collideWithBorders = true)
        {
            CollisionType collisionType = 0;
            Rectangle bounds = picture.Bounds;

            if ( collideWithBorders )
            {
                bounds.X = Math.Min(Math.Max(picture.Left + x, 0), level.form.Size.Width - picture.Size.Width - 15);
                bounds.Y = Math.Min(Math.Max(picture.Top + y, 0), level.form.Size.Height - picture.Size.Height - 35);
            }
            else 
            {
                bounds.X += x;
                bounds.Y += y;
            }

            Point center = new Point(bounds.X + bounds.Width / 2, bounds.Y + bounds.Height / 2);

            // Collide with block sprites
            foreach (Block block in level.blocks)
            {
                if (block.Bounds.IntersectsWith(bounds))
                {

                    CollisionType blockCollision = 
                        center.X < block.Left ? CollisionType.Right :
                        center.X > block.Right ? CollisionType.Left :
                        center.Y < block.Bottom ? CollisionType.Bottom : 
                        center.Y > block.Top ? CollisionType.Top :
                        0;

                    switch (blockCollision)
                    {
                        case CollisionType.Top:
                            bounds.Y = block.Bottom;
                            break;
                        case CollisionType.Bottom:
                            bounds.Y = block.Top - picture.Size.Height;
                            break;
                        case CollisionType.Left:
                            bounds.X = block.Right;
                            break;
                        case CollisionType.Right:
                            bounds.X = block.Left - picture.Size.Width;
                            break;
                    }

                    collisionType |= blockCollision;
                }

            }


            picture.Bounds = bounds;
            return collisionType;
        }


        public static void MovePicture(this PictureBox picture, Level level, int x, int y, bool collideWithBorders = true)
        {
            Rectangle bounds = picture.Bounds;

            if ( collideWithBorders )
            {
                bounds.X = Math.Min(Math.Max(picture.Left + x, 0), level.form.Size.Width - picture.Size.Width - 15);
                bounds.Y = Math.Min(Math.Max(picture.Top + y, 0), level.form.Size.Height - picture.Size.Height - 35);
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
