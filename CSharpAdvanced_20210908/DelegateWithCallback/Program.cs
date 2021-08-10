using System;

namespace DelegateWithCallback
{
    class Program
    {
        public delegate void Del(string message);

        static void Main(string[] args)
        {
            Del handler = new Del(FinsihResultMethode);

            MethodWithCallback(111, 222, handler);

            Console.ReadKey();
        }


        public static void  MethodWithCallback(int param1, int param2, Del callback)
        {

            //lange Berechnung


            //Callback wird zum Schluss aufgerufen, nachem alle Verabreitungen fertig ist
            callback("The number is " + (param1 + param2).ToString()); //Invoke -> FinsihResultMethode
        }


        public static void FinsihResultMethode(string message)
        {
            Console.WriteLine(message);
        }
    }
}
