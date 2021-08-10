using System;
using System.Threading;

namespace _002_ThreadMitParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            ParameterizedThreadStart parameterizedThread = new ParameterizedThreadStart(MachEtwasInEinemThread);

            Thread thread = new Thread(parameterizedThread);
            
            thread.Start(600); //Parameter übergabe aus Main. 
            thread.Join(); //Wir warten, bis der Thread fertig abgearbeitet ist


            //Diese Schleife wird abgearbeiten, wenn der vorige Thread durchgelaufen ist -> Dank thread.Join();
            for (int i = 0; i < 100; i++)
            {
                Console.Write("*");
            }


            Console.ReadLine();
        }

        private static void MachEtwasInEinemThread(object obj) //object obj -> Parameter für Thread Methode
        {
            if (obj is int until)
            {
                for (int i = 0; i < until; i++)
                {
                    Console.Write("#");
                }
            }
        }
    }
}
