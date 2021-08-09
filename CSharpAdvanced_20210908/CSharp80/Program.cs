using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CSharp80
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Using-Statement Intro
            Person p = new Person();

            FileStream stream = null;

            try
            {
                stream = new FileStream("test.txt", FileMode.OpenOrCreate);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                stream.Dispose();
            }


            using (FileStream myCoolStream = new FileStream("test.txt", FileMode.OpenOrCreate))
            {

            } //myCoolStream.Dispose (automatischer Aufruf)


            using (Person pp = new Person())
            {
                pp.Name = "Harry";
            }

            #endregion





            #region Allgemeines Feature (nicht 8.0 zugeordnet)
            int meineZahl = default; // oder -> meineZahl = 0; 

            int? meineNullableZahl = null;

            if (meineNullableZahl.HasValue) // meineNullableZahl ist [null]
            {
                Console.WriteLine(meineNullableZahl.Value);
            }

            meineNullableZahl = 123;

            if (meineNullableZahl.HasValue)
            {
                //Ausgabe 123;
                Console.WriteLine(meineNullableZahl.Value);
            }

            #endregion

            #region string mit @ und $
            string myString = "Hallo";
            string myString2 = "Welt";

            Console.WriteLine(myString + " - " + myString2);
            Console.WriteLine("{0} - {1}", myString, myString2); //Diese Idee kommt aus C -> Printf :-) 
            Console.WriteLine($"{myString} - {myString2}");

            string ausgabe = "Hallo Welter \n Zeilenumbruch  Tabulator";

            string pfad1 = "C:\\Windows\\Temp";

            string pfad2 = @"C:\Windows\Temp";

            #endregion


            #region Interface Default-Implementierung

            MyClass myClass = new MyClass();
            myClass.MethodeA(); // Überschriebene Methode wird angeboten. 
            myClass.Hallo(); //Die Methode ist nicht in MyInterface definiert.

            IMyInterface myClass2 = new MyClass(); //Dependeny Injection

            myClass2.MethodeA();
            myClass2.MethodeB();
            //fehlt myClass2.Hallo();

            //suunschöne Cast Methode
            ((IMyInterface)myClass).MethodeA();
            ((IMyInterface)myClass).MethodeB();

            //Cast mit as 
            if (myClass2 is IMyInterface)
            {
                IMyInterface test = myClass2 as IMyInterface;
            }
                

            test.MethodeA

            #endregion


        } //Hier wird p (Person) via CarbogeCollector abgebaut


       

        #region Asynchrone Stream //Wird bei ServiceLayer Methoden gerne verwendet. (WebAPI oder GRPC


        //Auflösen eines Namespace -> [STRG] + [.] -> using [Namespace] wird dann optional angeboten. 
        public static async IAsyncEnumerable<int> GeneriereZahlen()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        } //Hier verlässt er die Methode
        public static async void GebeZahlenAus()
        {
            await foreach (var zahl in GeneriereZahlen())
            {
                Console.WriteLine(zahl);
            }
        }


        #endregion


       
    }


    public class Person : IDisposable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Dispose()
        {
            Id = 0;
            Name = null;
        }
    }



    public interface IMyInterface
    {
        void MethodeA();

        void MethodeB()
        {
            Console.WriteLine("Mach etwas");
        }
    }

    public class MyClass : IMyInterface
    {
        public void MethodeA()
        {
            throw new NotImplementedException();
        }


        public void Hallo()
        {

        }
    }
}
