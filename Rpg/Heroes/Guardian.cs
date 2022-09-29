using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg
{
    class Guardian : BaseHeroe
    {
        /// <summary>
        /// Тип героя Страж
        /// </summary>
        public Guardian() : base(500, 80, "Страж")
        {

        }
        public Guardian(int health, int damage, string name) : base(health, damage, name)
        {

        }
    }
}
