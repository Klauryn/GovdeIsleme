using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp.Pages.Alarms
{
    public partial class uc_alarm : UserControl
    {
        public uc_alarm(string text)
        {
            InitializeComponent();
            TextProperty = text;
        }
        private string _text;

        [Category("Custom Props")]
        public string TextProperty
        {
            get { return _text; }
            set { _text = value; tb_Text.Text = value; }
        }

        private void rectangleShape1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
