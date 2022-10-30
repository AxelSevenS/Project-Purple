using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plateformeur
{
    public class Goal : Sprite
    {
        public Goal(PictureBox picture, Level level) : base(picture, level) { }
        
        public override void Interact(Player player)
        {
            if ( !player.picture.Bounds.IntersectsWith(picture.Bounds) )
                return;


            player.Win();
            int addedScore;

            Point playerCenter = new Point(player.picture.Left + player.picture.Width / 2, player.picture.Top + player.picture.Height / 2);

            if (playerCenter.Y > picture.Bottom - 48)
            {
                addedScore = 10;
            }
            else if (playerCenter.Y > picture.Bottom - 96)
            {
                addedScore = 20;
            }
            else if (playerCenter.Y > picture.Bottom - 144)
            {
                addedScore = 40;
            }
            else if (playerCenter.Y > picture.Bottom - 192)
            {
                addedScore = 50;
            }
            else
            {
                addedScore = 100;
            }

            player.score += addedScore;
            
            player.picture.Left = picture.Left;
        }

        public override void Kill()
        {
        }

        public override void Update()
        {
        }

        protected override void Animation()
        {
        }
    }
}
