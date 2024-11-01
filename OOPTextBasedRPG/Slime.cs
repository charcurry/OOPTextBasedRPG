using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPTextBasedRPG.GameSettings;

namespace OOPTextBasedRPG
{
    internal class Slime : Enemy
    {

        int distanceX;
        int distanceY;
        private readonly SlimeSettings slimeSettings;

        public Slime(Map map, Point2D position, SlimeSettings slimeSettings) : base(map, position)
        {
            this.slimeSettings = slimeSettings;
            attackDamage = slimeSettings.Damage;
            moveSpeed = slimeSettings.Speed;
            healthSystem.health = slimeSettings.Health;
            healthSystem.maxHealth = slimeSettings.MaxHealth;
            healthSystem.shield = slimeSettings.Shield;
            healthSystem.maxHealth = slimeSettings.MaxShield;
            icon = slimeSettings.Icon;
            color = slimeSettings.Color;
        }

        public override void EnemyUpdate()
        {
            if (!healthSystem.isDead && map.GetPlayer() != null)
            {
                if (map.GetPlayer() != null)
                {
                    distanceX = Math.Abs(position.x - map.GetPlayer().position.x);
                    distanceY = Math.Abs(position.y - map.GetPlayer().position.y);
                }

                if (distanceX <= slimeSettings.MaxDetectionRadius && distanceY <= slimeSettings.MaxDetectionRadius) 
                {
                    Random random = new Random();
                    int direction = random.Next(0, 4);

                    if (position.x - moveSpeed == map.GetPlayer().position.x)
                    {
                        direction = 0;
                    }
                    else if (position.x + moveSpeed == map.GetPlayer().position.x)
                    {
                        direction = 3;
                    }
                    else if (position.y - moveSpeed == map.GetPlayer().position.y)
                    {
                        direction = 2;
                    }
                    else if (position.y + moveSpeed == map.GetPlayer().position.y)
                    {
                        direction = 1;
                    }
                    switch (direction)
                    {
                        case 0:
                            int newXLeft = position.x - moveSpeed;
                            Point2D newPositionLeft = new Point2D(newXLeft, position.y);
                            Move(map, position, newPositionLeft);
                            break;
                        case 1:
                            int newYDown = position.y + moveSpeed;
                            Point2D newPositionDown = new Point2D(position.x, newYDown);
                            Move(map, position, newPositionDown);
                            break;
                        case 2:
                            int newYUp = position.y - moveSpeed;
                            Point2D newPositionUp = new Point2D(position.x, newYUp);
                            Move(map, position, newPositionUp);
                            break;
                        case 3:
                            int newXRight = position.x + moveSpeed;
                            Point2D newPositionRight = new Point2D(newXRight, position.y);
                            Move(map, position, newPositionRight);
                            break;
                    }
                }
            }
        }

    }
}
