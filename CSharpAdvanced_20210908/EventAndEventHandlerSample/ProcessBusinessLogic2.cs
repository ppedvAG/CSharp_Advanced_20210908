using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndEventHandlerSample
{
    public class ProcessBusinessLogic2
    {
        public event EventHandler ProcessCompleted;

        public event EventHandler ProcessCompletedNew;


        public void StartProcess()
        {
            //Mach etwas







            //Sample1
            OnProcessCompleted(EventArgs.Empty);

            //Sample2 mit eiger Event-Klasse
            MyEventArgs myEvent = new MyEventArgs();
            myEvent.Uhrzeit = DateTime.Now;
            OnProcessCompletedNew(myEvent);
        }

        protected virtual void OnProcessCompleted(EventArgs e)
        {
            //Invoke sender = this, EventArgs = e 
            ProcessCompleted?.Invoke(this, e);
        }

        protected virtual void OnProcessCompletedNew(MyEventArgs e)
        {
            ProcessCompletedNew?.Invoke(this, e);
        }
    }

    public class MyEventArgs : EventArgs
    {
        public DateTime Uhrzeit { get; set; }
    }
}
