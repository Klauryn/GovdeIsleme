using Csharp.Pages.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp.Pages.MachinePars
{
    public partial class Frm_MachinePars_Login : Form
    {
        static Frm_MachinePars_Login newLogin;
        static int loginResult;
        public Frm_MachinePars_Login()
        {
            InitializeComponent();
            tb_Password.PasswordChar = '*';
            tb_Password.MaxLength = 4;
        }
        public static int ShowLogin()
        {
            newLogin = new Frm_MachinePars_Login();
            newLogin.ShowDialog();
            return loginResult;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            loginResult = 2; //Failed 
            newLogin.Dispose();
        }

        private void btn_Accept_Click(object sender, EventArgs e)
        {
            if(tb_Password.Text == "2021")
            {
                loginResult = 1; //Success
                newLogin.Dispose();
            }
            else { MyMessageBox.ShowMessageBox("Hatalı şifre girdiniz!"); tb_Password.Text = ""; }
        }

        private void tb_Password_MouseDown(object sender, MouseEventArgs e)
        {
            double dNumPadResult = MyNumPad.ShowNumPad_Password(MousePosition.X - 100, MousePosition.Y + 25);
            if (dNumPadResult != 999999)
                tb_Password.Text = dNumPadResult.ToString();
        }

        private void tb_Password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
