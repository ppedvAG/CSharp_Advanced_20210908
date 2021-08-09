using System;

namespace CSharp73
{
    class Program
    {
        static void Main(string[] args)
        {
            MyBigClass class1 = new MyBigClass();
            class1.Vorname = "Max";
            class1.NAchname = "Musterfrau";
            class1.Birthday = DateTime.Now;
            
            MyBigClass class2 = new MyBigClass();
            class2.Vorname = "Maxi";
            class2.NAchname = "Muster";
            class2.Birthday = DateTime.Now;

            class1 = class2; //Referenz wird übergeben 

            MyBigStruct myStruct = new MyBigStruct();
            myStruct.Vorname = "Snoopy";
            myStruct.NAchname = "TheDog";
            myStruct.Birthday = new DateTime(1, 1, 1981);

            ref MyBigStruct myStructWithReferenz = ref myStruct; //Zuweisung wird wie bei einem Referenztyp verwendet.
        }
    }

    public struct MyBigStruct
    {
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string NAchname { get; set; }

        public DateTime Birthday { get; set; }
    }

    public class MyBigClass
    {
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string NAchname { get; set; }

        public DateTime Birthday { get; set; }
    }
}
