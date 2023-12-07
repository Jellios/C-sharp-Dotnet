using System;

namespace NamespaceDing
{
    public static class Dingetje
    {
        public static void Voorbeeld1()
        {
            List<int> numbers = new List<int> { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            IEnumerable<int> filteringQuery =
                from num in numbers
                where num < 3 || num > 7
                select num;
            foreach (int x in filteringQuery)
            {
                System.Console.WriteLine($"{x}");
            }
        }
        public static void Voorbeeld2()
        {
            string[] groupingQuery = { "carrots", "cabbage", "broccoli", "beans", "barley" };
            IEnumerable<IGrouping<char, string>> queryFoodGroups =
                from item in groupingQuery
                group item by item[0];
            foreach (var group in queryFoodGroups)
            {
                Console.WriteLine($"Key: {group.Key}");
                foreach (var item in group)
                {
                    Console.WriteLine($"Item: {item}");
                }
            }
        }
        public static void Main(string[] args)
        {
            Voorbeeld2();
        }
    }
}