using System;
using System.Drawing;

using System.Windows.Forms;

namespace Plateformeur
{
    public class Coin : Sprite
    {

        private bool _enabled = true;


        private bool enabled {
            get => _enabled;
            set
            {
                _enabled = value;
                picture.Visible = value;
            }
        }

        public Coin(PictureBox picture) : base(picture) { }

        public override void Update()
        {

        }

        public override void Interact()
        {
            if ( !enabled || !Player.current.picture.Bounds.IntersectsWith(picture.Bounds) )
                return;

            Player.current.score++;
            enabled = false;
        }

        public override void Reset()
        {
            base.Reset();
            enabled = true;
        }

    }
}
