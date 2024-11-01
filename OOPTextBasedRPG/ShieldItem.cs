﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPTextBasedRPG.GameSettings;

namespace OOPTextBasedRPG
{
    internal class ShieldItem : Item
    {
        public int healingValue;

        public ShieldItem(Point2D position, Map map, ShieldItemSettings shieldItemSettings) : base (position, map)
        {
            icon = shieldItemSettings.Icon;
            color = shieldItemSettings.Color;
            healingValue = shieldItemSettings.HealingValue;
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
