using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Plateformeur
{
    public abstract class Sprite
    {

        private Point startPosition;

        public PictureBox picture;


        public Sprite(PictureBox picture)
        {
            this.picture = picture;
            startPosition = picture.Location;
        }



        public abstract void Update();

        public virtual void Interact(Player player) {;}

        public virtual void Reset()
        {
            picture.Location = startPosition;
        }

    }
}
