using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTextBasedRPG
{
    internal abstract class Item : GameObject
    {
        public bool isPickedUp = false;
        public readonly Map map;
        public readonly ConsoleColor color;
        public readonly string icon;

        public Item(Point2D position, Map map, ConsoleColor color, string icon)
        {
            this.map = map;
            this.position = new Point2D(position.x, position.y);
            this.color = color;
            this.icon = icon;
        }

        public void ItemDraw()
        {
            if (!isPickedUp)
            {
                Console.SetCursorPosition(this.position.x, this.position.y);
                Console.ForegroundColor = color;
                Console.WriteLine(icon);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public abstract void PickupItem();
    }
}
