using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plateformeur
{
    public static class LevelManager
    {

        public static Form currentLevel;


        private static Level1 level1; 
        private static Level2 level2; 
        private static Level3 level3; 

        private static int levelNumber;

        public static void NextLevel()
        {
            levelNumber++;
            LoadLevel();
        }

        public static void SetLevel(int levelNumber)
        {
            LevelManager.levelNumber = levelNumber;
            LoadLevel();
        }

        public static void LoadLevel()
        {
            level1?.Close();
            level2?.Close();
            level3?.Close();

            switch (levelNumber)
            {
                default:
                    level1 = new Level1();
                    currentLevel = level1;
                    break;
                case 2:
                    level2 = new Level2();
                    currentLevel = level2;
                    break;
                case 3:
                    level3 = new Level3();
                    currentLevel = level3;
                    break;
                case 4:
                    // var youWin = new YouWin();
                    // youWin.Show();
                    break;
            }

            currentLevel.Show();
        }
        
    }
}
