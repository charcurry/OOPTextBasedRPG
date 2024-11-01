using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPTextBasedRPG.Settings;

namespace OOPTextBasedRPG
{
    internal class KeyItem : Item
    {

        public KeyItem(Point2D position, Map map, KeyItemSettings keyItemSettings) : base(position, map)
        {
            icon = keyItemSettings.Icon;
            color = keyItemSettings.Color;
        }

        public override void PickupItem()
        {
            map.GetPlayer().numKeys++;
            base.PickupItem();
        }
    }
}
