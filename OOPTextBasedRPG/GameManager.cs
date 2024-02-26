using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace OOPTextBasedRPG
{
    internal class GameManager
    {
        #region Variables
        private readonly Map map;
        private readonly HUD hud;
        private readonly List<Enemy> enemies;
        private readonly Player player;
        private readonly List<Item> items;
        #endregion

        #region Constructor
        public GameManager()
        {
            map = new Map();
            hud = new HUD(map);
            enemies = new List<Enemy>();
            player = new Player(map, 10, 10, 20, 20, new Point2D(3, 3), 3, 1);
            items = new List<Item>();
        }
        #endregion

        public void InitGame()
        {
            Console.WindowHeight = 63;
            Console.WindowWidth = 240;
            enemies.Add(new Slime(map, 10, 10, 10, 10, new Point2D(16, 9), ConsoleColor.DarkGreen, "O", 2, 1));
            enemies.Add(new Slime(map, 10, 10, 10, 10, new Point2D(16, 15), ConsoleColor.DarkGreen, "O", 1, 1));
            enemies.Add(new LightningSpirit(map, 1, 5, 1, 5, new Point2D(84, 12), ConsoleColor.Yellow, "Y", 3, 2));
            enemies.Add(new LightningSpirit(map, 1, 5, 1, 5, new Point2D(11, 19), ConsoleColor.Yellow, "Y", 3, 2));
            enemies.Add(new LightningSpirit(map, 1, 5, 1, 5, new Point2D(77, 28), ConsoleColor.Yellow, "Y", 3, 2));
            enemies.Add(new Slime(map, 10, 10, 10, 10, new Point2D(89, 16), ConsoleColor.DarkGreen, "O", 2, 1));
            enemies.Add(new Bat(map, 5, 3, 5, 3, new Point2D(49, 8), ConsoleColor.DarkBlue, "W", 1, 1));
            enemies.Add(new Bat(map, 5, 3, 5, 3, new Point2D(62, 27), ConsoleColor.DarkBlue, "W", 1, 1));
            enemies.Add(new Bat(map, 5, 3, 5, 3, new Point2D(22, 28), ConsoleColor.DarkBlue, "W", 1, 1));
            enemies.Add(new Slime(map, 10, 10, 10, 10, new Point2D(58, 11), ConsoleColor.DarkGreen, "O", 2, 1));
            enemies.Add(new Slime(map, 10, 10, 10, 10, new Point2D(16, 30), ConsoleColor.DarkGreen, "O", 2, 1));

            items.Add(new HealthItem(new Point2D(20, 4), map, ConsoleColor.Red, "H"));
            items.Add(new HealthItem(new Point2D(43, 13), map, ConsoleColor.Red, "H"));
            items.Add(new HealthItem(new Point2D(63, 30), map, ConsoleColor.Red, "H"));
            items.Add(new HealthItem(new Point2D(41, 27), map, ConsoleColor.Red, "H"));
            items.Add(new HealthItem(new Point2D(28, 18), map, ConsoleColor.Red, "H"));
            items.Add(new ShieldItem(new Point2D(10, 15), map, ConsoleColor.Cyan, "S"));
            items.Add(new ShieldItem(new Point2D(8, 31), map, ConsoleColor.Cyan, "S"));
            items.Add(new ShieldItem(new Point2D(66, 5), map, ConsoleColor.Cyan, "S"));
            items.Add(new KeyItem(new Point2D(8, 19), map, ConsoleColor.DarkGray, "F"));
            items.Add(new KeyItem(new Point2D(7, 13), map, ConsoleColor.DarkGray, "F"));

            map.AddEntity(player, player.position);
            foreach (var enemy in enemies)
            {
                map.AddEntity(enemy, enemy.position);
            }
            foreach (var item in items)
            {
                map.AddItem(item, item.position);
            }
            map.GetEntities();
            map.GetItems();
            Console.CursorVisible = false;
            map.RenderMap();
            hud.ShowHUD(player, enemies.ToArray());
        }

        public void RunGameLoop()
        {
            while (!player.gameOver)
            {
                player.PlayerDraw();
                ItemsDraw();
                EnemiesDraw();
                player.PlayerUpdate();
                EnemiesUpdate();
                player.gaveDamage = false;
                CheckGameOver();
                map.RenderMap();
                hud.ShowHUD(player, enemies.ToArray());
                CheckForWinner();
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
        private void RenderTextScreen(string displayText)
        {
            Console.Clear();
            Console.WriteLine(displayText);
        }

        private void CheckForWinner()
        {
            if (enemies.All(e => e.healthSystem.isDead))
            {
                RenderTextScreen("Victory");
            }
            if (player.healthSystem.isDead)
            {
                RenderTextScreen("Game Over");
            }
        }

        public void CheckGameOver()
        {
            if (player.healthSystem.isDead || enemies.All(e => e.healthSystem.isDead))
            {
                player.gameOver = true;
            }
        }

        private void EnemiesDraw()
        {
            foreach (var enemy in enemies)
            {
                enemy.EnemyDraw();
            }
        }

        private void EnemiesUpdate()
        {
            foreach (var enemy in enemies)
            {
                enemy.EnemyUpdate();
            }
        }

        private void ItemsDraw()
        {
            foreach (var item in items)
            {
                item.ItemDraw();
            }
        }

    }
}
