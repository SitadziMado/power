using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = InputDouble("Введите вещественное число: ");
            long n = InputNatural("Введите натуральное число: ");

            var result = Pow(number, n);
            Console.WriteLine("Результат                   : {0}.", result);
            Console.WriteLine("Результат встроенной функции: {0}.", Math.Pow(number, n));
        }

        private static double InputDouble(string prompt)
        {
            Console.WriteLine(prompt);

            double input;
            do
            {
                try
                {
                    input = double.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Требуется вещественное число.");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("Попробуйте ввести число поменьше.");
                }
            } while (true);

            return input;
        }

        private static long InputNatural(string prompt)
        {
            Console.WriteLine(prompt);

            long input;
            do
            {
                try
                {
                    input = long.Parse(Console.ReadLine());
                    if (input > 0)
                        break;
                    else
                        Console.WriteLine("Требуется натуральное число.");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Требуется натуральное число.");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("Попробуйте ввести число поменьше.");
                }
            } while (true);

            return input;
        }

        private static double Pow(double number, long exp)
        {
            double result = 1.0;
            double accumulate = number;

            while (exp > 0)
            {
                if ((exp & 1) == 1)
                    result *= accumulate;

                accumulate *= accumulate;
                exp >>= 1;
            }

            return result;
        }
    }
}
