using Plateformeur.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Plateformeur
{
    public partial class Level3 : Form
    {

        public Level level;


        public Level3()
        {

            InitializeComponent();

            level = new Level(this);
        }



        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            level.KeyDown(e);
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            level.KeyUp(e);
        }

        private void OnUpdateTick(object sender, EventArgs e)
        {
            level.Tick();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
