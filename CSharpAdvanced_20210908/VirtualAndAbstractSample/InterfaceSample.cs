using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualAndAbstractSample
{
    public interface InterfaceSample
    {
        void MessageOutput(string Message);
        void ZahlDesTages();
    }

    public class MyInterfaceSampleImplementation : InterfaceSample
    {
        public void MessageOutput(string Message)
        {
            throw new NotImplementedException();
        }

        public void ZahlDesTages()
        {
            throw new NotImplementedException();
        }
    }
}
