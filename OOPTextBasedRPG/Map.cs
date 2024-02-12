using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace OOPTextBasedRPG
{
    internal class Map
    {
        #region Wall Tile Char
        public char wallTile = '^';
        #endregion

        #region Border Offset
        public int borderOffset = 1;
        #endregion

        #region Map File
        static string path = @"map.txt";
        static readonly string[] mapRows = File.ReadAllLines(path);
        #endregion

        #region Map Axis Lengths
        public int mapXLength = mapRows[0].Length;
        public int mapYLength = mapRows.Length;
        #endregion

        #region Entities
        private List<Entity> entities = new List<Entity>();

        public Map(List<Entity> initialEntities)
        {
            entities.AddRange(initialEntities);
        }

        public void AddEntity(Entity entity, Point2D position)
        {
            entities.Add(entity);
            entity.position = position;
        }

        public void RemoveEntity(Point2D position)
        {
            foreach (var entity in GetEntities())
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
            if (tile == '^')
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write('▲');
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (tile == '*')
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write('♣');
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (tile == ' ')
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(' ');
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (tile == '~')
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write('»');
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (tile == 'A')
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write('⌂');
                Console.ForegroundColor = ConsoleColor.White;
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

        #region HUD
        static void RenderLegend()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("▲ - Mountains (Cannot Climb)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("» - Rivers");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  - Grass");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("♣ - Trees");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("⌂ - Towns");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        static void RenderHealth(Player player, Enemy enemy)
        {
            Console.WriteLine("Player Health: " + player.healthSystem.health);
            Console.WriteLine("Enemy Health: " + enemy.healthSystem.health);
            Console.WriteLine();
        }

        public void ShowHUD(Player player, Enemy enemy)
        {
            RenderLegend();
            RenderHealth(player, enemy);
        }
        #endregion
    }
}
