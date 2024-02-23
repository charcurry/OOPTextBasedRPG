using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTextBasedRPG
{
    internal class LightningSpirit : Enemy
    {
        public LightningSpirit(Map map, int health, int shield, int maxHealth, int maxShield, Point2D position, ConsoleColor color, string icon, int attackDamage, int moveSpeed) : base(map, health, shield, maxHealth, maxShield, position, color, icon, attackDamage, moveSpeed)
        {

        }

        public override void EnemyUpdate()
        {
            if (!healthSystem.isDead && map.GetPlayer() != null)
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
