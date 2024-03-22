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
            enemies.Add(new LightningSpirit(map, new Point2D(84, 12)));
            enemies.Add(new LightningSpirit(map, new Point2D(11, 19)));
            enemies.Add(new LightningSpirit(map, new Point2D(77, 28)));
            enemies.Add(new Slime(map, new Point2D(89, 16)));
            enemies.Add(new Bat(map, new Point2D(49, 8)));
            enemies.Add(new Bat(map, new Point2D(62, 27)));
            enemies.Add(new Bat(map, new Point2D(22, 28)));
            enemies.Add(new Slime(map, new Point2D(58, 11)));
            enemies.Add(new Slime(map, new Point2D(16, 30)));
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
