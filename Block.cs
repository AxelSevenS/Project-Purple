using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plateformeur
{
    public class Block : GameObject
    {
        public Block(PictureBox picture, Level level) : base(picture, level) { }
    }
}
