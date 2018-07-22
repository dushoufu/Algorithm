//Given an array S of n integers, are there elements a, b, c, and d in S such that a + b + c + d = target? 
//Find all unique quadruplets in the array which gives the sum of target.
//Note:
//Elements in a quadruplet (a, b, c, d) must be in non-descending order. (ie, a≤b≤c≤d)
//The solution set must not contain duplicate quadruplets.
//For example, given array S = { 1 0 - 1 0 - 2 2}, and target = 0.
//A solution set is:
//(-1,  0, 0, 1)
//(-2, -1, 1, 2)
//(-2,  0, 0, 2)

using System;
using System.Collections.Generic;

namespace Algorithm.Array
{
    partial class ArrayAlgorithm
    {

        public static void FourSum(int[] src, int target, out List<MyList<int>>result)

        {

            if (src.Length < 4)
            {
                result = new List<MyList<int>>();
                return;
            }

            System.Array.Sort(src);

            result = new List<MyList<int>>();

            for (int i = 0; i < src.Length - 3; i++)
            {
                if (i > 0 && src[i] == src[i - 1])
                    continue;
                for (int j = i + 1; j < src.Length - 2; j++)
                {
                    if (j > i+1 && src[j] == src[j - 1])
                        continue;
                    
                    int m = j + 1;
                    int n = src.Length - 1;

                    while (m < n)
                    {
                        int sum = src[i] + src[j] + src[m] + src[n];
                        if (sum > target)
                        {
                            n--;
                            while (src[n] == src[n + 1] && m < n)
                                n--;
                        }
                        else if (sum < target)
                        {
                            m++;
                            while (src[m] == src[m - 1] && m < n)
                                m++;
                        }
                        else
                        {
                            result.Add(new MyList<int> { src[i], src[j], src[m], src[n] });
                            n--;
                            while (src[n] == src[n + 1] && m < n)
                                n--;
                            m++;
                            while (src[m] == src[m - 1] && m < n)
                                m++;
                        }
                    }
                }
            }
            
        }

        public static bool TestFourSum(out string funcName)
        {
            //Console.WriteLine("Hello World!");

            System.Diagnostics.StackFrame sf = new System.Diagnostics.StackFrame(0);
            funcName = sf.GetMethod().Name;

            int[] a = new int[] {1 ,0, - 1 ,0 ,- 2 ,2 };
            int target = 0;

            MyList<int> expected1 = new MyList<int> { -1, 0, 0, 1 };
            MyList<int> expected2 = new MyList<int> { -2, -1, 1, 2};
            MyList<int> expected3 = new MyList<int> { -2, 0, 0, 2 };

            List<MyList<int>> result;
            FourSum(a, target, out result);

            if (result.Contains(expected1) && result.Contains(expected2) && result.Contains(expected3) && result.Count == 3)
                return true;

            return false;

        }
    }
}