using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.EventsAggregator
{
    public class eSelectedRecipeChanged : EventArgs
    {
        public static event EventHandler<eSelectedRecipeChanged> eChanged;
        public eSelectedRecipeChanged()
        {

        }

        protected virtual void OnChangeEvent(eSelectedRecipeChanged e)
        {
            eChanged?.Invoke(this, e);
        }

        public void EventFired()
        {
            OnChangeEvent(new eSelectedRecipeChanged());
        }
    }
}
