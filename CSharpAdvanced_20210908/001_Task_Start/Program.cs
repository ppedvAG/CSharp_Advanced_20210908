using System;
using System.Threading.Tasks; //ab .NET 4.0

namespace _001_Task_Start
{
    class Program
    {
        static void Main(string[] args)
        {

            Task easyTask = new Task(MachEtwasInEinemThread); //Funktionszeiger wird übergeben
            easyTask.Start(); //threading.start
            easyTask.Wait(); //threading.join

            for (int i = 0; i < 100; i++)
            {
                Console.Write("*");
            }

            Console.ReadKey();
        }


        private static void MachEtwasInEinemThread()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("#");
            }
        }
    }
}
