using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTextBasedRPG
{
    internal class HUD
    {
        #region HUD
        static void RenderLegend()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("▲ - Mountains (Cannot Climb)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("» - Rivers");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  - Grass");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("♣ - Trees");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("⌂ - Towns");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        static void RenderHealth(Player player, Enemy enemy)
        {
            Console.WriteLine("Player Health: " + player.healthSystem.health);
            Console.WriteLine("Enemy Health: " + enemy.healthSystem.health);
            Console.WriteLine();
        }

        public void ShowHUD(Player player, Enemy enemy)
        {
            RenderLegend();
            RenderHealth(player, enemy);
        }
        #endregion
    }
}
