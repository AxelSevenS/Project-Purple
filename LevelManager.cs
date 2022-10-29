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


        private static Level1 level1 = new Level1(); 

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
            level1.Hide();

            switch (levelNumber)
            {
                default:
                    try {
                        level1.level.Reset();
                        level1.Show();
                    } catch (System.ObjectDisposedException) {
                        level1 = new Level1();
                        level1.Show();
                    } finally {
                        currentLevel = level1;
                    }
                    break;
            }
        }
        
    }
}
