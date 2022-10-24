using Plateformeur.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plateformeur 
{
    public class Goomba : Enemy
    {
        public Goomba(PictureBox picture, int pointA, int pointB) : base(picture, pointA, pointB)
        {
        }

        public Goomba(PictureBox picture) : base(picture)
        {
        }

        public override void Reset()
        {
            base.Reset();
            picture.Image = Resources.goomba1;
        }

        protected override async void Animation()
        {
            bool animState = false;
            while (!dead)
            {
                picture.Image = animState ? Resources.goomba1 : Resources.goomba2;
                animState = !animState;
                await Task.Delay(200);
            }
        }

        public override async void Kill()
        {
            dead = true;
            picture.Image = Resources.goombaDead;
            await Task.Delay(400);
            picture.Visible = false;
        }

        protected override void Pound(Player player)
        {
            player.score += 5;
            Kill();
            picture.Image = Resources.goombaDead;
            player.Jump();
        }

        protected override void SideTouch(Player player)
        {
            Form1.current.Reset();
        }
    }
}
