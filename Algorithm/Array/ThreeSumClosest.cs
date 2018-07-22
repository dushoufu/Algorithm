//Given an array S of n integers, find three integers in S such that the sum is closest to a given number, target.
//Return the sum of the three integers.You may assume that each input would have exactly one solution.

//For example, given array S = { -1 2 1 - 4 }, and target = 1.
//The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).


using System;
using System.Collections.Generic;

namespace Algorithm.Array
{
    partial class ArrayAlgorithm
    {

        public static void ThreeSumClosest(int[] src, int target, out int result)

        {
            result = 0;

            if (src.Length < 3)
            {

                return;
            }

            System.Array.Sort(src);


            int minGap = int.MaxValue;

            for (int i = 0; i < src.Length - 2; i++)
            {
                while (i > 0 && src[i] == src[i - 1])
                    i++;

                int j = i + 1;
                int k = src.Length - 1;


                while (j < k)
                {
                    int sum = src[i] + src[j] + src[k];
                    int gap = Math.Abs(sum - target);

                    if (gap < minGap)
                    {
                        minGap = gap;
                        result = sum;
                    }

                    if (sum > target)
                    {
                        k--;
                    }
                    else
                    {
                        j++;
                    }

                }
            }

        }

        public static bool TestThreeSumClosest(out string funcName)
        {
            //Console.WriteLine("Hello World!");

            System.Diagnostics.StackFrame sf = new System.Diagnostics.StackFrame(0);
            funcName = sf.GetMethod().Name;


            int[] a = new int[] { -1, 2, 1, -4 };
            int target = 1;
            int expected = 2;
            int result;

            ThreeSumClosest(a, target, out result);

            if (result == expected)
                return true;

            return false;

        }
    }
}