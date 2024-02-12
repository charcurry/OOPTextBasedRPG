using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTextBasedRPG
{
    public class HealthSystem
    {
        #region Variables
        public int health;
        public int maxHealth;
        public bool isDead;
        #endregion

        #region Constructor
        public HealthSystem(int initHealth)
        {
            health = initHealth;
        }
        #endregion

        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                Console.WriteLine("Error: Entity Cannot Take " + damage + " Damage");
            }
            else if (health - damage <= 0)
            {
                health = 0;
                isDead = true;
            }
            else if (health > 0)
            {
                health -= damage;
            }
        }

        public void Heal(int hp)
        {
            if (hp < 0)
            {
                Console.WriteLine("Error: Entity Cannot Heal " + hp + " HP");
            }
            else if (health + hp > 100)
            {
                health = maxHealth;
            }
            else
            {
                health += hp;
            }
        }
    }
}