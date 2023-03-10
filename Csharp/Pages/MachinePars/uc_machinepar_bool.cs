using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Csharp.EventsAggregator;

namespace Csharp.Pages.MachinePars
{
    public partial class uc_machinepar_bool : UserControl
    {
        private eMachineParameterChanged fooChanged;
        public uc_machinepar_bool()
        {
            InitializeComponent();
            fooChanged = new eMachineParameterChanged();
            if (cb_State.Checked) { cb_State.Checked = true; btn_toggle.BackColor = Color.Green; btn_toggle.Text = "Aktif"; }
            else { cb_State.Checked = false; btn_toggle.BackColor = Color.Red; btn_toggle.Text = "Pasif"; }
        }
    
        private void btn_toggle_Click(object sender, EventArgs e)
        {
            if (cb_State.Checked) { cb_State.Checked = false; btn_toggle.BackColor = Color.Red; btn_toggle.Text = "Pasif"; }
            else { cb_State.Checked = true; btn_toggle.BackColor = Color.Green; btn_toggle.Text = "Aktif"; }
            fooChanged.EventFired();
        }

        private void uc_machinepar_bool_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            if (cb_State.Checked) { cb_State.Checked = true; btn_toggle.BackColor = Color.Green; btn_toggle.Text = "Aktif"; }
            else { cb_State.Checked = false; btn_toggle.BackColor = Color.Red; btn_toggle.Text = "Pasif"; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cb_State.Checked) { cb_State.Checked = true; btn_toggle.BackColor = Color.Green; btn_toggle.Text = "Aktif"; }
            else { cb_State.Checked = false; btn_toggle.BackColor = Color.Red; btn_toggle.Text = "Pasif"; }
        }
    }
}
