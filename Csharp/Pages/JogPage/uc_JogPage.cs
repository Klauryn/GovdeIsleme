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
using Csharp.Pages.General;
using Csharp.Controls;

namespace Csharp.Pages.JogPage
{
    public partial class uc_JogPage : UserControl
    {
        public enum eJogTab_ID
        {
            Hidrolik_Cap7Sol_Asagi = 1,
            Hidrolik_Cap7Sol_Yukari,
            Hidrolik_Cap7Sol_AsagiYukari,
            Hidrolik_Cap7Sag_Asagi,
            Hidrolik_Cap7Sag_Yukari,
            Hidrolik_Cap7Sag_AsagiYukari,
            Hidrolik_BasTakoz_Pimleri_Asagi,
            Hidrolik_BasTakoz_Pimleri_Yukari,
            Hidrolik_BasTakoz_Pimleri_AsagiYukari,
            Hidrolik_11x20_Slot_Asagi,
            Hidrolik_11x20_Slot_Yukari,
            Hidrolik_11x20_Slot_AsagiYukari,
            Hidrolik_ManivelaDeligi_Asagi,
            Hidrolik_ManivelaDeligi_Yukari,
            Hidrolik_ManivelaDeligi_AsagiYukari,
            Hidrolik_4Iletken_AnaBosaltma_Asagi,
            Hidrolik_4Iletken_AnaBosaltma_Yukari,
            Hidrolik_4Iletken_AnaBosaltma_AsagiYukari,
            Piston_AnaBosaltma_Tutucu_Ileri,
            Piston_AnaBosaltma_Tutucu_Geri,
            Hidrolik_IlaveBosaltma_1_Asagi,
            Hidrolik_IlaveBosaltma_1_Yukari,
            Hidrolik_IlaveBosaltma_1_AsagiYukari,
            Hidrolik_IlaveBosaltma_2_Asagi,
            Hidrolik_IlaveBosaltma_2_Yukari,
            Hidrolik_IlaveBosaltma_2_AsagiYukari,
            Hidrolik_BoyKesme_1_Ileri,
            Hidrolik_BoyKesme_1_Geri,
            Hidrolik_BoyKesme_1_IleriGeri,
            Hidrolik_BoyKesme_2_Ileri,
            Hidrolik_BoyKesme_2_Geri,
            Hidrolik_BoyKesme_2_IleriGeri,
            TahliyeKonveyoru_Run,
            TahliyeKonveyoru_Stop,
            Servo_ParcaSurme_PowerOnReq,
            Servo_ParcaSurme_PowerOffReq,
            Servo_ParcaSurme_HomingReq,
            Servo_ParcaSurme_GoPose,
            Servo_SagAyar_PowerOnReq,
            Servo_SagAyar_PowerOffReq,
            Servo_SagAyar_HomingReq,
            Servo_SagAyar_GoPose,
            Servo_SolAyar_PowerOnReq,
            Servo_SolAyar_PowerOffReq,
            Servo_SolAyar_HomingReq,
            Servo_SolAyar_GoPose,
            Piston_Gripper_Clamp,
            Piston_Gripper_UnClamp,
            Hidrolik_BoyKesme_12_Ileri,
            Hidrolik_BoyKesme_12_Geri,
            Hidrolik_BoyKesme_12_IleriGeri,
            HidrolikMotor_Run,
            HidrolikMotor_Stop,
            All_Servo_HomingReq,
            Piston_AnaBosaltmaManivela_Extend,
            Piston_AnaBosaltmaManivela_Retract,
            Piston_ParcaSabitleme_Extend,
            Piston_ParcaSabitleme_Retract,
        }
        public enum eJogContinuous_ID
        {
            Servo_ParcaSurme_Geri = 1,
            Servo_ParcaSurme_Ileri,
            Servo_SagAyar_Geri,
            Servo_SagAyar_Ileri,
            Servo_SolAyar_Geri,
            Servo_SolAyar_Ileri,
        }
        public uc_JogPage()
        {
            InitializeComponent();
            pistonUpDown2.titleText = "AnaBoşaltma Manivelası";
            pistonUpDown2.variableNameText = "AnaBosaltmaManivela";
            pistonUpDown2.lbl_first.Text = "Yukarı";
            pistonUpDown2.lbl_second.Text = "Aşağı";
            pistonUpDown1.titleText = "Parça Sabitleme Pistonu";
            pistonUpDown1.variableNameText = "ParcaSabitleme";
            pistonUpDown1.lbl_first.Text = "Yukarı";
            pistonUpDown1.lbl_second.Text = "Aşağı";
        }

        private void uc_JogPage_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            if (IO.Bits.WorkingModeAuto)
            {
                label_warning.Visible = true;
                //tableLayoutPanel_main.Enabled = false;
                page_Profilİsleme.Enabled = false;
                page_ServoMotorlar.Enabled = false;
            }
            else { label_warning.Visible = false; tableLayoutPanel_main.Enabled = true; }

