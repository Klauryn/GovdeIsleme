using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.EventsAggregator
{
    public class eChangedTableLayout : EventArgs
    {
        public static event EventHandler<eChangedTableLayout> eChanged;
        public eChangedTableLayout()
        {

        }

        protected virtual void OnChangeEvent(eChangedTableLayout e)
        {
            eChanged?.Invoke(this, e);
        }

        public void EventFired()
        {
            OnChangeEvent(new eChangedTableLayout());
        }
    }
}
