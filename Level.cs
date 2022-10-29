using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plateformeur
{
    public class Level
    {

        public Form form;

        public Label scoreLabel;
        public Player player;
        public List<Enemy> enemies = new List<Enemy>();
        public List<Coin> coins = new List<Coin>();
        public List<Platform> platforms = new List<Platform>();
        public List<Wall> walls = new List<Wall>();
        public List<Ceiling> ceilings = new List<Ceiling>();

        public int totalOriginShift = 0;
        public bool originShifting = false;

        public Level(Form form)
        {

            this.form = form;

            scoreLabel = null;
            player = null;
            enemies.Clear();
            coins.Clear();
            platforms.Clear();
            walls.Clear();
            ceilings.Clear();

            foreach (Control control in form.Controls)
            {
                foreach (Control child in control.Controls)
                {
                    SetControl(child);

                }
            }
        }

        private void SetControl(Control control)
        {
            string tag = (string)control.Tag;

            if (control is PictureBox picture)
            {

                if (tag == "Player")
                {
                    player = new Player(picture, this);
                }
                else if (tag == "Coin")
                {
                    coins.Add(new Coin(picture, this));
                }
                else if (tag.Contains("Koopa"))
                {
                    string[] split = tag.Split('_');
                    int width = split.Length > 1 ? int.Parse(split[1]) : 100;
                    enemies.Add(new Koopa(picture, this, width));
                }
                else if (tag.Contains("Goomba"))
                {
                    string[] split = tag.Split('_');
                    int width = split.Length > 1 ? int.Parse(split[1]) : 100;
                    enemies.Add(new Goomba(picture, this, width));
                }
                else if (tag == "Wall")
                {
                    walls.Add(new Wall(picture, this));
                }
                else if (tag == "Ceiling")
                {
                    ceilings.Add(new Ceiling(picture, this));
                }
                else if (tag == "Ground")
                {
                    platforms.Add(new Platform(picture, this));
                }

            }
            else if (control is Label label)
            {

                if (tag == "Score")
                {
                    scoreLabel = label;
                }
            }
        }

        public void KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Z || e.KeyCode == Keys.Up || e.KeyCode == Keys.Space)
                player.jumpInput = true;

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Q || e.KeyCode == Keys.Left)
                player.leftInput = true;

            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                player.rightInput = true;
        }

        public void KeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Z || e.KeyCode == Keys.Up || e.KeyCode == Keys.Space)
                player.jumpInput = false;

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Q || e.KeyCode == Keys.Left)
                player.leftInput = false;

            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                player.rightInput = false;
        }

        public void Tick()
        {

            if (player.Left > form.Width * 0.75)
                OriginShift();

            player.Update();

            try
            {
                foreach (Coin coin in coins)
                {
                    if (Utility.SqrDistance(coin.picture.Location, player.picture.Location) > 1000)
                        continue;

                    coin.Interact(player);
                }
            }
            catch (Exception) { }

            try
            {
                foreach (Enemy enemy in enemies)
                {
                    enemy.Update();

                    if (Utility.SqrDistance(enemy.picture.Location, player.picture.Location) > 1000)
                        continue;

                    enemy.Interact(player);
                }
            }
            catch (Exception) { }

        }

        public async void OriginShift()
        {
            if (originShifting)
                return;

            originShifting = true;
            int originShiftAmount = (int)(form.Width * 0.25);
            int originShiftIncrement = originShiftAmount / 20;
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(50);
                OriginShift(originShiftIncrement);

            }
            originShifting = false;
        }

        private void OriginShift(int increment)
        {

            foreach (Wall wall in walls)
            {
                wall.Left -= increment;
            }
            foreach (Ceiling ceiling in ceilings)
            {
                ceiling.Left -= increment;
            }
            foreach (Platform platform in platforms)
            {
                platform.Left -= increment;
            }
            foreach (Coin coin in coins)
            {
                coin.Left -= increment;
            }
            foreach (Enemy enemy in enemies)
            {
                enemy.Left -= increment;
                enemy.pointA -= increment;
                enemy.pointB -= increment;
            }
            player.Left -= increment;

            totalOriginShift -= increment;
        }

        public void Reset()
        {
            OriginShift(totalOriginShift);

            foreach (Wall wall in walls)
                wall?.Reset();

            foreach (Ceiling ceiling in ceilings)
                ceiling?.Reset();

            foreach (Platform platform in platforms)
                platform?.Reset();

            foreach (Coin coin in coins)
                coin?.Reset();

            foreach (Enemy enemy in enemies)
                enemy?.Reset();

            player?.Reset();
        }

    }
}