            for (int i = 0; i < TabControl_Jog.TabPages.Count; i++)
            {
                TabColors.Add(TabControl_Jog.TabPages[i], Color.AliceBlue);
            }
            SetTabHeader(TabControl_Jog.TabPages[0], Color.LightBlue);
            #region[Sensors]
            Sensor_11x70_Asagida.Visible = false;
            Sensor_11x70_Yukarida.Visible = false;
            Sensor_AnaBosaltmaTutucu_Geride.Visible = false;
            Sensor_AnaBosaltmaTutucu_Ileride.Visible = false;
            Sensor_AnaBosaltma_Asagida.Visible = false;
            Sensor_AnaBosaltma_Yukarida.Visible = false;
            Sensor_BasTakoz_Asagida.Visible = false;
            Sensor_BasTakoz_Yukarida.Visible = false;
            Sensor_Bicak1_Geride.Visible = false;
            Sensor_Bicak1_Ileride.Visible = false;
            Sensor_Bicak2_Geride.Visible = false;
            Sensor_Bicak2_Ileride.Visible = false;
            Sensor_Cap7Sag_Asagida.Visible = false;
            Sensor_Cap7Sag_Yukarida.Visible = false;
            Sensor_Cap7Sol_Asagida.Visible = false;
            Sensor_Cap7Sol_Yukarida.Visible = false;
            Sensor_IlaveBosaltma_1_Asagida.Visible = false;
            Sensor_IlaveBosaltma_1_Yukarida.Visible = false;
            Sensor_IlaveBosaltma_2_Asagida.Visible = false;
            Sensor_IlaveBosaltma_2_Yukarida.Visible = false;
            Sensor_ManivelaDeligi_Asagida.Visible = false;
            Sensor_ManivelaDeligi_Yukarida.Visible = false;
            Sensor_ParcaSurme_Home.Visible = false;
            Sensor_ParcaSurme_Neg.Visible = false;
            Sensor_ParcaSurme_Pos.Visible = false;
            #endregion
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region[Sensor]
            Sensor_11x70_Asagida.Visible = IO.Bits.Sensor11_Hidrolik_11x20_SlotAsagida;
            Sensor_11x70_Yukarida.Visible = IO.Bits.Sensor12_Hidrolik_11x20_SlotYukarıda;
            Sensor_AnaBosaltmaTutucu_Geride.Visible = IO.Bits.Sensor21_Piston_AnaBosaltma_Aktif_2_Geride && IO.Bits.Sensor19_Piston_AnaBosaltma_Aktif_1_Geride;
            Sensor_AnaBosaltmaTutucu_Ileride.Visible = IO.Bits.Sensor20_Piston_AnaBosaltma_Aktif_2_Ileride && IO.Bits.Sensor20_Piston_AnaBosaltma_Aktif_2_Ileride;
            Sensor_AnaBosaltma_Asagida.Visible = IO.Bits.Sensor16_Hidrolik_4Iletken_AnaBosaltma_Asagida;
            Sensor_AnaBosaltma_Yukarida.Visible = IO.Bits.Sensor17_Hidrolik_4Iletken_AnaBosaltma_Yukarida;
            Sensor_BasTakoz_Asagida.Visible = IO.Bits.Sensor9_Hidrolik_BasTakozPimleri_Extended;
            Sensor_BasTakoz_Yukarida.Visible = IO.Bits.Sensor10_Hidrolik_BasTakozPimleri_Retracted;
            Sensor_Bicak1_Geride.Visible = IO.Bits.Sensor27_Hidrolik_BoyKesme_1_Yukarida;
            Sensor_Bicak1_Ileride.Visible = IO.Bits.Sensor26_Hidrolik_BoyKesme_1_Asagida;
            Sensor_Bicak2_Geride.Visible = IO.Bits.Sensor29_Hidrolik_BoyKesme_2_Yukarida;
            Sensor_Bicak2_Ileride.Visible = IO.Bits.Sensor28_Hidrolik_BoyKesme_2_Asagida;
            Sensor_Cap7Sag_Asagida.Visible = IO.Bits.Sensor8_Hidrolik_Cap7_Sag_Extended;
            Sensor_Cap7Sag_Yukarida.Visible = IO.Bits.Sensor7_Hidrolik_Cap7_Sag_Retracted;
            Sensor_Cap7Sol_Asagida.Visible = IO.Bits.Sensor6_Hidrolik_Cap7_Sol_Extended;
            Sensor_Cap7Sol_Yukarida.Visible = IO.Bits.Sensor5_Hidrolik_Cap7_Sol_Retracted;
            Sensor_IlaveBosaltma_1_Asagida.Visible = IO.Bits.Sensor22_Hidrolik_4Bucuk_5_IlaveBosaltma_1_Asagida;
            Sensor_IlaveBosaltma_1_Yukarida.Visible = IO.Bits.Sensor23_Hidrolik_4Bucuk_5_IlaveBosaltma_1_Yukarida;
            Sensor_IlaveBosaltma_2_Asagida.Visible = IO.Bits.Sensor24_Hidrolik_6_IlaveBosaltma_2_Asagida;
            Sensor_IlaveBosaltma_2_Yukarida.Visible = IO.Bits.Sensor25_Hidrolik_6_IlaveBosaltma_2_Yukarida;
            Sensor_ManivelaDeligi_Asagida.Visible = IO.Bits.Sensor13_Hidrolik_Manivela_Deligi_Asagida;
            Sensor_ManivelaDeligi_Yukarida.Visible = IO.Bits.Sensor14_Hidrolik_Manivela_Deligi_Yukarida;
            Sensor_ParcaSurme_Home.Visible = IO.Bits.Sensor1_ServoParcaSurme_Home;
            Sensor_ParcaSurme_Neg.Visible = IO.Bits.Sensor30_ParcaSurme_NegLim;
            Sensor_ParcaSurme_Pos.Visible = IO.Bits.Sensor31_ParcaSurme_PosLim;
            #endregion
            if (IO.Bits.bServoPos)
            {
                IO.Words.Write_JogReq_ID_TabButton((ushort)eJogTab_ID.All_Servo_HomingReq);
            }

