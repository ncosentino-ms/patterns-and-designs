using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

public class Program
{
    public static void Main()
    {
        IEnumerable<int> setOfData = new int[]
        {
            1,
            2,
            3,
            4,
        };
        


        var stopwatch = Stopwatch.StartNew();

        var ienumerable = Iterator();
        Console.WriteLine($"Direct Assignment From Iterator: {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine();
        
        stopwatch.Restart();
        var ienumerableAny = ienumerable.Any();
        Console.WriteLine($"IEnumerable Any: {stopwatch.ElapsedMilliseconds} ms");

        stopwatch.Restart();
        var ienumerableCountLinq = ienumerable.Count();
        Console.WriteLine($"IEnumerable Count LINQ: {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine();



        //stopwatch.Restart();
        //var listToList = toList.ToList();
        //Console.WriteLine($"List ToList: {stopwatch.ElapsedMilliseconds} ms");

        //stopwatch.Restart();
        //var listAnyLinq = toList.Any();
        //Console.WriteLine($"List Any LINQ: {stopwatch.ElapsedMilliseconds} ms");

        //stopwatch.Restart();
        //var listCountLinq = toList.Count();
        //Console.WriteLine($"List Count LINQ: {stopwatch.ElapsedMilliseconds} ms");

        //stopwatch.Restart();
        //var countProperty = toList.Count;
        //Console.WriteLine($"List Count Property: {stopwatch.ElapsedMilliseconds} ms");

        Console.ReadLine();
    }

    private static IEnumerable<int> Iterator()
    {
        // simulates setup (i.e. connecting to a DB, perhaps)
        Thread.Sleep(1000);
        for (int i = 0; i < 5; i++)
        {
            // simulates overhead (i.e. pulling back records from a DB, perhaps)
            Thread.Sleep(250);
            yield return i;
        }

        // simulates cleanup (i.e. ... not sure, but maybe situations where resources are released)
        //Thread.Sleep(100);
    }

    // 
    private static List<int> FunctionWithListReturnType()
    {
        var list = new List<int>();
        foreach (var item in Iterator())
        {
            list.Add(item);
        }

        return list;
    }
}