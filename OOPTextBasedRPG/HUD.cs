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
        public readonly Settings settings;

        public int timerDuration;

        private readonly Map map;

        #region HUD Methods
        void RenderLegend()
        {
            Console.ForegroundColor = settings.Player.Color;
            Console.WriteLine("@ - Player");
            Console.ForegroundColor = settings.Map.WallTileColor;
            Console.WriteLine("# - Walls (Cannot move through)");
            Console.ForegroundColor = settings.Enemies.LightningSpirit.Color;
            Console.WriteLine("Y - Lightning Spirits");
            Console.ForegroundColor = settings.Player.DefaultConsoleColor;
            Console.ForegroundColor = settings.Enemies.Bat.Color;
            Console.WriteLine("W - Bats");
            Console.ForegroundColor = settings.Player.DefaultConsoleColor;
            Console.ForegroundColor = settings.Items.HealthItem.Color;
            Console.WriteLine("H - Health Pickups");
            Console.ForegroundColor = settings.Player.DefaultConsoleColor;
            Console.ForegroundColor = settings.Items.ShieldItem.Color;
            Console.WriteLine("S - Shield Pickups");
            Console.ForegroundColor = settings.Player.DefaultConsoleColor;
            Console.ForegroundColor = settings.Enemies.Slime.Color;
            Console.WriteLine("O - Slimes");
            Console.ForegroundColor = settings.Player.DefaultConsoleColor;
            Console.ForegroundColor = settings.Items.KeyItem.Color;
            Console.WriteLine("F - Keys");
            Console.ForegroundColor = settings.Map.DoorTileColor;
            Console.WriteLine("E - Doors (Locked)");
            Console.ForegroundColor = settings.Player.DefaultConsoleColor;
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

        public HUD(Map map, Settings settings)
        {
            this.map = map;
            this.settings = settings;
            this.timerDuration = settings.HUD.TimerDuration;
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
