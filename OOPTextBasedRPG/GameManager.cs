using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static OOPTextBasedRPG.Settings;

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
            player = new Player(map, spawnPoint);
            enemyManager = new EnemyManager(map);
            itemManager = new ItemManager(map);
        }

        public void Init()
        {
            //Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            //Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            //Console.SetWindowPosition(0, 0);
            enemyManager.InitEnemies();
            itemManager.InitItems();

            map.AddEntity(player, player.position);
            enemyManager.AddEnemies();
            itemManager.AddItems();

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

            RenderTextScreen(player.healthSystem.isDead ? gameOverText : victoryText);
            Console.WriteLine(continueText);
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