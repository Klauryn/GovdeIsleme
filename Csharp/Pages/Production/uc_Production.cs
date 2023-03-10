using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Csharp.Pages.Production.usercontrols;
using Csharp.Pages.JogPage;

namespace Csharp.Pages.Production
{
    public partial class uc_Production : UserControl
    {
        public uc_Production()
        {
            InitializeComponent();
            //parameters = new OperatorParameters();

        }
        public static OperatorParameters parameters;
        public static ePencereAdedi status;
        uc_TekUretimPage tekUretimPage;
        uc_TekUretimPage tekUretimPageRef;
        private void btn_TekUretim_Click(object sender, EventArgs e)
        {
            //panel_main.Controls.Clear();
            //tekUretimPage = new uc_TekUretimPage();
            //tekUretimPage.Dock = DockStyle.Fill;
            //panel_main.Controls.Add(tekUretimPage);

            if (!panel_main.Controls.Contains(tekUretimPageRef) && tekUretimPage == null)
            {
                tekUretimPage = new uc_TekUretimPage();
            }
            else
            {
                tekUretimPage = tekUretimPageRef;
            }
            if (!panel_main.Controls.Contains(tekUretimPage))
            {
                tekUretimPageRef = tekUretimPage;
                panel_main.Controls.Clear();
                tekUretimPage.Dock = DockStyle.Fill;
                panel_main.Controls.Add(tekUretimPage);
            }

            btn_TekUretim.BackColor = Color.DarkGreen;
            btn_SeriUretim.BackColor = Color.Gray;
            //parameters.OnTekUretimPage = true;
            //parameters.OnSeriUretimPage = false;
            tekUretimPage.onTekUretim = true;
            if (seriUretimPage != null)
            {
                seriUretimPage.OnSeriUretim = false;
            }
        }
        uc_SeriUretimPage seriUretimPage;
        uc_SeriUretimPage seriUretimPageRef;
        private void btn_SeriUretim_Click(object sender, EventArgs e)
        {
            //panel_main.Controls.Clear();
            //seriUretimPage = new uc_SeriUretimPage();
            //seriUretimPage.Dock = DockStyle.Fill;
            //panel_main.Controls.Add(seriUretimPage);

            if (!panel_main.Controls.Contains(seriUretimPageRef) && seriUretimPage == null)
            {
                seriUretimPage = new uc_SeriUretimPage();
            }
            else
            {
                seriUretimPage = seriUretimPageRef;
            }
            if (!panel_main.Controls.Contains(seriUretimPage))
            {
                seriUretimPageRef = seriUretimPage;
                panel_main.Controls.Clear();
                seriUretimPage.Dock = DockStyle.Fill;
                panel_main.Controls.Add(seriUretimPage);
            }

            btn_TekUretim.BackColor = Color.Gray;
            btn_SeriUretim.BackColor = Color.DarkGreen;
            //parameters.OnTekUretimPage = false;
            //parameters.OnSeriUretimPage = true;
            tekUretimPage.onTekUretim = false;
            seriUretimPage.OnSeriUretim= true;
        }

        private void uc_Production_Load(object sender, EventArgs e)
        {
            //panel_main.Controls.Clear();
            //tekUretimPage = new uc_TekUretimPage();
            //tekUretimPage.Dock = DockStyle.Fill;
            //panel_main.Controls.Add(tekUretimPage);

            if (!panel_main.Controls.Contains(tekUretimPageRef) && tekUretimPage == null)
            {
                tekUretimPage = new uc_TekUretimPage();
            }
            else
            {
                tekUretimPage = tekUretimPageRef;
            }
            if (!panel_main.Controls.Contains(tekUretimPage))
            {
                tekUretimPageRef = tekUretimPage;
                panel_main.Controls.Clear();
                tekUretimPage.Dock = DockStyle.Fill;
                panel_main.Controls.Add(tekUretimPage);
            }

            btn_TekUretim.BackColor = Color.DarkGreen;
            btn_SeriUretim.BackColor = Color.Gray;
            tekUretimPage.onTekUretim = true;
            if (seriUretimPage != null)
            {
                seriUretimPage.OnSeriUretim = false;
            }
        }
        
    }
}
