﻿using System;
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

        public bool couldPickUp = true;
        #endregion

        public void Move(Map map, Point2D startPos, Point2D endPos)
        {
            // this is a check for any entity with a move speed above 2 to make sure there is no clipping out of bounds
            if (moveSpeed >= 2)
            {
                int deltaX = Math.Abs(endPos.x - startPos.x);
                int deltaY = Math.Abs(endPos.y - startPos.y);
                int stepX = Math.Sign(endPos.x - startPos.x);
                int stepY = Math.Sign(endPos.y - startPos.y);

                int x = startPos.x;
                int y = startPos.y;

                if (deltaX >= deltaY)
                {
                    int error = deltaX / 2;
                    for (int i = 0; i < deltaX; i++)
                    {
                        if (map.GetTile(new Point2D(x, y)) == map.wallTile)
                        {
                            return;
                        }
                        error -= deltaY;
                        if (error < 0)
                        {
                            y += stepY;
                            error += deltaX;
                        }
                        x += stepX;
                    }
                }
                else
                {
                    int error = deltaY / 2;
                    for (int i = 0; i < deltaY; i++)
                    {
                        if (map.GetTile(new Point2D(x, y)) == map.wallTile)
                        {
                            return;
                        }
                        error -= deltaX;
                        if (error < 0)
                        {
                            x += stepX;
                            error += deltaY;
                        }
                        y += stepY;
                    }
                }
            }

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
                if (map.GetItem(endPos).isPickedUp)
                {
                    pickedUpItem = map.GetItem(endPos);
                    map.RemoveItem(endPos);
                    //map.AddEntity(map.GetEntity(startPos), endPos);
                    //map.RemoveEntity(startPos);
                    couldPickUp = true;
                }
                else
                {
                    couldPickUp = false;
                }
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
        public Entity(Point2D position)
        {
            Debug.WriteLine("Entity Class Constructed");
            healthSystem = new HealthSystem();
            this.position = new Point2D(position.x, position.y);
        }
        #endregion
    }
}