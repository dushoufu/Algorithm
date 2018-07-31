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
using System.Collections.Generic;

namespace Algorithm.Array
{
    partial class ArrayAlgorithm
    {
        public static int[] factorial = new int[] { 1, 1, 2, 6, 24, 120, 720, 5040, 40320 };


        public static bool IsLastSequence(int[] src)
        {
            int n = src.Length;
            for (int i = n; i > 0; i--)
            {
                if (src[n - i] != i)
                    return false;
            }

            return true;

        }

        public static int GetFactorial(int n)
        {
            if (n < 1 || n > 9)
                return -1;

            if (n == 1 || n == 0)
            {
                return 1;
            }
            else
            {
                return n * GetFactorial(n - 1);
            }
        }

        public static int[] PermutaionSequenceV1(int n,int k)
        {
            int[] src = new int[n];

            if (n < 1 || n > 9)
                return src;

            if (k > factorial[n])
                return src;

            for (int i = 0; i < n; i++)
                src[i] = i + 1;

            int index = 1;
            while(index != k&&!(IsLastSequence(src)))
            {
                NextPermutaion(src);
                index++;
            }

            return src;
        }


        public static int Next(int[] src,int index,int conficient)
        {
            int n = src.Length;

            HashSet<int> hs= new HashSet<int>();

            for (int j = 0; j < index;j++)
            {
                hs.Add(src[j]);
            }

            for (int i = 1; i <= n;i++)
            {
                int count = 0;
                if (!hs.Contains(i))
                {
                    foreach(var v in hs)
                    {
                        if (v < i)
                        {
                            count++;
                        }
                    }

                    if (count + 1 + conficient == i)
                    {
                        return i;
                    }    
                }
            }

            return -1;

        }


        public static int[] PermutaionSequenceV2(int n, int k)
        {
            int[] result = new int[n];

            if (n < 1 || n > 9)
                return result;

            if (k > factorial[n])
                return result;
            
            int i = 1;
            int rest = k;
            int conferial = 0;

            int fac = GetFactorial(n - 1 );

            result[0] = (k-1)/ fac+1;
            rest =(k-1)%fac;
            while(i<n)
            {
                fac = GetFactorial(n - 1 - i);
                conferial = rest / fac;
                result[i] = Next(result, i, conferial);

                rest = rest % GetFactorial(n - 1-i);
                i++;
            }

            return result;
        }


        int KT(int[] s, int n)
        {
            int i, j, cnt, sum;
            sum = 0;
            for (i = 0; i < n; ++i)
            {
                cnt = 0;
                for (j = i + 1; j < n; ++j)
                    if (s[j] < s[i]) ++cnt;
                sum += cnt * factorial[n - i - 1];
            }
            return sum;
        }


        public static int[] PermutaionSequenceV3(int n, int k)
        {
            int[] result = new int[n];

            if (n < 1 || n > 9)
                return result;
            
            if (k > factorial[n])
                return result;
            

            bool[] visit = new bool[10];
            for (int i = 0; i < n; i++)
                visit[i] = false;

            k--;
            int cnt = 0,j=1;

            for (int i = 0; i < n;i++)
            {
                cnt = k/factorial[n - 1-i];
                for (j = 1; j < n+1;j++)
                {
                    if (!visit[j])
                    {
                        if (cnt == 0)
                            break;
                        cnt--;
                    }
                }
                result[i] = j;
                visit[j] = true;
                k = k % factorial[n - 1 - i];
            }

            return result;
        }

        public static bool TestPermutaionSequence(out string funcName)
        {
            System.Diagnostics.StackFrame sf = new System.Diagnostics.StackFrame(0);
            funcName = sf.GetMethod().Name;

            int[] a = PermutaionSequenceV1(5,115);
            int[] b = PermutaionSequenceV3(5,115);

            //Console.WriteLine("a:");
            //foreach(var i in a)
            //{
            //    Console.Write("  {0}", i);
            //}

            //Console.WriteLine();
            //Console.WriteLine("b:");
            //foreach (var i in b)
            //{
            //    Console.Write("  {0}", i);
            //}

            //Console.WriteLine();
            return false;

        }

    }
}
