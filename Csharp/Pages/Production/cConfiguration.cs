using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Csharp.Ios;
using Csharp.Pages.MachinePars;
using System.Drawing;

namespace Csharp.Pages.Production
{
    public class cConfiguration
    {
        public static int mm_to_pixel_cevir(double mm)
        {
            try
            {
                int h = Screen.PrimaryScreen.WorkingArea.Height;
                int w = Screen.PrimaryScreen.WorkingArea.Width;
                return Convert.ToInt32(0.53 * mm);
            }
            catch (Exception e)
            {
                return Convert.ToInt32(0.53);
                throw;
            }

        }
        public static int pixel_to_mm_cevir(double pixsel)
        {
            return Convert.ToInt32(pixsel / 0.53);
        }
    }
    public class OperatorParameters : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private Dictionary<int, UserControl> list_AllSubbParts;

        public Dictionary<int, UserControl> ListAllSubbParts
        {
            get { return list_AllSubbParts; }
            set { list_AllSubbParts = value; InvokePropertyChanged(new PropertyChangedEventArgs("ListAllSubbParts")); }
        }
        private Dictionary<int, UserControl> _listDisplaingAllParts;

        public Dictionary<int, UserControl> ListDisplayingAllParts
        {
            get { return _listDisplaingAllParts; }
            set { _listDisplaingAllParts = value; InvokePropertyChanged(new PropertyChangedEventArgs("ListDisplaingAllSubbParts")); }
        }

        private Dictionary<int, UserControl> _listSeriUretimParts;

        public Dictionary<int, UserControl> ListSeriUretimParts
        {
            get { return _listSeriUretimParts; }
            set { _listSeriUretimParts = value; InvokePropertyChanged(new PropertyChangedEventArgs("ListSeriUretimParts")); }
        }

        private Dictionary<int, UserControl> _listSeriUretimLibraryParts;
        public Dictionary<int, UserControl> ListSeriUretimLibraryParts
        {
            get { return _listSeriUretimLibraryParts; }
            set { _listSeriUretimLibraryParts = value; InvokePropertyChanged(new PropertyChangedEventArgs("ListSeriUretimLibraryParts")); }
        }

        private Dictionary<int, UserControl> _listOptimizedSeriUretimParts;

        public Dictionary<int, UserControl> ListOptimizedSeriUretimParts
        {
            get { return _listOptimizedSeriUretimParts; }
            set { _listOptimizedSeriUretimParts = value; InvokePropertyChanged(new PropertyChangedEventArgs("ListOptimizedSeriUretimParts")); }
        }

        private Dictionary<int, UserControl> list_AllSubbParts_SeriUretim;

        public Dictionary<int, UserControl> List_AllSubbParts_SeriUretim
        {
            get { return list_AllSubbParts_SeriUretim; }
            set { list_AllSubbParts_SeriUretim = value; InvokePropertyChanged(new PropertyChangedEventArgs("List_AllSubbParts_SeriUretim")); }
        }

        private Dictionary<int, double> _listFire;

        public Dictionary<int, double> ListFire
        {
            get { return _listFire; }
            set { _listFire = value; InvokePropertyChanged(new PropertyChangedEventArgs("ListFire")); }
        }

        private Dictionary<int, UserControl> _listİslenenParts;

        public Dictionary<int, UserControl> ListİslenenParts
        {
            get { return _listİslenenParts; }
            set { _listİslenenParts = value; InvokePropertyChanged(new PropertyChangedEventArgs("ListİslenenParts")); }
        }
        public float GripperFiresi
        {
            get { return Convert.ToSingle(MachinePars_ToPLC.dicMachinePars_Nums[6].Value); }
        }
        public float KesmeFiresi
        {
            get { return Convert.ToSingle(MachinePars_ToPLC.dicMachinePars_Nums[7].Value); }
        }

        public float KafaFiresi
        {
            get { return Convert.ToSingle(MachinePars_ToPLC.dicMachinePars_Nums[8].Value); }
        }

        private Point pGövdeLocation;

        public Point PGövdeLocation
        {
            get { return pGövdeLocation; }
            set { pGövdeLocation = value; InvokePropertyChanged(new PropertyChangedEventArgs("PGövdeLocation")); }
        }

        private float dHamGovdeBoyu;

        public float HamGovdeBoyu
        {
            get { return dHamGovdeBoyu; }
            set { dHamGovdeBoyu = value; InvokePropertyChanged(new PropertyChangedEventArgs("HamGovdeBoyu")); }
        }

        public float HamGovdeBoyu_pixel
        {
            get { return cConfiguration.mm_to_pixel_cevir(dHamGovdeBoyu); }
        }

        private float dAltGovdeBoyu;

        public float AltGovdeBoyu
        {
            get { return dAltGovdeBoyu; }
            set { dAltGovdeBoyu = value; InvokePropertyChanged(new PropertyChangedEventArgs("AltGovdeBoyu")); }
        }

        public float AltGovdeBoyu_pixel
        {
            get { return cConfiguration.mm_to_pixel_cevir(dAltGovdeBoyu); }
        }

        private ePencereAdedi ePencereAdedi;

        public ePencereAdedi PencereAdedi
        {
            get { return ePencereAdedi; }
            set { ePencereAdedi = value; InvokePropertyChanged(new PropertyChangedEventArgs("PencereAdedi")); }
        }

        private eIletkenTipi eIletkenTipi;

        public eIletkenTipi IletkenTipi
        {
            get { return eIletkenTipi; }
            set { eIletkenTipi = value; InvokePropertyChanged(new PropertyChangedEventArgs("IletkenTipi")); }
        }

        private float dPencere1_Pos;

