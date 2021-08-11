using System;
using System.Reflection; 

namespace HelloReflections
{
    class Program
    {
        static void Main(string[] args)
        {
            //dll ist im Arbeitsspeicher geladen
            Assembly geladeneDll = Assembly.LoadFrom("TrumpTaschenrechner.dll");
            
            //lade Klasse
            Type trumpTaschenrechnerTyp = geladeneDll.GetType("TrumpTaschenrechner.Taschenrechner");

            object tr = Activator.CreateInstance(trumpTaschenrechnerTyp);

            //Lese Methode aus
            MethodInfo addInfo = trumpTaschenrechnerTyp.GetMethod("Add", new Type[] { typeof(Int32), typeof(Int32)});

            //verwende Methode
            var result = addInfo.Invoke(tr, new object[] { 11, 22 });

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
