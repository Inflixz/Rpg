using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg
{
    class Knight : BaseHeroe
    {
        /// <summary>
        /// Тип героя Рыцарь
        /// </summary>
        public Knight() : base(400, 165, "Рыцарь")
        {

        }
        public Knight(int health, int damage, string name) : base(health, damage, name)
        {
        }
    }
}
