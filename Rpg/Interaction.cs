using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg
{
    class Interaction
    {
        /// <summary>
        /// Класс отвечает за внешние взаимодействие с пользователем
        /// </summary>
        /// <returns></returns>
        public int TakeNumber()///<remarks>
                               ///метод принимает число
                               ///</remarks>
        {
            int result;
            string input = Console.ReadLine();
            while (!int.TryParse(input, out result))
            {
                Console.WriteLine("Ошибка. Введите цифру:");
                input = Console.ReadLine();
            }
            return result;
        }
        public string TakeText()///<remarks>
                                ///метод принимает текст
                                ///</remarks>
        {
            string result = Console.ReadLine();
            return result;
        }
        public void ShowTextWriteLine(string text)///<remarks>
                                                  ///метод показывает текст WriteLine
                                                  ///</remarks>
        {
            Console.WriteLine($"{text}");
        }
        public void ShowTextWrite(string text)///<remarks>
                                              ///метод показывает текст Write
                                              ///</remarks>
        {
            Console.Write($"{text}");
        }
        public void Clear()///<remarks>
                           ///очищение
                           ///</remarks>
        {
            Console.Clear();
        }
        
    }
}
