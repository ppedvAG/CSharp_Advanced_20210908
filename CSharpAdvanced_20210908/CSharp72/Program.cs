using System;

namespace CSharp72
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodeMitDefaultParameter(123);
            MethodeMitDefaultParameter(123, 456);
            MethodeMitDefaultParameter(123, 456, 789);
        }

        public static void MethodeMitDefaultParameter(int zahl1, int zahl2 = default, int zahl3 = default)
        {
            Console.WriteLine($"{zahl1 + zahl2 + zahl3}");
        }
    }
}
