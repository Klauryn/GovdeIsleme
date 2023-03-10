using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.EventsAggregator
{
    public class eUpdate_RecipeList : EventArgs
    {
        public static event EventHandler<eUpdate_RecipeList> eChanged;
        public eUpdate_RecipeList()
        {

        }

        protected virtual void OnChangeEvent(eUpdate_RecipeList e)
        {
            eChanged?.Invoke(this, e);
        }

        public void EventFired()
        {
            OnChangeEvent(new eUpdate_RecipeList());
        }
    }
}
