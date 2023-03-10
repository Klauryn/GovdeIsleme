using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp.Pages.Production.usercontrols.DelikUserController
{
    public partial class uc_Cap7_Sag : UserControl
    {

        private double vurmapos;

        public double VurmaPos
        {
            get { return vurmapos; }
            set { vurmapos = value; }
        }

        private double genislik;

        public double GenislikPos
        {
            get { return genislik; }
            set { genislik = value; }
        }

        public uc_Cap7_Sag(Point locationInPanel, double _vurmaPos, double genislikPos)
        {
            InitializeComponent();
            this.Location = new Point(locationInPanel.X - this.Width / 2, locationInPanel.Y - this.Height / 2);
            VurmaPos = _vurmaPos;
            GenislikPos = genislikPos;
        }
    }
}
