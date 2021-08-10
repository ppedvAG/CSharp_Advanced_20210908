using System;
using System.Threading.Tasks;

namespace _007_TaskContinueSample_WithParams
{
    class Program
    {
        static void Main(string[] args)
        {
            //var Task1
            Task<string> task = Task.Run(DayTime);

            task.ContinueWith(task => ShowDayTime(task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);

            Console.ReadKey();

        }

        public static string DayTime()
        {
            DateTime date = DateTime.Now;

            return date.Hour > 17
                ? "evening"
                : date.Hour > 12
                ? "afternoon"
                : "morning";
        }


        public static void ShowDayTime(string result)
        {
            Console.WriteLine(result);
        }
    }
}
