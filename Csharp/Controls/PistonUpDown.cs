using Csharp.Ios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Csharp.Pages.JogPage.uc_JogPage;

namespace Csharp.Controls
{
    public partial class PistonUpDown : UserControl
    {
        public string titleText { get; set; }
        public string variableNameText { get; set; }

        string btnName;
        public PistonUpDown()
        {
            InitializeComponent();
        }
        private void PistonUpDown_Load(object sender, EventArgs e)
        {
            lbl_Title.Text = titleText;

            Sensor_Piston_Extend.Visible = false;
            Sensor_Piston_Retract.Visible = false;
        }

        private void btn_Piston_Extend_Click(object sender, EventArgs e)
        {
            ButtonFunctionalities("_Extend");
        }

        private void btn_Piston_Retract_Click(object sender, EventArgs e)
        {
            ButtonFunctionalities("_Retract");
        }

        private void ButtonFunctionalities(string modePiston)
        {
            btnName = "Piston_" + variableNameText + modePiston;
            ushort number = (ushort)((eJogTab_ID)Enum.Parse(typeof(eJogTab_ID), btnName));

            IO.Words.Write_JogReq_ID_TabButton(number);
            IO.Bits.JogReq_TabButton.Value = true;
        }
    }
}
