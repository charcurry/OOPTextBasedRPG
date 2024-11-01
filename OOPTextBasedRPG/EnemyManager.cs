using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTextBasedRPG
{
    internal class EnemyManager
    {
        public readonly List<Enemy> enemies;
        public readonly Map map;
        public readonly EnemySettings enemySettings;

        public EnemyManager(Map map, EnemySettings enemySettings)
        {
            this.enemySettings = enemySettings;
            if (enemySettings == null)
            {
                throw new ArgumentException("enemy settings not initialized");
            }
            this.map = map;
            enemies = new List<Enemy>();
        }

        public void InitEnemies()
        {
            enemies.Add(new Slime(map, new Point2D(16, 9), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(16, 15), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(89, 16), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(58, 11), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(16, 30), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(68, 14), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(43, 21), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(38, 30), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(72, 26), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(24, 6), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(32, 20), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(36, 10), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(51, 29), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(8, 27), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(30, 13), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(66, 21), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(10, 20), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(14, 3), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(88, 10), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(78, 17), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(39, 17), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(81, 22), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(19, 17), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(45, 9), enemySettings.Slime));
            enemies.Add(new Slime(map, new Point2D(63, 4), enemySettings.Slime));

            enemies.Add(new LightningSpirit(map, new Point2D(84, 12), enemySettings.LightningSpirit));
            enemies.Add(new LightningSpirit(map, new Point2D(11, 19), enemySettings.LightningSpirit));
            enemies.Add(new LightningSpirit(map, new Point2D(77, 28), enemySettings.LightningSpirit));

            enemies.Add(new Bat(map, new Point2D(49, 8), enemySettings.Bat));
            enemies.Add(new Bat(map, new Point2D(62, 27), enemySettings.Bat));
            enemies.Add(new Bat(map, new Point2D(22, 28), enemySettings.Bat));
        }

        public void AddEnemies()
        {
            foreach (var enemy in enemies)
            {
                map.AddEntity(enemy, enemy.position);
            }
        }

        public void DrawEnemies()
        {
            foreach (var enemy in enemies)
            {
                enemy.EnemyDraw();
            }
        }

        public void UpdateEnemies()
        {
            foreach (var enemy in enemies)
            {
                enemy.EnemyUpdate();
            }
        }

        public bool AllEnemiesDefeated()
        {
            return enemies.All(e => e.healthSystem.isDead);
        }
    }
}
