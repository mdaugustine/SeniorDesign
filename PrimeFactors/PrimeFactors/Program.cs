using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an integer to compute its prime factors");

            int number = Convert.ToInt32(Console.ReadLine());

            for (int i = 2; i <= number; i++)
            {
                while (number % i == 0)
                {
                    Console.WriteLine(i);
                    number /= i;
                }
            }

            Console.ReadLine();
        }
    }
}
