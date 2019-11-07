using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Бездель М.А.

//Создан абстракный класс TypePay (наследник IComparable) с абстрактным методом калькуляции з/п и с переопределенным методом CompareTo
//Созданы 2 наследника класса TypePay - FixPrice (фиксированная з/п) и HourlyWage (почасовая оплата)
//В каждом наследнике переопределен метод калькуляции зарплаты с выводом на экран
//В базовом классе переопределен метод ToString, что позволяет выводить данный объектов на экран без дополнительных действий
//Создан массив данных сотрудников с различным видом оплаты труда

namespace PayDay
{
    class Program
    {
        static void Main(string[] args)
        {
            string tempName;
            int tempPay, i = 0;
            Console.Write("Введите количество людей с фиксированной месячной оплатой: ");
            int tempFix = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество людей с почасовой оплатой: ");
            int tempHour = Convert.ToInt32(Console.ReadLine());
            int sizeMassive = tempFix + tempHour;
            TypePay[] workers = new TypePay[sizeMassive];
            
            while (i < tempFix)
            {
                Console.Write("Введите имя сотрудника: ");
                tempName = Console.ReadLine();
                Console.Write("Введите сумму фиксирвоанной месячной оплаты труда: ");
                tempPay = Convert.ToInt32(Console.ReadLine());
                TypePay fix = new FixPrice(tempName, tempPay);
                fix.CalculationPay();
                workers[i] = fix;
                i++;
            }

            while (i < sizeMassive)
            {
                Console.Write("Введите имя сотрудника: ");
                tempName = Console.ReadLine();
                Console.Write("Введите сумму оплаты труда рабочего за час: ");
                tempPay = Convert.ToInt32(Console.ReadLine());
                TypePay hour = new HourlyWage(tempName, tempPay);
                hour.CalculationPay();
                workers[i] = hour;
                i++;
            }

            Console.WriteLine("\nНеотсортированный массив данных: \n");
            foreach (TypePay j in workers)
                Console.WriteLine(j);
            Array.Sort(workers);
            Console.WriteLine("\n\nОтсортированный по заработной плате массив данных: \n");
            foreach (TypePay j in workers)
                Console.WriteLine(j);
        }
    }
}
