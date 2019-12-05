using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace MinAvgTwoSlice
{
    // The point of this program is to find the minimum average slice from an array on integers
    // and to return the starting index of that slice
    class Program
    {
        static void Main(string[] args)
        {
            var A = new int[] {4, 2, 2, 5, 1, 5, 8};
            Solution(A);
        }

        private static int Solution(int[] A)
        {
            // this solution is based on the premise that the minimum average slice can only ever be
            // on a slice of 2 or 3 values
            int sum1 = 0;
            int sum2 = 0;
            var minAverage = new double();
            var currentAverage1 = new double();
            var currentAverage2 = new double();
            var lowestAverageIndex = 0;

            // Always going to be 0 if there are only 2 values
            if (A.Length <= 2)
            {
                return lowestAverageIndex;
            }
            
            // if the array is more than 2 values in length and iteration must finishes in 
            // the last-but-one value
            for (var i = 0; i < A.Length - 2; i++)
            {
                sum1 = A[i] + A[i + 1];
                currentAverage1 = (double)sum1 / 2;
                if (minAverage == 0)
                {
                    minAverage = currentAverage1;
                    lowestAverageIndex = i;
                }
                else
                {
                    if (currentAverage1 < minAverage)
                    {
                        minAverage = currentAverage1;
                        lowestAverageIndex = i;
                    }
                }

                // Now check the same i value but getting the average of only the following 2 values
                sum2 = A[i] + A[i + 1] + A[i + 2];
                currentAverage2 = (double)sum2 / 3;
                if (currentAverage2 < minAverage)
                {
                    minAverage = currentAverage2;
                    lowestAverageIndex = i;
                }
            }

            // lastly, check the 2 last values, as they have not yet been checked
            currentAverage1 = (double)(A[A.Length - 2] + A[A.Length - 1]) / 2;
            if (currentAverage1 < minAverage)
            {
                minAverage = currentAverage1;
                lowestAverageIndex = A.Length - 2;
            }

            return lowestAverageIndex;

        }
    }
}