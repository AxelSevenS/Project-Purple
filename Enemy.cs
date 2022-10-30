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
        
        protected bool toPointB = true;
        public int pointA;
        public int pointB;

        protected bool dead;

        protected virtual int speed => 2;


        public Enemy(PictureBox picture, Level level, int pointA, int pointB) : base(picture, level) 
        {
            this.pointA = pointA;
            this.pointB = pointB;

            Reset();
        }

        public Enemy(PictureBox picture, Level level, int width) : this(picture, level, picture.Left - width + picture.Width, picture.Left + width - picture.Width * 2)
        {
        }

        public Enemy(PictureBox picture, Level level) : this(picture, level, 100)
        {
        }

        protected void PositionCycle()
        {

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

            Animation();

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

        protected abstract void Pound(Player player);

        protected abstract void SideTouch(Player player);

    }
}
