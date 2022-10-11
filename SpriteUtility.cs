using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Plateformeur
{
    public static class SpriteUtility
    {
        public static void MovePicture(this PictureBox picture, int x, int y)
        {
            picture.Left = Math.Min(Math.Max(picture.Left + x, 0), Form1.current.Size.Width - picture.Size.Width - 15);
            picture.Top = Math.Min(Math.Max(picture.Top + y, 0), Form1.current.Size.Height - picture.Size.Height - 35);
        }
    }
}
