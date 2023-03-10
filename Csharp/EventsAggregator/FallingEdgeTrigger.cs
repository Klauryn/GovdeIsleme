using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.EventsAggregator
{
    public class FallingEdgeTrigger
    {
        public static event EventHandler StateChanged;
        protected virtual void OnStateChanged()
        {
            try
            {
                StateChanged?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
            }

        }
        private bool m_state;
        public bool State
        {
            get { return m_state; }
            set
            {
                if (m_state != value)
                {
                    m_state = value;
                    if (m_state == false)
                        OnStateChanged();
                };
            }
        }
    }
}
