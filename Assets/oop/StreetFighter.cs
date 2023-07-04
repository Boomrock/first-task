using System;
namespace oop
{
    //наследование
    class StreetFighter : Fighter
    {
        private Gun gun;
        protected int speed;
        protected const int defaultSpeed = 4;
        //dry
        public StreetFighter(int damage, int health = defaultHealth, int speed = defaultSpeed, Gun gun = null) : base(damage, health)
        {
            if (speed < 0)
                throw new ArgumentException("speed cannot be less than zero");
            this.gun = gun ?? new Gun(0);
            this.speed = speed;
        
        }

        public StreetFighter(Fighter fighter) : this(fighter.Damage, health: fighter.Health)
        {
        }
//Полиморфизм
        public override void Hit(Fighter enemy)
        {
            
            ToDamage(enemy, Damage + gun.Damage);
        }
        public bool TryStrategicRetreat(Fighter enemy)
        {
            if (enemy is StreetFighter streetFighter)
            {
                if (streetFighter.speed > this.speed)
                    return false;
                else
                    return true;
            }
            else
            {
                return true;
            }
        }
    }
}