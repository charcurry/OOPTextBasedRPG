using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTextBasedRPG
{
    public static class Settings
    {
        #region Player Settings
        public static int playerHealth = 10;
        public static int playerMaxHealth = 10;
        public static int playerShield = 10;
        public static int playerMaxShield = 10;
        public static int playerSpeed = 1;
        public static int playerDamage = 3;
        #endregion

        #region Slime Variables
        public static int slimeHealth = 10;
        public static int slimeMaxHealth = 10;
        public static int slimeShield = 10;
        public static int slimeMaxShield = 10;
        public static int slimeSpeed = 1;
        public static int slimeDamage = 2;
        public static ConsoleColor slimeColor = ConsoleColor.DarkGreen;
        public static string slimeIcon = "O";
        #endregion

        #region Bat Variables
        public static int batHealth = 5;
        public static int batMaxHealth = 5;
        public static int batShield = 3;
        public static int batMaxShield = 3;
        public static int batSpeed = 1;
        public static int batDamage = 1;
        public static ConsoleColor batColor = ConsoleColor.DarkBlue;
        public static string batIcon = "W";
        #endregion

        #region Lightning Spirit
        public static int lightningSpiritHealth = 1;
        public static int lightningSpiritMaxHealth = 1;
        public static int lightningSpiritShield = 5;
        public static int lightningSpiritMaxShield = 5;
        public static int lightningSpiritSpeed = 2;
        public static int lightningSpiritDamage = 1;
        public static ConsoleColor lightningSpiritColor = ConsoleColor.Yellow;
        public static string lightningSpiritIcon = "Y";
        #endregion
    }
}
