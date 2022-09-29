using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg
{
    class SingleRandom
    {
        /// <summary>
        /// Singleton для рандом
        /// </summary>
        private static SingleRandom instance;
        private Random Random { get; set; }
        private SingleRandom()
        {
            Random = new Random();
        }
        public static SingleRandom getInstance()
        {
            if (instance == null)
                instance = new SingleRandom();
            return instance;
        }
        public int Next(int number, int number2)
        {
            int result = Random.Next(number, number2);
            return result;
        }
        public int Next(int number)
        {
            int result = Random.Next(number);
            return result;
        }
        public double NextDouble()
        {
            double result = Random.NextDouble();
            return result;
        }
    }
}
