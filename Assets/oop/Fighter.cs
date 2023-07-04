using System;
namespace oop
{
    // класс - абстракция бойца 

    public class Fighter
    {
        protected const int defaultHealth = 10;

        public readonly int Damage;
        protected int health;
        protected bool lifeState = true;
        public bool LifeState
        {
            get => lifeState;
        }

        // инкапсуляция 
        public int Health
        {
            get => health;
            protected set
            {
                if (value > 0)
                    health = value;
                else
                    lifeState = false;
            }
        }

        public Fighter(int damage, int health = defaultHealth)
        {
            if (damage < 0) throw new ArgumentException("damage cannot be less than zero");
            if (health < 0) throw new ArgumentException("health cannot be less than zero");
            this.Damage = damage;
            this.health = health;
            this.lifeState = true;
        }

        protected void ToDamage(Fighter enemy, int damage)
        {
            enemy.Health -= damage;
        }
        // инкапсуляция 
        public virtual void Hit(Fighter enemy)
        {
            //dry 
            ToDamage(enemy, Damage);
        }
    }
}