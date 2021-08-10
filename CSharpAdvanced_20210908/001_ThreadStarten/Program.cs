using System;
using System.Threading;

namespace _001_ThreadStarten
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(MachEtwasInEinemThread); //Funktionszeiger muss zugeordnet werden
            thread.Start();
            thread.Join(); //Wir warten, bis der Thread fertig abgearbeitet ist


            //Diese Schleife wird abgearbeiten, wenn der vorige Thread durchgelaufen ist -> Dank thread.Join();
            for (int i = 0; i < 100; i++)
            {
                Console.Write("*");
            }


            Console.ReadLine();

        }


        private static void MachEtwasInEinemThread()
        {
            for (int i = 0; i <100;i++)
            {
                Console.Write("#");
            }
        }

    }
}
