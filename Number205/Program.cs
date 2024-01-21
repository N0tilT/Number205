using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number205
{
    internal class Program
    {
        static bool IsPalindrome(int number)
        {
            string numberString = number.ToString();
            return numberString.SequenceEqual(numberString.Reverse());
        }

        static int DigitProduct(int number)
        {
            int product = 1;
            while (number != 0)
            {
                int digit = number % 10;
                if (digit != 0)
                {
                    product *= digit;
                }
                number /= 10;
            }
            return product;
        }

        static void Main()
        {
            var palindromeGroups = new Dictionary<int, List<int>>();

            for (int i = 101; i <= 1000000000; i += 2)
            {
                int firstDigit = int.Parse(Convert.ToString(i.ToString()[0]));
                if (firstDigit % 2 == 0 || firstDigit == 5) { 
                    i += (int)Math.Pow(10, i.ToString().Length - 1); 
                    continue; 
                };
                if (i % 10 == 0) { 
                    i++; 
                    continue; 
                };
                if (IsPalindrome(i))
                {
                    if (IsPrime(i))
                    {
                        int product = DigitProduct(i);
                        if (!palindromeGroups.ContainsKey(product))
                        {
                            palindromeGroups[product] = new List<int>();
                        }
                        palindromeGroups[product].Add(i);
                        Console.WriteLine(i);
                    }
                }
            }

            var largestGroup = palindromeGroups.OrderByDescending(g => g.Value.Count).First();
            var largestNumbers = largestGroup.Value.OrderByDescending(n => n).Take(5).ToList();

            largestNumbers.Sort();

            Console.WriteLine("5 самых больших по значению чисел в группе с наибольшим количеством элементов:");
            foreach (int number in largestNumbers)
            {
                Console.WriteLine(number);
            }
            Console.ReadKey();
        }

        private static bool IsPrime(int number)
        {
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
