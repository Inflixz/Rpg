using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg
{
    class Archer : BaseHeroe
    {
        /// <summary>
        /// Тип героя Лучник
        /// </summary>
        public Archer() : base(350, 155,"Лучник")
        {

        }
        public Archer(int health, int damage, string name) : base(health, damage, name)
        {

        }
    }
}
