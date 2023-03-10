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
using Csharp.Ios;

namespace Csharp.Pages
{
    public partial class uc_StationStatusPage : UserControl
    {
        Dictionary<int, string> dic_GirisConvStatus = new Dictionary<int, string>();
        Dictionary<int, string> dic_KapakBeslemeStatus = new Dictionary<int, string>();
        Dictionary<int, string> dic_ManipulatorStatus = new Dictionary<int, string>();
        Dictionary<int, string> dic_EtiketlemeStatus = new Dictionary<int, string>();
        Dictionary<int, string> dic_KoliStatus = new Dictionary<int, string>();
        Dictionary<int, string> dic_CikisConvStatus = new Dictionary<int, string>();
        Dictionary<int, string> dic_KoliAcmaBantlamaStatus = new Dictionary<int, string>();
        Dictionary<int, string> dic_IticiCekiciStatus = new Dictionary<int, string>();
        DataSet ds_GirisConvStatus = new DataSet();
        DataSet ds_KapakBeslemeStatus = new DataSet();
        DataSet ds_ManipulatorStatus = new DataSet();
        DataSet ds_EtiketlemeStatus = new DataSet();
        DataSet ds_KoliStatus = new DataSet();
        DataSet ds_CikisConvStatus = new DataSet();
        DataSet ds_KoliAcmaBantlamaStatus = new DataSet();
        DataSet ds_IticiCekiciStatus = new DataSet();
        DataTable dt_GirisConvStatus = new DataTable();
        DataTable dt_KapakBeslemeStatus = new DataTable();
        DataTable dt_ManipulatorStatus = new DataTable();
        DataTable dt_EtiketlemeStatus = new DataTable();
        DataTable dt_KoliStatus = new DataTable();
        DataTable dt_CikisConvStatus = new DataTable();
        DataTable dt_KoliAcmaBantlamaStatus = new DataTable();
        DataTable dt_IticiCekiciStatus = new DataTable();
        string filename_GirisConvStatus = System.Threading.Thread.GetDomain().BaseDirectory + "//StationStatus/GirisConvStatus.xml";
        string filename_KapakBeslemeStatus = System.Threading.Thread.GetDomain().BaseDirectory + "//StationStatus/KapakBeslemeStatus.xml";
        string filename_ManipulatorStatus = System.Threading.Thread.GetDomain().BaseDirectory + "//StationStatus/ManipulatorStatus.xml";
        string filename_EtiketlemeStatus = System.Threading.Thread.GetDomain().BaseDirectory + "//StationStatus/EtiketlemeStatus.xml";
        string filename_KoliStatus = System.Threading.Thread.GetDomain().BaseDirectory + "//StationStatus/KoliStatus.xml";
        string filename_CikisConvStatus = System.Threading.Thread.GetDomain().BaseDirectory + "//StationStatus/CikisConvStatus.xml";
        string filename_KoliAcmaBantlamaStatus = System.Threading.Thread.GetDomain().BaseDirectory + "//StationStatus/KoliAcmaBantlamaStatus.xml";
        string filename_IticiCekiciStatus = System.Threading.Thread.GetDomain().BaseDirectory + "//StationStatus/IticiCekiciStatus.xml";
        public uc_StationStatusPage()
        {
            InitializeComponent();
        }
        private void uc_StationStatusPage_Load(object sender, EventArgs e)
        {
            timer_status.Enabled = true;
            //Check whether file is exist or not.
            if (File.Exists(filename_GirisConvStatus) && File.Exists(filename_KapakBeslemeStatus) && File.Exists(filename_ManipulatorStatus)
                && File.Exists(filename_EtiketlemeStatus) && File.Exists(filename_KoliStatus) && File.Exists(filename_CikisConvStatus) && File.Exists(filename_KoliAcmaBantlamaStatus)
                && File.Exists(filename_IticiCekiciStatus))
            {
                ds_GirisConvStatus.ReadXml(filename_GirisConvStatus);
                ds_KapakBeslemeStatus.ReadXml(filename_KapakBeslemeStatus);
                ds_ManipulatorStatus.ReadXml(filename_ManipulatorStatus);
                ds_EtiketlemeStatus.ReadXml(filename_EtiketlemeStatus);
                ds_KoliStatus.ReadXml(filename_KoliStatus);
                ds_CikisConvStatus.ReadXml(filename_CikisConvStatus);
                ds_KoliAcmaBantlamaStatus.ReadXml(filename_KoliAcmaBantlamaStatus);
                ds_IticiCekiciStatus.ReadXml(filename_IticiCekiciStatus);
            }
            else
            {
                makeDefaultXmlFile();
                MyMessageBox.ShowMessageBox("İstasyon durumları kayıt dosyası silinmiş.Makine üreticisi ile iletişime geçiniz.");
            }
            FillDictionaries();
        }
        private void FillDictionaries()
        {
            foreach (DataRow dr in ds_GirisConvStatus.Tables["Giris Conv"].Rows)
            {
                dic_GirisConvStatus.Add(Convert.ToInt32(dr["Key"]), dr["Value"].ToString());
            }

            foreach (DataRow dr in ds_KapakBeslemeStatus.Tables["Kapak Besleme"].Rows)
            {
                dic_KapakBeslemeStatus.Add(Convert.ToInt32(dr["Key"]), dr["Value"].ToString());
            }

            foreach (DataRow dr in ds_ManipulatorStatus.Tables["Manipulator"].Rows)
            {
                dic_ManipulatorStatus.Add(Convert.ToInt32(dr["Key"]), dr["Value"].ToString());
            }

            foreach (DataRow dr in ds_EtiketlemeStatus.Tables["Etiketleme"].Rows)
            {
                dic_EtiketlemeStatus.Add(Convert.ToInt32(dr["Key"]), dr["Value"].ToString());
            }

            foreach (DataRow dr in ds_KoliStatus.Tables["Kolileme"].Rows)
            {
                dic_KoliStatus.Add(Convert.ToInt32(dr["Key"]), dr["Value"].ToString());
            }

            foreach (DataRow dr in ds_CikisConvStatus.Tables["Cikis Conv"].Rows)
            {
                dic_CikisConvStatus.Add(Convert.ToInt32(dr["Key"]), dr["Value"].ToString());
            }
            foreach (DataRow dr in ds_KoliAcmaBantlamaStatus.Tables["Koli Acma Bantlama"].Rows)
            {
                dic_KoliAcmaBantlamaStatus.Add(Convert.ToInt32(dr["Key"]), dr["Value"].ToString());
            }
            foreach (DataRow dr in ds_IticiCekiciStatus.Tables["Itici Cekici"].Rows)
            {
                dic_IticiCekiciStatus.Add(Convert.ToInt32(dr["Key"]), dr["Value"].ToString());
            }

        }
        private void makeDefaultXmlFile()
        {
            ds_GirisConvStatus.DataSetName = "Station Status GirisConv";
            ds_KapakBeslemeStatus.DataSetName = "Station Status KapakBesleme";
            ds_ManipulatorStatus.DataSetName = "Station Status Manipulator";
            ds_EtiketlemeStatus.DataSetName = "Station Status Etiketleme";
            ds_KoliStatus.DataSetName = "Station Status Koli";
            ds_CikisConvStatus.DataSetName = "Station Status CikisConv";
            ds_KoliAcmaBantlamaStatus.DataSetName = "Station Status Koli AcmaBantlama";
            ds_IticiCekiciStatus.DataSetName = "Station Status IticiCekici";

            dt_GirisConvStatus.TableName = "Giris Conv";
            dt_GirisConvStatus.Columns.Add("Key");
            dt_GirisConvStatus.Columns.Add("Value");

            dt_KapakBeslemeStatus.TableName = "Kapak Besleme";
            dt_KapakBeslemeStatus.Columns.Add("Key");
            dt_KapakBeslemeStatus.Columns.Add("Value");

            dt_ManipulatorStatus.TableName = "Manipulator";
            dt_ManipulatorStatus.Columns.Add("Key");
            dt_ManipulatorStatus.Columns.Add("Value");

            dt_EtiketlemeStatus.TableName = "Etiketleme";
            dt_EtiketlemeStatus.Columns.Add("Key");
            dt_EtiketlemeStatus.Columns.Add("Value");

            dt_KoliStatus.TableName = "Kolileme";
            dt_KoliStatus.Columns.Add("Key");
            dt_KoliStatus.Columns.Add("Value");

            dt_CikisConvStatus.TableName = "Cikis Conv";
            dt_CikisConvStatus.Columns.Add("Key");
            dt_CikisConvStatus.Columns.Add("Value");

            dt_KoliAcmaBantlamaStatus.TableName = "Koli Acma Bantlama";
            dt_KoliAcmaBantlamaStatus.Columns.Add("Key");
            dt_KoliAcmaBantlamaStatus.Columns.Add("Value");

            dt_IticiCekiciStatus.TableName = "Itici Cekici";
            dt_IticiCekiciStatus.Columns.Add("Key");
            dt_IticiCekiciStatus.Columns.Add("Value");


            ds_GirisConvStatus.Tables.Add(dt_GirisConvStatus);
            ds_KapakBeslemeStatus.Tables.Add(dt_KapakBeslemeStatus);
            ds_ManipulatorStatus.Tables.Add(dt_ManipulatorStatus);
            ds_KoliStatus.Tables.Add(dt_KoliStatus);
            ds_EtiketlemeStatus.Tables.Add(dt_EtiketlemeStatus);
            ds_CikisConvStatus.Tables.Add(dt_CikisConvStatus);
            ds_KoliAcmaBantlamaStatus.Tables.Add(dt_KoliAcmaBantlamaStatus);
            ds_IticiCekiciStatus.Tables.Add(dt_IticiCekiciStatus);

            //Create Giris Conv table
            for (int i = 0; i <= 100; i++)
            {
                ds_GirisConvStatus.Tables["Giris Conv"].Rows.Add(i.ToString(), "Reserve");
            }
            //Create Kapak Besleme table
            for (int i = 0; i <= 100; i++)
            {
                ds_KapakBeslemeStatus.Tables["Kapak Besleme"].Rows.Add(i.ToString(), "Reserve");
            }
            //Create Manipulator table
            for (int i = 0; i <= 100; i++)
            {
                ds_ManipulatorStatus.Tables["Manipulator"].Rows.Add(i.ToString(), "Reserve");
            }
            //Create Etiketleme table
            for (int i = 0; i <= 100; i++)
            {
                ds_EtiketlemeStatus.Tables["Etiketleme"].Rows.Add(i.ToString(), "Reserve");
            }
            //Create Kolileme table
            for (int i = 0; i <= 100; i++)
            {
                ds_KoliStatus.Tables["Kolileme"].Rows.Add(i.ToString(), "Reserve");
            }
            //Create Cikis Conv table
            for (int i = 0; i <= 100; i++)
            {
                ds_CikisConvStatus.Tables["Cikis Conv"].Rows.Add(i.ToString(), "Reserve");
            }
            //Create Koli Acma Bantlama table
            for (int i = 0; i <= 100; i++)
            {
                ds_KoliAcmaBantlamaStatus.Tables["Koli Acma Bantlama"].Rows.Add(i.ToString(), "Reserve");
            }
            //Create İtici Cekici table
            for (int i = 0; i <= 100; i++)
            {
                ds_IticiCekiciStatus.Tables["Itici Cekici"].Rows.Add(i.ToString(), "Reserve");
            }
            ds_GirisConvStatus.WriteXml(filename_GirisConvStatus);
            ds_KapakBeslemeStatus.WriteXml(filename_KapakBeslemeStatus);
            ds_ManipulatorStatus.WriteXml(filename_ManipulatorStatus);
            ds_EtiketlemeStatus.WriteXml(filename_EtiketlemeStatus);
            ds_KoliStatus.WriteXml(filename_KoliStatus);
            ds_CikisConvStatus.WriteXml(filename_CikisConvStatus);
            ds_KoliAcmaBantlamaStatus.WriteXml(filename_KoliAcmaBantlamaStatus);
            ds_IticiCekiciStatus.WriteXml(filename_IticiCekiciStatus);

        }
        private void timer_status_Tick(object sender, EventArgs e)
        {
            label_Status_GirisConv.Text = dic_GirisConvStatus[IO.Words.Management_Status];
        }
    }
}
