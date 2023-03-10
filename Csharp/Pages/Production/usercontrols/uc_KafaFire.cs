using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp.Pages.Production.usercontrols
{
    public partial class uc_KafaFire : UserControl
    {
        public uc_KafaFire()
        {
            InitializeComponent();
        }

        private double mmBoy;

        public double MmBoy
        {
            get { return mmBoy; }
            set { mmBoy = value; }
        }
        public static uc_KafaFire Add(double boy)
        {
            uc_KafaFire new_KafaFire = new uc_KafaFire();
            new_KafaFire.MmBoy = boy;
            new_KafaFire.Height = 80;
            new_KafaFire.Width = cConfiguration.mm_to_pixel_cevir(boy);
            return new_KafaFire;
        }
    }
}
