using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTextBasedRPG
{
    internal class ShieldItem : Item
    {
        public ShieldItem(Point2D position, Map map, ConsoleColor color, string icon) : base (position, map, color, icon)
        {

        }

        public override void PickupItem()
        {
            map.GetPlayer().healthSystem.RegenerateShield(5);
            isPickedUp = true;
        }
    }
}
