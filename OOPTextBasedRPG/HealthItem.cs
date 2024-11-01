using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPTextBasedRPG.GameSettings;

namespace OOPTextBasedRPG
{
    internal class HealthItem : Item
    {
        public int healingValue; 

        public HealthItem(Point2D position, Map map, HealthItemSettings healthItemSettings) : base(position, map) 
        {
            color = healthItemSettings.Color;
            icon = healthItemSettings.Icon;
            healingValue = healthItemSettings.HealingValue;
        }

        public override void PickupItem()
        {
            if (map.GetPlayer().healthSystem.health != map.GetPlayer().healthSystem.maxHealth)
            {
                map.GetPlayer().healthSystem.Heal(healingValue);
                base.PickupItem();
            }
        }
    }
}
