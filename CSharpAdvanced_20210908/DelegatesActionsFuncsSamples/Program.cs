using System;

namespace DelegatesActionsFuncsSamples
{

    delegate int NumbChange(int n); //Dieses Delegate kann mit Methoden zusammenarbeiten, die die selbe MethodenSignatur vorweist


    delegate string MyStringBuilder(string strParam);

    class Program
    {
        //delegate 


        static void Main(string[] args)
        {
            #region Sample1
            NumbChange nc1 = new NumbChange(AddNumber);  //Übergeben den Funktionzeiger an das Delegat
            int result = nc1(111);

            nc1 += SubNumber;
            result= nc1(222);
            Console.WriteLine(result);
            #endregion


            #region Sample2
            string str = "";
            string str1 = string.Empty;

            MyStringBuilder myStringBuilder = new MyStringBuilder(AddHelloWorld);
            myStringBuilder += AddHelloPPEDV;
            str = myStringBuilder(str);



            myStringBuilder -= AddHelloPPEDV;
            str = myStringBuilder(str);


            #endregion

           
            Action a1 = new Action(A); //Methode A wird an delegate (äh Action) drangehängt. 
            a1(); //rufen wir die Methode A auf. 
            a1 += B;
            a1(); // aufgerufen wird jetzt -> public static void A() UND public static void B()



            Action<int> a2 = new Action<int>(C);
            Action<int, DateTime> action3 = new Action<int, DateTime>(C);
            action3(111, DateTime.Now);

            Func<int, int, int> func = new Func<int, int, int>(AddNumber);
            int erg = func(111, 222);
            Console.WriteLine(erg);

            Console.ReadKey();
        }


        public static void A()
        {
            Console.WriteLine("A");
        }

        public static void B()
        {
            Console.WriteLine("B");
        }

        public static void C(int zahl)
        {
            Console.Write("C" + zahl);
        }

        public static void C(int zahl, DateTime time)
        {
            Console.WriteLine("C" + zahl);
            Console.WriteLine(time.ToShortDateString());
        }


        public static int AddNumber(int number)
        {
            return number + 5;
        }

        public static int AddNumber(int z1, int z2)
        {
            return z1 + z2;
        }

        public static int SubNumber(int number)
        {
            return number - 5;
        }


        public static string AddHelloWorld(string currentString)
        {
            return currentString += " Hello World ";
        }

        public static string AddHelloPPEDV(string currentString)
        {
            return currentString += " Hello PPEDV ";
        }


    }
}
