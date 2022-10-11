using System;
using System.Drawing;

using System.Windows.Forms;

namespace Plateformeur
{
    public class Player : Sprite
    {
        public static Player current;


        private int _score = 0;



        public int gravity;

        public bool right, left;



        public int score
        {
            get => _score;
            set
            {
                _score = Math.Min(Math.Max(value, 0), 999);
                Console.WriteLine("Score: " + _score);
            }
        }




        public Player(PictureBox picture) : base(picture) 
        {
            current = this;
        }


        public void Jump()
        {
            const int jumpForce = -15;
            gravity = jumpForce;
        }

        public override void Update()
        {
            const int moveSpeed = 5;
            const int fallSpeed = 10;

            gravity += (gravity < fallSpeed ? 1 : 0);

            int moveDirection = right ? 1 : left ? -1 : 0;
            picture.MovePicture(moveDirection * moveSpeed, gravity);
        }

        public override void Reset()
        {
            base.Reset();
            score = 0;
        }

    }
}
