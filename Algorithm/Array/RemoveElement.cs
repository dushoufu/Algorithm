//Given an array and a value, remove all instances of that value in place and return the new length.

//The order of elements can be changed.It doesn't matter what you leave beyond the new length.


using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithm.Array
{
    partial class ArrayAlgorithm
    {
        public static void RemoveElement(int[] src, int target,out int newLen)
        {
            newLen = src.Length;
            int index = 0;
            for (int i = 0; i < src.Length; i++)
            {
                if (src[i] != target)
                    src[index++] = src[i];
            }

            newLen = index;

        }

        public static void RemoveElement(ref int[] src, int target, out int newLen)
        {
            newLen = src.Length;
            int index = 0;
            for (int i = 0; i < src.Length; i++)
            {
                if (src[i] != target)
                    src[index++] = src[i];
            }

            newLen = index;

        }

 
        public static bool TestRemoveElement(out string funcName)
        {
          System.Diagnostics.StackFrame sf = new System.Diagnostics.StackFrame(0);
            funcName = sf.GetMethod().Name;

            int[] a = new int[] { 3, 2, 2, 2, 7, 11, 14, 15 };
            int target = 2;

            int expected_len = 5;
            int result = 0;

            RemoveElement( a, target,out result);

            int[] b = new int[] { 3, 2, 2, 2, 7, 11, 14, 15 };
            RemoveElement(ref b, target, out result);

            if (expected_len==result)
                return true;

            return false;

        }

    }
}
