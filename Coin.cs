using System;
using System.Drawing;

using System.Windows.Forms;

namespace Plateformeur
{
    public class Coin : Sprite
    {

        private bool enabled = true;


        public Coin(PictureBox picture) : base(picture) { }

        public override void Update()
        {
            if (enabled && Player.current.picture.Bounds.IntersectsWith(picture.Bounds))
            {
                Player.current.score++;
                enabled = false;
            }

            picture.Visible = enabled;
        }

        public override void Reset()
        {
            base.Reset();
            enabled = true;
        }

    }
}
