using System;
using System.Collections.Generic;

namespace GenericsSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> nameList = new List<string>(); //typisierten List -> string wird als DatenTyp verwendet. 
            nameList.Add("Harry");
            nameList.Add("Emanuella");


            IList<int> zahlenListe = new List<int>(); //intern verwendet die List-Klasse ein Array mit 4 Elementen (im Defaultzustand). 


            IDictionary<Guid, string> dict = new Dictionary<Guid, string>();
            dict.Add(new KeyValuePair<Guid, string>(Guid.NewGuid(), "Hallooooo :-)"));

            DataStore<string, DateTime> dataStore = new DataStore<string, DateTime>();

            dataStore.AddOrUpdate(1, "Hallo");
            string returnValue = dataStore.GetData(1);
            dataStore.DisplayDefault<DateTime>(); //01.01.001


         }
    }

    public class DataStore<T, ABC>
    {
        private T[] _data = new T[10];

        public T[] Data
        {
            get => _data;
            set => _data = value;
        }

        public void AddOrUpdate(int index, T item)
        {
            if (index >= 0 && index < 10)
                _data[index] = item;
        }

        public T GetData (int index)
        {
            if (index >= 0 && index < 10)
                return _data[index];
            else
                return default(T);
        }

        public void DisplayDefault<DD>()
        {
            DD item = default(DD);

            Console.WriteLine($"Default value of {typeof(DD)} is {(item == null ? "null" : item.ToString())}.");
        }


    }
}
