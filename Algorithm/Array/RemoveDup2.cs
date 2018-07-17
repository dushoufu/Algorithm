using System;


namespace Algorithm.Array
{
    partial class ArrayAlgorithm
    {

        //        Follow up for "Remove Duplicates": What if duplicates are allowed at most twice?

        //        For example, given sorted array A = [1,1,1,2,2,3], your function should return length = 5, and A is now[1, 1, 2, 2, 3]

        public static int RemoveDup2(int[] src)
        {
            if (2 >= src.Length)
            {
                return src.Length;
            }

            int index = 2;

            for (int i = 2; i < src.Length; i++)
                if (src[i] != src[index - 2])
                {
                    src[index++] = src[i];

                }

            return index;
        }

        public static bool TestRemoveDup2(out string funcName)
        {
            //Console.WriteLine("Hello World!");

             System.Diagnostics.StackFrame sf = new System.Diagnostics.StackFrame(0);
            funcName = sf.GetMethod().Name;

            int[] a = new int[] { 1, 2, 3, 3, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6 };
            int[] a_expected = new int[] { 1, 2, 3, 3, 4, 4, 5, 5, 6, 6 };


            int len = RemoveDup2(a);

            if (!TestResult(a, len, a_expected))
                return false;

            a = new int[] { 1, 2 };
            a_expected = new int[] { 1, 2 };

            len = RemoveDup2(a);


            return TestResult(a, len, a_expected);

        }

    }
}
