using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using static System.Net.WebRequestMethods;
using File = System.IO.File;
using static OOPTextBasedRPG.GameSettings;

namespace OOPTextBasedRPG
{
    internal class Map
    {
        public MapSettings mapSettings;
        public PlayerSettings playerSettings;

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
        public Map(MapSettings mapSettings, PlayerSettings playerSettings)
        {
            this.playerSettings = playerSettings;
            this.mapSettings = mapSettings;
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
                    WriteTile(tile, x, y);

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

        public void WriteTile(char tile, int x, int y)
        {
            if (tile == '#')
            {
                Console.ForegroundColor = mapSettings.WallTileColor;
                Console.Write(mapSettings.WallTile);
                Console.ForegroundColor = playerSettings.DefaultConsoleColor;
            }
            else if (tile == 'E')
            {
                Console.ForegroundColor = mapSettings.DoorTileColor;
                Console.Write(mapSettings.DoorTile);
                Console.ForegroundColor = playerSettings.DefaultConsoleColor;
            }
            else if (tile == ' ')
            {
                Console.ForegroundColor = mapSettings.AirTileColor;
                Console.Write(mapSettings.AirTile);
                Console.ForegroundColor = playerSettings.DefaultConsoleColor;
            }
            else if (tile == '~')
            {
                Console.ForegroundColor = mapSettings.WaterTileColor;
                Console.Write(mapSettings.WaterTile);
                Console.ForegroundColor = playerSettings.DefaultConsoleColor;
            }
            //else if (tile == 'O')
            //{
            //    entities.Add(new Slime(this, new Point2D(x,y)));
            //    Debug.Write("enemy made");
            //}
            else
            {
                Console.Write(tile);
            }
        }

        public char GetTile(Point2D coords)
        {
            return mapRows[coords.y - mapSettings.BorderOffset][coords.x - mapSettings.BorderOffset];
        }

        public void SetTile(Point2D position, char newTile)
        {
            if (position.y >= mapSettings.BorderOffset && position.y < mapYLength + mapSettings.BorderOffset && position.x >= mapSettings.BorderOffset && position.x < mapXLength + mapSettings.BorderOffset)
            {
                var rowArray = mapRows[position.y - mapSettings.BorderOffset].ToCharArray();
                rowArray[position.x - mapSettings.BorderOffset] = newTile;
                mapRows[position.y - mapSettings.BorderOffset] = new string(rowArray);
            }

        }
    }
}
