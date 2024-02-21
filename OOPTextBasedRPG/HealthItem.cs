using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTextBasedRPG
{
    internal class HealthItem : Item
    {
        public HealthItem(Point2D position, Map map, Player player) : base (position, map, player) 
        {
            
        }
    }
}
