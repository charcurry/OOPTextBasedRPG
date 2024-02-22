using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTextBasedRPG
{
    internal class GameManager
    {
        #region Variables
        private readonly Map map;
        private readonly HUD hud;
        private readonly Enemy enemy;
        private readonly Player player;
        private readonly HealthItem healthItem;
        #endregion

        #region Constructor
        public GameManager()
        {
            map = new Map();
            hud = new HUD();
            enemy = new Enemy(map, 10, new Point2D(16, 10));
            player = new Player(enemy, map, 10, new Point2D(3, 3));
            healthItem = new HealthItem(new Point2D(8, 8), map, player);
        }
        #endregion

        public void InitGame()
        {
            map.AddEntity(player, player.position);
            map.AddEntity(enemy, enemy.position);
            map.AddItem(healthItem, healthItem.position);
            map.GetEntities();
            map.GetItems();
            Console.CursorVisible = false;
            map.RenderMap();
            hud.ShowHUD(player, enemy);
        }

        public void RunGameLoop()
        {
            while (!player.gameOver)
            {
                player.PlayerDraw();
                healthItem.ItemDraw();
                enemy.EnemyDraw();
                player.PlayerUpdate();
                enemy.EnemyUpdate();
                player.gaveDamage = false;
                if (player.healthSystem.isDead)
                {
                    player.gameOver = true;
                    player.playerDead = true;
                }
                else if (enemy.healthSystem.isDead)
                {
                    player.gameOver = true;
                    player.playerVictory = true;
                }
                map.RenderMap();
                hud.ShowHUD(player, enemy);
                if (player.playerVictory)
                {
                    RenderTextScreen("Victory");
                }
                if (player.playerDead)
                {
                    RenderTextScreen("Game Over");
                }
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
    }
}
