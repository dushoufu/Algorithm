//The set[1, 2, 3,…, n] contains a total of n! unique permutations.
//  By listing and labeling all of the permutations in order, We get the following sequence (ie, for n = 3):
//"123"
//"132"
//"213"
//"231"
//"312"
//"321"
//Given n and k, return the kth permutation sequence.
//Note: Given n will be between 1 and 9 inclusive.

using System;
using System.Linq;

namespace Algorithm.Array
{
    partial class ArrayAlgorithm
    {
        public static void PermutaionSequence(int n,int k)
        {
            if (src.Length < 2)
                return;

            int PartionIndex = src.Length;
            for (int i = src.Length - 2; i >= 0; i--)
            {
                if (src[i] < src[i + 1])
                {
                    PartionIndex = i;
                    break;

                }
                else
                { continue; }
            }

            if (PartionIndex == src.Length)
            {
                return;
            }

            int changedIndex = src.Length;
            for (int i = src.Length - 1; i >= 0; i--)
            {
                if (src[i] > src[PartionIndex])
                {
                    changedIndex = i;
                    break;
                }
            }

            Swap(ref src[PartionIndex], ref src[changedIndex]);

            Reverse(src, PartionIndex + 1);

        }

        public static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        public static void Reverse(int[] a, int startIndex)
        {
            int len = a.Length - startIndex;
            for (int i = 0; i < len / 2; i++)
            {
                Swap(ref a[i + startIndex], ref a[a.Length - 1 - i]);
            }
        }

        public static bool TestPermutaionSequence(out string funcName)
        {
            System.Diagnostics.StackFrame sf = new System.Diagnostics.StackFrame(0);
            funcName = sf.GetMethod().Name;

            int[] a = new int[] { 4, 2, 1, 6, 7, 5, 3 };
            int[] expected = new int[] { 4, 2, 1, 7, 3, 5, 6 };

            NextPermutaion(a);

            if (a.SequenceEqual(expected))
                return true;

            return false;

        }

    }
}
