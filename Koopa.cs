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

        protected override int speed => 1;

        public Koopa(PictureBox picture, Level level, int pointA, int pointB) : base(picture, level, pointA, pointB)
        {
        }

        public Koopa(PictureBox picture, Level level, int width) : base(picture, level, width)
        {
        }

        public Koopa(PictureBox picture, Level level) : base(picture, level)
        {
        }

        public override void Reset()
        {
            picture.Image = Resources.koopaRight1;
            inShell = false;
            direction = 0;
            base.Reset();
        }

        protected override void AliveUpdate()
        {
            if (inShell)
            {

                if (picture.OutOfBounds())
                    Kill();

                if (direction == 0)
                    return;


                CollisionType collision = picture.MovePictureWithCollision(level, direction * 7, gravity, false);

                bool hitRight = direction == 1 && collision.HasFlag(CollisionType.Right);
                bool hitLeft = direction == -1 && collision.HasFlag(CollisionType.Left);
                if (hitRight || hitLeft)
                {
                    direction = -direction;
                }


                if (collision.HasFlag(CollisionType.Bottom) || collision.HasFlag(CollisionType.Top))
                {
                    gravity = 1;
                }
                else
                {
                    const int fallSpeed = 10;
                    gravity = Utility.MoveTowards(gravity, fallSpeed, 1);
                }

                foreach(Enemy enemy in level.enemies)
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
                    picture.Image = Resources.koopaShell;
                }
                else
                {
                    if (toPointB)
                    {
                        picture.Image = animState ? Resources.koopaRight1 : Resources.koopaRight2;
                    }
                    else
                    {
                        picture.Image = animState ? Resources.koopaLeft1 : Resources.koopaLeft2;
                    }
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
                player.Kill();
            }
        }
    }
}
