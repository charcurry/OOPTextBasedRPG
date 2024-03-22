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
        public int shield;
        public int maxShield;
        public bool isDead;
        #endregion

        #region Constructor
        public HealthSystem()
        {

        }
        #endregion

        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                Console.WriteLine("Error: Player Cannot Take " + damage + " Damage");
            }
            else if (health - damage <= 0 && shield == 0)
            {
                health = 0;
                shield = 0;
                isDead = true;
            }
            else if (health + shield - damage <= 0)
            {
                health = 0;
                shield = 0;
                isDead = true;
            }
            else if (shield - damage <= 0)
            {
                health -= (damage - shield);
                shield = 0;
            }
            else if (shield > 0)
            {
                shield -= damage;

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
            else if (health + hp > 20)
            {
                health = maxHealth;
            }
            else
            {
                health += hp;
            }
        }

        public void RegenerateShield(int hp)
        {
            if (hp < 0)
            {
                Console.WriteLine("Error: Player Cannot Regenerate " + hp + " Shield");
            }
            else if (shield + hp > 20)
            {
                shield = maxShield;
            }
            else
            {
                shield += hp;
            }
        }
    }
}