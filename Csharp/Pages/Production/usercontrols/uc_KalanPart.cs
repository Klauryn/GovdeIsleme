using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp.Pages.Production.usercontrols
{
    public partial class uc_KalanPart : UserControl
    {
        public uc_KalanPart()
        {
            InitializeComponent();
        }
        private double mmBoy;

        public double MmBoy
        {
            get { return mmBoy; }
            set { mmBoy = value; }
        }

        public static uc_KalanPart Add(double boy)
        {
            uc_KalanPart new_KalanPart = new uc_KalanPart();
            new_KalanPart.MmBoy = boy;
            new_KalanPart.Height = 80;
            new_KalanPart.Width = cConfiguration.mm_to_pixel_cevir(boy);
            return new_KalanPart;
        }
    }
}
