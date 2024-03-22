using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using static System.Net.WebRequestMethods;
using File = System.IO.File;
using static OOPTextBasedRPG.Settings;

namespace OOPTextBasedRPG
{
    internal class Map
    {

        #region Map File
        static string path = @"map.txt";
        static readonly string[] mapRows = File.ReadAllLines(path);
        #endregion

        #region Map Axis Lengths
        public int mapXLength = mapRows[0].Length;
        public int mapYLength = mapRows.Length;
        #endregion

        #region Items
        private readonly List<Item> items = new List<Item>();

        public void AddItem(Item item, Point2D position)
        {
            items.Add(item);
            item.position = position;
        }

        public void RemoveItem(Point2D position)
        {
            foreach (var item in GetItems().ToList())
            {
                if (item.position.y == position.y && item.position.x == position.x)
                {
                    items.Remove(item);
                }
            }
        }

        public Item GetItem(Point2D position)
        {
            foreach (var item in GetItems())
            {
                if (item.position.y == position.y && item.position.x == position.x)
                {
                    return item;
                }
            }
            return null;
        }


        public List<Item> GetItems()
        {
            return items;
        }
        #endregion

        #region Entities
        private readonly List<Entity> entities = new List<Entity>();

        public Map(List<Entity> initialEntities, List<Item> items)
        {
            entities.AddRange(initialEntities);
            items.AddRange(items);
        }

        public void AddEntity(Entity entity, Point2D position)
        {
            entities.Add(entity);
            entity.position = position;
        }

        public void RemoveEntity(Point2D position)
        {
            foreach (var entity in GetEntities().ToList())
            {
                if (entity.position.y == position.y && entity.position.x == position.x)
                {
                    entities.Remove(entity);
                }
            }
        }

        public Entity GetEntity(Point2D position)
        {
            foreach (var entity in GetEntities())
            {
                if (entity.position.y == position.y && entity.position.x == position.x)
                {
                    return entity;
                }
            }
            return null;
        }

        public Player GetPlayer()
        {
            foreach (var entity in GetEntities())
            {
                if (entity is Player player)
                {
                    return player;
                }
            }
            return null;
        }

        public Enemy GetEnemy()
        {
            foreach (var entity in GetEntities())
            {
                if (entity is Enemy enemy)
                {
                    return enemy;
                }
            }
            return null;
        }

        public List<Entity> GetEntities()
        {
            return entities;
        }
        #endregion

        #region Constructor
        public Map()
        {
            Debug.WriteLine("Map Class Constructed");
        }
        #endregion

        public void RenderMap()
        {
            Console.SetCursorPosition(0, 0);

            Console.Write('┌');
            for (int i = 0; i < mapXLength; i++)
            {
                Console.Write('─');
            }
            Console.Write('┐');
            Console.WriteLine();
            for (int y = 0; y < mapRows.Length; y++)
            {
                Console.Write('│');
                string mapRow = mapRows[y];
                for (int x = 0; x < mapRow.Length; x++)
                {
                    char tile = mapRow[x];
                    WriteTile(tile);

                }
                Console.Write('│');
                Console.WriteLine();
            }
            Console.Write('└');
            for (int i = 0; i < mapXLength; i++)
            {
                Console.Write('─');
            }
            Console.Write('┘');
            Console.WriteLine();
        }

        public void WriteTile(char tile)
        {
            if (tile == '#')
            {
                Console.ForegroundColor = wallTileColor;
                Console.Write(wallTile);
                Console.ForegroundColor = defaultConsoleColor;
            }
            else if (tile == 'E')
            {
                Console.ForegroundColor = doorTileColor;
                Console.Write(doorTile);
                Console.ForegroundColor = defaultConsoleColor;
            }
            else if (tile == ' ')
            {
                Console.ForegroundColor = airTileColor;
                Console.Write(airTile);
                Console.ForegroundColor = defaultConsoleColor;
            }
            else if (tile == '~')
            {
                Console.ForegroundColor = waterTileColor;
                Console.Write(waterTile);
                Console.ForegroundColor = defaultConsoleColor;
            }
            else
            {
                Console.Write(tile);
            }
        }

        public char GetTile(Point2D coords)
        {
            return mapRows[coords.y - borderOffset][coords.x - borderOffset];
        }

        public void SetTile(Point2D position, char newTile)
        {
            if (position.y >= borderOffset && position.y < mapYLength + borderOffset && position.x >= borderOffset && position.x < mapXLength + borderOffset)
            {
                var rowArray = mapRows[position.y - borderOffset].ToCharArray();
                rowArray[position.x - borderOffset] = newTile;
                mapRows[position.y - borderOffset] = new string(rowArray);
            }

        }
    }
}
