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

        private int animState = 1;

        public Goomba(PictureBox picture, Level level, int pointA, int pointB) : base(picture, level, pointA, pointB)
        {
        }

        public Goomba(PictureBox picture, Level level, int width) : base(picture, level, width)
        {
        }

        public Goomba(PictureBox picture, Level level) : base(picture, level)
        {
        }

        public override void Reset()
        {
            base.Reset();
            picture.Image = Resources.goomba1;
        }

        protected override void Animation()
        {
            if (dead)
                return;
                
            const int animLength = 20;
            picture.Image = animState < animLength ? Resources.goomba1 : Resources.goomba2;
            
            if (animState >= animLength*2)
                animState = 1;
            else
                animState++;
            
        }

        public override async void Kill()
        {
            if (dead)
                return;
            
            dead = true;
            level.player.score += 5;
            picture.Image = Resources.goombaDead;
            await Task.Delay(400);
            picture.Visible = false;
        }

        protected override void Pound(Player player)
        {
            Kill();
            picture.Image = Resources.goombaDead;
            player.Jump();
        }

        protected override void SideTouch(Player player)
        {
            player.Kill();
        }
    }
}
