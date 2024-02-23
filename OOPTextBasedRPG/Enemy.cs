using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTextBasedRPG
{
    internal abstract class Enemy : Entity
    {
        private readonly ConsoleColor color;
        private readonly string icon;
        public readonly Map map;

        #region Constructor
        public Enemy(Map map, int health, int shield, int maxHealth, int maxShield, Point2D position, ConsoleColor color, string icon, int attackDamage, int moveSpeed) : base(health, shield, maxHealth, maxShield, position, attackDamage, moveSpeed)
        {
            this.map = map;
            this.color = color;
            this.icon = icon;
            Debug.WriteLine("Enemy Class Constructed");
        }
        #endregion

        public void EnemyDraw()
        {
            if (!healthSystem.isDead)
            {
                Console.SetCursorPosition(this.position.x, this.position.y);
                Console.ForegroundColor = color;
                Console.WriteLine(icon);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public abstract void EnemyUpdate(); 
    }
}
