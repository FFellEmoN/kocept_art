using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiatorArena
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Arena
    {

    }

    class Player
    {
        public Player(float health, float damage)
        {
            Health = health;
            Damage = damage;
        }

        public float Health { get; protected set; }
        public float Damage { get; protected set; }
        public string Name { get; private set; }

        public virtual void TakeDamage(float damage)
        {
            Health -= damage;
        }
    }

    class Human : Player
    {
        private static float _health = 100;
        private static float _damage = 10;

        public Human() : base(_health, _damage)
        {

        }

        public override void TakeDamage(float health)
        {
            base.TakeDamage(health);
            Resurrect();
        }

        private void Resurrect()
        {
            int chanceResurrection = 3;
            int minValue = 0;
            int maxValue = 10;

            float healthAfterResurrection = 60;

            Random random = new Random();

            if (random.Next(minValue, maxValue) <= chanceResurrection)
            {
                Health = healthAfterResurrection;
            }
        }
    }

    class Vampire
    {

    }

    class Knight
    {

    }

    class Demon
    {

    }

    class wizard
    {

    }
}
