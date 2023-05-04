using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace dz9
{
    class ArrayH
    {
        public delegate bool MyDelegate(int number);

        public static List<int> GetEvenNumbers(int[] array)
        {
            return GetNumbers(array, n => n % 2 == 0);
        }

        public static List<int> GetOddNumbers(int[] array)
        {
            return GetNumbers(array, n => n % 2 != 0);
        }

        public static List<int> GetPrimeNumbers(int[] array)
        {
            return GetNumbers(array, IsPrime);
        }

        public static List<int> GetFibonacciNumbers(int[] array)
        {
            return GetNumbers(array, IsFibonacci);
        }

        private static List<int> GetNumbers(int[] array, MyDelegate filter)
        {
            List<int> result = new List<int>();

            foreach (int number in array)
            {
                if (filter(number))
                {
                    result.Add(number);
                }
            }

            return result;
        }

        private static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsFibonacci(int number)
        {
            if (number == 0 || number == 1)
            {
                return true;
            }

            int a = 0;
            int b = 1;

            while (b < number)
            {
                int c = a + b;
                a = b;
                b = c;
            }

            return b == number;
        }
    }
    internal class cs1
    {
        public static void task_1()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("Array:");
            foreach (int number in array)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();

            Console.WriteLine("Even numbers:");
            foreach (int number in ArrayH.GetEvenNumbers(array))
            {
                Console.Write(number + " ");
            }

            Console.WriteLine("\nOdd numbers:");
            foreach (int number in ArrayH.GetOddNumbers(array))
            {
                Console.Write(number + " ");
            }

            Console.WriteLine("\nPrime numbers:");
            foreach (int number in ArrayH.GetPrimeNumbers(array))
            {
                Console.Write(number + " ");
            }

            Console.WriteLine("\nFibonacci numbers:");
            foreach (int number in ArrayH.GetFibonacciNumbers(array))
            {
                Console.Write(number + " ");
            }
            Console.WriteLine("\n");
        }
    }
}
