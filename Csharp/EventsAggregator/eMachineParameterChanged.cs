using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.EventsAggregator
{
    public class eMachineParameterChanged : EventArgs
    {
        public static event EventHandler<eMachineParameterChanged> eChanged;
        public eMachineParameterChanged()
        {

        }

        protected virtual void OnChangeEvent(eMachineParameterChanged e)
        {
            eChanged?.Invoke(this, e);
        }   

        public void EventFired()
        {
            OnChangeEvent(new eMachineParameterChanged());
        }
    }
}
