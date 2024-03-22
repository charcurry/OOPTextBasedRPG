using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPTextBasedRPG.Settings;

namespace OOPTextBasedRPG
{
    internal class ShieldItem : Item
    {
        public int healingValue;

        public ShieldItem(Point2D position, Map map) : base (position, map)
        {
            icon = shieldItemIcon;
            color = shieldItemColor;
            healingValue = shieldItemHealingValue;
        }

        public override void PickupItem()
        {
            if (map.GetPlayer().healthSystem.shield != map.GetPlayer().healthSystem.maxShield)
            {
                map.GetPlayer().healthSystem.RegenerateShield(healingValue);
                base.PickupItem();
            }
        }
    }
}
