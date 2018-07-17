using System;
using System.Collections;

namespace Algorithm.Array
{
    partial class ArrayAlgorithm
    {

        //Given an array of integers, find two numbers such that they add up to a specific target number.
        //The function twoSum should return indices of the two numbers such that they add up to the target,
        //where index1 must be less than index2.Please note that your returned answers(both index1 and index2) are not zero-based.

        //You may assume that each input would have exactly one solution.
        //Input: numbers={2, 7, 11, 15}, target=9
        //Output: index1=1, index2=2

        public static void TwoSum(int[] src,int target,out int index1,out int index2)
        {
            index1 = 0;
            index2 = 0;

            if (src.Length<1)
            {
                return;
            }

            Hashtable ht = new Hashtable();
            for (int i= 0; i < src.Length;i++ )
            {
                ht.Add(src[i], i);
            }

            for (int i = 0; i < src.Length;i++)
            {
                if (src[i] > target)
                    break;
                
                if(ht.ContainsKey(target-src[i]))
                {
                    index1 = i;
                    index2 = (int)ht[target - src[i]];

                    return;
                }
            }
            
        }


        public static bool TestTwoSum(out string funcName)
        {
            //Console.WriteLine("Hello World!");

            System.Diagnostics.StackFrame sf = new System.Diagnostics.StackFrame(0);
            funcName = sf.GetMethod().Name;

            int[] a = new int[] { 2, 7, 11, 15 };
            int target = 17;

            int index1,index1_expected = 0;
            int index2,index2_expected = 3;

            TwoSum(a,target,out index1,out index2);

            if (index1 == index1_expected && index2 == index2_expected)
                return true;

            return false;

        }

    }
}
