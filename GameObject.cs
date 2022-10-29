using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plateformeur
{
    public abstract class GameObject
    {
        protected Point startPosition;

        public PictureBox picture;
        public Level level;

        
        public int Left
        {
            get => picture.Left;
            set => picture.Left = value;
        }
        public int Right => picture.Right;

        public int Top
        {
            get => picture.Top;
            set => picture.Top = value;
        }
        public int Bottom => picture.Bottom;

        public Point Location
        {
            get => picture.Location;
            set => picture.Location = value;
        }

        public int Width => picture.Width;

        public int Height => picture.Height;

        public Rectangle Bounds
        {
            get => picture.Bounds;
            set => picture.Bounds = value;
        }




        public GameObject(PictureBox picture, Level level)
        {
            this.picture = picture;
            this.level = level;
            startPosition = Location;
        }

        public virtual void Interact(Player player) { }

        public virtual void Reset()
        {
            Location = startPosition;
        }
    }
}
