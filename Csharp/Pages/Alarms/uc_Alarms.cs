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

namespace Csharp.Pages.Alarms
{
    public partial class uc_Alarms : UserControl
    {
        public uc_Alarms()
        {
            InitializeComponent();
            flowLayoutPanel_1.Controls.Clear();
        }
        private void uc_StartCondPage_Load(object sender, EventArgs e)
        {
            DisplayAlarms();
            timer1.Enabled = true;
        }

        uc_alarm Alarm0 = new uc_alarm("Acil stop butonuna basildi.");
        uc_alarm Alarm1 = new uc_alarm("Cycle da iken manuel moda geçildi.");
        uc_alarm Alarm2 = new uc_alarm("Stop butonuna basıldı.");
        uc_alarm Alarm3 = new uc_alarm("Ekrandan durdur butonuna basıldı.");
        uc_alarm Alarm4 = new uc_alarm("Modbus haberleşmesi kurulamadı.");
        uc_alarm Alarm5 = new uc_alarm("Açılacak delikler konumlandırılamadı.");
        uc_alarm Alarm6 = new uc_alarm("Modbus haberleşme hatası mevcuttur.(1)");
        uc_alarm Alarm7 = new uc_alarm("Modbus haberleşme hatası mevcuttur.(2)");
        uc_alarm Alarm8 = new uc_alarm("Modbus haberleşme hatası mevcuttur.(3)");
        uc_alarm Alarm9 = new uc_alarm("Modbus haberleşme hatası mevcuttur.(4)");
        uc_alarm Alarm10 = new uc_alarm("Modbus haberleşme hatası mevcuttur.(5)");
        uc_alarm Alarm11 = new uc_alarm("Parca Sürme Servosu Torque Limit Hatası.");
        uc_alarm Alarm12 = new uc_alarm("Alarm12");
        uc_alarm Alarm13 = new uc_alarm("Alarm13");
        uc_alarm Alarm14 = new uc_alarm("Alarm14");
        uc_alarm Alarm15 = new uc_alarm("Alarm15");
        uc_alarm Alarm16 = new uc_alarm("Alarm16");
        uc_alarm Alarm17 = new uc_alarm("Alarm17");
        uc_alarm Alarm18 = new uc_alarm("Alarm18");
        uc_alarm Alarm19 = new uc_alarm("Alarm19");
        uc_alarm Alarm20 = new uc_alarm("Alarm20");
        private void DisplayAlarms()
        {
            //0
            if (IO.Bits.Is_OnAlarm0 == true && flowLayoutPanel_1.Controls.Contains(Alarm0)==false)
            {
                flowLayoutPanel_1.Controls.Add(Alarm0);
            }
            else if(IO.Bits.Is_OnAlarm0 == false) { flowLayoutPanel_1.Controls.Remove(Alarm0); }
            //1
            if (IO.Bits.Is_OnAlarm1 == true && flowLayoutPanel_1.Controls.Contains(Alarm1) == false)
            {
                flowLayoutPanel_1.Controls.Add(Alarm1);
            }
            else if (IO.Bits.Is_OnAlarm1 == false) { flowLayoutPanel_1.Controls.Remove(Alarm1); }
            //2
            if (IO.Bits.Is_OnAlarm2 == true && flowLayoutPanel_1.Controls.Contains(Alarm2) == false)
            {
                flowLayoutPanel_1.Controls.Add(Alarm2);
            }
            else if (IO.Bits.Is_OnAlarm2 == false) { flowLayoutPanel_1.Controls.Remove(Alarm2); }
            //3
            if (IO.Bits.Is_OnAlarm3 == true && flowLayoutPanel_1.Controls.Contains(Alarm3) == false)
            {
                flowLayoutPanel_1.Controls.Add(Alarm3);
            }
            else if (IO.Bits.Is_OnAlarm3 == false) { flowLayoutPanel_1.Controls.Remove(Alarm3); }
            //4
            if (IO.Bits.Is_OnAlarm4 == true && flowLayoutPanel_1.Controls.Contains(Alarm4) == false)
            {
                flowLayoutPanel_1.Controls.Add(Alarm4);
            }
            else if (IO.Bits.Is_OnAlarm4 == false) { flowLayoutPanel_1.Controls.Remove(Alarm4); }
            //5
            if (IO.Bits.Is_OnAlarm5 == true && flowLayoutPanel_1.Controls.Contains(Alarm5) == false)
            {
                flowLayoutPanel_1.Controls.Add(Alarm5);
            }
            else if (IO.Bits.Is_OnAlarm5 == false) { flowLayoutPanel_1.Controls.Remove(Alarm5); }
            //6
            if (IO.Bits.Is_OnAlarm6 == true && flowLayoutPanel_1.Controls.Contains(Alarm6) == false)
            {
                flowLayoutPanel_1.Controls.Add(Alarm6);
            }
            else if (IO.Bits.Is_OnAlarm6 == false) { flowLayoutPanel_1.Controls.Remove(Alarm6); }
            //7
            if (IO.Bits.Is_OnAlarm7 == true && flowLayoutPanel_1.Controls.Contains(Alarm7) == false)
            {
                flowLayoutPanel_1.Controls.Add(Alarm7);
            }
            else if (IO.Bits.Is_OnAlarm7 == false) { flowLayoutPanel_1.Controls.Remove(Alarm7); }
            //8
            if (IO.Bits.Is_OnAlarm8 == true && flowLayoutPanel_1.Controls.Contains(Alarm8) == false)
            {
                flowLayoutPanel_1.Controls.Add(Alarm8);
            }
            else if (IO.Bits.Is_OnAlarm8 == false) { flowLayoutPanel_1.Controls.Remove(Alarm8); }
            //9
            if (IO.Bits.Is_OnAlarm9 == true && flowLayoutPanel_1.Controls.Contains(Alarm9) == false)
            {
                flowLayoutPanel_1.Controls.Add(Alarm9);
            }
            else if (IO.Bits.Is_OnAlarm9 == false) { flowLayoutPanel_1.Controls.Remove(Alarm9); }
            //10
            if (IO.Bits.Is_OnAlarm10 == true && flowLayoutPanel_1.Controls.Contains(Alarm10) == false)
            {
                flowLayoutPanel_1.Controls.Add(Alarm10);
            }
            else if (IO.Bits.Is_OnAlarm10 == false) { flowLayoutPanel_1.Controls.Remove(Alarm10); }
            //11
            if (IO.Bits.Is_OnAlarm11 == true && flowLayoutPanel_1.Controls.Contains(Alarm11) == false)
            {
                flowLayoutPanel_1.Controls.Add(Alarm11);
            }
            else if (IO.Bits.Is_OnAlarm11 == false) { flowLayoutPanel_1.Controls.Remove(Alarm11); }
            //12
            if (IO.Bits.Is_OnAlarm12 == true && flowLayoutPanel_1.Controls.Contains(Alarm12) == false)
            {
                flowLayoutPanel_1.Controls.Add(Alarm12);
            }
            else if (IO.Bits.Is_OnAlarm12 == false) { flowLayoutPanel_1.Controls.Remove(Alarm12); }
            //13
            if (IO.Bits.Is_OnAlarm13 == true && flowLayoutPanel_1.Controls.Contains(Alarm13) == false)
            {
                flowLayoutPanel_1.Controls.Add(Alarm13);
            }
            else if (IO.Bits.Is_OnAlarm13 == false) { flowLayoutPanel_1.Controls.Remove(Alarm13); }
            //14
            if (IO.Bits.Is_OnAlarm14 == true && flowLayoutPanel_1.Controls.Contains(Alarm14) == false)
            {
                flowLayoutPanel_1.Controls.Add(Alarm14);
            }
            else if (IO.Bits.Is_OnAlarm14 == false) { flowLayoutPanel_1.Controls.Remove(Alarm14); }
            //15
            if (IO.Bits.Is_OnAlarm15 == true && flowLayoutPanel_1.Controls.Contains(Alarm15) == false)
            {
                flowLayoutPanel_1.Controls.Add(Alarm15);
            }
            else if (IO.Bits.Is_OnAlarm15 == false) { flowLayoutPanel_1.Controls.Remove(Alarm15); }
            //16
            if (IO.Bits.Is_OnAlarm16 == true && flowLayoutPanel_1.Controls.Contains(Alarm16) == false)
            {
                flowLayoutPanel_1.Controls.Add(Alarm16);
            }
            else if (IO.Bits.Is_OnAlarm16 == false) { flowLayoutPanel_1.Controls.Remove(Alarm16); }
            //17
            if (IO.Bits.Is_OnAlarm17 == true && flowLayoutPanel_1.Controls.Contains(Alarm17) == false)
            {
                flowLayoutPanel_1.Controls.Add(Alarm17);
            }
            else if (IO.Bits.Is_OnAlarm17 == false) { flowLayoutPanel_1.Controls.Remove(Alarm17); }
            //18
            if (IO.Bits.Is_OnAlarm18 == true && flowLayoutPanel_1.Controls.Contains(Alarm18) == false)
            {
                flowLayoutPanel_1.Controls.Add(Alarm18);
            }
            else if (IO.Bits.Is_OnAlarm18 == false) { flowLayoutPanel_1.Controls.Remove(Alarm18); }
            //19
            if (IO.Bits.Is_OnAlarm19 == true && flowLayoutPanel_1.Controls.Contains(Alarm19) == false)
            {
                flowLayoutPanel_1.Controls.Add(Alarm19);
            }
            else if (IO.Bits.Is_OnAlarm19 == false) { flowLayoutPanel_1.Controls.Remove(Alarm19); }
            //20
            if (IO.Bits.Is_OnAlarm20 == true && flowLayoutPanel_1.Controls.Contains(Alarm20) == false)
            {
                flowLayoutPanel_1.Controls.Add(Alarm20);
            }
            else if (IO.Bits.Is_OnAlarm20 == false) { flowLayoutPanel_1.Controls.Remove(Alarm20); }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            DisplayAlarms();
        }
    }
}