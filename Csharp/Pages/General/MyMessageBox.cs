using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp.Pages.General
{
    public partial class MyMessageBox : Form
    {
        static MyMessageBox newMessageBox;
        static int buttonResult;
        public MyMessageBox()
        {
            InitializeComponent();
        }
        public static int ShowMessageBox(string sMsg)
        {
            newMessageBox = new MyMessageBox();
            newMessageBox.label_msg.Text = sMsg;
            newMessageBox.label_tittle.Text = "Uyarı!"; // Default Title
            newMessageBox.ShowDialog();
            return buttonResult;
        }
        public static int ShowMessageBox(string sMsg,bool IsOkCancel)
        {
            newMessageBox = new MyMessageBox();
            newMessageBox.label_msg.Text = sMsg;
            newMessageBox.label_tittle.Text = "Uyarı!"; // Default Title
            newMessageBox.btn_Ok.Visible = false;
            newMessageBox.btn_Accept.Visible = true;
            newMessageBox.btn_Cancel.Visible = true;
            newMessageBox.ShowDialog();
            return buttonResult;
        }
        public static int ShowMessageBox(string sMsg, int rastgeleDegerVer)
        {
            newMessageBox = new MyMessageBox();
            newMessageBox.label_msg.Text = sMsg;
            newMessageBox.label_tittle.Text = "Uyarı!"; // Default Title
            newMessageBox.btn_Ok.Text = "Değiştirdim";
            newMessageBox.ShowDialog();
            return buttonResult;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            buttonResult = 100;
            newMessageBox.Dispose();
        }

        private void btn_Accept_Click(object sender, EventArgs e)
        {
            buttonResult = 100;
            newMessageBox.Dispose();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            buttonResult = 2;
            newMessageBox.Dispose();
        }
    }
}
