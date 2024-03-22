using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPTextBasedRPG.Settings;

namespace OOPTextBasedRPG
{
    internal class Slime : Enemy
    {

        int distanceX;
        int distanceY;

        public Slime(Map map, Point2D position) : base(map, position)
        {
            attackDamage = slimeDamage;
            moveSpeed = slimeSpeed;
            healthSystem.health = slimeHealth;
            healthSystem.maxHealth = slimeMaxHealth;
            healthSystem.shield = slimeShield;
            healthSystem.maxHealth = slimeMaxShield;
            icon = slimeIcon;
            color = slimeColor;
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

                if (distanceX <= slimeMaxDetectionRadius && distanceY <= slimeMaxDetectionRadius) 
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
