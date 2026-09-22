


using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

var nums = new List<int>() { 1, 2, 3, 4, 5, 3, 6 };

var x = nums.Where(n => n == 3).Single();

// Language Integrated Query - LINQ
var friends = new List<string> { "Tim", "Tim", "Susan", "David" };

Console.WriteLine(friends.SingleOrDefault(f => f == "Tim") ?? "Not Found");
Console.WriteLine($"Here it is: {x}");

//IEnumerable<int> GetNumbersOneToOneHundred()
//{
    
//    for(var t = 0; t<101; t++)
//    {
//        Thread.Sleep(100);
//        yield return t;
//    }
    
//}

//var sw = new Stopwatch();
//sw.Start();



//foreach(var e in  GetNumbersOneToOneHundred().Where(n => n % 2 == 0).Take(10))
//{
//    Console.WriteLine(e);
    
//}

//sw.Stop();
//Console.WriteLine($"That took {sw.ElapsedMilliseconds} milliseconds");