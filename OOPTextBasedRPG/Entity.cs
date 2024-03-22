﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPTextBasedRPG.Settings;

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

        public int movesLeftToGetThroughWater = movesToGetThroughWater;
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
                //checks tiles along x-axis
                if (deltaX >= deltaY)
                {
                    int error = deltaX / 2;
                    //checks each tile along axis
                    for (int i = 0; i < deltaX; i++)
                    {
                        //checks for wall
                        if (map.GetTile(new Point2D(x, y)) == wallTile)
                        {
                            return;
                        }
                        error -= deltaY;
                        //moves normally
                        if (error < 0)
                        {
                            y += stepY;
                            error += deltaX;
                        }
                        x += stepX;
                    }
                }
                //checks tiles along y-axis
                else
                {
                    int error = deltaY / 2;
                    //checks each tile along axis
                    for (int i = 0; i < deltaY; i++)
                    {
                        //checks for wall
                        if (map.GetTile(new Point2D(x, y)) == wallTile)
                        {
                            return;
                        }
                        error -= deltaX;
                        //moves normally
                        if (error < 0)
                        {
                            x += stepX;
                            error += deltaY;
                        }
                        y += stepY;
                    }
                }
            }
            //dealing with water tiles
            if (map.GetTile(startPos) == waterTile && (this == map.GetPlayer() || this == (Slime)map.GetEnemy()))
            {
                if (movesLeftToGetThroughWater > 0)
                {
                    movesLeftToGetThroughWater--;
                    return;
                }
                else
                {
                    movesLeftToGetThroughWater = movesToGetThroughWater;
                }
            }
            //dealing with the edge of the world
            if (endPos.y < 0 + borderOffset || endPos.x < 0 + borderOffset || endPos.y >= map.mapYLength + borderOffset || endPos.x >= map.mapXLength + borderOffset)
            {
                return;
            }
            //dealing with wall tiles
            else if (map.GetTile(endPos) == wallTile)
            {
                return;
            }
            // dealing with doors
            else if (this == map.GetPlayer() && map.GetTile(endPos) == doorTile)
            {
                if (map.GetPlayer().numKeys > 0)
                {
                    map.SetTile(endPos, airTile);
                    map.GetPlayer().numKeys--;
                }
            }
            // dealing with attacking other entities
            else if (map.GetEntity(endPos) != null)
            {
                Attack(map.GetEntity(endPos));
                if (map.GetEntity(endPos).healthSystem.isDead)
                {
                    map.RemoveEntity(endPos);
                }
            }
            //dealing with picking up items
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
            // dealing with moving normally
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