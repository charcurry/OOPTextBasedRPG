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

        public EnemyManager(Map map)
        {
            this.map = map;
            enemies = new List<Enemy>();
        }

        public void InitEnemies()
        {
            enemies.Add(new Slime(map, new Point2D(16, 9)));
            enemies.Add(new Slime(map, new Point2D(16, 15)));
            enemies.Add(new Slime(map, new Point2D(89, 16)));
            enemies.Add(new Slime(map, new Point2D(58, 11)));
            enemies.Add(new Slime(map, new Point2D(16, 30)));
            enemies.Add(new Slime(map, new Point2D(68, 14)));
            enemies.Add(new Slime(map, new Point2D(43, 21)));
            enemies.Add(new Slime(map, new Point2D(38, 30)));
            enemies.Add(new Slime(map, new Point2D(72, 26)));
            enemies.Add(new Slime(map, new Point2D(24, 6)));
            enemies.Add(new Slime(map, new Point2D(32, 20)));
            enemies.Add(new Slime(map, new Point2D(36, 10)));
            enemies.Add(new Slime(map, new Point2D(51, 29)));
            enemies.Add(new Slime(map, new Point2D(8, 27)));
            enemies.Add(new Slime(map, new Point2D(30, 13)));
            enemies.Add(new Slime(map, new Point2D(66, 21)));
            enemies.Add(new Slime(map, new Point2D(10, 20)));
            enemies.Add(new Slime(map, new Point2D(14, 3)));
            enemies.Add(new Slime(map, new Point2D(88, 10)));
            enemies.Add(new Slime(map, new Point2D(78, 17)));
            enemies.Add(new Slime(map, new Point2D(39, 17)));
            enemies.Add(new Slime(map, new Point2D(81, 22)));
            enemies.Add(new Slime(map, new Point2D(19, 17)));
            enemies.Add(new Slime(map, new Point2D(45, 9)));
            enemies.Add(new Slime(map, new Point2D(63, 4)));

            enemies.Add(new LightningSpirit(map, new Point2D(84, 12)));
            enemies.Add(new LightningSpirit(map, new Point2D(11, 19)));
            enemies.Add(new LightningSpirit(map, new Point2D(77, 28)));

            enemies.Add(new Bat(map, new Point2D(49, 8)));
            enemies.Add(new Bat(map, new Point2D(62, 27)));
            enemies.Add(new Bat(map, new Point2D(22, 28)));
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
