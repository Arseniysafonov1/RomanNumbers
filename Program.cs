using System;

namespace RomanNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RomanNumber rn = new RomanNumber(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
            }
            Console.WriteLine();
            Random random = new Random();
            RomanNumber[] arr = new RomanNumber[10];
            for (int i = 0; i < 10; i++)
            {
                arr[i] = new RomanNumber((ushort)random.Next(1, ushort.MaxValue));
                Console.WriteLine($"arr[{i}] = { arr[i].ToString()}");
            }
            Array.Sort(arr);
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"arr[{i}] = { arr[i].ToString()}");
            }
            Console.WriteLine();


            RomanNumber r1 = new RomanNumber(99);
            Console.WriteLine(r1.ToString());
            RomanNumber r2 = r1.Clone() as RomanNumber;
            Console.WriteLine(r2.ToString());
            RomanNumber r3 = new RomanNumber(999);
            Console.WriteLine(r3.ToString());
            Console.WriteLine();
            try
            {
                Console.WriteLine(RomanNumber.Sub(r2, r1));
            }
            catch
            {
                Console.WriteLine("Error!");
            }
            Console.WriteLine();
            Console.WriteLine(RomanNumber.Add(r1, r2).ToString());
            Console.WriteLine(RomanNumber.Div(r1, r2).ToString());
            try
            {
                Console.WriteLine(RomanNumber.Mul(r1, r3).ToString());
            }
            catch
            {
                Console.WriteLine($"Error multing {r1} and {r3}");
            }
        }
    }
}
