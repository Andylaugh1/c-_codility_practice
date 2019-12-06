using System;
using System.Linq;
using static System.Linq.Enumerable;
using Range = System.Range;

namespace CountDiv
{
    class Program
    {
        static void Main(string[] args)
        {
            var A = 0;
            var B = 11;
            var K = 2;
            Solution(A, B, K);
        }
        // Currently this solution is 100% correct but gets 0 for time complexity
        private static int Solution(int A, int B, int K)
        {
            var result = 0;
            var numbersInRange = B - A + 1;
            var numberRange = Enumerable.Range(A, numbersInRange).ToList();
            var highestDivisible = 0;
            
            
            for (var i = numberRange.Count-1; i >= 0; i--)
            {
                if (numberRange[i] % K == 0)
                {
                    result++;
                    highestDivisible = numberRange[i];
                    break;
                }
            }

            var additionalDivisibles = (highestDivisible - A) / K;

            result += additionalDivisibles;


            return result;
        }
    }
}