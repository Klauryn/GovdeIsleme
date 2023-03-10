using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.EventsAggregator
{
    public class eRecipeParameterChanged : EventArgs
    {
        public static event EventHandler<eRecipeParameterChanged> eChanged;
        public eRecipeParameterChanged()
        {

        }

        protected virtual void OnChangeEvent(eRecipeParameterChanged e)
        {
            eChanged?.Invoke(this, e);
        }

        public void EventFired()
        {
            OnChangeEvent(new eRecipeParameterChanged());
        }
    }
}
