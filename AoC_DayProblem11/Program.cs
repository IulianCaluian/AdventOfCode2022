// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Security.Cryptography;

Console.WriteLine("Hello, World!");
List<Monkey> monkeysTest = new List<Monkey>()
{
    new Monkey()
    {
        Q = new Queue<long>(new List<long> { 79, 98 }),
        Op = p => p * 19,
        DivisibleCondition = 23,
        NextTrue = 2,
        NextFalse = 3
    },
    new Monkey()
    {
        Q = new Queue<long>(new List<long> { 54, 65, 75, 74 }),
        Op = p => p + 6,
        DivisibleCondition = 19,
        NextTrue = 2,
        NextFalse = 0
    },
    new Monkey()
    {
        Q = new Queue<long>(new List<long> { 79, 60, 97 }),
        Op = p => p *p,
        DivisibleCondition = 13,
        NextTrue = 1,
        NextFalse = 3
    },
     new Monkey()
    {
        Q = new Queue<long>(new List<long> { 74 }),
        Op = p => p + 3,
        DivisibleCondition = 17,
        NextTrue = 0,
        NextFalse = 1
    }
};



List <Monkey> monkeysProd = 
    
    new List<Monkey>()
{
    new Monkey()
    {
        Q = new Queue<long>(new List<long> { 85, 79, 63, 72 }),
        Op = p => p * 17,
        DivisibleCondition = 2,
        NextTrue = 2,
        NextFalse = 6
    },
    new Monkey()
    {
        Q = new Queue<long>(new List<long> { 53, 94, 65, 81, 93, 73, 57, 92 }),
        Op = p => p * p,
        DivisibleCondition = 7,
        NextTrue = 0,
        NextFalse = 2
    },
    new Monkey()
    {
        Q = new Queue<long>(new List<long> { 62, 63 }),
        Op = p => p + 7,
        DivisibleCondition = 13,
        NextTrue = 7,
        NextFalse = 6
    },
     new Monkey()
    {
        Q = new Queue<long>(new List<long> { 57, 92, 56 }),
        Op = p => p + 4,
        DivisibleCondition =5,
        NextTrue = 4,
        NextFalse = 5
    },
       new Monkey()
    {
        Q = new Queue<long>(new List<long> {  67}),
        Op = p => p + 5,
        DivisibleCondition = 3,
        NextTrue = 1,
        NextFalse = 5
    },
         new Monkey()
    {
        Q = new Queue<long>(new List<long> {  85, 56, 66, 72, 57, 99 }),
        Op = p => p + 6,
        DivisibleCondition = 19,
        NextTrue = 1,
        NextFalse = 0
    },
    new Monkey()
    {
        Q = new Queue<long>(new List<long> { 86, 65, 98, 97, 69 }),
        Op = p => p * 13,
        DivisibleCondition = 11,
        NextTrue = 3,
        NextFalse = 7
    },
    new Monkey()
    {
        Q = new Queue<long>(new List<long> { 87, 68, 92, 66, 91, 50, 68 }),
        Op = p => p + 2,
        DivisibleCondition = 17,
        NextTrue = 4,
        NextFalse = 3
    }
};

long monkeyTestModulo = 23 * 19 * 13 * 17;
long monkeyProdModulo = 9699690;

List<Monkey> monkeys = monkeysProd;
long monkeyModulo = monkeyProdModulo;

for (long r = 1; r <= 10000; r++)
{
    foreach (var m in monkeys)
    {
        do
        {
            if (m.Q.Count == 0)
                break;

            m.ItemsInspected++;

            long wi = m.Q.Dequeue();
            wi = m.Op(wi)  % monkeyModulo;
           // wi = m.Op(wi) / 3;

            if (wi % m.DivisibleCondition == 0)
                monkeys[m.NextTrue].Q.Enqueue(wi);
            else
                monkeys[m.NextFalse].Q.Enqueue(wi);


        } while (true);


    }

   // long poz = 0;
    foreach(var m in monkeys)
    { 
       // poz++;
      //  Console.WriteLine($"M {poz}:" + string.Join(',', m.Q.ToList()));
      //  Console.WriteLine(m.ItemsInspected);
    }
   // Console.WriteLine("----------------------");



}

long poz = 0;
foreach (var m in monkeys)
{
    poz++;
      Console.WriteLine($"M {poz}: " + m.ItemsInspected);
}
// Console.WriteLine("----------------------");



public class Monkey
{
    public Queue<long> Q { get; set; }
    public Func<long, long> Op { get; set; }
    public long DivisibleCondition { get; set; }
    public int NextTrue { get; set; }
    public int NextFalse { get; set; }
    public long ItemsInspected { get; set; } = 0;
}
