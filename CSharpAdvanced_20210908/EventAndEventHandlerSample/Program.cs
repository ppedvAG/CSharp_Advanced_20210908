using System;

namespace EventAndEventHandlerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessBusinessLogic processBusinessLogic = new ProcessBusinessLogic();
            processBusinessLogic.ProcessCompleted += ProcessBusinessLogic_ProcessCompleted;
            processBusinessLogic.StartProcess();


            ProcessBusinessLogic2 processBusinessLogic2 = new ProcessBusinessLogic2();
            processBusinessLogic2.ProcessCompleted += ProcessBusinessLogic2_ProcessCompleted;
            processBusinessLogic2.ProcessCompletedNew += ProcessBusinessLogic2_ProcessCompletedNew;
            processBusinessLogic2.StartProcess();


        }

        private static void ProcessBusinessLogic2_ProcessCompletedNew(object sender, EventArgs e)
        {
            MyEventArgs myEventArgs = (MyEventArgs)e;

            Console.WriteLine($"Fertig am/um {myEventArgs.Uhrzeit.ToLongDateString()}");
        }

        private static void ProcessBusinessLogic2_ProcessCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("ProcessBusinessLogic2 ist fertig mit Berechnung");
        }

        private static void ProcessBusinessLogic_ProcessCompleted()
        {
            Console.WriteLine("ProcessBusinessLogic ist fertig mit Berechnung");
        }
    }
}
