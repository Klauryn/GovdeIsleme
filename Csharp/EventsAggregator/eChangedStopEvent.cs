using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.EventsAggregator
{
    public class eChangedStopEvent : EventArgs
    {
        public static event EventHandler<eChangedStopEvent> eChanged;
        public eChangedStopEvent()
        {

        }

        protected virtual void OnChangeEvent(eChangedStopEvent e)
        {
            eChanged?.Invoke(this, e);
        }

        public void EventFired()
        {
            OnChangeEvent(new eChangedStopEvent());
        }
    }
}