        public float Pencere_Pos_1
        {
            get { return dPencere1_Pos; }
            set { dPencere1_Pos = value; InvokePropertyChanged(new PropertyChangedEventArgs("Pencere_Pos_1")); }
        }
        private float dPencere2_Pos;

        public float Pencere_Pos_2
        {
            get { return dPencere2_Pos; }
            set { dPencere2_Pos = value; InvokePropertyChanged(new PropertyChangedEventArgs("Pencere_Pos_2")); }
        }
        private float dPencere3_Pos;

        public float Pencere_Pos_3
        {
            get { return dPencere3_Pos; }
            set { dPencere3_Pos = value; InvokePropertyChanged(new PropertyChangedEventArgs("Pencere_Pos_3")); }
        }
        private float dPencere4_Pos;

        public float Pencere_Pos_4
        {
            get { return dPencere4_Pos; }
            set { dPencere4_Pos = value; InvokePropertyChanged(new PropertyChangedEventArgs("Pencere_Pos_4")); }
        }
        private float dPencere5_Pos;

        public float Pencere_Pos_5
        {
            get { return dPencere5_Pos; }
            set { dPencere5_Pos = value; InvokePropertyChanged(new PropertyChangedEventArgs("Pencere_Pos_5")); }
        }
        private float dPencere6_Pos;

        public float Pencere_Pos_6
        {
            get { return dPencere6_Pos; }
            set { dPencere6_Pos = value; InvokePropertyChanged(new PropertyChangedEventArgs("Pencere_Pos_6")); }
        }

        private bool bYatayIc;

        public bool YatayIcSelected
        {
            get { return bYatayIc; }
            set { bYatayIc = value; InvokePropertyChanged(new PropertyChangedEventArgs("YatayIcSelected")); }
        }

        private bool bYatayDis;

        public bool YatayDisSelected
        {
            get { return bYatayDis; }
            set { bYatayDis = value; InvokePropertyChanged(new PropertyChangedEventArgs("YatayDisSelected")); }
        }

        private bool bLeft;
        public bool LeftSelected
        {
            get { return bLeft; }
            set { bLeft = value; InvokePropertyChanged(new PropertyChangedEventArgs("LeftSelected")); }
        }

        private bool bRight;
        public bool RightSelected
        {
            get { return bRight; }
            set { bRight = value; InvokePropertyChanged(new PropertyChangedEventArgs("RightSelected")); }
        }

        private float dKalanboy;
        public float KalanBoy
        {
            get { return dKalanboy; }
            set { dKalanboy = value; InvokePropertyChanged(new PropertyChangedEventArgs("KalanBoy")); }
        }

        private float dKullanılanBoy;
        public float KullanılanBoy
        {
            get { return dKullanılanBoy; }
            set { dKullanılanBoy = value; InvokePropertyChanged(new PropertyChangedEventArgs("KullanılanBoy")); }
        }

        private int dGovdeAdedi;
        public int GovdeAdedi
        {
            get { return dGovdeAdedi; }
            set { dGovdeAdedi = value; InvokePropertyChanged(new PropertyChangedEventArgs("GovdeAdedi")); }
        }

        private double topluhamGovdeBoy;
        public double TopluhamGovdeBoy
        {
            get { return topluhamGovdeBoy; }
            set { topluhamGovdeBoy = value; InvokePropertyChanged(new PropertyChangedEventArgs("TopluhamGovdeBoy")); }
        }
        public double TopluhamGovdeBoy_pixel
        {
            get { return cConfiguration.mm_to_pixel_cevir(topluhamGovdeBoy); }
        }

        private Point ptopluGövdeLocation;

        public Point PTopluGövdeLocation
        {
            get { return ptopluGövdeLocation; }
            set { ptopluGövdeLocation = value; InvokePropertyChanged(new PropertyChangedEventArgs("PTopluGövdeLocation")); }
        }

        private bool bstartConditions_TekUretim;
        public bool bStartConditions_TekUretim
        {
            get { return bstartConditions_TekUretim; }
            set { bstartConditions_TekUretim = value; }
        }
        private bool bstartConditions_SeriUretim;
        public bool bStartConditions_SeriUretim
        {
            get { return bstartConditions_SeriUretim; }
            set { bstartConditions_SeriUretim = value; }
        }

        private bool onTekUretimPage;
        public bool OnTekUretimPage
        {
            get { return onTekUretimPage; }
            set { onTekUretimPage = value; }
        }

        private bool onSeriUretimPage;
        public bool OnSeriUretimPage
        {
            get { return onSeriUretimPage; }
            set { onSeriUretimPage = value; }
        }

    }
    public enum eIletkenTipi
    {
        [Description("3")]
        Iletken_3,
        [Description("4")]
        Iletken_4,
        [Description("4,5")]
        Iletken_45,
        [Description("5")]
        Iletken_5,
        [Description("5,5")]
        Iletken_55,
        [Description("6")]
        Iletken_6,
    }
    public enum ePencereAdedi
    {
        [Description("Yok")]
        pencere_Yok,
        [Description("1")]
        pencere_Bir,
        [Description("2")]
        pencere_Iki,
        [Description("3")]
        pencere_Uc,
        [Description("4")]
        pencere_Dort,
        [Description("5")]
        pencere_Bes,
        [Description("6")]
        pencere_Alti,
    }

    public enum DelikTipi
    {
        Cap7Sol = 1,
        Cap7Sag,
        Delik_11x20,
        BasTakoz,
        Manivela,
        AnaBosaltma,
        IlaveBosaltma_1,
        IlaveBosaltma_2,
        Kesme
    }
    public enum eTipKontrol
    {
        Tip3 = 3,
        Tip4,
        Tip5,
        Tip6,
        Tip45 = 45,
        Tip55 = 55,
    }
}
