using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg
{
    class Wizard : BaseHeroe
    {
        /// <summary>
        /// Тип героя Маг
        /// </summary>
        public Wizard() : base(300, 180,"Mаг")
        {

        }
        public Wizard(int health, int damage, string name) : base(health, damage, name)
        {

        }
    }
}
