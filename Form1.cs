using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plateformeur
{
    public partial class Form1 : Form
    {

        public static Form1 current;

        private Player player;
        private Enemy[] enemies;
        private Coin[] coins;



        public Form1()
        {
            current = this;

            InitializeComponent();


            coins = new Coin[1]
            {
                new Coin(coinPicture1)
            };

            enemies = new Enemy[]
            {
                new Enemy(enemyPicture1, new Point(50, 50), new Point(100, 100))
            };

            player = new Player(playerPicture);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            g.Clear(Color.White);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Z || e.KeyCode == Keys.Up || e.KeyCode == Keys.Space)
                player.Jump();

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Q || e.KeyCode == Keys.Left)
                player.left = true;
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                player.right = true;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Q || e.KeyCode == Keys.Left)
                player.left = false;
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                player.right = false;
        }

        private void OnUpdateTick(object sender, EventArgs e)
        {

            player.Update();

            foreach (Enemy enemy in enemies)
                enemy?.Update();

            foreach (Coin coin in coins)
                coin?.Update();

            // panel1.Refresh();

        }




        public void Reset()
        {

            foreach( Coin coin in coins)
                coin?.Reset();

            foreach ( Enemy enemy in enemies)
                enemy?.Reset();

            player?.Reset();
        }
    }
}
