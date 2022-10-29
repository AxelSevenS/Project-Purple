using System.Drawing;

using System.Windows.Forms;

namespace Plateformeur
{
    public abstract class Sprite : GameObject
    {
        public Sprite(PictureBox picture, Level level) : base(picture, level) { }



        public abstract void Kill();

        protected abstract void Animation();
        

        public abstract void Update();

    }
}
