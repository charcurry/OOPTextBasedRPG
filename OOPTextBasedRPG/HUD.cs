using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTextBasedRPG
{
    internal class HUD
    {
        public Enemy lastEnemyAttacked;
        public Enemy attacker;

        private readonly Map map;

        #region HUD
        static void RenderLegend()
        {
            Console.WriteLine("@ - Player");
            Console.WriteLine("# - Walls (Cannot move through)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Y - Lightning Spirits");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("W - Bats");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("H - Health Pickups");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("S - Shield Pickups");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("O - Slimes");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("F - Keys");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("E - Doors");
            Console.WriteLine();
        }

        public void RenderHUD(Player player, Enemy[] enemies)
        {
            if (map.GetPlayer() != null)
            {
                lastEnemyAttacked = (Enemy)map.GetPlayer().attackedEnemy;
            }
            attacker = GetAttacker(enemies);
            Console.WriteLine("Player Health: " + player.healthSystem.health + " Player Shield: " + player.healthSystem.shield);
            Console.WriteLine("# of Keys: " + player.numKeys);
            if (lastEnemyAttacked != null)
            {
                Console.WriteLine("Enemy Health: " + lastEnemyAttacked.healthSystem.health + " Enemy Shield: " + lastEnemyAttacked.healthSystem.shield);
            }
            else if (attacker != null)
            {
                Console.WriteLine("Enemy Health: " + attacker.healthSystem.health + " Enemy Shield: " + attacker.healthSystem.shield);
            }
            Console.WriteLine();
        }

        public void ShowHUD(Player player, Enemy[] enemies)
        {
            RenderLegend();
            RenderHUD(player, enemies);
        }

        public HUD(Map map)
        {
            this.map = map;
        }

        public Enemy GetAttacker(Enemy[] enemies)
        {
            foreach (var enemy in enemies)
            {
                if (enemy == enemy.attacker)
                {
                    return enemy;
                }
            }
            return null;
        }

        #endregion
    }
}
