using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Platformer
{
    public partial class Form1 : Form
    {


        private Enemy[] enemies;
        private Coin[] coins;

        public Form1()
        {
            InitializeComponent();

            enemies = new Enemy[1]
            {
                new Enemy(new Point(50, 50), new Size(20, 20))
            };

            coins = new Coin[1]
            {
                new Coin(new Point(20, 20))
            };
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(g);
            }

            foreach (Coin coin in coins)
            {
                coin.Draw(g);
            }
        }
    }
}
