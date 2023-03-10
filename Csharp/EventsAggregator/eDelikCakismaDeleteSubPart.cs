using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.EventsAggregator
{
    public class eDelikCakismaDeleteSubPart : EventArgs
    {
        public static event EventHandler<eDelikCakismaDeleteSubPart> eChanged;
        public eDelikCakismaDeleteSubPart()
        {

        }

        protected virtual void OnChangeEvent(eDelikCakismaDeleteSubPart e)
        {
            eChanged?.Invoke(this, e);
        }

        public void EventFired()
        {
            OnChangeEvent(new eDelikCakismaDeleteSubPart());
        }
    }
}
