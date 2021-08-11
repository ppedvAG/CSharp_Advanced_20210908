using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Serialisierung_Erweiterungsmethoden.Serializer;
using System.Collections.Generic;

namespace Serialisierung_Erweiterungsmethoden
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Person person = new Person()
            {
                Vorname = "Max",
                Nachname = "Muster",
                Alter = 45,
                Kontostand = 100_000,
                KreditLimit = 500_000
            };

            Person person2 = new Person()
            {
                Vorname = "Maria",
                Nachname = "Muster",
                Alter = 33,
                Kontostand = 1000_000,
                KreditLimit = 5000_000
            };


            Stream stream = null;


            #region List Serialisieren

            PersonCollection personCollection = new();
            personCollection.AddPerson(person);
            personCollection.AddPerson(person2);


            List<Person> personList = new List<Person>();
            personList.Add(person);
            personList.Add(person2);
            #endregion

            #region Binary Collection
            //Schreiben
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            stream = File.OpenWrite("PersonCollection.bin");
            binaryFormatter.Serialize(stream, personList);
            stream.Close(); //stream.Close würde auch sehr gut in einem Finally-Block bei try-catch-finally

            ////Lesen
            stream = File.OpenRead("PersonCollection.bin");
            List<Person> personenColl = (List<Person>)binaryFormatter.Deserialize(stream);
            stream.Close();
            #endregion



            #region Binary
            //Schreiben
            //BinaryFormatter binaryFormatter = new BinaryFormatter();
            //stream = File.OpenWrite("Person.bin");
            //binaryFormatter.Serialize(stream, person);
            //stream.Close(); //stream.Close würde auch sehr gut in einem Finally-Block bei try-catch-finally

            ////Lesen
            //stream = File.OpenRead("Person.bin");
            //Person geladenePerson = (Person)binaryFormatter.Deserialize(stream);
            //stream.Close();
            #endregion


            #region Xml

            //Schreiben
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            stream = File.OpenWrite("Person.xml");
            xmlSerializer.Serialize(stream, person);
            stream.Close();

            //Lesen
            stream = File.OpenRead("Person.xml");
            Person geladenePerson1 = (Person)xmlSerializer.Deserialize(stream);
            stream.Flush();
            stream.Close();
            #endregion


            #region Json
            string jsonString = JsonConvert.SerializeObject(person);
            await File.WriteAllTextAsync("Person.json", jsonString);



            //Lesen
            Person person7 = JsonConvert.DeserializeObject<Person>(jsonString);



            #endregion


            #region CSVSerializer mit Erweiterungs-Methoden (Extentions-Methods)
            //using Serialisierung_Erweiterungsmethoden.Serializer; muss angegeben werden, damit wir die ERweiterungsmethode Serialize angeboten bekommen.  
            person.Serialize("Person.csv");


            person = new Person();
            person.Deserialize("Person.csv");
            #endregion

            //Int32 number;
            //String text;


            //int number2;
            //string text2;
        }
    }

    [Serializable]
    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }

        public int Alter { get; set; }


        // [field:NonSerialized] //->bei Binär 
        // [XmlIgnore] -> bei XML Serialisierung
        // [JsonIgnore] ->Newtonsoft.Json;
        public decimal Kontostand { get; set; }

        //[XmlIgnore]
        //NonSerialized funktioniert nur bei Variablen -> nicht bei Properties

        //[NonSerialized] //binär und JSON
        public decimal KreditLimit;
    }

    [Serializable]
    public class PersonCollection
    {
        private IList<Person> _collection = new List<Person>();

        public IList<Person> Collection
        {
            get
            {
                return _collection;
            }

            set
            {
                Collection = value;
            }
        }


        public void AddPerson(Person p)
        {
            Collection.Add(p);
        }
    }
}
