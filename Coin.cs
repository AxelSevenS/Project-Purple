﻿using System;
using System.Collections.Generic;
using System.Drawing;

using System.Windows.Forms;

namespace Plateformeur
{
    public class Coin : Sprite
    {

        public static List<Coin> coins = new List<Coin>();

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

        public override void Interact(Player player)
        {
            if ( !enabled || !player.picture.Bounds.IntersectsWith(picture.Bounds) )
                return;

            player.score++;
            enabled = false;
        }

        public override void Reset()
        {
            base.Reset();
            enabled = true;
        }

    }
}
