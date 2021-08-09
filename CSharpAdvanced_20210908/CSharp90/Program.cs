using System;

namespace CSharp90
{
    class Program
    {
        static void Main(string[] args)
        {
            //USE CASES für Records -> Ergebis - Strukturen, bei denen das Ergebnis im Nachhinein nicht mehr manipuliert werden kann. (Abfrage von Service Layer Methoden) 
            //USE Cases -> Entities für EF Core -> 



            PersonRecord personRecord1 = new PersonRecord(1, "Mario Bart");
            PersonRecord personRecord2 = new PersonRecord(1, "Mario Bart");

            MyPerson myPerson1Class = new MyPerson(1, "Helge Schneider");
            MyPerson myPerson2Class = new MyPerson(1, "Helge Schneider");


            PersonRecord personRecord3 = personRecord1 with { Name = "Kevin" }; //Beim Kopierren, bzw initiieren von personRecord3 kann man bei WITH den Datensatz nochmals manipulieren.

            if (myPerson1Class == myPerson2Class)
            {
                Console.WriteLine("myPerson1Class == myPerson2Class -> gleich");
            }
            else
            {
                Console.WriteLine("myPerson1Class == myPerson2Class -> ungleich");
            }


            if (personRecord1 == personRecord2)
            {
                Console.WriteLine("personRecord1 == personRecord2 -> gleich");
            }
            else
            {
                Console.WriteLine("personRecord1 == personRecord2 -> ungleich");
            }

            if (myPerson1Class.Equals(myPerson2Class))
            {
                Console.WriteLine("myPerson1Class.Equals(myPerson2Class) -> gleich");
            }
            else
            {
                Console.WriteLine("myPerson1Class.Equals(myPerson2Class) -> ungleich");
            }

            if (personRecord1.Equals(personRecord1))
            {
                Console.WriteLine("personRecord1.Equals(personRecord2) -> gleich");
            }
            else
            {
                Console.WriteLine("personRecord1.Equals(personRecord2) -> ungleich");
            }

            personRecord1.GetHashCode(); //Ist in Records ausimplementiert // In Klassen muss GetHastCode überschrieben werden. 

            (int id, string name) = personRecord1;
        }
    }

    public record PersonRecord(int Id, string Name);

    public record EmployeeRecord : PersonRecord
    {
        public decimal Gehalt { get; init; }

        public EmployeeRecord(int Id, string Name)
            :base(Id, Name)
        {

        }

        public EmployeeRecord(int Id, string Name, decimal Gehalt)
           : base(Id, Name)
        {
            this.Gehalt = Gehalt;
        }
    }


    public class MyPerson
    {
        //ctor + tab + tab -> Konstruktor
        public MyPerson(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
