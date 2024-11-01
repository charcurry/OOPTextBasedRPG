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
        public readonly Map map;
        public readonly ItemSettings itemSettings;

        public ItemManager(Map map, ItemSettings itemSettings)
        {
            items = new List<Item>();
            this.map = map;
            this.itemSettings = itemSettings;
        }

        public void InitItems()
        {
            items.Add(new HealthItem(new Point2D(20, 4), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(43, 13), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(63, 30), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(41, 27), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(28, 18), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(8, 6), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(15, 7), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(51, 21), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(17, 27), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(14, 21), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(58, 25), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(79, 9), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(92, 18), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(50, 4), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(45, 17), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(68, 10), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(84, 28), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(6, 17), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(93, 11), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(28, 31), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(23, 15), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(71, 17), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(22, 22), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(35, 6), map, itemSettings.HealthItem));
            items.Add(new HealthItem(new Point2D(60, 15), map, itemSettings.HealthItem));

            items.Add(new ShieldItem(new Point2D(10, 15), map, itemSettings.ShieldItem));
            items.Add(new ShieldItem(new Point2D(8, 31), map, itemSettings.ShieldItem));
            items.Add(new ShieldItem(new Point2D(60, 17), map, itemSettings.ShieldItem));
            items.Add(new ShieldItem(new Point2D(66, 5), map, itemSettings.ShieldItem));

            items.Add(new KeyItem(new Point2D(8, 19), map, itemSettings.KeyItem));
            items.Add(new KeyItem(new Point2D(7, 13), map, itemSettings.KeyItem));
            items.Add(new KeyItem(new Point2D(50, 18), map, itemSettings.KeyItem));
            items.Add(new KeyItem(new Point2D(75, 14), map, itemSettings.KeyItem));
        }

        public void AddItems()
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
