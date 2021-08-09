using System;

namespace CSharp71
{
    class Program
    {
        static void Main(string[] args)
        {
            int zahl = 123;
            string name = "Otto";

            var tupel = (zahl, name);



            #region Default-Werte

            int zahl1 = default; // Zuweisung des Wertes 0

            DateTime myDateTime = default; // 01.01.0001

            DateTime myDateTime1 = new();
            DateTime oldDateTime = new DateTime();
            #endregion

            Console.WriteLine("Hello World!");

            Print<string>("Hallo");
            Print<int>(12345);
            Print<DateTime>(DateTime.Now);


            Print<string, int>("Hallo", 12456);
        }

        static void Print<T>(T input)
        {
            switch (input)
            {
                case int i:
                    Console.WriteLine($"Integer: {i}");
                    break;
                case string s:
                    Console.WriteLine($"String: {s}");
                    break;
                default:
                    Console.WriteLine("Unbekannter DatenTyp");
                    break;

            }
        }

        static void Print<T, T2>(T input, T2 input2)
        {
            switch (input)
            {
                case int i:
                    Console.WriteLine($"Integer: {i}");
                    break;
                case string s:
                    Console.WriteLine($"String: {s}");
                    break;
                default:
                    Console.WriteLine("Unbekannter DatenTyp");
                    break;

            }
        }
    }
}
