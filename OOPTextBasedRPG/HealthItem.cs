using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPTextBasedRPG.Settings;

namespace OOPTextBasedRPG
{
    internal class HealthItem : Item
    {
        public int healingValue; 

        public HealthItem(Point2D position, Map map) : base(position, map) 
        {
            color = healthItemColor;
            icon = healthItemIcon;
            healingValue = healthItemHealingValue;
        }

        public override void PickupItem()
        {
            map.GetPlayer().healthSystem.Heal(healingValue);
            base.PickupItem();
        }
    }
}
