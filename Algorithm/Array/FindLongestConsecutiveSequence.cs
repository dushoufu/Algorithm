using System;
using System.Collections;
using System.Collections.Generic;


namespace Algorithm.Array
{
    partial class ArrayAlgorithm
    {

        //Given an unsorted array of integers, find the length of the longest consecutive elements sequence.
        //For example, Given[100, 4, 200, 1, 3, 2], The longest consecutive elements sequence is [1, 2, 3, 4]. Return its length: 4.
        //Your algorithm should run in O(n) complexity.

        public static int FindLongestConsecutiveSequence(int[] src,out int[] result)
        {
            if (1 >= src.Length)
            {
                result = (int[])src.Clone();
                return src.Length;
            }

            HashSet<int> hash = new HashSet<int>();


            foreach (int i in src)
            {
                hash.Add(i);
            }

            int maxIndex = 0;
            int maxRightCount = 0;
            int maxLeftCount = 0;

            int countRight = 0;
            int countLeft = 0;
         
            for (int i = 0; i < src.Length&&hash.Contains(src[i]); i++)
            {
                int j = 1;
                countRight = 0;
                while (hash.Contains(src[i] + j))
                {
                    countRight++;
                    hash.Remove(src[i] + j);

                    j++;
                }
               
                j = 1;
                countLeft = 0;
                while (hash.Contains(src[i]-j))
                {
                    countLeft++;
                    hash.Remove(src[i] - j);

                    j++;
                }

                if(countLeft+countRight > maxLeftCount+maxRightCount)
                {
                    maxLeftCount  = countLeft;
                    maxRightCount = countRight;
                    maxIndex = i;
                }
            }

            int len = maxLeftCount + maxRightCount + 1;
            result = new int[len];
            result[maxLeftCount] = src[maxIndex];
            for (int i = 1; i <= maxLeftCount;i++)
            {
                result[maxLeftCount - i] = src[maxIndex] - i;
            }

            for (int i = 1; i <= maxRightCount;i++)
            {
                result[maxLeftCount + i] = src[maxIndex] + i;
            }

            return len;
        }

        public static bool TestFindLongestConsecutiveSequence(out string funcName)
        {
            //Console.WriteLine("Hello World!");

            System.Diagnostics.StackFrame sf = new System.Diagnostics.StackFrame(0);
            funcName = sf.GetMethod().Name;

            int[] a = new int[] { 122, 2, 333, 3, 14, 34, 434, 25, 4,125, 5, 35, 36, 46, 6, 6 };
            int[] a_expected = new int[] { 2,3,4,5,6};
            int[] a_result;

            int len = FindLongestConsecutiveSequence(a,out a_result);

            return TestResult(a_result, len, a_expected);

        }

    }
}
