using System;

namespace CSharp70
{
    class Program
    {
        static void Main(string[] args)
        {
            #region  Out-Variable

            string eingabe = "12345";
            
            int ausgabe;

            if (int.TryParse(eingabe, out ausgabe))
            {
                //Wenn ausgabe nummerisch ist, dann können zahl ausgeben 
                Console.WriteLine(ausgabe);
            }

            #endregion


            #region Feste Wertzuweisungen 
           
            int eineMillionen = 1_000_000;
            decimal Geldbeträge = 123m;

            #endregion


            #region Rückgabe per Referenz
            int[] zahlen = { 5, 7, 9, 11, 14, 16 };
            ref int position = ref Zahlensuche(14, zahlen);

            position = 777777;
            Console.WriteLine(zahlen[4]); //Ausgabe: 777777

            #endregion

            string vorname = "Otto";
            string zweiterVorname = string.Empty;
            string nachname = "Walkes";

            string complete_name = vorname + (zweiterVorname != string.Empty ? zweiterVorname : string.Empty) +nachname;
        }

        private bool MyTryParse(string eingabe, out int toCheck)
        {
            for (int i=0; i < eingabe.Length; i++)
            {
                if (!char.IsDigit(eingabe[i]))
                {
                    throw new ArgumentException(); 
                }
            }

            toCheck = Convert.ToInt32(eingabe);
            return true;
        }

        public static ref int Zahlensuche(int gesuchteZahl, int[] zahlen)
        {
            for (int i= 0; i < zahlen.Length; i++)
            {
                if (zahlen[i] == gesuchteZahl)
                    return ref zahlen[i];
            }

            throw new IndexOutOfRangeException();
        }
    }
}
