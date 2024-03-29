﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPTextBasedRPG.Settings;

namespace OOPTextBasedRPG
{
    internal class KeyItem : Item
    {

        public KeyItem(Point2D position, Map map) : base(position, map)
        {
            icon = keyItemIcon;
            color = keyItemColor;
        }

        public override void PickupItem()
        {
            map.GetPlayer().numKeys++;
            base.PickupItem();
        }
    }
}
