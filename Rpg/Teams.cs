using System;
using System.Collections.Generic;

namespace Rpg
{
    class Teams
    {
        public List<BaseHeroe> Heroes { get; set; }
        /// <summary>
        /// Класс который отвечает за действия команд
        /// </summary>
        public Teams()
        {
            Heroes = new List<BaseHeroe>();
        }
        public int CountOfHeroes ///<remarks>
                                 ///подсчёт кол-ва героев в команде
                                 ///</remarks>
        {
            get
            {
                return Heroes.Count;
            }
        }
        public string InfoOfHeroe(int number)///<remarks>
                                             ///информация о герое команды
                                             ///</remarks>
        {
            string datasOfHeroe = Heroes[number].ReturnInfo();
            return datasOfHeroe;
        }
        public bool IsEqualTo(Type t, Type t2)///<remarks>
                                              ///проверка на одинаковость героев
                                              ///</remarks>
        {
            if (t.Equals(t2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ContainsOfHeroes(BaseHeroe heroe)///<remarks>
                                                     ///проверка на одинаковость героев всей команды
                                                     ///</remarks>
        {
            bool availabilityOfHeroe = false;
            int i = 0;
            for (;i < Heroes.Count; i++)
            {
                if (IsEqualTo(heroe.GetType(), Heroes[i].GetType()))
                {
                    availabilityOfHeroe = true;
                }
            }
            return availabilityOfHeroe;
        }
        public bool StatusOfHeroe(int _heroe)///<remarks>
                                             ///проверка жизнь/смерть героя
                                             ///</remarks>
        {
            return Heroes[_heroe].Live;
        }
        public bool StatusOfAllHeroes()///<remarks>
                                       ///проверка жизнь/смерть всех героев команды
                                       ///</remarks>
        {
            bool statusOfAllHeroes = false;
            int i = 0;
            while (i < 3)
            {
                if (StatusOfHeroe(i))
                {
                    return true;
                }
                i++;
            }
            return statusOfAllHeroes;
        }
        
        public bool AddingHeroes(BaseHeroe _heroe)///<remarks>
                                                  ///добавление героя в команду
                                                  ///</remarks>
        {
            if (_heroe != null || ContainsOfHeroes(_heroe))
            {
                Heroes.Add(_heroe);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int TakingDamage(int _damaginigHeroe)///<remarks>
                                                    ///взятие урона у атакующего героя
                                                    ///</remarks>
        {
            int result = 0;
            if (Heroes[_damaginigHeroe].Live)
            {
                result = Heroes[_damaginigHeroe].Damaging();
            }
            return result;
        }
        public void GetDamage(int _damagedHeroe, int _damage)///<remarks>
                                                             ///нанесение урона герою
                                                             ///</remarks>
        {
            if (Heroes[_damagedHeroe].Live)
            {
                Heroes[_damagedHeroe].GetDamaged(_damage);
            }
        }
    }
}
