//Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.

//For example, given nums = [0, 1, 0, 3, 12], after calling your function, nums should be[1, 3, 12, 0, 0]


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.Array
{
    partial class ArrayAlgorithm
    {
        public static void RemoveZeros(ref int[] src)
        {
            int index = 0;
            for (int i = 0; i < src.Length; i++)
            {
                if (src[i] != 0)
                    src[index++] = src[i];
            }

            for (int i = index; i < src.Length; i++)
                src[i] = 0;

        }



        public static bool TestRemoveZeros(out string funcName)
        {
            System.Diagnostics.StackFrame sf = new System.Diagnostics.StackFrame(0);
            funcName = sf.GetMethod().Name;

            int[] a = new int[] { 3, 0,2, 2,0, 2, 0,7, 11, 14, 15 };
            int[] expected = new int[]{3,2,2,2,7,11,14,15,0,0,0};

            RemoveZeros(ref a);

            List<int> a1 = new List<int>(a);
            List<int> expected1 = new List<int>(expected);
         
            if (a1.SequenceEqual(expected))
                return true;

            return false;

        }

    }
}