            if (IO.Bits.WorkingModeAuto)
            {
                label_warning.Visible = true;
                page_Profilİsleme.Enabled = false;
                page_ServoMotorlar.Enabled = false;
            }
            else
            {
                label_warning.Visible = false;
                page_Profilİsleme.Enabled = true;
                page_ServoMotorlar.Enabled = true;
            }

            tb_ParcaSurmeAktuelPos.Text = Math.Round(IO.Floats.ParcaSurme_AktuelPosition, 2).ToString();
            tb_ParcaSurmeAktuelVel.Text = Math.Round(IO.Floats.ParcaSurme_AktuelVelocity, 2).ToString();
            tb_SolKalipAktuelPos.Text = Math.Round(IO.Floats.SolKalipAyar_AktuelPosition, 2).ToString();
            tb_SolKalipAktuelVel.Text = Math.Round(IO.Floats.SolKalipAyar_AktuelVelocity, 2).ToString();
            tb_SagKalipAktuelPos.Text = Math.Round(IO.Floats.SagKalipAyar_AktuelPosition, 2).ToString();
            tb_SagKalipAktuelVel.Text = Math.Round(IO.Floats.SagKalipAyar_AktuelVelocity, 2).ToString();

            
        }

        private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();
        private void SetTabHeader(TabPage page, Color color)
        {
            TabColors[page] = color;
            TabControl_Jog.Invalidate();
        }
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                using (Brush br = new SolidBrush(TabColors[TabControl_Jog.TabPages[e.Index]]))
                {
                    e.Graphics.FillRectangle(br, e.Bounds);
                    SizeF sz = e.Graphics.MeasureString(TabControl_Jog.TabPages[e.Index].Text, e.Font);
                    e.Graphics.DrawString(TabControl_Jog.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + (e.Bounds.Width - sz.Width) / 2, e.Bounds.Top + (e.Bounds.Height - sz.Height) / 2 + 1);

                    Rectangle rect = e.Bounds;
                    rect.Offset(0, 1);
                    rect.Inflate(0, -1);
                    e.Graphics.DrawRectangle(Pens.DarkGray, rect);
                    e.DrawFocusRectangle();

                }
            }
            catch (Exception)
            {
                ;
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            for (int i = 0; i < TabControl_Jog.TabPages.Count; i++)
            {
                SetTabHeader(TabControl_Jog.TabPages[i], Color.AliceBlue);
            }
            SetTabHeader(TabControl_Jog.SelectedTab, Color.LightBlue);

        }

        private void tb_ParcaSurmeGoPos_MouseDown(object sender, MouseEventArgs e)
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
                //tb_IticiServoGoPos.Text = dNumPadResult.ToString();
                tb_ParcaSurmeGoPos.Text = dNumPadResult.ToString();
                IO.Floats.Write_ParcaSurme_HedefPos(Convert.ToSingle(dNumPadResult));
            }
        }
        private void tb_SagKalipGoPos_MouseDown(object sender, MouseEventArgs e)
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
                //tb_IticiServoGoPos.Text = dNumPadResult.ToString();
                tb_SagKalipGoPos.Text = dNumPadResult.ToString();
                IO.Floats.Write_SagKalipAyar_HedefPos(Convert.ToSingle(dNumPadResult));
            }
        }
        private void tb_SolKalipGoPos_MouseDown(object sender, MouseEventArgs e)
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
                //tb_IticiServoGoPos.Text = dNumPadResult.ToString();
                tb_SolKalipGoPos.Text = dNumPadResult.ToString();
                IO.Floats.Write_SolKalipAyar_HedefPos(Convert.ToSingle(dNumPadResult));
            }
        }
    }
}
