using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LazyEvaluationDemo
{
    public class Program
    {
        public static void Main()
        {
            var evenNumbers = MyUtils.GetEvenNumbersLazy();
            var counter = 0;
            foreach (var evenNumber in evenNumbers)
            {
                Console.WriteLine(evenNumber);
                counter++;
                if (counter >= 10) break;
            }
            Console.WriteLine("10 even numbers are printed");
            Console.ReadLine();
        }
    }
    
    public static class MyUtils
    {
        public static List<int> GetEvenNumbersEager()
        {
            var result = new List<int>();
            for (var i = 0; i < 100; i++)
            {
                if (i % 2 == 0) result.Add(i);
            }
            return result;
        }

        public static IEnumerable<int> GetEvenNumbersLazy()
        {
            for (var i = 0; i < 100; i++)
            {
                if (i%2 == 0)
                    yield return i;
            }
        }
    }
}
