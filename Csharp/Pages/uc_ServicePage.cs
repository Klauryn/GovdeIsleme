using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Csharp.Ios;

namespace Csharp.Pages
{
    public partial class uc_ServicePage : UserControl
    {
        public uc_ServicePage()
        {
            InitializeComponent();
        }

        private void uc_ServicePage_Load(object sender, EventArgs e)
        {
            //label2.Text = IO.Bits.sıfır.ToString();
            //label3.Text = IO.Words.sıfır.ToString();
            //label4.Text = IO.Floats.sıfır.ToString();


            //label5.Text = IO.Bits.ikiyüzellibeş.ToString();
            //label6.Text = IO.Words.yüzyirmiyedi.ToString();
            //label7.Text = IO.Floats.otuzbir.ToString();

            //IO.Bits.Write_sıfır(true);
            //IO.Bits.Write_ikiyüzellibeş(true);
            //IO.Words.Write_sıfır(32);
            //IO.Words.Write_yüzyirmiyedi(32);
            //IO.Floats.Write_sıfır(Convert.ToSingle(32.32));
            //IO.Floats.Write_otuzbir(Convert.ToSingle(32.32));

        }

        private void rectangleShape5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
