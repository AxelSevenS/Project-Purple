using Plateformeur.Properties;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Plateformeur
{
    public class Player : Sprite
    {

        private int _score = 0;

        public int moveDirection = 0;
        public int lastDirection = 1;
        private int animState = 1;



        public int gravity;
        private bool canJump;

        public bool rightInput, leftInput, jumpInput;



        public int score
        {
            get => _score;
            set
            {
                _score = Math.Min(Math.Max(value, 0), 999);

                if (level.scoreLabel != null)
                    level.scoreLabel.Text = $"Score : {score}";
            }
        }




        public Player(PictureBox picture, Level level) : base(picture, level) 
        {
            score = 0;
        }


        public void Jump()
        {
            const int jumpForce = -12;
            gravity = jumpForce;
        }

        public override void Update()
        {
            const int moveSpeed = 5;

            if (picture.Bounds.Bottom >= level.form.Height)
                Kill();

            moveDirection = rightInput ? 1 : leftInput ? -1 : 0;
            if (moveDirection != 0)
            {
                lastDirection = moveDirection;
            }


            CollisionType collision = picture.MovePictureWithCollision(level, moveDirection * moveSpeed, gravity, false);

            picture.Left = Math.Max(0, Math.Min(Left, LevelManager.currentLevel.Width - Width));

            canJump = false;

            if (collision.HasFlag(CollisionType.Bottom) || collision.HasFlag(CollisionType.Top))
            {
                gravity = 1;

                if (collision.HasFlag(CollisionType.Bottom))
                {
                    canJump = true;
                }
            }
            else
            {
                const int fallSpeed = 10;
                gravity = Utility.MoveTowards(gravity, fallSpeed, 1);
            }

            if (jumpInput && canJump)
                Jump();

            Animation();
        }

        public override void Kill()
        {
            level.Reset();
        }

        protected override void Animation()
        {
            StringBuilder stateName = new StringBuilder("mario");
            stateName.Append(lastDirection == 1 ? "Right" : "Left");
            stateName.Append(canJump ? (moveDirection == 0 ? "0" : animState.ToString()) : "Jump");

            switch (stateName.ToString()) {
                case "marioLeft0":
                    picture.Image = Resources.marioLeft0;
                    break;
                case "marioLeft1":
                    picture.Image = Resources.marioLeft1;
                    break;
                case "marioLeft2":
                    picture.Image = Resources.marioLeft2;
                    break;
                case "marioLeft3":
                    picture.Image = Resources.marioLeft3;
                    break;
                case "marioLeftJump":
                    picture.Image = Resources.marioLeftJump;
                    break;
                case "marioRight0":
                    picture.Image = Resources.marioRight0;
                    break;
                case "marioRight1":
                    picture.Image = Resources.marioRight1;
                    break;
                case "marioRight2":
                    picture.Image = Resources.marioRight2;
                    break;
                case "marioRight3":
                    picture.Image = Resources.marioRight3;
                    break;
                case "marioRightJump":
                    picture.Image = Resources.marioRightJump;
                    break;
            }

            animState = animState > 3 ? 1 : ++animState; 
        }

        public override void Reset()
        {
            base.Reset();
            score = 0;
        }

    }
}
