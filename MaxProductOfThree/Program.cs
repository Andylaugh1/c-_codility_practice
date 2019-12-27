using System;

namespace MaxProductOfThree
{
    class Program
    {
        static void Main(string[] args)
        {
            var A = new int[]{-5, 5, -5, 4};
            Solution(A);
        }

        private static int Solution(int[] A)
        {
            var result = 0;
            Quicksort(A, 0, A.Length-1);
            
            result = A[A.Length-1] * A[A.Length-2] * A[A.Length - 3];
    
            return result;

        }

        private static void Quicksort(int[] A, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(A, left, right);

                if (pivot > 1)
                {
                    Quicksort(A, left, pivot - 1);
                }

                if (pivot + 1 < right)
                {
                    Quicksort(A, pivot + 1, right);
                }
            }
        }

        private static int Partition(int[] A, int left, int right)
        {
            int pivot = A[left];
            while (true)
            {
                while (A[left] < pivot)
                {
                    left++;
                }

                while (A[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    int temp = A[left];
                    A[left] = A[right];
                    A[right] = temp;

                    if (A[left] == A[right])
                        left++;
                }
                else
                {
                    return right;
                }
            }
        }
    }
}