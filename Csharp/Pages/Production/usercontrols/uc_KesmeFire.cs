using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Csharp.Pages.MachinePars;

namespace Csharp.Pages.Production.usercontrols
{
    public partial class uc_KesmeFire : UserControl
    {
        public uc_KesmeFire()
        {
            InitializeComponent();
        }

        private double vurmaPos;

        public double dVurmaPos
        {
            get { return vurmaPos; }
            set { vurmaPos = value; }
        }

        private double mmBoy;

        public double MmBoy
        {
            get { return mmBoy; }
            set { mmBoy = value; }
        }
        public static uc_KesmeFire Add(double boy,double kullanılanboy)
        {
            uc_KesmeFire newKesmeFire = new uc_KesmeFire();
            newKesmeFire.MmBoy = boy;
            newKesmeFire.Height = 80;
            newKesmeFire.dVurmaPos = kullanılanboy + MachinePars_ToPLC.dicMachinePars_Nums[75].Value;
            newKesmeFire.Width = cConfiguration.mm_to_pixel_cevir(boy);
            return newKesmeFire;
        }
    }
}
