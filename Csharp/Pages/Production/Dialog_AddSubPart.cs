using Csharp.Pages.General;
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

namespace Csharp.Pages.Production
{
    public partial class Dialog_AddSubPart : Form
    {
        public Dialog_AddSubPart()
        {
            InitializeComponent();
        }

        static Dialog_AddSubPart dialog;
        static Tuple<string, string, double, string, string, Tuple<double,double,double,double,double,double>> Result; //Tip,İletkenSayısı,Boy,BoşaltmaTip,BoşaltmaSayısı,p1,p2,p3,p4,p5,p6
        static string selectedTip, selectedIletkenSayisi, selectedBosaltmaTip, selectedBosaltmaSayisi;
        static double selectedBoy, selectedp1, selectedp2, selectedp3, selectedp4, selectedp5, selectedp6;

        public static Tuple<string, string, double, string, string, Tuple<double, double, double, double, double, double>> MyShow() //Tuple<string, double, double, string, int, bool, bool> MyShow()
        {
            dialog = new Dialog_AddSubPart();
            dialog.ShowDialog();
            return new Tuple<string, string, double, string, string,Tuple <double, double, double, double, double, double>>
                (selectedTip, selectedIletkenSayisi, selectedBoy, selectedBosaltmaTip, selectedBosaltmaSayisi,Tuple.Create(selectedp1,selectedp2,selectedp3,selectedp4,selectedp5,selectedp6));
        }

        private void Dialog_AddSubPart_Load(object sender, EventArgs e)
        {
            gB_BosaltmaTipi.Visible = false;
            gB_BosaltmaSayisi.Visible = false;
            tlp_pencerekonum.Visible = false;
        }

        private void cb_Tip_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTip = cb_Tip.SelectedItem.ToString();
            double dBoy = tb_Boy.Text!="" ? Convert.ToDouble(tb_Boy.Text) : 0;      

