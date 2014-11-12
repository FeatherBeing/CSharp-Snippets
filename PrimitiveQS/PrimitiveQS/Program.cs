using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimitiveQS
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] unsorted = { 9, 10, 7, 1, 2, 3, 4, 5, 6 };
            string[] unsorted2 = { "the", "quick", "brown", "fox", "jumped", "over", "the", "lazy", "dog" };
            Console.WriteLine(string.Join(", ", Quicksort(unsorted)));
            Console.WriteLine(string.Join(", ", Quicksort(unsorted2)));
        }

        private static IEnumerable<T> Quicksort<T>(IEnumerable<T> list) 
            where T : IComparable<T>
        {
            if ((list == null) || !list.Any())
                return Enumerable.Empty<T>();

            var smallerAndLarger = list.Skip(1).GroupBy(n => n.CompareTo(list.First()));

            return Quicksort(smallerAndLarger.FirstOrDefault(x => x.Key < 0))
                   .Concat(new List<T>(new[] { list.First() }))
                   .Concat(Quicksort(smallerAndLarger.FirstOrDefault(x => x.Key >= 0)));
        }
    }
}
