using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualAndAbstractSample
{
    public abstract class AbstractClassSample //abstrakte Klassen sind Schablonen -> diese können nicht instanziiert werden
    {
        public abstract void OutputText();

        public abstract int ZahlDesTages();
    }


    public class MySubClass : AbstractClassSample
    {
        public override void OutputText()
        {
            Console.WriteLine("MySubClass.OutputText");
        }

        public override int ZahlDesTages()
        {
            Console.WriteLine("MySubClass.ZahlDesTages");

            return 123;
        }
    }


}
