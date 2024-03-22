using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPTextBasedRPG.Settings;

namespace OOPTextBasedRPG
{
    internal class HUD
    {
        public Enemy lastEnemyAttacked;
        public Item lastItemPickedUp;
        public Enemy attacker;

        public int timerDuration = HUDTimerDuration;

        private readonly Map map;

        #region HUD Methods
        static void RenderLegend()
        {
            Console.ForegroundColor = playerColor;
            Console.WriteLine("@ - Player");
            Console.ForegroundColor = wallTileColor;
            Console.WriteLine("# - Walls (Cannot move through)");
            Console.ForegroundColor = lightningSpiritColor;
            Console.WriteLine("Y - Lightning Spirits");
            Console.ForegroundColor = defaultConsoleColor;
            Console.ForegroundColor = batColor;
            Console.WriteLine("W - Bats");
            Console.ForegroundColor = defaultConsoleColor;
            Console.ForegroundColor = healthItemColor;
            Console.WriteLine("H - Health Pickups");
            Console.ForegroundColor = defaultConsoleColor;
            Console.ForegroundColor = shieldItemColor;
            Console.WriteLine("S - Shield Pickups");
            Console.ForegroundColor = defaultConsoleColor;
            Console.ForegroundColor = slimeColor;
            Console.WriteLine("O - Slimes");
            Console.ForegroundColor = defaultConsoleColor;
            Console.ForegroundColor = keyItemColor;
            Console.WriteLine("F - Keys");
            Console.ForegroundColor = doorTileColor;
            Console.WriteLine("E - Doors (Locked)");
            Console.ForegroundColor = defaultConsoleColor;
            Console.WriteLine();
        }

        public async void RenderHUD(Player player, Enemy[] enemies)
        {
            Console.WriteLine("Player Objective: Defeat All of the Enemies Without Dying");
            Console.WriteLine();
            if (map.GetPlayer() != null)
            {
                lastEnemyAttacked = (Enemy)map.GetPlayer().attackedEnemy;
            }
            attacker = GetAttacker(enemies);
            Console.WriteLine("Player Health: " + player.healthSystem.health + "  " + "Player Shield: " + player.healthSystem.shield + "  ");
            Console.WriteLine("# of Keys: " + player.numKeys);
            if (lastEnemyAttacked != null)
            {
                Console.WriteLine("Last Enemy Health: " + lastEnemyAttacked.healthSystem.health + "  " + "Last Enemy Shield: " + lastEnemyAttacked.healthSystem.shield + "  ");
            }
            else if (attacker != null)
            {
                Console.WriteLine("Last Enemy Health: " + attacker.healthSystem.health + "  " + "Last Enemy Shield: " + attacker.healthSystem.shield + "  ");
            }
            if (attacker == null && lastEnemyAttacked == null)
            {
                Console.WriteLine();
            }
            Console.WriteLine();
            if (map.GetPlayer() != null)
            {
                lastItemPickedUp = map.GetPlayer().pickedUpItem;
            }
            if (lastItemPickedUp != null && map.GetPlayer().couldPickUp == true)
            {
                Console.WriteLine("Last Item Picked Up: " + lastItemPickedUp.GetType().Name + "                   ");
            }
            else if (map.GetPlayer() != null && map.GetPlayer().couldPickUp == false) 
            {
                Console.WriteLine("Cannot Pick Up Item as Player Resource is Full               ");
                await Task.Delay(timerDuration * 1000); //milliseconds to seconds
                if (lastItemPickedUp != null)
                {
                    map.GetPlayer().couldPickUp = true;
                }
                else if (lastItemPickedUp == null)
                {
                    //Console.SetCursorPosition(0, 48);
                    //Console.WriteLine("                                                                 ");
                    map.GetPlayer().couldPickUp = true;
                    //Console.SetCursorPosition(0, 0);
                }
            }
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
