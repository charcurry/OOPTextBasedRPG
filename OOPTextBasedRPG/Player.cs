using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOPTextBasedRPG
{
    internal class Player : Entity
    {

        #region GameOver States
        public bool gameOver = false;
        public bool playerVictory = false;
        #endregion

        #region Player Death
        public bool playerDead = false;
        #endregion

        #region Classes
        //readonly Map map;
        #endregion

        public int numKeys;

        public void PlayerDraw()
        {
            if (!healthSystem.isDead)
            {
                Console.SetCursorPosition(this.position.x, this.position.y);
                Console.ForegroundColor = color;
                Console.WriteLine(icon);
                Console.ForegroundColor = playerSettings.DefaultConsoleColor;
            }
        }

        public void PlayerUpdate()
        {
            if (!healthSystem.isDead)
            {
                while (Console.KeyAvailable) { Console.ReadKey(true); }
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.Key == playerSettings.Controls.UpKey || input.Key == playerSettings.Controls.AltUpKey)
                {
                    int newY = position.y - moveSpeed;
                    Point2D newPosition = new Point2D(position.x, newY);
                    Move(map, position, newPosition);
                    //int newEnemyY = enemy.position.y - moveSpeed;
                    //Point2D newEnemyPosition = new Point2D(enemy.position.x, newEnemyY);
                    //if (gaveDamage)
                    //{
                    //    enemy.Move(map, enemy.position, newEnemyPosition);
                    //}
                }
                else if (input.Key == playerSettings.Controls.LeftKey || input.Key == playerSettings.Controls.AltLeftKey)
                {
                    int newX = position.x - moveSpeed;
                    Point2D newPosition = new Point2D(newX, position.y);
                    Move(map, position, newPosition);
                    //int newEnemyX = enemy.position.x - moveSpeed;
                    //Point2D newEnemyPosition = new Point2D(newEnemyX, enemy.position.y);
                    //if (gaveDamage)
                    //{
                    //    enemy.Move(map, enemy.position, newEnemyPosition);
                    //}
                }
                else if (input.Key == playerSettings.Controls.RightKey || input.Key == playerSettings.Controls.AltRightKey)
                {
                    int newX = position.x + moveSpeed;
                    Point2D newPosition = new Point2D(newX, position.y);
                    Move(map, position, newPosition);
                    //int newEnemyX = enemy.position.x + moveSpeed;
                    //Point2D newEnemyPosition = new Point2D(newEnemyX, enemy.position.y);
                    //if (gaveDamage)
                    //{
                    //    enemy.Move(map, enemy.position, newEnemyPosition);
                    //}
                }
                else if (input.Key == playerSettings.Controls.DownKey || input.Key == playerSettings.Controls.AltDownKey)
                {
                    int newY = position.y + moveSpeed;
                    Point2D newPosition = new Point2D(position.x, newY);
                    Move(map, position, newPosition);
                    //int newEnemyY = enemy.position.y + moveSpeed;
                    //Point2D newEnemyPosition = new Point2D(enemy.position.x, newEnemyY);
                    //if (gaveDamage)
                    //{
                    //    enemy.Move(map, enemy.position, newEnemyPosition);
                    //}
                }
                else if (input.Key == playerSettings.Controls.QuitKey)
                {
                    gameOver = true;
                }
            }
        }


        #region Constructor

        private readonly PlayerSettings playerSettings;
        public Player(Map map, Point2D position, PlayerSettings playerSettings) : base(position, map)
        {
            this.playerSettings = playerSettings;
            this.map = map;
            attackDamage = playerSettings.Damage;
            moveSpeed = playerSettings.Speed;
            healthSystem.health = playerSettings.Health;
            healthSystem.maxHealth = playerSettings.MaxHealth;
            healthSystem.shield = playerSettings.Shield;
            healthSystem.maxShield = playerSettings.MaxShield;
            icon = playerSettings.Icon;
            color = playerSettings.Color;
            Debug.WriteLine("Player Class Constructed");
        }
        #endregion
    }
}