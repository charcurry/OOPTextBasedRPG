using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTextBasedRPG
{
    internal class Enemy : Entity
    {

        #region Classes
        readonly Map map;
        #endregion

        #region Constructor
        public Enemy(Map map, int health) : base(health)
        {
            this.map = map;
            this.position.y = 10;
            this.position.x = 16;
            Debug.WriteLine("Enemy Class Constructed");
        }
        #endregion

        public void EnemyDraw(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("G");
        }

        public void EnemyUpdate()
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
            if (!map.GetPlayer().gaveDamage)
            {
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
