using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTextBasedRPG
{
    abstract class Entity : GameObject
    {
        #region Variables
        public HealthSystem healthSystem;

        public int damageNumber = 1;

        public bool gaveDamage;

        public int moveSpeed = 1;
        #endregion

        public void Move(Map map, Point2D startPos, Point2D endPos)
        {
            if (endPos.y < 0 + map.borderOffset || endPos.x < 0 + map.borderOffset || endPos.y >= map.mapYLength + map.borderOffset || endPos.x >= map.mapXLength + map.borderOffset)
            {
                return;
            }
            else if (map.GetTile(endPos) == map.wallTile)
            {
                return;
            }
            else if (map.GetEntity(endPos) != null)
            {
                Attack(map.GetEntity(endPos));
            }
            else
            {
                map.AddEntity(map.GetEntity(startPos), endPos);
                map.RemoveEntity(startPos);
            }
        }

        public void Attack(Entity target)
        {
            //Random random = new Random();
            //int damage = random.Next(0, 2);
            target.healthSystem.TakeDamage(damageNumber);
            gaveDamage = true;
        }

        #region Constructor
        public Entity(int health)
        {
            Debug.WriteLine("Entity Class Constructed");
            healthSystem = new HealthSystem(health);
        }
        #endregion
    }
}