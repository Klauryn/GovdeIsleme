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
    public partial class uc_ManivelaDeligi : UserControl
    {
        private double vurmapos;

        public double VurmaPos
        {
            get { return vurmapos; }
            set { vurmapos = value; }
        }
        public uc_ManivelaDeligi(Point locationInPanel, double _vurmaPos)
        {
            InitializeComponent();
            this.Location = new Point(locationInPanel.X - this.Width / 2, locationInPanel.Y - this.Height / 2);
            VurmaPos = _vurmaPos;
        }
    }
}
