using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTextBasedRPG
{
    internal class ShieldItem : Item
    {
        public ShieldItem(Point2D position, Map map, Player player) : base(position, map, player)
        {

        }

        public override void PickupItem()
        {
            player.healthSystem.Heal(3);
            isPickedUp = true;
        }
    }
}
