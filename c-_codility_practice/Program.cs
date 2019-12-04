using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CodilityPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new int[]{1, 4, 5, 8};
            var b = new int[]{4, 5, 9, 10};
            var c = new int[]{4, 6, 7, 10, 2};
            Solution(a, b, c);
        }

        public static int Solution(int[] A, int[] B, int[] C)
        {
            var planks = A.Zip(B, (a, b) => (a, b));
            var nails = C.ToImmutableSortedSet();

            return GetNumberNailsRequired(planks, nails);
        }

        private static int GetNumberNailsRequired(IEnumerable<(int, int)> planks, ImmutableSortedSet<int> nails)
        {
            var result = 0;
            foreach (var plank in planks)
            {
                result = Math.Max(result, FindPositionOfNail(nails, plank, result));
            }

            return result + 1;
        }

        private static int FindPositionOfNail(ImmutableSortedSet<int> nails, (int, int) plank, int result)
        {
            var plankStart = 0;
            var plankEnd = 1;

            var nailArrayIndex = 0;
            var nailHitLocation = 1;

            return 0;
        }
    }
}