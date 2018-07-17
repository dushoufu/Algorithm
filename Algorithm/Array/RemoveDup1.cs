using System;


namespace Algorithm.Array
{
    partial class ArrayAlgorithm
    {

//Given a sorted array, remove the duplicates in place such that each element appear only once and return the new length.
//Do not allocate extra space for another array, you must do this in place with constant memory.
//For example, Given input array A = [1, 1, 2],
//Your function should return length = 2, and A is now[1, 2].

        public static int RemoveDup1(int[] src)
        {
            if (1 >= src.Length)
            {
                return src.Length;
            }

            int index = 1;

            for (int i = 1; i < src.Length; i++)
                if (src[i] != src[index - 1])
                {
                    src[index++] = src[i];

                }

            return index;
        }

        public static bool TestRemoveDup1(out string funcName)
        {
            //Console.WriteLine("Hello World!");

            System.Diagnostics.StackFrame sf = new System.Diagnostics.StackFrame(0);
            funcName = sf.GetMethod().Name;

            int[] a = new int[] { 1, 2, 3, 3, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6 };
            int[] a_expected = new int[] { 1, 2, 3, 4, 5, 6 };


            int len = RemoveDup1(a);
   

            if (len != a_expected.Length)
                return false;

            for (int i = 0; i < len; i++)
            {
                if (a[i] != a_expected[i])
                    return false;
            }

            a = new int[] { 1};
            a_expected = new int[] { 1};

            len = RemoveDup2(a);


            if (len != a_expected.Length)
                return false;

            for (int i = 0; i < len; i++)
            {
                if (a[i] != a_expected[i])
                    return false;
            }


            return true;

        }

    }
}
