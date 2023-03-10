using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp.Pages
{
    public partial class uc_AboutPage : UserControl
    {
        public uc_AboutPage()
        {
            InitializeComponent();
        }
        string filename = System.Threading.Thread.GetDomain().BaseDirectory + "//Eplan.pdf";
        private void uc_AboutPage_Load(object sender, EventArgs e)
        {
            axAcroPDF1.LoadFile(filename);
        }
    }
}
