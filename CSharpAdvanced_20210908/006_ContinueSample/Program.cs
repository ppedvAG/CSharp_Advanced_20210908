using System;
using System.Threading;
using System.Threading.Tasks;

namespace _006_ContinueSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = new Task(() =>
            {
                Console.WriteLine("Task 1 ist gestartet");
                Thread.Sleep(1000);
                throw new Exception();
            });

            t1.Start();

            //Allgemeine Folgetask
            t1.ContinueWith(t => 
            {
                Console.WriteLine("Allgemeiner Folgetask");
             });

            t1.ContinueWith(t =>
            {
                Console.WriteLine("Fortlaufender Task - TaskContinuationOptions.OnlyOnRanToCompletion");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            t1.ContinueWith(t =>
            {
                Console.WriteLine("Fortlaufender Task - TaskContinuationOptions.OnlyOnFaulted");
            }, TaskContinuationOptions.OnlyOnFaulted);


            Console.ReadLine();
        }
    }
}
