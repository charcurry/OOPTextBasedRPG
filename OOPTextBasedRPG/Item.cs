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
        public readonly Player player;

        public Item(Point2D position, Map map, Player player)
        {
            this.player = player;
            this.map = map;
            this.position = new Point2D(position.x, position.y);
        }

        public void ItemDraw()
        {
            if (!isPickedUp)
            {
                Console.SetCursorPosition(this.position.x, this.position.y);
                Console.WriteLine("T");
            }
        }

        public abstract void PickupItem();
    }
}
