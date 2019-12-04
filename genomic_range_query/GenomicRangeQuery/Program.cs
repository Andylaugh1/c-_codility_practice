using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GenomicRangeQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = "CAGCCTA";
            var P = new int[3]{2, 5, 0};
            var Q = new int[3] {4, 5, 6};
            Solution(S, P, Q);
        }

        private static int[] Solution(string S, int[] P, int[] Q)
        {
            var result = new List<int>();
            var impactFactors = new Dictionary<string, int>();
            impactFactors.Add("A", 1);
            impactFactors.Add("C", 2);
            impactFactors.Add("G", 3);
            impactFactors.Add("T", 4);

            var lettersToNumbers = new List<int>();

            var lowestValue = 1;
            for (var i = 0; i < S.Length; i++)
            {
                lettersToNumbers.Add(impactFactors[S[i].ToString()]);
            }
            
            for (var i = 0; i < P.Length; i++)
            {
                var positionA = P[i];
                var positionB = Q[i];
                if (lettersToNumbers[positionA] == 1 || lettersToNumbers[positionB] == 1)
                {
                    result.Add(lowestValue);
                }

                else if (positionA == positionB)
                {
                    result.Add(lowestValue);;
                }

                else if (positionB - positionA == 1)
                {
                    lowestValue = Math.Min(lettersToNumbers[positionA], lettersToNumbers[positionB]);
                    result.Add(lowestValue);
                }
                else
                {
                    var arraySliceSize = positionB - positionA;
                    var arraySlice = lettersToNumbers.Take(arraySliceSize);
                    var lowestImpactFactor = GetLowestValue(positionA, positionB, lettersToNumbers);
                    result.Add(lowestImpactFactor);
                }
                
            }

            return result.ToArray();
        }


        private static int GetLowestValue(int positionA, int positionB, List<int> lettersToNumbers)
        {
            var result = lettersToNumbers[positionA];
            for (var i = positionA+1; i < positionB+1; i++)
            {
                if (lettersToNumbers[i] == 1)
                {
                    return 1;
                }
                if (lettersToNumbers[i] < result)
                {
                    result = lettersToNumbers[i];
                }
            }

            return result;

        }
    }
}