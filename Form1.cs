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

namespace Plateformeur
{
    public partial class Form1 : Form
    {

        public static Form1 current;

        private Player player;
        public List<PictureBox> walls = new List<PictureBox>();
        public List<PictureBox> ceilings = new List<PictureBox>();
        public List<PictureBox> ground = new List<PictureBox>();



        public Form1()
        {
            current = this;

            InitializeComponent();

            foreach (Control control in panel1.Controls)
            {

                if (control is PictureBox picture)
                {

                    string tag = (string)picture.Tag;

                    switch (tag)
                    {
                        case "Coin":
                            Coin.coins.Add(new Coin(picture));
                            break;
                        case "Goomba":
                            Enemy.enemies.Add(new Goomba(picture));
                            break;
                        case "Koopa":
                            Enemy.enemies.Add(new Koopa(picture));
                            break;
                        case "Wall":
                            walls.Add(picture);
                            break;
                        case "Ceiling":
                            ceilings.Add(picture);
                            break;
                        case "Ground":
                            ground.Add(picture);
                            break;

                    }

                }
            }

            player = new Player(playerPicture, scoreLabel);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Z || e.KeyCode == Keys.Up || e.KeyCode == Keys.Space)
                player.jumpInput = true;

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Q || e.KeyCode == Keys.Left)
                player.leftInput = true;
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                player.rightInput = true;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Z || e.KeyCode == Keys.Up || e.KeyCode == Keys.Space)
                player.jumpInput = false;

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Q || e.KeyCode == Keys.Left)
                player.leftInput = false;
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                player.rightInput = false;
        }

        private void OnUpdateTick(object sender, EventArgs e)
        {

            player.Update();

            foreach (Coin coin in Coin.coins) 
            {
                if ( Utility.SqrDistance(coin.picture.Location, Player.current.picture.Location) > 1000 )
                    continue;

                coin.Interact(player);
            }

            foreach (Enemy enemy in Enemy.enemies) 
            {
                enemy.Update();

                if (Utility.SqrDistance(enemy.picture.Location, Player.current.picture.Location) > 1000)
                    continue;

                enemy.Interact(player);
            }

        }




        public void Reset()
        {

            foreach (Coin coin in Coin.coins)
                coin?.Reset();

            foreach (Enemy enemy in Enemy.enemies)
                enemy?.Reset();

            player?.Reset();
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
    }
}
