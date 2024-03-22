using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTextBasedRPG
{
    internal class ItemManager
    {
        public readonly List<Item> items;

        public ItemManager()
        {
            items = new List<Item>();
        }

        public void InitItems(Map map)
        {
            items.Add(new HealthItem(new Point2D(20, 4), map));
            items.Add(new HealthItem(new Point2D(43, 13), map));
            items.Add(new HealthItem(new Point2D(63, 30), map));
            items.Add(new HealthItem(new Point2D(41, 27), map));
            items.Add(new HealthItem(new Point2D(28, 18), map));
            items.Add(new ShieldItem(new Point2D(10, 15), map));
            items.Add(new ShieldItem(new Point2D(8, 31), map));
            items.Add(new ShieldItem(new Point2D(66, 5), map));
            items.Add(new KeyItem(new Point2D(8, 19), map));
            items.Add(new KeyItem(new Point2D(7, 13), map));
        }

        public void AddItems(Map map)
        {
            foreach (var item in items)
            {
                map.AddItem(item, item.position);
            }
        }

        public void DrawItems()
        {
            foreach (var item in items)
            {
                item.ItemDraw();
            }
        }
    }

}
