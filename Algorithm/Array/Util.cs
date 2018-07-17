using System;


namespace Algorithm.Array
{
    partial class ArrayAlgorithm
    {
        public static bool TestResult(int[] result,int len,int [] expectedResult)
        {
            if (len != expectedResult.Length)
                return false;

            for (int i = 0; i < len;i++)
            {
                if (result[i] != expectedResult[i])
                    return false;
            }

            return true;
        }

    }
}
