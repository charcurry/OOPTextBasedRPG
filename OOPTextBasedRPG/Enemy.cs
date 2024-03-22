using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPTextBasedRPG.Settings;

namespace OOPTextBasedRPG
{
    internal abstract class Enemy : Entity
    {
        public readonly Map map;

        #region Constructor
        public Enemy(Map map, Point2D position) : base(position)
        {
            this.map = map;
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
                Console.ForegroundColor = defaultConsoleColor;
            }
        }

        public abstract void EnemyUpdate(); 
    }
}
