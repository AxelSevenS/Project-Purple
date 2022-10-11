using System;
using System.Drawing;

using System.Windows.Forms;

namespace Plateformeur
{
    public class Enemy : Sprite
    { 

        Point pointA;
        Point pointB;


        public Enemy(PictureBox picture, Point pointA, Point pointB) : base(picture) 
        {
            this.pointA = pointA;
            this.pointB = pointB;
        }

        public override void Update()
        {
            if (Player.current.picture.Bounds.IntersectsWith(picture.Bounds))
                Form1.current.Reset();
        }

    }
}
