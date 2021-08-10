using System;
using System.Threading.Tasks;

namespace _003_TaskFactorySample
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = Task.Factory.StartNew(MachEtwasInEinemThread); // Der Task startet sofort seine Arbeit
            task.Wait();
            
            
            
            //Daher haben wir in der .NET Framework 4.5 - Entwicklervorschau die neue Task.Run - Methode
            //eingeführt. Dies macht Task.Factory.StartNew in keiner Weise überflüssig, sondern sollte 
            //einfach als schnelle Möglichkeit zur Verwendung von Task.Factory.StartNew angesehen werden, 
            //ohne dass eine Reihe von Parametern angegeben werden müssen. Es ist eine Abkürzung. 
            //Tatsächlich wird Task.Run in Bezug auf dieselbe Logik implementiert, die für Task.Factory.StartNew verwendet wird, 
            //wobei nur einige Standardparameter übergeben werden. Wenn Sie eine Aktion an Task.Run übergeben:
            //Task task2 = Task.Run(IchMacheEtwasImTask); // // Im Hintergrund wird die  -> Task.Factory.StartNew(IchMacheEtwasImTask); aufgerufen

            Task task2 = Task.Run(MachEtwasInEinemThread);
            task2.Wait();

            Console.WriteLine("Bin fertig");
            Console.ReadLine();
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
