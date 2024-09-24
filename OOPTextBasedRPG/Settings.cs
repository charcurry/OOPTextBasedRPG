using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTextBasedRPG
{
    public static class Settings
    {
        public const ConsoleColor defaultConsoleColor = ConsoleColor.White;

        #region Player Settings
        public const int playerHealth = 10;
        public const int playerMaxHealth = 20;
        public const int playerShield = 10;
        public const int playerMaxShield = 20;
        public const int playerSpeed = 1;
        public const int playerDamage = 3;
        public const ConsoleColor playerColor = ConsoleColor.Magenta;
        public const string playerIcon = "@";
        public const ConsoleKey upKey = ConsoleKey.W;
        public const ConsoleKey downKey = ConsoleKey.S;
        public const ConsoleKey leftKey = ConsoleKey.A;
        public const ConsoleKey rightKey = ConsoleKey.D;
        public const ConsoleKey altUpKey = ConsoleKey.UpArrow;
        public const ConsoleKey altDownKey = ConsoleKey.DownArrow;
        public const ConsoleKey altLeftKey = ConsoleKey.LeftArrow;
        public const ConsoleKey altRightKey = ConsoleKey.RightArrow;
        public const ConsoleKey quitKey = ConsoleKey.Escape;
        public static Point2D spawnPoint = new Point2D(3, 3);
        #endregion

        #region Enemy Settings

            #region Slime Settings
            public const int slimeHealth = 5;
            public const int slimeMaxHealth = 5;
            public const int slimeShield = 5;
            public const int slimeMaxShield = 5;
            public const int slimeSpeed = 1;
            public const int slimeDamage = 2;
            public const ConsoleColor slimeColor = ConsoleColor.DarkGreen;
            public const string slimeIcon = "O";
            public const int slimeMaxDetectionRadius = 5;
            #endregion

            #region Bat Settings
            public const int batHealth = 5;
            public const int batMaxHealth = 5;
            public const int batShield = 3;
            public const int batMaxShield = 3;
            public const int batSpeed = 1;
            public const int batDamage = 1;
            public const ConsoleColor batColor = ConsoleColor.DarkBlue;
            public const string batIcon = "W";
            #endregion

            #region Lightning Spirit Settings
            public const int lightningSpiritHealth = 1;
            public const int lightningSpiritMaxHealth = 1;
            public const int lightningSpiritShield = 5;
            public const int lightningSpiritMaxShield = 5;
            public const int lightningSpiritSpeed = 2;
            public const int lightningSpiritDamage = 1;
            public const ConsoleColor lightningSpiritColor = ConsoleColor.Yellow;
            public const string lightningSpiritIcon = "Y";
            #endregion

        #endregion

        #region Item Settings

            #region Health Item Settings
            public const ConsoleColor healthItemColor = ConsoleColor.Red;
            public const string healthItemIcon = "H";
            public const int healthItemHealingValue = 5;
            #endregion

            #region Shield Item Settings
            public const ConsoleColor shieldItemColor = ConsoleColor.Cyan;
            public const string shieldItemIcon = "S";
            public const int shieldItemHealingValue = 5;
            #endregion

            #region Key Item Settings
            public const ConsoleColor keyItemColor = ConsoleColor.DarkGray;
            public const string keyItemIcon = "F";
        #endregion

        #endregion

        #region HUD Settings
        public const int HUDTimerDuration = 3;
        public const string continueText = "Press any key to continue...";
        public const string gameOverText = "Game Over";
        public const string victoryText = "Victory";
        #endregion

        #region Map Settings
        public const ConsoleColor airTileColor = ConsoleColor.White;
        public const ConsoleColor wallTileColor = ConsoleColor.White;
        public const ConsoleColor doorTileColor = ConsoleColor.DarkGray;
        public const ConsoleColor waterTileColor = ConsoleColor.DarkBlue;
        public const char airTile = ' ';
        public const char wallTile = '#';
        public const char doorTile = 'E';
        public const char waterTile = '~';
        public const int borderOffset = 1;
        public const int movesToGetThroughWater = 1;
        #endregion
    }
}
