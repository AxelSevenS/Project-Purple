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
    public partial class Level1 : Form
    {

        public Level level;


        public Level1()
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





        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox81_Click(object sender, EventArgs e)
        {

        }
    }
}
