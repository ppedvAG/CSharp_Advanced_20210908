using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndEventHandlerSample
{

    //public delegate void Notify();

    public class ProcessBusinessLogic
    {
        public event Action ProcessCompleted;

        public void StartProcess()
        {
            //Mach was

            OnProcessCompleted();
        }


        protected virtual void OnProcessCompleted()
        {
            ProcessCompleted?.Invoke();
        }
    }
}
