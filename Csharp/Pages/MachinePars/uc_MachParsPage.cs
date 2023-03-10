using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Csharp.Pages.General;
using System.Xml;
using System.Collections.Specialized;
using Csharp.EventsAggregator;
using Csharp.Ios;

namespace Csharp.Pages.MachinePars
{
    public partial class uc_MachParsPage : UserControl
    {
        string filename = System.Threading.Thread.GetDomain().BaseDirectory + "//MachineParameters.xml";
        public uc_MachParsPage()
        {
            InitializeComponent();
        }
        private void uc_MachParsPage_Load(object sender, EventArgs e)
        {
            //MachinePars_ToPLC.ReadMachinePars_WithXml(); Commended cause Filled in Form Load
            //MachinePars_ToPLC.FillDictionaries(); Commended cause Filled in Form Load
            FillUserControlsFromDictionary();
            MachinePars_ToPLC.WritePLC();

            eMachineParameterChanged.eChanged -= EMachineParameterChanged_eChanged;
            eMachineParameterChanged.eChanged += EMachineParameterChanged_eChanged;

            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                TabColors.Add(tabControl1.TabPages[i], Color.AliceBlue);
            }
            SetTabHeader(tabControl1.TabPages[0], Color.LightBlue);

            foreach (uc_machinepar_numerik item in tableLayoutPanel_nums13.Controls.OfType<uc_machinepar_numerik>())
            {
                item.tb_value.ReadOnly = true;
            }
        }
        private void EMachineParameterChanged_eChanged(object sender, eMachineParameterChanged e)
        {
            FillDatasetFromUserControls();
            MachinePars_ToPLC.WritePLC();
        }
        private void DefineMaxMinLimit()
        {
            foreach (uc_machinepar_numerik ucNum in tableLayoutPanel_nums1.Controls.OfType<uc_machinepar_numerik>())
            {
                ucNum.MinLimit = 0;
                ucNum.MaxLimit = 9999;
            }
            foreach (uc_machinepar_numerik ucNum in tableLayoutPanel_nums2.Controls.OfType<uc_machinepar_numerik>())
            {
                ucNum.MinLimit = 0;
                ucNum.MaxLimit = 9999;
            }
            foreach (uc_machinepar_numerik ucNum in tableLayoutPanel_nums3.Controls.OfType<uc_machinepar_numerik>())
            {
                ucNum.MinLimit = 0;
                ucNum.MaxLimit = 9999;
            }
            foreach (uc_machinepar_numerik ucNum in tableLayoutPanel_nums4.Controls.OfType<uc_machinepar_numerik>())
            {
                ucNum.MinLimit = 0;
                ucNum.MaxLimit = 9999;
            }
            foreach (uc_machinepar_numerik ucNum in tableLayoutPanel_nums7.Controls.OfType<uc_machinepar_numerik>())
            {
                ucNum.MinLimit = 0;
                ucNum.MaxLimit = 9999;
            }
            foreach (uc_machinepar_numerik ucNum in tableLayoutPanel_nums8.Controls.OfType<uc_machinepar_numerik>())
            {
                ucNum.MinLimit = 0;
                ucNum.MaxLimit = 9999;
            }
            foreach (uc_machinepar_numerik ucNum in tableLayoutPanel_nums9.Controls.OfType<uc_machinepar_numerik>())
            {
                ucNum.MinLimit = 0;
                ucNum.MaxLimit = 9999;
            }
            foreach (uc_machinepar_numerik ucNum in tableLayoutPanel_nums12.Controls.OfType<uc_machinepar_numerik>())
            {
                ucNum.MinLimit = 0;
                ucNum.MaxLimit = 9999;
            }
            foreach (uc_machinepar_numerik ucNum in tableLayoutPanel_nums13.Controls.OfType<uc_machinepar_numerik>())
            {
                ucNum.MinLimit = 0;
                ucNum.MaxLimit = 9999;
            }
            foreach (uc_machinepar_numerik ucNum in tableLayoutPanel_nums14.Controls.OfType<uc_machinepar_numerik>())
            {
                ucNum.MinLimit = 0;
                ucNum.MaxLimit = 9999;
            }

            ucmachineparnumerik_0.MinLimit = 0;
            ucmachineparnumerik_1.MinLimit = 0;
            ucmachineparnumerik_2.MinLimit = 0;
            ucmachineparnumerik_3.MinLimit = 0;
            ucmachineparnumerik_4.MinLimit = 0;
            ucmachineparnumerik_5.MinLimit = 0;

            ucmachineparnumerik_0.MaxLimit = 200;
            ucmachineparnumerik_1.MaxLimit = 1000;
            ucmachineparnumerik_2.MaxLimit = 10;
            ucmachineparnumerik_3.MaxLimit = 30;
            ucmachineparnumerik_4.MaxLimit = 10;
            ucmachineparnumerik_5.MaxLimit = 30;
        }
        public void FillUserControlsFromDictionary()
        {
            DefineMaxMinLimit();

            #region[Bools]
            try //Name lerin "_" ile sıralanmış olması önemli. İçlerini otomatik olarak dolduruyoruz.
            {
                
            }
            catch (Exception e)
            {
                ;
            }
            #endregion

            #region[Nums] 
            try //Name lerin "_" ile sıralanmış olması önemli. İçlerini otomatik olarak dolduruyoruz.
            {
                
                foreach (uc_machinepar_numerik ucNum in tableLayoutPanel_nums13.Controls.OfType<uc_machinepar_numerik>())
                {
                    
                }
                foreach (uc_machinepar_numerik ucNum in tableLayoutPanel_nums14.Controls.OfType<uc_machinepar_numerik>())
                {
                    
                }

            }
            catch (Exception e)
            {
                ;
            }
            #endregion
        }
        private void FillDatasetFromUserControls()
        {
            #region[First Fill Dictionaries]
            #region[Bools]
            try //Name lerin "_" ile sıralanmış olması önemli. İçlerini otomatik olarak dolduruyoruz.
            {
                foreach (uc_machinepar_bool ucBool in tableLayoutPanel_bools.Controls.OfType<uc_machinepar_bool>())
                {
                }
            }
            catch (Exception e)
            {
                ;
            }
            #endregion
            #region[Nums] 
            try //Name lerin "_" ile sıralanmış olması önemli. İçlerini otomatik olarak dolduruyoruz.
            {
                foreach (uc_machinepar_numerik ucNum in tableLayoutPanel_nums1.Controls.OfType<uc_machinepar_numerik>())
                {
                }
                foreach (uc_machinepar_numerik ucNum in tableLayoutPanel_nums2.Controls.OfType<uc_machinepar_numerik>())
                {
                }
                foreach (uc_machinepar_numerik ucNum in tableLayoutPanel_nums3.Controls.OfType<uc_machinepar_numerik>())
                {
                }
                

            }
            catch (Exception e)
            {
                ;
            }
            #endregion
            #endregion
            foreach (var item in MachinePars_ToPLC.dicMachinePars_Bools)
            {
            }
            foreach (var item in MachinePars_ToPLC.dicMachinePars_Nums)
            {
            }
            MachinePars_ToPLC.ds_machinePars.WriteXml(filename);
        }
        private void SetTabHeader(TabPage page, Color color)
        {
            TabColors[page] = color;
            tabControl1.Invalidate();
        }
        private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                using (Brush br = new SolidBrush(TabColors[tabControl1.TabPages[e.Index]]))
                {
                    e.Graphics.FillRectangle(br, e.Bounds);
                    SizeF sz = e.Graphics.MeasureString(tabControl1.TabPages[e.Index].Text, e.Font);
                    e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + (e.Bounds.Width - sz.Width) / 2, e.Bounds.Top + (e.Bounds.Height - sz.Height) / 2 + 1);

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
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                SetTabHeader(tabControl1.TabPages[i], Color.AliceBlue);
            }
            SetTabHeader(tabControl1.SelectedTab, Color.LightBlue);
        }

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_MesafeArttır_Click(object sender, EventArgs e)
        {
            if (MachinePars_ToPLC.dicMachinePars_Nums[78].Value > 0)
            {
                MachinePars_ToPLC.dicMachinePars_Nums[54].Value += MachinePars_ToPLC.dicMachinePars_Nums[78].Value;
                MachinePars_ToPLC.dicMachinePars_Nums[57].Value += MachinePars_ToPLC.dicMachinePars_Nums[78].Value;
                MachinePars_ToPLC.dicMachinePars_Nums[60].Value += MachinePars_ToPLC.dicMachinePars_Nums[78].Value;
                MachinePars_ToPLC.dicMachinePars_Nums[63].Value += MachinePars_ToPLC.dicMachinePars_Nums[78].Value;
                MachinePars_ToPLC.dicMachinePars_Nums[66].Value += MachinePars_ToPLC.dicMachinePars_Nums[78].Value;
                MachinePars_ToPLC.dicMachinePars_Nums[69].Value += MachinePars_ToPLC.dicMachinePars_Nums[78].Value;
                MachinePars_ToPLC.dicMachinePars_Nums[72].Value += MachinePars_ToPLC.dicMachinePars_Nums[78].Value;
                MachinePars_ToPLC.dicMachinePars_Nums[75].Value += MachinePars_ToPLC.dicMachinePars_Nums[78].Value;
            }

            FillUserControlsFromDictionary();
            MachinePars_ToPLC.WritePLC();

        }

        private void btn_MesafeAzalt_Click(object sender, EventArgs e)
        {
            if (MachinePars_ToPLC.dicMachinePars_Nums[78].Value > 0)
            {
                MachinePars_ToPLC.dicMachinePars_Nums[54].Value -= MachinePars_ToPLC.dicMachinePars_Nums[78].Value;
                MachinePars_ToPLC.dicMachinePars_Nums[57].Value -= MachinePars_ToPLC.dicMachinePars_Nums[78].Value;
                MachinePars_ToPLC.dicMachinePars_Nums[60].Value -= MachinePars_ToPLC.dicMachinePars_Nums[78].Value;
                MachinePars_ToPLC.dicMachinePars_Nums[63].Value -= MachinePars_ToPLC.dicMachinePars_Nums[78].Value;
                MachinePars_ToPLC.dicMachinePars_Nums[66].Value -= MachinePars_ToPLC.dicMachinePars_Nums[78].Value;
                MachinePars_ToPLC.dicMachinePars_Nums[69].Value -= MachinePars_ToPLC.dicMachinePars_Nums[78].Value;
                MachinePars_ToPLC.dicMachinePars_Nums[72].Value -= MachinePars_ToPLC.dicMachinePars_Nums[78].Value;
                MachinePars_ToPLC.dicMachinePars_Nums[75].Value -= MachinePars_ToPLC.dicMachinePars_Nums[78].Value;
            }

            FillUserControlsFromDictionary();
            MachinePars_ToPLC.WritePLC();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            uc_machinepar_actPos.tb_value.ReadOnly = true;
            uc_machinepar_actPos.tb_value.Text = IO.Floats.ParcaSurme_AktuelPosition.ToString("0.000");
            uc_machinepar_actPos.tb_Text.Text = "Parça Sürme Aktüel Pozisyon";

            try
            {
                ucmachineparnumerik_99.tb_value.Text = IO.Words.VurusSayisi_Cap7Sag.ToString();
                ucmachineparnumerik_100.tb_value.Text = IO.Words.VurusSayisi_Cap7Sol.ToString();
                ucmachineparnumerik_101.tb_value.Text = IO.Words.VurusSayisi_Slot11x20.ToString();
                ucmachineparnumerik_102.tb_value.Text = IO.Words.VurusSayisi_BasTakoz.ToString();
                ucmachineparnumerik_103.tb_value.Text = IO.Words.VurusSayisi_Manivela.ToString();
                ucmachineparnumerik_104.tb_value.Text = IO.Words.VurusSayisi_AnaBosaltma.ToString();
                ucmachineparnumerik_105.tb_value.Text = IO.Words.VurusSayisi_IlaveBosaltma1.ToString();
                ucmachineparnumerik_106.tb_value.Text = IO.Words.VurusSayisi_IlaveBosaltma2.ToString();
                ucmachineparnumerik_107.tb_value.Text = IO.Words.VurusSayisi_Kesme.ToString();
            }
            catch (Exception)
            {
                ;
            }
        }
    }
}