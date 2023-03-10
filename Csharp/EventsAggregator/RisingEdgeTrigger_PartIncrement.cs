using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.EventsAggregator
{
    class RisingEdgeTrigger_PartIncrement
    {
        public static event EventHandler StateChanged;

        public bool State
        {
            get { return m_state; }
            set
            {
                if (m_state != value)
                {
                    m_state = value;
                    if (m_state)
                        OnStateChanged();
                };
            }
        }

        public void OnStateChanged()
        {
            try
            {
                StateChanged?.Invoke(this, EventArgs.Empty);
                //StateChanged?.BeginInvoke(this, EventArgs.Empty,null,null);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
            }
        }
        private bool m_state;
    }
}
