using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTextBasedRPG
{
    internal class KeyItem : Item
    {

        public KeyItem(Point2D position, Map map, ConsoleColor color, string icon) : base(position, map, color, icon)
        {

        }

        public override void PickupItem()
        {
            map.GetPlayer().numKeys++;
            base.PickupItem();
        }
    }
}
