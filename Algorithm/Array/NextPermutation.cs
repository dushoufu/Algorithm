//Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.
//If such arrangement is not possible, it must rearrange it as the lowest possible order(ie, sorted in ascending order).
//The replacement must be in-place, do not allocate extra memory.
//Here are some examples.Inputs are in the left-hand column and its corresponding outputs are in the right-hand column.

//1,2,3 → 1,3,2
//3,2,1 → 1,2,3
//1,1,5 → 1,5,1


// eg: 4 2 1 7 6 5 3
//First: From right to left, find the first number(called partionNumber)that violate the increase trend, which is 1 in the above example;
//Second: From right to left,find the first number(called changeNumber)which is larger than the partionNumber, which is 3;
//Third:Swap the partionNumber and changed Number
//Last:reverse the right sequence of the partionNumber index
using System;
using System.Linq;

namespace Algorithm.Array
{
    partial class ArrayAlgorithm
    {
        public static void NextPermutaion(int[] src)
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

            Reverse(src, PartionIndex+1);

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
                Swap(ref a[i+startIndex], ref a[a.Length - 1 - i]);
            }
        }

        public static bool TestNextPermutaion(out string funcName)
        {
            System.Diagnostics.StackFrame sf = new System.Diagnostics.StackFrame(0);
            funcName = sf.GetMethod().Name;

            int[] a = new int[] { 4, 2, 1,6, 7, 5, 3 };
            int[] expected = new int[] { 4, 2, 1, 7, 3, 5, 6 };

            NextPermutaion(a);

            if (a.SequenceEqual(expected))
                return true;

            return false;

        }

    }
}
