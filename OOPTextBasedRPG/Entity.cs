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

        public Item pickedUpItem;

        public Entity attackedEnemy;
        public Entity attacker;

        public int attackDamage;

        public bool gaveDamage;

        public int moveSpeed;
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
            else if (this == map.GetPlayer() && map.GetTile(endPos) == map.doorTile)
            {
                if (map.GetPlayer().numKeys > 0)
                {
                    map.SetTile(endPos, map.airTile);
                    map.GetPlayer().numKeys--;
                }
            }
            else if (map.GetEntity(endPos) != null)
            {
                Attack(map.GetEntity(endPos));
                if (map.GetEntity(endPos).healthSystem.isDead)
                {
                    map.RemoveEntity(endPos);
                }
            }
            else if (map.GetItem(endPos) != null && this == map.GetPlayer())
            {
                map.GetItem(endPos).PickupItem();
                pickedUpItem = map.GetItem(endPos);
                map.RemoveItem(endPos); 
                map.AddEntity(map.GetEntity(startPos), endPos);
                map.RemoveEntity(startPos);
            }
            else
            {
                map.AddEntity(map.GetEntity(startPos), endPos);
                map.RemoveEntity(startPos);
            }
        }

        public void Attack(Entity target)
        {
            target.healthSystem.TakeDamage(attackDamage);
            gaveDamage = true;
            attackedEnemy = target;
            attacker = this;
        }

        #region Constructor
        public Entity(int health, int shield, int maxHealth, int maxShield, Point2D position, int attackDamage, int moveSpeed)
        {
            Debug.WriteLine("Entity Class Constructed");
            healthSystem = new HealthSystem(health, shield, maxHealth, maxShield);
            this.position = new Point2D(position.x, position.y);
            this.attackDamage = attackDamage;
            this.moveSpeed = moveSpeed;
        }
        #endregion
    }
}