using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqLambdaSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Person> persons = new List<Person>()
            {
                new Person {Id=1, Age=37, Vorname="Kevin", Nachname="Winter"},
                new Person {Id=2, Age=29, Vorname="Hannes", Nachname="Preishuber"},
                new Person {Id=3, Age=19, Vorname="Scott", Nachname="Hunter"},

                new Person {Id=4, Age=21, Vorname="Scott", Nachname="Hanselmann"},
                new Person {Id=5, Age=45, Vorname="Daniel", Nachname="Roth"},
                new Person {Id=6, Age=50, Vorname="Bill", Nachname="Gates"},

                new Person {Id=7, Age=70, Vorname="Newton", Nachname="King"},
                new Person {Id=8, Age=40, Vorname="Andre", Nachname="R"},
                new Person {Id=9, Age=60, Vorname="Petra", Nachname="Musterfrau"},
            };

            //Linq Statement
            IList<Person> linqStatementResult = (from p in persons
                                                 where p.Age >= 40 && p.Age < 50
                                                 orderby p.Nachname
                                                 select p).ToList();

            IList<Person> people = persons.Where(p => p.Age >= 40 && p.Age < 50)
                                          .OrderBy(o => o.Nachname)
                                          .ToList();



            //Altersdurschnitt einer Personengruppe ermitteln
            double altersdurschnitt = persons.Average(a => a.Age);

            //Altersdurschnitt von allen PErsonen, die über/gleich 40 Jahre alt sind.
            double altersdurschnitt1 = persons.Where(p => p.Age > 40).Average(a => a.Age);

            Person selectedPerson = persons.Single(s => s.Id == 4);

            Person firstPersonInList = persons.First();


            //Wenn in der List keine Person vorhanden ist, dann wird das Objekt Personen mit Default-Werten zurück gegeben -> default(T) 
            Person firstPersonInList1 = persons.FirstOrDefault();
            Person lastPersonInList = persons.Last();

            double gesamtAlterAllerPersonen = persons.Sum(a => a.Age);


            int pagingNumber = 1; //Aktuell Seite 
            int pagingSize = 3; //Anzahl der Elemente, die auf einer Seite angezeigt werden


            //Paging wird auf der WebAPI Seite implementiert 
            IList<Person> ergebnisSeite1 = persons.Skip((pagingNumber - 1) * pagingSize).Take(pagingSize).ToList();
            
            //Seite 2
            pagingNumber = 2;
            IList<Person> ergebnisSeite2 = persons.Skip((pagingNumber - 1) * pagingSize).Take(pagingSize).ToList();


            //Seite 3
            pagingNumber = 3;
            IList<Person> ergebnisSeite3 = persons.Skip((pagingNumber - 1) * pagingSize).Take(pagingSize).ToList();


            if (ergebnisSeite1.Count != 0)
            {
                //Existiert eine Ergebnismenge
            }

            if (!ergebnisSeite1.Any())
            {

            }
        }
    }


    public class Person
    {
        public int Id { get; set; }
        public int Age { get; set; }

        public string Vorname { get; set; }
        public string Nachname { get; set; }
    }
}
