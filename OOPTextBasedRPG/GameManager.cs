using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPTextBasedRPG
{
    internal class GameManager
    {
        private readonly Map map;
        private readonly HUD hud;
        private readonly Player player;
        private readonly EnemyManager enemyManager;
        private readonly ItemManager itemManager;

        public GameManager()
        {
            map = new Map();
            hud = new HUD(map);
            player = new Player(map, new Point2D(3, 3));
            enemyManager = new EnemyManager(map);
            itemManager = new ItemManager();
        }

        public void Init()
        {
            enemyManager.InitEnemies();
            itemManager.InitItems(map);

            map.AddEntity(player, player.position);
            enemyManager.AddEnemies();
            itemManager.AddItems(map);

            map.GetEntities();
            map.GetItems();
            Console.CursorVisible = false;
            map.RenderMap();
            hud.ShowHUD(player, enemyManager.enemies.ToArray());
        }

        public void Update()
        {
            player.PlayerUpdate();
            enemyManager.UpdateEnemies();
            player.gaveDamage = false;
            CheckGameOver();
        }

        public void Draw()
        {
            map.RenderMap();
            hud.ShowHUD(player, enemyManager.enemies.ToArray());
            itemManager.DrawItems();
            enemyManager.DrawEnemies();
            player.PlayerDraw();
        }

        public void RunGameLoop()
        {
            Init();
            Draw();

            while (!player.gameOver)
            {
                Update();
                Draw();
            }

            RenderTextScreen(player.healthSystem.isDead ? "Game Over" : "Victory");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        private void CheckGameOver()
        {
            if (player.healthSystem.isDead || enemyManager.AllEnemiesDefeated())
            {
                player.gameOver = true;
            }
        }

        private void RenderTextScreen(string displayText)
        {
            Console.Clear();
            Console.WriteLine(displayText);
        }
    }
}