            //Boşaltmalar Visible/Invisible
            if (cb_Tip.SelectedIndex == 1)
            {
                gB_BosaltmaTipi.Visible = true;
                gB_BosaltmaSayisi.Visible = true;
            }
            else
            {
                tlp_pencerekonum.Visible = false;
                gB_BosaltmaTipi.Visible = false;
                gB_BosaltmaSayisi.Visible = false;
            }
        }
        private void cb_BosaltmaTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedBosaltmaTip = cb_BosaltmaTip.SelectedItem.ToString();
        }

        private void cb_IletkenSayisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIletkenSayisi = cb_IletkenSayisi.SelectedItem.ToString();
        }

        private void tb_Boy_MouseUp(object sender, MouseEventArgs e)
        {
            //NumPad ekrana sığmaz ise sığdıralım.
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            int MouseXPos = MousePosition.X - 100;
            int MouseYPos = MousePosition.Y + 25;
            while (MouseXPos > resolution.Width - 382)
            {
                MouseXPos = MouseXPos - 1;
            }
            while (MouseYPos > resolution.Height - 335)
            {
                MouseYPos = MouseYPos - 1;
            }
            double dNumPadResult = MyNumPad.ShowNumPad(MouseXPos, MouseYPos);
            if (dNumPadResult != 999999)
            {
                if (dNumPadResult > 3001)
                {
                    MyMessageBox.ShowMessageBox("Boy 3001'den büyük olamaz!");
                }
                else
                {
                    tb_Boy.Text = dNumPadResult.ToString();
                }
            }
        }

        private void tb_Boy_TextChanged(object sender, EventArgs e)
        {
            string foo = tb_Boy.Text;
            double.Parse(foo, CultureInfo.InvariantCulture).ToString();
            selectedBoy = Convert.ToDouble(foo);
        }

        private void tb_p1_MouseUp(object sender, MouseEventArgs e)
        {
            //NumPad ekrana sığmaz ise sığdıralım.
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            int MouseXPos = MousePosition.X - 100;
            int MouseYPos = MousePosition.Y + 25;
            while (MouseXPos > resolution.Width - 382)
            {
                MouseXPos = MouseXPos - 1;
            }
            while (MouseYPos > resolution.Height - 335)
            {
                MouseYPos = MouseYPos - 1;
            }
            double dNumPadResult = MyNumPad.ShowNumPad(MouseXPos, MouseYPos);
            if (dNumPadResult != 999999)
            {
                tb_p1.Text = dNumPadResult.ToString();
            }
        }

        private void tb_p2_MouseUp(object sender, MouseEventArgs e)
        {
            //NumPad ekrana sığmaz ise sığdıralım.
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            int MouseXPos = MousePosition.X - 100;
            int MouseYPos = MousePosition.Y + 25;
            while (MouseXPos > resolution.Width - 382)
            {
                MouseXPos = MouseXPos - 1;
            }
            while (MouseYPos > resolution.Height - 335)
            {
                MouseYPos = MouseYPos - 1;
            }
            double dNumPadResult = MyNumPad.ShowNumPad(MouseXPos, MouseYPos);
            if (dNumPadResult != 999999)
            {
                tb_p2.Text = dNumPadResult.ToString();
            }
        }

        private void tb_p3_MouseUp(object sender, MouseEventArgs e)
        {
            //NumPad ekrana sığmaz ise sığdıralım.
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            int MouseXPos = MousePosition.X - 100;
            int MouseYPos = MousePosition.Y + 25;
            while (MouseXPos > resolution.Width - 382)
            {
                MouseXPos = MouseXPos - 1;
            }
            while (MouseYPos > resolution.Height - 335)
            {
                MouseYPos = MouseYPos - 1;
            }
            double dNumPadResult = MyNumPad.ShowNumPad(MouseXPos, MouseYPos);
            if (dNumPadResult != 999999)
            {
                tb_p3.Text = dNumPadResult.ToString();
            }
        }

        private void tb_p4_MouseUp(object sender, MouseEventArgs e)
        {
            //NumPad ekrana sığmaz ise sığdıralım.
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            int MouseXPos = MousePosition.X - 100;
            int MouseYPos = MousePosition.Y + 25;
            while (MouseXPos > resolution.Width - 382)
            {
                MouseXPos = MouseXPos - 1;
            }
            while (MouseYPos > resolution.Height - 335)
            {
                MouseYPos = MouseYPos - 1;
            }
            double dNumPadResult = MyNumPad.ShowNumPad(MouseXPos, MouseYPos);
            if (dNumPadResult != 999999)
            {
                tb_p4.Text = dNumPadResult.ToString();
            }
        }

        private void tb_p5_MouseUp(object sender, MouseEventArgs e)
        {
            //NumPad ekrana sığmaz ise sığdıralım.
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            int MouseXPos = MousePosition.X - 100;
            int MouseYPos = MousePosition.Y + 25;
            while (MouseXPos > resolution.Width - 382)
            {
                MouseXPos = MouseXPos - 1;
            }
            while (MouseYPos > resolution.Height - 335)
            {
                MouseYPos = MouseYPos - 1;
            }
            double dNumPadResult = MyNumPad.ShowNumPad(MouseXPos, MouseYPos);
            if (dNumPadResult != 999999)
            {
                tb_p5.Text = dNumPadResult.ToString();
            }
        }

        private void cb_BosaltmaSayisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedBosaltmaSayisi = cb_BosaltmaSayisi.SelectedItem.ToString();
            tlp_pencerekonum.Visible = true;
            switch (cb_BosaltmaSayisi.SelectedIndex)
            {
                case 0: //1
                    tb_p1.Visible = true;
                    tb_p2.Visible = false;
                    tb_p3.Visible = false;
                    tb_p4.Visible = false;
                    tb_p5.Visible = false;
                    tb_p6.Visible = false;

                    label_p1.Visible = true;
                    label_p2.Visible = false;
                    label_p3.Visible = false;
                    label_p4.Visible = false;
                    label_p5.Visible = false;
                    label_p6.Visible = false;

                    break;

                case 1: //2
                    tb_p1.Visible = true;
                    tb_p2.Visible = true;
                    tb_p3.Visible = false;
                    tb_p4.Visible = false;
                    tb_p5.Visible = false;
                    tb_p6.Visible = false;

                    label_p1.Visible = true;
                    label_p2.Visible = true;
                    label_p3.Visible = false;
                    label_p4.Visible = false;
                    label_p5.Visible = false;
                    label_p6.Visible = false;
                    break;

                case 2: //3
                    tb_p1.Visible = true;
                    tb_p2.Visible = true;
                    tb_p3.Visible = true;
                    tb_p4.Visible = false;
                    tb_p5.Visible = false;
                    tb_p6.Visible = false;

                    label_p1.Visible = true;
                    label_p2.Visible = true;
                    label_p3.Visible = true;
                    label_p4.Visible = false;
                    label_p5.Visible = false;
                    label_p6.Visible = false;
                    break;

                case 3: //4
                    tb_p1.Visible = true;
                    tb_p2.Visible = true;
                    tb_p3.Visible = true;
                    tb_p4.Visible = true;
                    tb_p5.Visible = false;
                    tb_p6.Visible = false;

                    label_p1.Visible = true;
                    label_p2.Visible = true;
                    label_p3.Visible = true;
                    label_p4.Visible = true;
                    label_p5.Visible = false;
                    label_p6.Visible = false;
                    break;

                case 4: //5
                    tb_p1.Visible = true;
                    tb_p2.Visible = true;
                    tb_p3.Visible = true;
                    tb_p4.Visible = true;
                    tb_p5.Visible = true;
                    tb_p6.Visible = false;

                    label_p1.Visible = true;
                    label_p2.Visible = true;
                    label_p3.Visible = true;
                    label_p4.Visible = true;
                    label_p5.Visible = true;
                    label_p6.Visible = false;
                    break;

                case 5: //6
                    tb_p1.Visible = true;
                    tb_p2.Visible = true;
                    tb_p3.Visible = true;
                    tb_p4.Visible = true;
                    tb_p5.Visible = true;
                    tb_p6.Visible = true;

                    label_p1.Visible = true;
                    label_p2.Visible = true;
                    label_p3.Visible = true;
                    label_p4.Visible = true;
                    label_p5.Visible = true;
                    label_p6.Visible = true;
                    break;

                default:
                    break;
            }
        }

        private void tb_p6_MouseUp(object sender, MouseEventArgs e)
        {
            //NumPad ekrana sığmaz ise sığdıralım.
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            int MouseXPos = MousePosition.X - 100;
            int MouseYPos = MousePosition.Y + 25;
            while (MouseXPos > resolution.Width - 382)
            {
                MouseXPos = MouseXPos - 1;
            }
            while (MouseYPos > resolution.Height - 335)
            {
                MouseYPos = MouseYPos - 1;
            }
            double dNumPadResult = MyNumPad.ShowNumPad(MouseXPos, MouseYPos);
            if (dNumPadResult != 999999)
            {
                tb_p6.Text = dNumPadResult.ToString();
            }
        }

        private void btn_Accept_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
