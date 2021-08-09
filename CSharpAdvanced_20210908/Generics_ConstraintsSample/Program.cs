using System;
using System.Collections;

namespace Generics_ConstraintsSample
{
    class Program
    {
        //Wertetypen -> bool, int, float, decimal, double, long, short, struct

        //referenztypen -> string, class, record, interface, all objects in .net like ArrayList, List<T>, DateTime, 
        static void Main(string[] args)
        {
            ////DataStore<T> where T : class  // Hier dürfen nur Referenztypen zugelassen werden
            ///

            //DataStore<string> store1 = new DataStore<string>();
            //DataStore<MyClass> store2 = new DataStore<MyClass>();

            //DataStore<IMyInterface> store3 = new DataStore<IMyInterface>();


            //DataStore<MyStruct> store4 = new DataStore<MyStruct>(); 

            //DataStore<int> store5 = new DataStore<int>(); 

            //DataStore<ArrayList> store6 = new DataStore<ArrayList>();

            //DataStore<MyRecord> store7 = new DataStore<MyRecord>();




            //DataStore1<T> where T : struct // Hier dürfen nur Wertetypen zugelassen werden
            //DataStore1<string> store7 = new DataStore1<string>();
            //DataStore1<MyClass> store8 = new DataStore1<MyClass>();
            //DataStore1<IMyInterface> store9 = new DataStore1<IMyInterface>();
            //DataStore1<MyStruct> store10 = new DataStore1<MyStruct>();
            //DataStore1<int> store11 = new DataStore1<int>();
            //DataStore1<MyRecord> store7 = new DataStore1<MyRecord>();
        }
    }




    class DataStore<T> where T : class //Referenztypen dürfen verwendet werden
    {
        public T Data { get; set; }
    }

    class DataStore1<T>
        where T : struct //Struct oder Werttyp
    {
        public T Data { get; set; }
    }

    class DataStore2<T> where T : Animal //Animal Klasse können wir verwenden oder eine vererbte Klasse von Animal
    {
        public T Data { get; set; }
    }

    class DataStore3<T> where T : new() //Alle Klassen mit einem Default-Konstruktor
    {
        public T Data { get; set; }
    }

    public class Animal
    {
        public string Name { get; set; } = "R2D2";
    }

    public class Dog : Animal
    {
        public string Hunderasse { get; set; } = "ein wau wau";
    }

    public record MyRecord
    {

    }
    public class MyClass
    {

    }

    public interface IMyInterface
    {
    }

    public struct MyStruct
    {
        string Name { get; set; }
    }
}
