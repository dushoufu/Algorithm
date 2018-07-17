//Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0? 
//Find all unique triplets in the array which gives the sum of zero.

//Note:
//Elements in a triplet (a, b, c) must be in non-descending order. (ie, a≤b≤c)
//The solution set must not contain duplicate triplets.
//For example, given array S = { -1 0 1 2 - 1 - 4}.
//A solution set is:
//(-1, 0, 1)
//(-1, -1, 2)

using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithm.Array
{
    partial class ArrayAlgorithm
    {

        public static void ThreeSumZero(int[] src, int target, out int[] outResult, int outLen)
        {
            List<>


        }


        public static bool TestThreeSumZero(out string funcName)
        {
            //Console.WriteLine("Hello World!");

            System.Diagnostics.StackFrame sf = new System.Diagnostics.StackFrame(0);
            funcName = sf.GetMethod().Name;

            int[] a = new int[] { -1, 1, 2, -1, -4 };
            int target = 17;

            int index1, index1_expected = 0;
            int index2, index2_expected = 3;

            TwoSum(a, target, out index1, out index2);

            if (index1 == index1_expected && index2 == index2_expected)
                return true;

            return false;

        }
    }
}