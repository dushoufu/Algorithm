using System;
using System.Collections.Generic;
using Algorithm.Array;

namespace Algorithm
{
    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            string func;
            bool result;
            Dictionary<string, bool> resultDic = new Dictionary<string, bool>();

            result = ArrayAlgorithm.TestRemoveDup1(out func);
            resultDic.Add(func, result);


            result = ArrayAlgorithm.TestRemoveDup2(out func);
            resultDic.Add(func, result);

            result = ArrayAlgorithm.TestFindLongestConsecutiveSequence(out func);
            resultDic.Add(func, result);

            result = ArrayAlgorithm.TestTwoSum(out func);
            resultDic.Add(func, result);

            result = ArrayAlgorithm.TestThreeSumZero(out func);
            resultDic.Add(func, result);

            result = ArrayAlgorithm.TestFourSum(out func);
            resultDic.Add(func, result);

            result = ArrayAlgorithm.TestThreeSumClosest(out func);
            resultDic.Add(func, result);

            result = ArrayAlgorithm.TestRemoveElement(out func);
            resultDic.Add(func, result);

            result = ArrayAlgorithm.TestRemoveZeros(out func);
            resultDic.Add(func, result);

            result = ArrayAlgorithm.TestNextPermutaion(out func);
            resultDic.Add(func, result);

            foreach (KeyValuePair<string, bool> kv in resultDic)
            {
                Console.WriteLine("{0}:{1}", kv.Key, kv.Value);
            }

            Console.ReadKey();
        }

    }
}
