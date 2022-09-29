using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg
{
    class BaseHeroe
    {
        /// <summary>
        /// Класс характеристик героев
        /// </summary>
        /// <param name="health">хп героя</param>
        /// <param name="damage">урон героя</param>
        /// <param name="name">имя героя</param>
        public BaseHeroe(int health, int damage, string name)
        {
            Health = health;
            Damage = damage;
            Name = name;
            Live = true;
        }
        public int Health { get; private set; }
        public int Damage { get; private set; }
        public string Name { get; private set; }
        public bool Live { get; private set; }
        SingleRandom random = SingleRandom.getInstance();
        public int Damaging()///<remarks>
                             ///генерирование урона
                             ///</remarks>
        {
            int result = random.Next(Damage / 2, Damage * 2);
            return result;
        }
        public void GetDamaged(int _damage)///<remarks>
                                           ///нанесение урона
                                           ///</remarks>
        {
            if (Health <= Damage)
            {
                Health = 0;
                Live = false;
            }
            else
            {
                Health = Health - _damage;
            }
        }
        public string ReturnInfo()///<remarks>
                                  /// метод вывода информации по герою 
                                  /// </remarks>
        {
            string alive = Live == true ? "Жив" : "Мёртв";
            string datas = $"{Name}, {Damage} урон, {Health} - здоровья. {alive}";
            return datas;
        }
    }
}