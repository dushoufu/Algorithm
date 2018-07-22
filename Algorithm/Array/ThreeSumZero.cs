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
        public class MyList<T> : List<T>
        {
            public override int GetHashCode()
            {
                int hc = 0;

                List<int> own = this as List<int>;
                foreach(int a in own)
                {
                    hc += a.GetHashCode();
                }

                return hc;
            }

            public override bool Equals(object obj)
            {
                if (obj == this)
                    return true;

                List<int> own = this as List<int>;
                List<int> other = obj as List<int>;

                if (own.Count != other.Count)
                    return false;

                for (int i = 0; i < own.Count;i++)
                {
                    if (own[i] != other[i])
                        return false;
                }

                return true;
            }
        }


        public static void ThreeSumZero_v2(int[] src, int target,out HashSet<MyList<int>> result)
        {
            result = new HashSet<MyList<int>>();

            if (src.Length < 3)
                return;

            System.Array.Sort(src);

            for (int i = 0; i < src.Length-2;i++)
            {
                while (i > 0 && src[i] == src[i - 1])
                    i++;
                
                int j = i + 1;
                int k = src.Length - 1;


                while(j<k)
                {
                    int sum = src[i] + src[j] + src[k];

                    if(sum>target)
                    {
                        k--;
                        while (src[k+1] == src[k] && k>j)
                            k--;
                    }
                    else if (sum < target)
                    {
                        j++;
                        while (src[j] == src[j-1] && j<k)
                            j++;
                    }
                    else
                    {
                        result.Add(new MyList<int> { src[i], src[j], src[k] });
                        j++;
                        while (src[j] == src[j -1] && j<k) j++;
                        k--;
                        while (src[k] == src[k + 1] && k>j) k--;
                    }
                }
            }
                

        }

        public static void ThreeSumZero(int[] src, out HashSet<MyList<int>> result)
        {
            result = new HashSet<MyList<int>>();

            Hashtable hs = new Hashtable();
            for (int i = 0; i < src.Length;i++)
            {
                if (hs.ContainsKey(src[i]))
                {

                    List<int> index = hs[src[i]] as List<int>;
                    index.Add(i);
                }
                else
                {
                    hs[src[i]] = new List<int> { i };
                }
            }

            for (int i = 0; i < src.Length; i++)
                for (int j = i + 1; j < src.Length; j++)
                {
                    int c = -src[i] - src[j];
                    if (hs.ContainsKey(c))
                    {
                        List<int> id = hs[c] as List<int>;
                        int idx = id.Find(x => x > i && x > j);
                        if (idx != 0)
                        {
                            MyList<int> res = new MyList<int> { src[i], src[j], c };
                            res.Sort();
                            result.Add(res);
                        }
                    }
                }

        }



        public static bool TestThreeSumZero(out string funcName)
        {
            //Console.WriteLine("Hello World!");

            System.Diagnostics.StackFrame sf = new System.Diagnostics.StackFrame(0);
            funcName = sf.GetMethod().Name;

            int[] a = new int[] { -1, 0 ,1 ,2 ,- 1, - 4 };

            HashSet<MyList<int>> result = new HashSet<MyList<int>>();

            MyList<int> expected_list1 = new MyList<int> { -1, 0, 1 };
            MyList<int> expected_list2 = new MyList<int> { -1, -1,2 };

            ThreeSumZero(a, out result);

            if (!result.Contains(expected_list1) || !result.Contains(expected_list2) || result.Count != 2)
                return false;

            ThreeSumZero_v2(a, 0,out result);
            if (!result.Contains(expected_list1) || !result.Contains(expected_list2) || result.Count != 2)
                return false;

            return true;

        }
    }
}