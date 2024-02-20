﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTextBasedRPG
{
    internal class Program
    {
        #region Instantiation
        static readonly Map map = new Map();
        static readonly HUD hud = new HUD();
        static readonly Enemy enemy = new Enemy(map, 10, new Point2D(16, 10));
        static readonly Player player = new Player(enemy, map, 10, new Point2D(3, 3));
        static readonly Item item = new Item(new Point2D(8,8), map, player);
        #endregion

        static void Main(string[] args)
        {

            map.AddEntity(player, player.position);
            map.AddEntity(enemy, enemy.position);
            map.AddItem(item, item.position);
            map.GetEntities();
            map.GetItems();
            Console.CursorVisible = false;
            map.RenderMap();
            hud.ShowHUD(player, enemy);

            while (!player.gameOver)
            {
                player.PlayerDraw();
                enemy.EnemyDraw(enemy.position.x, enemy.position.y);
                item.ItemDraw(item.position.x, item.position.y);
                player.PlayerUpdate();
                if (!player.gaveDamage)
                {
                    enemy.EnemyUpdate();
                }
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

            void RenderTextScreen(string displayText)
            {
                Console.Clear();
                Console.WriteLine(displayText);
            }
        }
    }
}