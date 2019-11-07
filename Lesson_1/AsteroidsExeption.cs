using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1
{
    public class AsteroidsException : Exception
    {
        public AsteroidsException()
        {
            Console.WriteLine("Неверное значение. Введите число от 1 до 20");
        }
    }
}
