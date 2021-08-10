using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualAndAbstractSample
{
    public class BaseClassWithVirtualMethods
    {
        //Virtuall hat eine Basis-Implementierung 
        //Diese kann sogar überschrieben werden
        public virtual void MyVirtualMethod ()
        {
            Console.WriteLine($"{this.ToString()} BaseClassWithVirtualMethods.MyVirtualMethod");
        }

        public void ABC()
        {
            Console.WriteLine("BaseClassWithVirtualMethods.ABC");
        }
    }

    public class SubClassWithOverride : BaseClassWithVirtualMethods
    {
        public override void MyVirtualMethod()
        {
            //optional -> base.MyVirtualMethod();

            Console.WriteLine($"{this.ToString()} SubClassWithOverride.MyVirtualMethod");
        }

        public void DEF()
        {
            base.ABC();
        }
    }
}
