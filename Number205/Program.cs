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

            for (int i = 100; i <= 1000000000; i++)
            {
                if (IsPalindrome(i))
                {
                    int product = DigitProduct(i);
                    if (!palindromeGroups.ContainsKey(product))
                    {
                        palindromeGroups[product] = new List<int>();
                    }
                    palindromeGroups[product].Add(i);
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
        }
    }
}
