using System;
using System.Threading;

namespace _008_MonitorSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void KritischerCodeAbschnitt()
        {
            int x = 1;


            Monitor.Enter(x);

            try
            {
                //callen weitere Methoden 
                //if-else Struktur
            }
            finally
            {
                Monitor.Exit(x);
            }
        }
    }
}
