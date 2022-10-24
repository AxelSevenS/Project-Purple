using Plateformeur.Properties;
using System;
using System.Threading.Tasks;
using System.Drawing;

using System.Windows.Forms;
using System.Collections.Generic;

namespace Plateformeur
{
    public abstract class Enemy : Sprite
    {

        public static List<Enemy> enemies = new List<Enemy>();

        private bool toPointB = true;
        private int pointA;
        private int pointB;

        protected bool dead;


        public Enemy(PictureBox picture, int pointA, int pointB) : base(picture) 
        {
            this.pointA = pointA;
            this.pointB = pointB;

            Reset();

            Animation();
        }

        public Enemy(PictureBox picture) : this(picture, picture.Left - 100 + picture.Width, picture.Left + 100 - picture.Width * 2)
        {
        }

        protected void PositionCycle()
        {
            const int speed = 3;

            picture.Left = Utility.MoveTowards(picture.Left, toPointB ? pointB : pointA, speed);

            // When the enemy reaches the targeted point, change target.
            if ((toPointB && picture.Bounds.Left == pointB) || (!toPointB && picture.Bounds.Left == pointA))
                toPointB = !toPointB;
        }

        public override void Update()
        {
            if (!dead)
            {
                AliveUpdate();
            }

        }

        public sealed override void Interact(Player player)
        {
            if (!dead && player.picture.Bounds.IntersectsWith(picture.Bounds))
            {
                if (player.picture.Bottom < picture.Bounds.Bottom - picture.Height / 4)
                {
                    Pound(player);
                }
                else
                {
                    SideTouch(player);
                }
            }

        }

        public override void Reset()
        {
            base.Reset();
            dead = false;
            picture.Visible = true;
            toPointB = true;
            picture.Left = pointA;
        }

        protected virtual void AliveUpdate()
        {
            PositionCycle();
        }

        public abstract void Kill();

        protected abstract void Animation();

        protected abstract void Pound(Player player);

        protected abstract void SideTouch(Player player);

    }
}
