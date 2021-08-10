using System;
using System.Threading;
using System.Threading.Tasks;

namespace _002_Task_Beenden
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Task task = Task.Factory.StartNew(MEineMethideMitAbbrechen, cts);

            Thread.Sleep(5000);
            cts.Cancel();

        }

        private static void MEineMethideMitAbbrechen(object param) //CancellationTokenSource wird übergeben
        {
            CancellationTokenSource source = (CancellationTokenSource)param;

            while(true)
            {
                Console.WriteLine("ZZZzzzz.....zzzZZZzz...Zzz.ZZ");
                Thread.Sleep(50);


                //Wurde CancellationTokenSource mitgeteilt, dass der Thread beendet werden soll. 
                if (source.IsCancellationRequested)
                    break;
            }
        }
    }
}
