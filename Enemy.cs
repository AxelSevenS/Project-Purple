using System;
using System.Drawing;

using System.Windows.Forms;

namespace Plateformeur
{
    public class Enemy : Sprite
    { 

        private bool toPointB = true;
        private int pointA;
        private int pointB;


        public Enemy(PictureBox picture, int pointA, int pointB) : base(picture) 
        {
            this.pointA = pointA;
            this.pointB = pointB;

            this.picture.Left = pointA;
        }

        public Enemy(PictureBox picture) : base(picture)
        {
            this.pointA = picture.Left - 100 + picture.Width;
            this.pointB = picture.Left + 100 - picture.Width * 2;

            this.picture.Left = pointA;
        }

        public override void Update()
        {
            const int speed = 3;

            int movementDirection = toPointB ^ (pointB > pointA) ? -1 : 1;
            int distanceToPoint = toPointB ? Math.Abs(pointB - picture.Left) : Math.Abs(pointA - picture.Left);
            
            picture.MovePicture(movementDirection * Math.Min(distanceToPoint, speed), 0);


            // When the enemy reaches the targeted point, change target.
            if ((toPointB && picture.Bounds.Left == pointB) || (!toPointB && picture.Bounds.Left == pointA))
                    toPointB = !toPointB;

            if (Player.current.picture.Bounds.IntersectsWith(picture.Bounds))
                Form1.current.Reset();
        }

    }
}
