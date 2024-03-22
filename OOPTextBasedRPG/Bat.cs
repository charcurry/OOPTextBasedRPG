using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPTextBasedRPG.Settings;

namespace OOPTextBasedRPG
{
    internal class Bat : Enemy
    {
        public Bat(Map map, Point2D position) : base(map, position)
        {
            attackDamage = batDamage;
            moveSpeed = batSpeed;
            healthSystem.health = batHealth;
            healthSystem.maxHealth = batMaxHealth;
            healthSystem.shield = batShield;
            healthSystem.maxHealth = batMaxShield;
            icon = batIcon;
            color = batColor;
        }

        public override void EnemyUpdate()
        {
            if (!healthSystem.isDead && map.GetPlayer() != null)
            {
                Random random = new Random();
                int direction = random.Next(0, 4);
                switch (direction)
                {
                    case 0:
                        int newXLeft = position.x - moveSpeed;
                        int newYLeft = position.y - moveSpeed;
                        Point2D newPositionLeft = new Point2D(newXLeft, newYLeft);
                        Move(map, position, newPositionLeft);
                        break;
                    case 1:
                        int newYDown = position.y + moveSpeed;
                        int newXDown = position.x + moveSpeed;
                        Point2D newPositionDown = new Point2D(newXDown, newYDown);
                        Move(map, position, newPositionDown);
                        break;
                    case 2:
                        int newYUp = position.y + moveSpeed;
                        int newXUp = position.x - moveSpeed;
                        Point2D newPositionUp = new Point2D(newXUp, newYUp);
                        Move(map, position, newPositionUp);
                        break;
                    case 3:
                        int newXRight = position.x + moveSpeed;
                        int newYRight = position.y - moveSpeed;
                        Point2D newPositionRight = new Point2D(newXRight, newYRight);
                        Move(map, position, newPositionRight);
                        break;
                }
            }
        }

    }
}
