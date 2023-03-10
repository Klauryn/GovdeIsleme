using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp.Pages.Production.usercontrols.DelikUserController
{
    public partial class uc_AnaBosaltmaUst : UserControl
    {
        public uc_AnaBosaltmaUst(Point locationInPanel)
        {
            InitializeComponent();
            this.Location = new Point(locationInPanel.X - this.Width / 2, locationInPanel.Y - this.Height / 2);
        }
    }
}
