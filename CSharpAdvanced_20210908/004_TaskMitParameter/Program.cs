using System;
using System.Threading.Tasks;

namespace _004_TaskMitParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            Katze katze = new();

            Task<string> task1 = new Task<string>(() => MachEtwas(katze));
            Task<string> task1b = new Task<string>(() => MachEtwas(katze, DateTime.Now));
            task1.Start();
            task1.Wait();
            string result = task1.Result; //Result Property erscheint nur dann, wenn das Task-Object eine Rückgabe definiert hat -> Task<string>

            //via Factory
            Task<string> task2 = Task.Factory.StartNew(MachEtwas, katze);
            task2.Wait();
            string result1 = task2.Result;


            //via Task.Run
            Task<string> task3 = Task.Run<string>(() => MachEtwas(katze));
            task3.Wait();
            string result2 = task3.Result;


        }

        private static string MachEtwas(object input)
        {
            if (input is Katze myCat)
                return myCat.Name;

            throw new AggregateException();
        }


        private static string MachEtwas(object input, DateTime dateTime)
        {

            Console.WriteLine(((Katze)input).Name);
            Console.WriteLine(dateTime.ToShortDateString());

            return dateTime.ToShortDateString();
        }
    }


    public class Katze
    {
        public string Name { get; set; } = "Maya";
    }
}
