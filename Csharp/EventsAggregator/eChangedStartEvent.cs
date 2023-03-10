using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.EventsAggregator
{
    public class eChangedStartEvent : EventArgs
    {
        public static event EventHandler<eChangedStartEvent> eChanged;
        public eChangedStartEvent()
        {

        }

        protected virtual void OnChangeEvent(eChangedStartEvent e)
        {
            eChanged?.Invoke(this, e);
        }

        public void EventFired()
        {
            OnChangeEvent(new eChangedStartEvent());
        }
    }
}
