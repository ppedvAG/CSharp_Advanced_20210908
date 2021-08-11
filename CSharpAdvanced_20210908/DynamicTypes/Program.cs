using System;
using System.Dynamic;

namespace DynamicTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic myObj = new ExpandoObject();

            myObj.Vorname = "Max";
            myObj.Nachname = "Mustermann";

            Console.WriteLine(myObj.Nachname);

            myObj.Geb = DateTime.Now;

            dynamic d1 = 7;
            dynamic d2 = "a string";
            dynamic d4 = System.Diagnostics.Process.GetProcesses();

        }
    }
}
