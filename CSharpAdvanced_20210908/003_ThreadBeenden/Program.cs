using System;
using System.Threading;

namespace _003_ThreadBeenden
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(MachEtwas);
            t.Start();

            Thread.Sleep(3000); //nach 3 Sekunden soll der Thread beendet werden
            t.Interrupt();

            Console.WriteLine("Ready");
            Console.ReadLine();
        }

        private static void MachEtwas() //Dieser Thread benötigt 10 Sek (50 x 0,2Sek.)
        {
            try
            {
                for (int i = 0; i <50; i++)
                {
                    Thread.Sleep(200);
                    Console.WriteLine("zZZzzzZZzzzz");
                }
            }
            catch
            {

            }
        }
    }
}
