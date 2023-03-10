using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp.Pages.General
{
    public partial class MyNumPad : Form
    {
        static string sNum;
        int maxLenght = 7;
        static MyNumPad mynumpad;
        static double numpadResult;
        public MyNumPad(bool IsPassword)
        {
            InitializeComponent();
            sNum = null;
            if (IsPassword)
            {
                tb_num.PasswordChar = '*';
                tb_num.MaxLength = 4;
            }
        }
        public static double ShowNumPad(int X,int Y)
        {
            mynumpad = new MyNumPad(false);
            var point = new Point(X, Y);
            mynumpad.Location = point;
            mynumpad.ShowDialog();
            return numpadResult;
        }
        public static double ShowNumPad_Password(int X, int Y)
        {
            mynumpad = new MyNumPad(true);
            var point = new Point(X, Y);
            mynumpad.Location = point;
            mynumpad.ShowDialog();
            return numpadResult;
        }

        private void roundedButton_7_Click(object sender, EventArgs e)
        {
            if (sNum?.Length < maxLenght || sNum==null)
                sNum = sNum + "7";
            tb_num.Text = sNum;
        }

        private void roundedButton_8_Click(object sender, EventArgs e)
        {
            if (sNum?.Length < maxLenght || sNum == null)
                sNum = sNum + "8";
            tb_num.Text = sNum;
        }

        private void roundedButton_9_Click(object sender, EventArgs e)
        {
            if (sNum?.Length < maxLenght || sNum == null)
                sNum = sNum + "9";
            tb_num.Text = sNum;
        }

        private void roundedButton_4_Click(object sender, EventArgs e)
        {
            if (sNum?.Length < maxLenght || sNum == null)
                sNum = sNum + "4";
            tb_num.Text = sNum;
        }

        private void roundedButton_5_Click(object sender, EventArgs e)
        {
            if (sNum?.Length < maxLenght || sNum == null)
                sNum = sNum + "5";
            tb_num.Text = sNum;
        }

        private void roundedButton_6_Click(object sender, EventArgs e)
        {
            if (sNum?.Length < maxLenght || sNum == null)
                sNum = sNum + "6";
            tb_num.Text = sNum;
        }

        private void roundedButton_3_Click(object sender, EventArgs e)
        {
            if (sNum?.Length < maxLenght || sNum == null)
                sNum = sNum + "3";
            tb_num.Text = sNum;
        }

        private void roundedButton_2_Click(object sender, EventArgs e)
        {
            if (sNum?.Length < maxLenght || sNum == null)
                sNum = sNum + "2";
            tb_num.Text = sNum;
        }

        private void roundedButton_1_Click(object sender, EventArgs e)
        {
            if (sNum?.Length < maxLenght || sNum == null)
                sNum = sNum + "1";
            tb_num.Text = sNum;
        }
        private void roundedButton_0_Click(object sender, EventArgs e)
        {
            if (sNum?.Length < maxLenght || sNum == null)
                sNum = sNum + "0";
            tb_num.Text = sNum;
        }

        private void roundedButton_dot_Click(object sender, EventArgs e)
        {
            try
            {
                if (sNum.Contains("."))
                {
                    ;
                }
                else
                {
                    if (sNum?.Length < maxLenght - 1 || sNum == null)
                        sNum = sNum + ".";
                    tb_num.Text = sNum;
                }
            }
            catch (Exception)
            {

                ;
            }
            
        }

        private void btn_backspace_Click(object sender, EventArgs e)
        {
            if(sNum?.Length!=0 && sNum != null)
                sNum = sNum.Substring(0, sNum.Length - 1);
            tb_num.Text = sNum;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            sNum = "";
            tb_num.Text = sNum;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (sNum?.Length != 0 && sNum != null)
            {
                //sNum = sNum.Replace(".", ",");
                numpadResult=Convert.ToDouble(sNum, System.Globalization.CultureInfo.InvariantCulture);
                //double.Parse(sNum, CultureInfo.InvariantCulture).ToString();
                //numpadResult = Convert.toDouble(sNum);
            }
            else
                numpadResult = 999999;
            this.Dispose();
        }


    }
}
