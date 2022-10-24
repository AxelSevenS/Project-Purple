using Plateformeur.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plateformeur
{
    public class Koopa : Enemy
    {

        private bool inShell;
        private int direction;
        private int gravity;

        public Koopa(PictureBox picture, int pointA, int pointB) : base(picture, pointA, pointB)
        {
        }

        public Koopa(PictureBox picture) : base(picture)
        {
        }

        public override void Reset()
        {
            base.Reset();
            picture.Image = Resources.goomba1;
            inShell = false;
            direction = 0;
        }

        protected override void AliveUpdate()
        {
            if (inShell)
            {

                if (picture.OutOfBounds())
                    Kill();

                if (direction == 0)
                    return;


                CollisionType collision = picture.MovePictureWithCollision(direction * 7, gravity, false);

                bool hitRight = direction == 1 && (collision & CollisionType.Right) == CollisionType.Right;
                bool hitLeft = direction == -1 && (collision & CollisionType.Left) == CollisionType.Left;
                if (hitRight || hitLeft)
                {
                    direction = -direction;
                }


                if ((collision & CollisionType.Bottom) == CollisionType.Bottom || (collision & CollisionType.Top) == CollisionType.Top)
                {
                    gravity = 1;
                }
                else
                {
                    const int fallSpeed = 10;
                    gravity = Utility.MoveTowards(gravity, fallSpeed, 1);
                }

                foreach(Enemy enemy in enemies)
                {
                    if (enemy == this)
                        continue;

                    if (picture.Bounds.IntersectsWith(enemy.picture.Bounds))
                        enemy.Kill();
                }
            }
            else
            {
                PositionCycle();
            }
        }

        protected override async void Animation()
        {
            bool animState = false;
            while (!dead)
            {
                if (inShell)
                {
                    picture.Image = Resources.goombaDead;
                }
                else
                {
                    picture.Image = animState ? Resources.goomba1 : Resources.goomba2;
                    animState = !animState;
                }
                await Task.Delay(200);
            }
        }

        public override void Kill()
        {
            dead = true;
            picture.Visible = false;
        }

        protected override void Pound(Player player)
        {
            if (inShell)
            {
                if (direction == 0)
                {
                    direction = player.lastDirection;
                } else
                {
                    direction = 0;
                }
            }
            else
            {
                inShell = true;
            }
            player.Jump();
        }

        protected override void SideTouch(Player player)
        {
            if (inShell && direction == 0)
            {
                direction = player.lastDirection;
            }
            else
            {
                Form1.current.Reset();
            }
        }
    }
}
