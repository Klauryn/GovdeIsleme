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
    public partial class uc_GripperFire : UserControl
    {
        public uc_GripperFire()
        {
            InitializeComponent();
        }

        private double mmBoy;

        public double MmBoy
        {
            get { return mmBoy; }
            set { mmBoy = value; }
        }
        public static uc_GripperFire Add(double boy)
        {
            uc_GripperFire new_GripperFire = new uc_GripperFire();
            new_GripperFire.MmBoy = boy;
            new_GripperFire.Height = 80;
            new_GripperFire.Width = cConfiguration.mm_to_pixel_cevir(boy);
            return new_GripperFire;
        }
    }
}
