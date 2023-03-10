using Csharp.EventsAggregator;
using Csharp.Ios;
using Csharp.MyLibs;
using Csharp.Pages;
using Csharp.Pages.Alarms;
using Csharp.Pages.DelikFormuller;
using Csharp.Pages.General;
using Csharp.Pages.JogPage;
using Csharp.Pages.MachinePars;
using Csharp.Pages.Production;
using Csharp.Pages.ProductionPage;
using Csharp.Pages.RecipePars;
using Csharp.Pages.Signals;
using Csharp.Pages.StartConditions;
using Csharp.Pages.Warnings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Csharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label_date.Text = DateTime.Now.ToShortDateString();
            label_time.Text = DateTime.Now.ToLongTimeString();
            panel_main.Controls.Clear();
            uc_HomePage homePage = new uc_HomePage();
            homePage.Dock = DockStyle.Fill;
            panel_main.Controls.Add(homePage);
            Modbus.init();
            MonitorMode();
        }
        #region[Open Pages]
        private void btn_HomePage_Click(object sender, EventArgs e)
        {
            panel_main.Controls.Clear();
            uc_HomePage homePage = new uc_HomePage();
            homePage.Dock = DockStyle.Fill;
            panel_main.Controls.Add(homePage);
        }
        private void btn_StartCondPage_Click(object sender, EventArgs e)
        {
            panel_main.Controls.Clear();
            uc_Page_DelikFormuller delikFormulPages = new uc_Page_DelikFormuller();
            delikFormulPages.Dock = DockStyle.Fill;
            panel_main.Controls.Add(delikFormulPages);
        }

        private void btn_JogPage_Click(object sender, EventArgs e)
        {
            panel_main.Controls.Clear();
            uc_JogPage jogPage = new uc_JogPage();
            jogPage.Dock = DockStyle.Fill;
            panel_main.Controls.Add(jogPage);
        }

        private void btn_MachParsPage_Click(object sender, EventArgs e)
        {
            //int iLoginResult = Frm_MachinePars_Login.ShowLogin();
            //if (iLoginResult == 1)
            //{
            panel_main.Controls.Clear();
            uc_MachParsPage MachParsPage = new uc_MachParsPage();
            MachParsPage.Dock = DockStyle.Fill;
            panel_main.Controls.Add(MachParsPage);
            //}
        }
        uc_Production productionManagement;
        uc_Production productionManagementRef;
        private void btn_ProductionManagement_Click(object sender, EventArgs e)
        {
            //panel_main.Controls.Clear();
            //uc_Production productionManagement = new uc_Production();
            //productionManagement.Dock = DockStyle.Fill;
            //panel_main.Controls.Add(productionManagement);

            if (!panel_main.Controls.Contains(productionManagementRef) && productionManagement == null)
            {
                productionManagement = new uc_Production();
            }
            else
            {
                productionManagement = productionManagementRef;
            }
            if (!panel_main.Controls.Contains(productionManagement))
            {
                productionManagementRef = productionManagement;
                panel_main.Controls.Clear();
                productionManagement.Dock = DockStyle.Fill;
                panel_main.Controls.Add(productionManagement);
            }
        }
        private void btn_StationStatusPage_Click(object sender, EventArgs e)
        {
            panel_main.Controls.Clear();
            uc_StationStatusPage StationStatusPage = new uc_StationStatusPage();
            StationStatusPage.Dock = DockStyle.Fill;
            panel_main.Controls.Add(StationStatusPage);
        }

        private void btn_ProductionPage_Click(object sender, EventArgs e)
        {
            panel_main.Controls.Clear();
            uc_ProductionPage ProductionPage = new uc_ProductionPage();
            ProductionPage.Dock = DockStyle.Fill;
            panel_main.Controls.Add(ProductionPage);
        }

        private void btn_SignalsPage_Click(object sender, EventArgs e)
        {
            panel_main.Controls.Clear();
            uc_SignalsPage SignalsPage = new uc_SignalsPage();
            SignalsPage.Dock = DockStyle.Fill;
            panel_main.Controls.Add(SignalsPage);
        }

        private void btnServicePage_Click(object sender, EventArgs e)
        {
            panel_main.Controls.Clear();
            uc_ServicePage ServicePage = new uc_ServicePage();
            ServicePage.Dock = DockStyle.Fill;
            panel_main.Controls.Add(ServicePage);
        }
        private void btnAbout_Click(object sender, EventArgs e)
        {
            panel_main.Controls.Clear();
            uc_AboutPage AboutPage = new uc_AboutPage();
            AboutPage.Dock = DockStyle.Fill;
            panel_main.Controls.Add(AboutPage);
        }
        private void pictureBox_Alarm_Click(object sender, EventArgs e)
        {
            panel_main.Controls.Clear();
            uc_Alarms AlarmsPage = new uc_Alarms();
            AlarmsPage.Dock = DockStyle.Fill;
            panel_main.Controls.Add(AlarmsPage);
        }
        private void pictureBox_StartCond_Click(object sender, EventArgs e)
        {
            panel_main.Controls.Clear();
            uc_StartCondPage StartCondPage = new uc_StartCondPage();
            StartCondPage.Dock = DockStyle.Fill;
            panel_main.Controls.Add(StartCondPage);
        }
        private void pictureBox_Warnings_Click(object sender, EventArgs e)
        {
            panel_main.Controls.Clear();
            uc_Warnings WarningPage = new uc_Warnings();
            WarningPage.Dock = DockStyle.Fill;
            panel_main.Controls.Add(WarningPage);
        }
        #endregion

        //private eChangedStartEvent fooUpdateStartEvent;
        //private eChangedStopEvent fooUpdateStopEvent;

        private RisingEdgeTrigger_Stop fooRisingEdgeTrigger_Stop;
        private RisingEdgeTrigger_Start fooRisingEdgeTrigger_Start;
        private RisingEdgeTrigger_PartIncrement fooRisingEdgeTrigger_PartIncrement;
        private RisingEdgeTrigger_ChangedPart fooRisingEdgeTrigger_ChangedPart;
        private void timer1_Tick(object sender, EventArgs e)
        {
            #region [MachinePars to PLC for States of Yaglama]
            
            //MachinePars_ToPLC.dicMachinePars_Nums[108].Value
            #endregion


            //uc_TekUretimPage.clickStopButton = false;

            TabButtonResetSignals.Reset();
            StopButtonResetSignals.Reset();
            StartButtonResetSignals.Reset();
            //ResetButtonResetSignals.Reset();

            if (MachinePars_ToPLC.dicMachinePars_Bools[3].Value)
            {
                IO.Bits.bKontrolTipAktif.Value = true;
            }
            else { IO.Bits.bKontrolTipAktif.Value = false; }

            if (partInc/*IO.Bits.bPartIncrement*/)
            {
                fooRisingEdgeTrigger_PartIncrement.State = true;
            }
            else { fooRisingEdgeTrigger_PartIncrement.State = false; }

            if (IO.Bits.Lifebit)
            {
                radioBtn_Connection.Checked = true;
            }
            else { radioBtn_Connection.Checked = false; }
            MonitorMode();
            label_date.Text = DateTime.Now.ToShortDateString();
            label_time.Text = DateTime.Now.ToLongTimeString();
            Monitor_Alarm_Warning_StartCond();

            if (IO.Bits.IsStartButton)
            {
                fooRisingEdgeTrigger_Start.State = true;
                //fooUpdateStartEvent = new eChangedStartEvent();
                //fooUpdateStartEvent.EventFired();
            }
            else { fooRisingEdgeTrigger_Start.State = false; }

            if (IO.Bits.IsAlarmExist)
            {
                fooRisingEdgeTrigger_Stop.State = true;
                /*fooUpdateStopEvent = new eChangedStopEvent();
                fooUpdateStopEvent.EventFired();*/
            }
            else { fooRisingEdgeTrigger_Stop.State = false; }

            if (IO.Bits.bChangedPart.Value)
            {
                fooRisingEdgeTrigger_ChangedPart.State = true;
                //fooUpdateStartEvent = new eChangedStartEvent();
                //fooUpdateStartEvent.EventFired();
            }
            else { fooRisingEdgeTrigger_ChangedPart.State = false; }

            var x = Application.OpenForms[0].Controls[0].Controls[3];
            var y = this.panel_main.Controls[0].Controls[0].Controls[1];
            var z = y.Controls.Owner;
            //Kullanıcı üretim sayfasında değilse başlangıç koşulu false
            Control active_form = Application.OpenForms[0].ActiveControl;
            if (active_form.GetType() == typeof(uc_Production) || active_form.Text == "ÜRETİM")
                staticCsharpStdCnd_Ok.StdCond_Ok_1 = true;
            else
                staticCsharpStdCnd_Ok.StdCond_Ok_1 = false;

            if (staticCsharpStdCnd_Ok.StdCond_Ok_1 && staticCsharpStdCnd_Ok.StdCond_Ok_2 && staticCsharpStdCnd_Ok.StdCond_Ok_3 && staticCsharpStdCnd_Ok.StdCond_Ok_4
                && staticCsharpStdCnd_Ok.StdCond_Ok_5 && staticCsharpStdCnd_Ok.StdCond_Ok_6 && staticCsharpStdCnd_Ok.StdCond_Ok_7 && staticCsharpStdCnd_Ok.StdCond_Ok_8
                && staticCsharpStdCnd_Ok.StdCond_Ok_9 && staticCsharpStdCnd_Ok.StdCond_Ok_10)
            {
                IO.Bits.StartConditionOk_ToPLC.Value = true;          //PLC ye başlangıç koşulları OK gönder.
            }
            else
            {
                IO.Bits.StartConditionOk_ToPLC.Value = false;          //PLC ye başlangıç koşulları OK gönder.
            }
            Modbus.ReadModbusServer_Values();
        }
        private void MonitorMode()
        {
            if (IO.Bits.IsCycle)
            {
                panel_cycle.Visible = true;
                panel_stdcondOK.Visible = false;
                panel_stop.Visible = false;
                panel_waiting.Visible = false;
            }
            else if (IO.Bits.IsStartConditionOk)
            {
                panel_cycle.Visible = false;
                panel_stdcondOK.Visible = true;
                panel_stop.Visible = false;
                panel_waiting.Visible = false;
            }
            else if (IO.Bits.IsStop)
            {
                panel_cycle.Visible = false;
                panel_stdcondOK.Visible = false;
                panel_stop.Visible = true;
                panel_waiting.Visible = false;
            }
            else
            {
                panel_cycle.Visible = false;
                panel_stdcondOK.Visible = false;
                panel_stop.Visible = false;
                panel_waiting.Visible = true;
            }

            if (IO.Bits.WorkingModeAuto)
            {
                label_Auto_Manu.Text = "Otomatik Mod Aktif";
            }
            else
            {
                label_Auto_Manu.Text = "Manuel Mod Aktif";
            }
        }
        int counter_StCond, counter_Alarm, counter_Warning;
        private void Monitor_Alarm_Warning_StartCond()
        {

            if (IO.Bits.IsStartConditionOk || IO.Bits.IsCycle)
            {
                pictureBox_StartCond.Visible = false;
                pictureBox_StartCond.Enabled = false;
            }
            else
            {
                pictureBox_StartCond.Visible = true;
                pictureBox_StartCond.Enabled = true;
                counter_StCond = counter_StCond + 1;
                if (counter_StCond > 6)
                {
                    pictureBox_StartCond.Margin = new Padding(12, 12, 12, 12);
                    counter_StCond = 0;
                }
                else if (counter_StCond > 3) { pictureBox_StartCond.Margin = new Padding(3, 3, 3, 3); }
            }
            if (IO.Bits.IsAlarmExist)
            {
                pictureBox_Alarm.Visible = true;
                pictureBox_Alarm.Enabled = true;
                counter_Alarm = counter_Alarm + 1;
                if (counter_Alarm > 6)
                {
                    pictureBox_Alarm.Margin = new Padding(12, 12, 12, 12);
                    counter_Alarm = 0;
                }
                else if (counter_Alarm > 3) { pictureBox_Alarm.Margin = new Padding(3, 3, 3, 3); }
            }
            else
            {
                pictureBox_Alarm.Visible = false;
                pictureBox_Alarm.Enabled = false;
            }
            if (IO.Bits.IsWarningExist)
            {
                pictureBox_Warnings.Visible = true;
                pictureBox_Warnings.Enabled = true;
                counter_Warning = counter_Warning + 1;
                if (counter_Warning > 6)
                {
                    pictureBox_Warnings.Margin = new Padding(12, 12, 12, 12);
                    counter_Warning = 0;
                }
                else if (counter_Warning > 3) { pictureBox_Warnings.Margin = new Padding(3, 3, 3, 3); }
            }
            else
            {
                pictureBox_Warnings.Visible = false;
                pictureBox_Warnings.Enabled = false;
            }
        }
        private eSelectedRecipeChanged fooRecipeChanged;
        private void cb_SelectedRecipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            fooRecipeChanged.EventFired();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fooRisingEdgeTrigger_Stop = new RisingEdgeTrigger_Stop();
            fooRisingEdgeTrigger_Start = new RisingEdgeTrigger_Start();
            fooRisingEdgeTrigger_PartIncrement = new RisingEdgeTrigger_PartIncrement();
            fooRisingEdgeTrigger_ChangedPart = new RisingEdgeTrigger_ChangedPart();


            MachinePars_ToPLC.ReadMachinePars_WithXml();
            MachinePars_ToPLC.FillDictionaries();
            MachinePars_ToPLC.WritePLC();

            fooRecipeChanged = new eSelectedRecipeChanged();
            eSelectedRecipeChanged.eChanged -= ESelectedRecipeChanged_eChanged;
            eSelectedRecipeChanged.eChanged += ESelectedRecipeChanged_eChanged;

            eChangedStartEvent.eChanged -= EUpdateRecipes_eChanged;
            eChangedStartEvent.eChanged += EUpdateRecipes_eChanged;

            List<string> listRecipes = new List<string>();
            listRecipes = RecipePars_ToPLC.Read_Recipe_Names();
            uc_TekUretimPage.Init();
            uc_SeriUretimPage.Init();
            //threadModbus = new Thread(new ThreadStart(Modbus.ReadModbusServer_Values));
            //threadModbus.Start();
            Modbus.ReadModbusServer_Values();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
            //threadModbus.Abort();
            this.Dispose();
        }

        private void EUpdateRecipes_eChanged(object sender, eChangedStartEvent e)
        {
            List<string> listRecipes = new List<string>();
            listRecipes = RecipePars_ToPLC.Read_Recipe_Names();
        }

        private void btn_PanelAcKapa_Click(object sender, EventArgs e)
        {
            TableLayoutColumnStyleCollection styles = tableLayoutPanel1.ColumnStyles;
            styles[1].SizeType = SizeType.Percent;

            if (styles[1].Width > (float)14)
            {
                styles[1].Width = (float)2;
                btn_PanelAcKapa.Text = "<";
                tableLayoutPanel2.Visible = false;
            }
            else
            {
                styles[1].Width = (float)14.2;
                btn_PanelAcKapa.Text = ">";
                tableLayoutPanel2.Visible = true;
            }
        }

        bool partInc;
        private void btn_PartInc_Click(object sender, EventArgs e)
        {
            if (!partInc)
            {
                partInc = true;
                btn_PartInc.BackColor = Color.DarkSlateBlue;
            }
            else
            {
                partInc = false;
                btn_PartInc.BackColor = Color.MediumSlateBlue;
            }
        }

        private void resetButtonMain_Click_1(object sender, EventArgs e)
        {
            //IO.Bits.resetButton_toPLC.Value = true;
        }

        private void ESelectedRecipeChanged_eChanged(object sender, eSelectedRecipeChanged e)
        {
            //RecipePars_ToPLC.Fill();
            RecipePars_ToPLC.SelectRecipe(staticSelectedRecipe.sName);
            RecipePars_ToPLC.WritePLC();
        }

    }
}
