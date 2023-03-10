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
using Csharp.Pages.Production;
using Csharp.RecipePars;

namespace Csharp.Pages.DelikFormuller
{
    public partial class uc_Page_DelikFormuller : UserControl
    {
        public uc_Page_DelikFormuller()
        {
            InitializeComponent();
        }

        private void uc_Page_DelikFormuller_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("", 1, HorizontalAlignment.Center);
            listView1.Columns.Add("Vurma Pozisyonu", listView1.Width / 6, HorizontalAlignment.Center);
            listView1.Columns.Add("Genişlik", listView1.Width / 6, HorizontalAlignment.Center);
            listView1.Columns.Add("Delik Tipi", listView1.Width / 6, HorizontalAlignment.Center);
            listView1.Columns.Add("", 885, HorizontalAlignment.Center);

            if (uc_TekUretimPage.SortedlstArrProductionElements != null)
            {
                foreach (arrProductionElement VARIABLE in uc_TekUretimPage.SortedlstArrProductionElements)
                {
                    if (VARIABLE.EDelikTipi == DelikTipi.BasTakoz)
                    {
                        ListViewItem listViewItem = new ListViewItem();
                        listViewItem.SubItems.Add(VARIABLE.dVurmaPos.ToString("0.00"));
                        listViewItem.SubItems.Add(VARIABLE.dGenislikPos.ToString());
                        listViewItem.SubItems.Add(VARIABLE.EDelikTipi.ToString());
                        listView1.Items.Add(listViewItem);
                    }

                }
                uc_TekUretimPage.SortedlstArrProductionElements.Clear();
            }
            if (uc_SeriUretimPage.SortedlstArrProductionElements != null)
            {
                foreach (arrProductionElement VARIABLE in uc_SeriUretimPage.SortedlstArrProductionElements)
                {
                    if (VARIABLE.EDelikTipi == DelikTipi.BasTakoz)
                    {
                        ListViewItem listViewItem = new ListViewItem();
                        listViewItem.SubItems.Add(VARIABLE.dVurmaPos.ToString("0.00"));
                        listViewItem.SubItems.Add(VARIABLE.dGenislikPos.ToString());
                        listViewItem.SubItems.Add(VARIABLE.EDelikTipi.ToString());
                        listView1.Items.Add(listViewItem);
                    }
                }
                uc_SeriUretimPage.SortedlstArrProductionElements.Clear();
            }

            //ColumnHeader cHeader = new ColumnHeader();
            //cHeader.Text = "Vurma Pozisyonu";
            //cHeader.Name = "tVurmaPos";
            //cHeader.Width = listView1.Width / 3;
            //listView1.Columns.Add(cHeader);

            //ColumnHeader cHeader1 = new ColumnHeader();
            //cHeader1.Text = "Genişlik";
            //cHeader1.Name = "tGenislik";
            //cHeader1.Width = listView1.Width / 3;
            //listView1.Columns.Add(cHeader1);

            //ColumnHeader cHeader2 = new ColumnHeader();
            //cHeader2.Text = "Delik Tipi";
            //cHeader2.Name = "tDelikTipi";
            //cHeader2.Width = listView1.Width / 3;
            //listView1.Columns.Add(cHeader2);
        }

        private void listView1_DrawColumnHeader_1(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (var sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;

                using (var headerFont = new Font("Consolas", 16, FontStyle.Bold))
                {
                    e.Graphics.FillRectangle(Brushes.SteelBlue, e.Bounds);
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        Brushes.WhiteSmoke, e.Bounds, sf);
                }
            }
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
