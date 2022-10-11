using System;
using System.Drawing;

using System.Windows.Forms;

namespace Plateformeur
{
    public class Player : Sprite
    {
        public static Player current;

        private Label scoreLabel;
        private int _score = 0;



        public int gravity;
        private bool canJump;

        public bool rightInput, leftInput, jumpInput;



        public int score
        {
            get => _score;
            set
            {
                _score = Math.Min(Math.Max(value, 0), 999);
                scoreLabel.Text = $"Score : {_score}";
            }
        }




        public Player(PictureBox picture, Label scoreLabel) : base(picture) 
        {
            current = this;
            this.scoreLabel = scoreLabel;
            score = 0;
        }


        public void Jump()
        {
            if (!canJump) return;

            const int jumpForce = -12;
            gravity = jumpForce;
        }

        public override void Update()
        {
            const int moveSpeed = 5;

            int moveDirection = rightInput ? 1 : leftInput ? -1 : 0;
            if ( picture.MovePicture(moveDirection * moveSpeed, gravity) )
            {
                gravity = 1;

                canJump = true;
            }
            else
            {
                const int fallSpeed = 10;
                gravity += (gravity < fallSpeed ? 1 : 0);

                canJump = false;
            }

            if (jumpInput)
                Jump();
        }

        public override void Reset()
        {
            base.Reset();
            score = 0;
        }

    }
}
