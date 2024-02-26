using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTextBasedRPG
{
    internal class HealthItem : Item
    {
        public HealthItem(Point2D position, Map map, ConsoleColor color, string icon) : base(position, map, color, icon) 
        {

        }

        public override void PickupItem()
        {
            map.GetPlayer().healthSystem.Heal(5);
            isPickedUp = true;
        }
    }
}
