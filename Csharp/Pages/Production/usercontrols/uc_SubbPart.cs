using Csharp.Pages.MachinePars;
using Csharp.Pages.Production.usercontrols.DelikUserController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Csharp.Pages.General;
using Csharp.EventsAggregator;

namespace Csharp.Pages.Production.usercontrols
{
    public partial class uc_SubbPart : UserControl, ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public static double pencere_Bir_MinLimit { get; set; }
        public static double pencere_Bir_MaxLimit { get; set; }
        public static double pencereArasılimit_2 { get; set; }
        public static double pencere_Iki_MaxLimit { get; set; }
        public static double pencereArasılimit_3 { get; set; }
        public static double pencere_Uc_MaxLimit { get; set; }
        public static double pencereArasılimit_4 { get; set; }
        public static double pencere_Dort_MaxLimit { get; set; }
        public static double pencereArasılimit_5 { get; set; }
        public static double pencere_Bes_MaxLimit { get; set; }
        public static double pencereArasılimit_6 { get; set; }
        public static double pencere_Alti_MaxLimit { get; set; }

        public uc_SubbPart(double boy)
        {
            this.MmBoy = boy; // Boy property sine user control nesnesi üzerinden erişilebilsin.
            InitializeComponent();
            //fooCakismaDelete = new eDelikCakismaDeleteSubPart();

        }

        #region Yatay Köşe ile İlgili Propertyler

        public bool bYatayKöseDis_Selected { get; set; }
        public bool bYatayKöseIc_Selected { get; set; }
        public bool bYatayKöseLeft_Selected { get; set; }
        public bool bYatayKöseRight_Selected { get; set; }

        #endregion

        public IletkeneGoreGenislik Cap7Sol_Genislik = new IletkeneGoreGenislik();
        public IletkeneGoreGenislik Cap7Sag_Genislik = new IletkeneGoreGenislik();

        public IletkeneGoreGenislik Cap7Sol_Genislik_Takoz = new IletkeneGoreGenislik();
        public IletkeneGoreGenislik Cap7Sag_Genislik_Takoz = new IletkeneGoreGenislik();

        public IletkeneGoreGenislik Cap7Sol_Genislik_YatayKose = new IletkeneGoreGenislik();
        public IletkeneGoreGenislik Cap7Sag_Genislik_YatayKose = new IletkeneGoreGenislik();

        private double dcap7Sol_Genislik;
        public double dCap7Sol_Genislik
        {
            get { return dcap7Sol_Genislik; }
            set { dcap7Sol_Genislik = value; }
        }

        private double dcap7Sol_Genislik_Takoz;
        public double dCap7Sol_Genislik_Takoz
        {
            get { return dcap7Sol_Genislik_Takoz; }
            set { dcap7Sol_Genislik_Takoz = value; }
        }

        private List<arrProductionElement> listOfDelik;
        public List<arrProductionElement> ListOfDelik
        {
            get { return listOfDelik; }
            set { listOfDelik = value; }
        }

        private double dcap7Sag_Genislik;
        public double dCap7Sag_Genislik
        {
            get { return dcap7Sag_Genislik; }
            set { dcap7Sag_Genislik = value; }
        }

        private double dcap7Sag_Genislik_Takoz;
        public double dCap7Sag_Genislik_Takoz
        {
            get { return dcap7Sag_Genislik_Takoz; }
            set { dcap7Sag_Genislik_Takoz = value; }
        }

        private double dcap7Sag_Genislik_Kosebent;
        public double dCap7Sag_Genislik_Kosebent
        {
            get { return dcap7Sag_Genislik_Kosebent; }
            set { dcap7Sag_Genislik_Kosebent = value; }
        }

        private double dcap7Sol_Genislik_Kosebent;
        public double dCap7Sol_Genislik_Kosebent
        {
            get { return dcap7Sol_Genislik_Kosebent; }
            set { dcap7Sol_Genislik_Kosebent = value; }
        }

        public uc_SubbPart subbPart;
        public static uc_SubbPart LastCreatedSubbPart;

        private double mmBoy;
        public double MmBoy
        {
            get { return mmBoy; }
            set { mmBoy = value; }
        }

        private double mm_oncesindekiBoy;
        public double Mm_OncesindekiBoy
        {
            get { return mm_oncesindekiBoy; }
            set { mm_oncesindekiBoy = value; }
        }
        #region Seri Üretim İle İlgili
        public int nGovdeAdedi { get; set; }
        public int nSeriUretim_GovdeNumber { get; set; }
        public int nUretilenGovdeAdedi { get; set; }

        public int nGovdeAdedi_Kullanılan { get; set; } // Bunu döndürünce bir arttıracağız.
        #endregion
        public eIletkenTipi IletkenTipi { get; set; }
        public ePencereAdedi PencereAdedi { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boy">Yaratılacak subb part ın boyu</param>
        /// <param name="OncesindeKullanilanToplamBoy">Bu subb part başlamadan önceki toplam boy</param>
        /// <returns></returns>
        public static uc_SubbPart Add(double boy, double OncesindeKullanilanToplamBoy, eIletkenTipi IletkenTipi, ePencereAdedi _PencereAdedi,
            bool YatayIcSelected, bool YatayDisSelected, bool LeftSelected, bool RightSelected, double Pencere_Pos_1, double Pencere_Pos_2,
            double Pencere_Pos_3, double Pencere_Pos_4, double Pencere_Pos_5, double Pencere_Pos_6, int GovdeAdedi)
        {
            uc_SubbPart subbPart = new uc_SubbPart(boy);
            subbPart.ListOfDelik = new List<arrProductionElement>();
            //PencereAdedi pencere = new PencereAdedi();
            subbPart.MmBoy = boy; // Boy property sine user control nesnesi üzerinden erişilebilsin.
            subbPart.Mm_OncesindekiBoy = OncesindeKullanilanToplamBoy;
            subbPart.Height = 80;
            subbPart.Width = cConfiguration.mm_to_pixel_cevir(boy);

            // Yatay Köse Propertylerini Input parametreleri yardımıyla dolduralım.
            subbPart.bYatayKöseDis_Selected = YatayDisSelected;
            subbPart.bYatayKöseIc_Selected = YatayIcSelected;
            subbPart.bYatayKöseLeft_Selected = LeftSelected;
            subbPart.bYatayKöseRight_Selected = RightSelected;

            subbPart.Read_InitialValues_FromMachinePars(IletkenTipi, _PencereAdedi);
            subbPart.nGovdeAdedi = GovdeAdedi;
            subbPart.IletkenTipi = IletkenTipi;
            subbPart.PencereAdedi = _PencereAdedi;
            subbPart.Pencere_Bir = Pencere_Pos_1;
            subbPart.Pencere_Iki = Pencere_Pos_2;
            subbPart.Pencere_Uc = Pencere_Pos_3;
            subbPart.Pencere_Dort = Pencere_Pos_4;
            subbPart.Pencere_Bes = Pencere_Pos_5;
            subbPart.Pencere_Alti = Pencere_Pos_6;
            subbPart.Pencere_Yok = 0.0;



            //subbPart.CreateDelikler();
            subbPart.ListOfDelik = new List<arrProductionElement>(subbPart.CreateDelikler_Updated());
            LastCreatedSubbPart = subbPart;
            //if (subbPart.d11x20VeManivelaArasıMesafe <= 0)
            //{
            //    subbPart.fooCakismaDelete.EventFired();
            //}
            return subbPart;
        }

        private eDelikCakismaDeleteSubPart fooCakismaDelete;
        public string sonElemanTekCiftDurumu;
        private bool bManivelaDeligiSolAktif;
        private bool bManivelaDeligiSağAktif;
        public double d11x20VeManivelaArasıMesafe;

        private bool b11x20VeCap7Disable_Min;
        private bool b11x20VeCap7Disable_Max;

        //CREATE DELİKLER
        public List<arrProductionElement> CreateDelikler_Updated()
        {
            List<arrProductionElement> returned_ListOfDelik = new List<arrProductionElement>();

            int dBasTakozDisMesafesi_px = cConfiguration.mm_to_pixel_cevir(MachinePars_ToPLC.dicMachinePars_Nums[9].Value);
            int dTakozDelikDisMesafesi_px = cConfiguration.mm_to_pixel_cevir(MachinePars_ToPLC.dicMachinePars_Nums[10].Value);
            int dKosebentDelikDisMesafesi_px = cConfiguration.mm_to_pixel_cevir(MachinePars_ToPLC.dicMachinePars_Nums[26].Value);
            int dManivelaDelikDisMesafesi_px = cConfiguration.mm_to_pixel_cevir(MachinePars_ToPLC.dicMachinePars_Nums[11].Value);
            int dVidaVeSogutmaDisMesafesi_Bas_px = cConfiguration.mm_to_pixel_cevir(MachinePars_ToPLC.dicMachinePars_Nums[12].Value);
            int dVidaVeSogutmaDisMesafesi_Son_px = cConfiguration.mm_to_pixel_cevir(MachinePars_ToPLC.dicMachinePars_Nums[13].Value);
            int dVidaVeSogutmaInceTip_Bas_px = cConfiguration.mm_to_pixel_cevir(MachinePars_ToPLC.dicMachinePars_Nums[15].Value);
            //int dVidaVeSogutmaInceTip_Son_px = cConfiguration.mm_to_pixel_cevir(MachinePars_ToPLC.dicMachinePars_Nums[16].Value);
            int dMontajDelikleriArasıBosluk_px = cConfiguration.mm_to_pixel_cevir(MachinePars_ToPLC.dicMachinePars_Nums[14].Value);

            double dBasTakozDisMesafesi_mm = MachinePars_ToPLC.dicMachinePars_Nums[9].Value;
            double dTakozDelikDisMesafesi_mm = MachinePars_ToPLC.dicMachinePars_Nums[10].Value;
            double dKosebentDelikDisMesafesi_mm = MachinePars_ToPLC.dicMachinePars_Nums[26].Value;
            double dManivelaDelikDisMesafesi_mm = MachinePars_ToPLC.dicMachinePars_Nums[11].Value;
            double dVidaVeSogutmaDisMesafesi_Bas_mm = MachinePars_ToPLC.dicMachinePars_Nums[12].Value;
            double dVidaVeSogutmaDisMesafesi_Son_mm = MachinePars_ToPLC.dicMachinePars_Nums[13].Value;
            double dVidaVeSogutmaInceTip_Bas_mm = MachinePars_ToPLC.dicMachinePars_Nums[15].Value;
            //double dVidaVeSogutmaInceTip_Son_mm = MachinePars_ToPLC.dicMachinePars_Nums[16].Value;
            double dMontajDelikleriArasıBosluk_mm = MachinePars_ToPLC.dicMachinePars_Nums[14].Value;

            dCap7Sol_Genislik_Kosebent = MachinePars_ToPLC.dicMachinePars_Nums[43].Value;
            dCap7Sag_Genislik_Kosebent = MachinePars_ToPLC.dicMachinePars_Nums[44].Value;

            int sagaKaydirmaDegeri_px = 68;
            int dPencerePos1_px = cConfiguration.mm_to_pixel_cevir(Pencere_Bir) + sagaKaydirmaDegeri_px;
            int dPencerePos2_px = cConfiguration.mm_to_pixel_cevir(Pencere_Iki) + sagaKaydirmaDegeri_px;
            int dPencerePos3_px = cConfiguration.mm_to_pixel_cevir(Pencere_Uc) + sagaKaydirmaDegeri_px;
            int dPencerePos4_px = cConfiguration.mm_to_pixel_cevir(Pencere_Dort) + sagaKaydirmaDegeri_px;
            int dPencerePos5_px = cConfiguration.mm_to_pixel_cevir(Pencere_Bes) + sagaKaydirmaDegeri_px;
            int dPencerePos6_px = cConfiguration.mm_to_pixel_cevir(Pencere_Alti) + sagaKaydirmaDegeri_px;

            double dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm = 40;
            double dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm = 40;

            int dVidaVeSogutmaDisMesafesi_Bas_AnaBos_px = cConfiguration.mm_to_pixel_cevir(dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm);
            int dVidaVeSogutmaDisMesafesi_Son_AnaBos_px = cConfiguration.mm_to_pixel_cevir(dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);

            //Yatay Köşe ile ilgili parametreler
            double dIcKöse_Offseti_mm = MachinePars_ToPLC.dicMachinePars_Nums[20].Value;
            int dIcKöse_Offseti_px = cConfiguration.mm_to_pixel_cevir(MachinePars_ToPLC.dicMachinePars_Nums[20].Value);
            double dYatayKose_DelikAraligi_mm = MachinePars_ToPLC.dicMachinePars_Nums[21].Value;
            double dDisKöse_Offseti_mm = MachinePars_ToPLC.dicMachinePars_Nums[22].Value;

            bool bVidaVeSogutmaInceTipAktif = MachinePars_ToPLC.dicMachinePars_Bools[2].Value;

            //if (bVidaVeSogutmaInceTipAktif)
            //{
            //    dVidaVeSogutmaInceTip_Bas_px = dVidaVeSogutmaInceTip_Bas_px;
            //}
            //else
            //{
            //    dVidaVeSogutmaInceTip_Bas_px = 0;
            //}

            dVidaVeSogutmaInceTip_Bas_px = bVidaVeSogutmaInceTipAktif == true ? dVidaVeSogutmaInceTip_Bas_px : 0;
            dVidaVeSogutmaInceTip_Bas_mm = bVidaVeSogutmaInceTipAktif == true ? dVidaVeSogutmaInceTip_Bas_mm : 0;

            bManivelaDeligiSolAktif = MachinePars_ToPLC.dicMachinePars_Bools[0].Value;
            bManivelaDeligiSağAktif = MachinePars_ToPLC.dicMachinePars_Bools[1].Value;

            int dManivelaDeligiBoy = 20;
            int d11x20DeligiBoy = 20;

            double dAnaBosaltmaBoy = 312.5;
            int dAnaBosaltmaBoy_px = cConfiguration.mm_to_pixel_cevir(dAnaBosaltmaBoy); //166 px
            int AnaBosaltmaSag_UstPanelArasıMesafe = 60;

            if (this.PencereAdedi == ePencereAdedi.pencere_Yok && !bYatayKöseLeft_Selected && !bYatayKöseRight_Selected) // Pencere Seçilmediyse ve Yatay Köşe Seçilmediyse
            {
                #region [////////////////////       70 - 109      \\\\\\\\\\\\\\\\\\\\]

                if (this.MmBoy >= 70 && this.MmBoy <= 109)
                {
                    uc_BasTakozSlotlari uc_BasTakozSon = new uc_BasTakozSlotlari(
                        new Point(dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                        CalculateBasTakozSon(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm, MmBoy));
                    this.panel_ust.Controls.Add(uc_BasTakozSon);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_BasTakozSon.VurmaPos,
                        EDelikTipi = DelikTipi.BasTakoz
                    });

                    uc_BasTakozSlotlari_Ters uc_BasTakozTersSon =
                        new uc_BasTakozSlotlari_Ters(new Point(dBasTakozDisMesafesi_px, this.panel_alt.Height / 2));
                    this.panel_alt.Controls.Add(uc_BasTakozTersSon);

                    uc_BasTakozSlotlari uc_BasTakozBas = new uc_BasTakozSlotlari(
                        new Point(this.panel_ust.Width - dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                        CalculateBasTakozBas(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm));
                    this.panel_ust.Controls.Add(uc_BasTakozBas);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_BasTakozBas.VurmaPos,
                        EDelikTipi = DelikTipi.BasTakoz
                    });

                    uc_BasTakozSlotlari_Ters uc_BasTakozTersBas =
                        new uc_BasTakozSlotlari_Ters(new Point(this.panel_alt.Width - dBasTakozDisMesafesi_px,
                            this.panel_alt.Height / 2));
                    this.panel_alt.Controls.Add(uc_BasTakozTersBas);

                    uc_Cap7_Sol uc_cap7BasUst =
                        new uc_Cap7_Sol(new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                            CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sol_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7BasUst);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7BasUst.GenislikPos,
                        dVurmaPos = uc_cap7BasUst.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sol
                    });

                    uc_Cap7_Sag uc_cap7BasAl =
                        new uc_Cap7_Sag(
                            new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height - this.panel_orta.Height / 4),
                            CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sag_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7BasAl);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7BasAl.GenislikPos,
                        dVurmaPos = uc_cap7BasAl.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sag
                    });

                    uc_Cap7_Sol uc_cap7SonUst =
                        new uc_Cap7_Sol(
                            new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                            CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sol_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7SonUst);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7SonUst.GenislikPos,
                        dVurmaPos = uc_cap7SonUst.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sol
                    });

                    uc_Cap7_Sag uc_cap7SonAlt = new uc_Cap7_Sag(
                        new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px,
                            this.panel_orta.Height - this.panel_orta.Height / 4),
                        CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sag_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7SonAlt);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7SonAlt.GenislikPos,
                        dVurmaPos = uc_cap7SonAlt.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sag
                    });

                }

                #endregion

                #region [////////////////////       110 - 149      \\\\\\\\\\\\\\\\\\\\]

                if (this.MmBoy >= 110 && this.MmBoy <= 149)
                {
                    uc_11x20Slot uc11X20SlotUst1 = new uc_11x20Slot(new Point(panel_ust.Width / 2, panel_ust.Height / 2),
                        Calculate11x20Orta(Mm_OncesindekiBoy,
                            CalculateYaymaAlanıOrta(dBasTakozDisMesafesi_mm, dBasTakozDisMesafesi_mm, MmBoy)));
                    this.panel_ust.Controls.Add(uc11X20SlotUst1);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc11X20SlotUst1.VurmaPos,
                        EDelikTipi = DelikTipi.Delik_11x20
                    });

                    uc_11x20Slot uc11X20SlotAlt = new uc_11x20Slot(new Point(panel_alt.Width / 2, panel_alt.Height / 2),
                        Calculate11x20Orta(Mm_OncesindekiBoy,
                            CalculateYaymaAlanıOrta(dBasTakozDisMesafesi_mm, dBasTakozDisMesafesi_mm, MmBoy)));
                    this.panel_alt.Controls.Add(uc11X20SlotAlt);

                    uc_BasTakozSlotlari uc_BasTakozSon = new uc_BasTakozSlotlari(
                        new Point(dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                        CalculateBasTakozSon(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm, MmBoy));
                    this.panel_ust.Controls.Add(uc_BasTakozSon);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_BasTakozSon.VurmaPos,
                        EDelikTipi = DelikTipi.BasTakoz
                    });

                    uc_BasTakozSlotlari_Ters uc_BasTakozTersSon =
                        new uc_BasTakozSlotlari_Ters(new Point(dBasTakozDisMesafesi_px, this.panel_alt.Height / 2));
                    this.panel_alt.Controls.Add(uc_BasTakozTersSon);

                    uc_BasTakozSlotlari uc_BasTakozBas = new uc_BasTakozSlotlari(
                        new Point(this.panel_ust.Width - dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                        CalculateBasTakozBas(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm));
                    this.panel_ust.Controls.Add(uc_BasTakozBas);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_BasTakozBas.VurmaPos,
                        EDelikTipi = DelikTipi.BasTakoz
                    });

                    uc_BasTakozSlotlari_Ters uc_BasTakozTersBas =
                        new uc_BasTakozSlotlari_Ters(new Point(this.panel_alt.Width - dBasTakozDisMesafesi_px,
                            this.panel_alt.Height / 2));
                    this.panel_alt.Controls.Add(uc_BasTakozTersBas);

                    uc_Cap7_Sol uc_cap7BasUst =
                        new uc_Cap7_Sol(new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                            CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sol_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7BasUst);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7BasUst.GenislikPos,
                        dVurmaPos = uc_cap7BasUst.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sol
                    });

                    uc_Cap7_Sag uc_cap7BasAl =
                        new uc_Cap7_Sag(
                            new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height - this.panel_orta.Height / 4),
                            CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sag_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7BasAl);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7BasAl.GenislikPos,
                        dVurmaPos = uc_cap7BasAl.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sag
                    });

                    uc_Cap7_Sol uc_cap7SonUst =
                        new uc_Cap7_Sol(
                            new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                            CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sol_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7SonUst);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7SonUst.GenislikPos,
                        dVurmaPos = uc_cap7SonUst.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sol
                    });

                    uc_Cap7_Sag uc_cap7SonAlt = new uc_Cap7_Sag(
                        new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px,
                            this.panel_orta.Height - this.panel_orta.Height / 4),
                        CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sag_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7SonAlt);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7SonAlt.GenislikPos,
                        dVurmaPos = uc_cap7SonAlt.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sag
                    });

                }

                #endregion

                #region [////////////////////       150 - 199      \\\\\\\\\\\\\\\\\\\\]

                if (this.MmBoy >= 150 && this.MmBoy <= 199)
                {
                    uc_11x20Slot uc11X20SlotUst1 = new uc_11x20Slot(new Point(panel_ust.Width / 2, panel_ust.Height / 2),
                        Calculate11x20Orta(Mm_OncesindekiBoy,
                            CalculateYaymaAlanıOrta(dBasTakozDisMesafesi_mm, dBasTakozDisMesafesi_mm, MmBoy)));
                    this.panel_ust.Controls.Add(uc11X20SlotUst1);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc11X20SlotUst1.VurmaPos,
                        EDelikTipi = DelikTipi.Delik_11x20
                    });

                    uc_11x20Slot uc11X20SlotAlt = new uc_11x20Slot(new Point(panel_alt.Width / 2, panel_alt.Height / 2),
                        Calculate11x20Orta(Mm_OncesindekiBoy,
                            CalculateYaymaAlanıOrta(dBasTakozDisMesafesi_mm, dBasTakozDisMesafesi_mm, MmBoy)));
                    this.panel_alt.Controls.Add(uc11X20SlotAlt);

                    uc_BasTakozSlotlari uc_BasTakozSon = new uc_BasTakozSlotlari(
                        new Point(dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                        CalculateBasTakozSon(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm, MmBoy));
                    this.panel_ust.Controls.Add(uc_BasTakozSon);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_BasTakozSon.VurmaPos,
                        EDelikTipi = DelikTipi.BasTakoz
                    });

                    uc_BasTakozSlotlari_Ters uc_BasTakozTersSon =
                        new uc_BasTakozSlotlari_Ters(new Point(dBasTakozDisMesafesi_px, this.panel_alt.Height / 2));
                    this.panel_alt.Controls.Add(uc_BasTakozTersSon);

                    uc_BasTakozSlotlari uc_BasTakozBas = new uc_BasTakozSlotlari(
                        new Point(this.panel_ust.Width - dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                        CalculateBasTakozBas(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm));
                    this.panel_ust.Controls.Add(uc_BasTakozBas);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_BasTakozBas.VurmaPos,
                        EDelikTipi = DelikTipi.BasTakoz
                    });

                    uc_BasTakozSlotlari_Ters uc_BasTakozTersBas =
                        new uc_BasTakozSlotlari_Ters(new Point(this.panel_alt.Width - dBasTakozDisMesafesi_px,
                            this.panel_alt.Height / 2));
                    this.panel_alt.Controls.Add(uc_BasTakozTersBas);

                    uc_Cap7_Sol uc_cap7BasUst =
                        new uc_Cap7_Sol(new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                            CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sol_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7BasUst);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7BasUst.GenislikPos,
                        dVurmaPos = uc_cap7BasUst.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sol
                    });

                    uc_Cap7_Sag uc_cap7BasAl =
                        new uc_Cap7_Sag(
                            new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height - this.panel_orta.Height / 4),
                            CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sag_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7BasAl);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7BasAl.GenislikPos,
                        dVurmaPos = uc_cap7BasAl.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sag
                    });

                    uc_Cap7_Sol uc_cap7SonUst =
                        new uc_Cap7_Sol(
                            new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                            CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sol_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7SonUst);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7SonUst.GenislikPos,
                        dVurmaPos = uc_cap7SonUst.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sol
                    });

                    uc_Cap7_Sag uc_cap7SonAlt = new uc_Cap7_Sag(
                        new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px,
                            this.panel_orta.Height - this.panel_orta.Height / 4),
                        CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sag_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7SonAlt);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7SonAlt.GenislikPos,
                        dVurmaPos = uc_cap7SonAlt.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sag
                    });

                    uc_Cap7_Sol uc_cap7_OrtaUst = new uc_Cap7_Sol(
                        new Point(this.panel_orta.Width / 2, this.panel_orta.Height / 4),
                        CalculateCap7Orta(Mm_OncesindekiBoy,
                            CalculateYaymaAlanıOrta(dBasTakozDisMesafesi_mm, dBasTakozDisMesafesi_mm, MmBoy)),
                        dCap7Sol_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7_OrtaUst);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7_OrtaUst.GenislikPos,
                        dVurmaPos = uc_cap7_OrtaUst.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sol
                    });

                    uc_Cap7_Sag uc_cap7_OrtaAlt = new uc_Cap7_Sag(
                        new Point(this.panel_orta.Width / 2, this.panel_orta.Height - this.panel_orta.Height / 4),
                        CalculateCap7Orta(Mm_OncesindekiBoy,
                            CalculateYaymaAlanıOrta(dBasTakozDisMesafesi_mm, dBasTakozDisMesafesi_mm, MmBoy)),
                        dCap7Sag_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7_OrtaAlt);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7_OrtaAlt.GenislikPos,
                        dVurmaPos = uc_cap7_OrtaAlt.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sag
                    });
                }

                #endregion

                #region [////////////////////       200 - 499      \\\\\\\\\\\\\\\\\\\\]
                if (this.MmBoy >= 200 && this.MmBoy <= 499)
                {
                    uc_ManivelaDeligi uc_ManivelaBas = new uc_ManivelaDeligi(
                        new Point(this.panel_ust.Width - dManivelaDelikDisMesafesi_px, (this.panel_ust.Height / 2) - 1),
                        CalculateManivelaBas(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm));

                    uc_11x20Slot uc11X20SlotUst = new uc_11x20Slot(new Point(panel_ust.Width / 2, panel_ust.Height / 2),
                        Calculate11x20Orta(Mm_OncesindekiBoy,
                            CalculateYaymaAlanıOrta(dBasTakozDisMesafesi_mm, dBasTakozDisMesafesi_mm, MmBoy)));

                    d11x20VeManivelaArasıMesafe = _11x20VeManivelaArasıMesafe(uc_ManivelaBas.VurmaPos,
                        uc11X20SlotUst.VurmaPos, dManivelaDeligiBoy, d11x20DeligiBoy);

                    ///////////////////////////////////////////////////    11x20    \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    if (bManivelaDeligiSağAktif || bManivelaDeligiSolAktif)
                    {
                        if (d11x20VeManivelaArasıMesafe > 0)
                        {
                            this.panel_ust.Controls.Add(uc11X20SlotUst);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = 0.0,
                                dVurmaPos = uc11X20SlotUst.VurmaPos,
                                EDelikTipi = DelikTipi.Delik_11x20
                            });
                            uc_11x20Slot uc11X20SlotAlt = new uc_11x20Slot(new Point(panel_alt.Width / 2, panel_alt.Height / 2),
                                Calculate11x20Orta(Mm_OncesindekiBoy,
                                    CalculateYaymaAlanıOrta(dBasTakozDisMesafesi_mm, dBasTakozDisMesafesi_mm, MmBoy)));
                            this.panel_alt.Controls.Add(uc11X20SlotAlt);
                        }
                    }
                    //////////////// cap 7 orta \\\\\\\\\\\\\\\\\
                    uc_Cap7_Sol ucCap7SolOrta = new uc_Cap7_Sol(new Point(panel_orta.Width / 2, this.panel_orta.Height / 4),
                                CalculateCap7Orta(Mm_OncesindekiBoy,
                                    CalculateYaymaAlanıOrta(dTakozDelikDisMesafesi_mm, dTakozDelikDisMesafesi_mm, MmBoy)), dCap7Sol_Genislik);
                    this.panel_orta.Controls.Add(ucCap7SolOrta);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = ucCap7SolOrta.GenislikPos,
                        dVurmaPos = ucCap7SolOrta.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sol
                    });
                    uc_Cap7_Sag ucCap7SagOrta = new uc_Cap7_Sag(new Point(panel_orta.Width / 2, panel_orta.Height - this.panel_orta.Height / 4),
                        CalculateCap7Orta(Mm_OncesindekiBoy,
                            CalculateYaymaAlanıOrta(dTakozDelikDisMesafesi_mm, dTakozDelikDisMesafesi_mm, MmBoy)), dCap7Sag_Genislik);
                    this.panel_orta.Controls.Add(ucCap7SagOrta);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = ucCap7SagOrta.GenislikPos,
                        dVurmaPos = ucCap7SagOrta.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sag
                    });

                    ///////////////////////////////////////     Manivela Delikleri Baş      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    //if (bManivelaDeligiSağAktif || bManivelaDeligiSolAktif)
                    //{

                    //    //fooCakismaDelete = new eDelikCakismaDeleteSubPart();
                    //    //fooCakismaDelete.EventFired();
                    //}
                    if (bManivelaDeligiSağAktif)
                    {
                        //    if (d11x20VeManivelaArasıMesafe > 0)
                        //    {
                        this.panel_ust.Controls.Add(uc_ManivelaBas);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {
                            dGenislikPos = 0.0,
                            dVurmaPos = uc_ManivelaBas.VurmaPos,
                            EDelikTipi = DelikTipi.Manivela
                        });

                        uc_ManivelaDeligi uc_ManivelaBasAlt = new uc_ManivelaDeligi(
                            new Point(this.panel_ust.Width - dManivelaDelikDisMesafesi_px,
                                (this.panel_alt.Height / 2) + 1),
                            CalculateManivelaBas(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm));
                        this.panel_alt.Controls.Add(uc_ManivelaBasAlt);
                    }

                    //}

                    ///////////////////////////////////////     Manivela Delikleri Son      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    uc_ManivelaDeligi uc_ManivelaSon = new uc_ManivelaDeligi(
                        new Point(dManivelaDelikDisMesafesi_px, (this.panel_ust.Height / 2) - 1),
                        CalculateManivelaSon(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm, MmBoy));

                    if (bManivelaDeligiSolAktif)
                    {
                        //    if (d11x20VeManivelaArasıMesafe > 0)
                        //    {
                        this.panel_ust.Controls.Add(uc_ManivelaSon);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {
                            dGenislikPos = 0.0,
                            dVurmaPos = uc_ManivelaSon.VurmaPos,
                            EDelikTipi = DelikTipi.Manivela
                        });

                        uc_ManivelaDeligi uc_ManivelaSonAlt = new uc_ManivelaDeligi(
                            new Point(dManivelaDelikDisMesafesi_px, (this.panel_alt.Height / 2) + 1),
                            CalculateManivelaSon(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm, MmBoy));
                        this.panel_alt.Controls.Add(uc_ManivelaSonAlt);
                    }


                    //}

                    ///////////////////////////////////////     Baş Takoz Slotları      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    uc_BasTakozSlotlari uc_BasTakozSon = new uc_BasTakozSlotlari(
                        new Point(dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                        CalculateBasTakozSon(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm, MmBoy));
                    this.panel_ust.Controls.Add(uc_BasTakozSon);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_BasTakozSon.VurmaPos,
                        EDelikTipi = DelikTipi.BasTakoz
                    });

                    uc_BasTakozSlotlari_Ters uc_BasTakozTersSon =
                        new uc_BasTakozSlotlari_Ters(new Point(dBasTakozDisMesafesi_px, this.panel_alt.Height / 2));
                    this.panel_alt.Controls.Add(uc_BasTakozTersSon);

                    uc_BasTakozSlotlari uc_BasTakozBas = new uc_BasTakozSlotlari(
                        new Point(this.panel_ust.Width - dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                        CalculateBasTakozBas(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm));
                    this.panel_ust.Controls.Add(uc_BasTakozBas);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_BasTakozBas.VurmaPos,
                        EDelikTipi = DelikTipi.BasTakoz
                    });

                    uc_BasTakozSlotlari_Ters uc_BasTakozTersBas =
                        new uc_BasTakozSlotlari_Ters(new Point(this.panel_alt.Width - dBasTakozDisMesafesi_px,
                            this.panel_alt.Height / 2));
                    this.panel_alt.Controls.Add(uc_BasTakozTersBas);

                    uc_Cap7_Sol uc_cap7BasUst =
                        new uc_Cap7_Sol(new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                            CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sol_Genislik);
                    this.panel_orta.Controls.Add(uc_cap7BasUst);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7BasUst.GenislikPos,
                        dVurmaPos = uc_cap7BasUst.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sol
                    });

                    uc_Cap7_Sag uc_cap7BasAl =
                        new uc_Cap7_Sag(
                            new Point(dTakozDelikDisMesafesi_px,
                                this.panel_orta.Height - this.panel_orta.Height / 4),
                            CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sag_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7BasAl);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7BasAl.GenislikPos,
                        dVurmaPos = uc_cap7BasAl.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sag
                    });

                    uc_Cap7_Sol uc_cap7SonUst =
                        new uc_Cap7_Sol(
                            new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px,
                                this.panel_orta.Height / 4),
                            CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy),
                            dCap7Sol_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7SonUst);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7SonUst.GenislikPos,
                        dVurmaPos = uc_cap7SonUst.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sol
                    });

                    uc_Cap7_Sag uc_cap7SonAlt = new uc_Cap7_Sag(
                        new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px,
                            this.panel_orta.Height - this.panel_orta.Height / 4),
                        CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sag_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7SonAlt);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7SonAlt.GenislikPos,
                        dVurmaPos = uc_cap7SonAlt.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sag
                    });

                    ///////////////////////////////////////     50mm Sonrasına Vurulacak 11x20 ve Cap7 Delikleri Baş      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    uc_11x20Slot uc_11x20SlotBas_50mm = new uc_11x20Slot(
                        new Point(this.panel_ust.Width - dVidaVeSogutmaDisMesafesi_Bas_px,
                            this.panel_ust.Height / 2),
                        Calculate11x20(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm));
                    this.panel_ust.Controls.Add(uc_11x20SlotBas_50mm);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_11x20SlotBas_50mm.VurmaPos,
                        EDelikTipi = DelikTipi.Delik_11x20
                    });

                    uc_11x20Slot uc_11x20SlotTersBas_50mm = new uc_11x20Slot(
                        new Point(this.panel_alt.Width - dVidaVeSogutmaDisMesafesi_Bas_px,
                            this.panel_alt.Height / 2),
                        Calculate11x20(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm));
                    this.panel_alt.Controls.Add(uc_11x20SlotTersBas_50mm);

                    uc_Cap7_Sol uc_cap7BasUst_50mm = new uc_Cap7_Sol(
                        new Point(panel_ust.Width - dVidaVeSogutmaDisMesafesi_Bas_px, this.panel_orta.Height / 4),
                        CalculateCap7Bas(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm), dCap7Sol_Genislik);
                    this.panel_orta.Controls.Add(uc_cap7BasUst_50mm);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7BasUst_50mm.GenislikPos,
                        dVurmaPos = uc_cap7BasUst_50mm.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sol
                    });

                    uc_Cap7_Sag uc_cap7BasAlt_50mm = new uc_Cap7_Sag(
                        new Point(panel_alt.Width - dVidaVeSogutmaDisMesafesi_Bas_px,
                            this.panel_orta.Height - this.panel_orta.Height / 4),
                        CalculateCap7Bas(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm), dCap7Sag_Genislik);
                    this.panel_orta.Controls.Add(uc_cap7BasAlt_50mm);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7BasAlt_50mm.GenislikPos,
                        dVurmaPos = uc_cap7BasAlt_50mm.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sag
                    });

                    ///////////////////////////////////////     50mm Sonrasına Vurulacak 11x20 ve Cap7 Delikleri Son      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    uc_11x20Slot uc_11x20SlotSon_50mm = new uc_11x20Slot(
                        new Point(dVidaVeSogutmaDisMesafesi_Son_px, this.panel_ust.Height / 2),
                        Calculate11x20(Mm_OncesindekiBoy, MmBoy - dVidaVeSogutmaDisMesafesi_Son_mm));
                    this.panel_ust.Controls.Add(uc_11x20SlotSon_50mm);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_11x20SlotSon_50mm.VurmaPos,
                        EDelikTipi = DelikTipi.Delik_11x20
                    });

                    uc_11x20Slot uc_11x20SlotTersSon_50mm = new uc_11x20Slot(
                        new Point(dVidaVeSogutmaDisMesafesi_Son_px, this.panel_alt.Height / 2),
                        Calculate11x20(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Son_mm));
                    this.panel_alt.Controls.Add(uc_11x20SlotTersSon_50mm);

                    /////////
                    uc_Cap7_Sol uc_cap7SonUst_50mm = new uc_Cap7_Sol(
                        new Point(dVidaVeSogutmaDisMesafesi_Son_px, this.panel_orta.Height / 4),
                        CalculateCap7Son(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Son_mm, MmBoy),
                        dCap7Sol_Genislik);
                    this.panel_orta.Controls.Add(uc_cap7SonUst_50mm);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7SonUst_50mm.GenislikPos,
                        dVurmaPos = uc_cap7SonUst_50mm.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sol
                    });

                    uc_Cap7_Sag uc_cap7SonAlt_50mm = new uc_Cap7_Sag(
                        new Point(dVidaVeSogutmaDisMesafesi_Son_px,
                            this.panel_orta.Height - this.panel_orta.Height / 4),
                        CalculateCap7Son(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Son_mm, MmBoy),
                        dCap7Sag_Genislik);
                    this.panel_orta.Controls.Add(uc_cap7SonAlt_50mm);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7SonAlt_50mm.GenislikPos,
                        dVurmaPos = uc_cap7SonAlt_50mm.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sag
                    });

                    if (bManivelaDeligiSağAktif || bManivelaDeligiSolAktif)
                    {
                        if (d11x20VeManivelaArasıMesafe < 0)
                        {
                            //MyMessageBox.ShowMessageBox("Manivela deliği ile 11x20 slot deliği çakışmıştır.");
                            //returned_ListOfDelik.Clear();
                            //this.panel_ust.Controls.Clear();
                            //this.panel_orta.Controls.Clear();
                            //this.panel_alt.Controls.Clear();
                        }
                    }
                }
                #endregion

                #region [////////////////////       500 - 109      \\\\\\\\\\\\\\\\\\\\]

                if (this.MmBoy >= 500)
                {
                    uc_BasTakozSlotlari uc_BasTakozSon = new uc_BasTakozSlotlari(
                        new Point(dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                        CalculateBasTakozSon(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm, MmBoy));
                    this.panel_ust.Controls.Add(uc_BasTakozSon);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_BasTakozSon.VurmaPos,
                        EDelikTipi = DelikTipi.BasTakoz
                    });

                    uc_BasTakozSlotlari_Ters uc_BasTakozTersSon =
                        new uc_BasTakozSlotlari_Ters(new Point(dBasTakozDisMesafesi_px, this.panel_alt.Height / 2));
                    this.panel_alt.Controls.Add(uc_BasTakozTersSon);

                    uc_BasTakozSlotlari uc_BasTakozBas = new uc_BasTakozSlotlari(
                        new Point(this.panel_ust.Width - dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                        CalculateBasTakozBas(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm));
                    this.panel_ust.Controls.Add(uc_BasTakozBas);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_BasTakozBas.VurmaPos,
                        EDelikTipi = DelikTipi.BasTakoz
                    });

                    uc_BasTakozSlotlari_Ters uc_BasTakozTersBas =
                        new uc_BasTakozSlotlari_Ters(new Point(this.panel_alt.Width - dBasTakozDisMesafesi_px,
                            this.panel_alt.Height / 2));
                    this.panel_alt.Controls.Add(uc_BasTakozTersBas);

                    uc_Cap7_Sol uc_cap7BasUst =
                        new uc_Cap7_Sol(new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                            CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sol_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7BasUst);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7BasUst.GenislikPos,
                        dVurmaPos = uc_cap7BasUst.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sol
                    });

                    uc_Cap7_Sag uc_cap7BasAlt =
                        new uc_Cap7_Sag(
                            new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height - this.panel_orta.Height / 4),
                            CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sag_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7BasAlt);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7BasAlt.GenislikPos,
                        dVurmaPos = uc_cap7BasAlt.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sag
                    });

                    uc_Cap7_Sol uc_cap7SonUst =
                        new uc_Cap7_Sol(
                            new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                            CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sol_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7SonUst);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7SonUst.GenislikPos,
                        dVurmaPos = uc_cap7SonUst.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sol
                    });

                    uc_Cap7_Sag uc_cap7SonAlt = new uc_Cap7_Sag(
                        new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px,
                            this.panel_orta.Height - this.panel_orta.Height / 4),
                        CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sag_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7SonAlt);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7SonAlt.GenislikPos,
                        dVurmaPos = uc_cap7SonAlt.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sag
                    });

                    ///////////////////////////////////////     50mm Sonrasına Vurulacak 11x20 ve Cap7 Delikleri Baş      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    uc_11x20Slot uc_11x20SlotBas_50mm =
                        new uc_11x20Slot(
                            new Point(this.panel_ust.Width - dVidaVeSogutmaDisMesafesi_Bas_px,
                                this.panel_ust.Height / 2),
                            Calculate11x20(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm));
                    this.panel_ust.Controls.Add(uc_11x20SlotBas_50mm);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_11x20SlotBas_50mm.VurmaPos,
                        EDelikTipi = DelikTipi.Delik_11x20
                    });

                    uc_11x20Slot uc_11x20SlotTersBas_50mm = new uc_11x20Slot(
                        new Point(this.panel_alt.Width - dVidaVeSogutmaDisMesafesi_Bas_px, this.panel_alt.Height / 2),
                        Calculate11x20(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm));
                    this.panel_alt.Controls.Add(uc_11x20SlotTersBas_50mm);

                    ///////
                    uc_Cap7_Sol uc_cap7BasUst_50mm = new uc_Cap7_Sol(
                        new Point(panel_ust.Width - dVidaVeSogutmaDisMesafesi_Bas_px, this.panel_orta.Height / 4),
                        CalculateCap7Bas(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm), dCap7Sol_Genislik);
                    this.panel_orta.Controls.Add(uc_cap7BasUst_50mm);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7BasUst_50mm.GenislikPos,
                        dVurmaPos = uc_cap7BasUst_50mm.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sol
                    });

                    uc_Cap7_Sag uc_cap7BasAlt_50mm = new uc_Cap7_Sag(
                        new Point(panel_alt.Width - dVidaVeSogutmaDisMesafesi_Bas_px,
                            this.panel_orta.Height - this.panel_orta.Height / 4),
                        CalculateCap7Bas(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm), dCap7Sag_Genislik);
                    this.panel_orta.Controls.Add(uc_cap7BasAlt_50mm);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7BasAlt_50mm.GenislikPos,
                        dVurmaPos = uc_cap7BasAlt_50mm.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sag
                    });

                    ///////////////////////////////////////     50mm Sonrasına Vurulacak 11x20 ve Cap7 Delikleri Son      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    uc_11x20Slot uc_11x20SlotSon_50mm =
                        new uc_11x20Slot(new Point(dVidaVeSogutmaDisMesafesi_Son_px, this.panel_ust.Height / 2),
                            Calculate11x20(Mm_OncesindekiBoy, MmBoy - dVidaVeSogutmaDisMesafesi_Son_mm));
                    this.panel_ust.Controls.Add(uc_11x20SlotSon_50mm);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_11x20SlotSon_50mm.VurmaPos,
                        EDelikTipi = DelikTipi.Delik_11x20
                    });

                    uc_11x20Slot uc_11x20SlotTersSon_50mm = new uc_11x20Slot(
                        new Point(dVidaVeSogutmaDisMesafesi_Son_px, this.panel_alt.Height / 2),
                        Calculate11x20(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Son_mm));
                    this.panel_alt.Controls.Add(uc_11x20SlotTersSon_50mm);

                    /////////
                    uc_Cap7_Sol uc_cap7SonUst_50mm = new uc_Cap7_Sol(
                        new Point(dVidaVeSogutmaDisMesafesi_Son_px, this.panel_orta.Height / 4),
                        CalculateCap7Son(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Son_mm, MmBoy),
                        dCap7Sol_Genislik);
                    this.panel_orta.Controls.Add(uc_cap7SonUst_50mm);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7SonUst_50mm.GenislikPos,
                        dVurmaPos = uc_cap7SonUst_50mm.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sol
                    });

                    uc_Cap7_Sag uc_cap7SonAlt_50mm = new uc_Cap7_Sag(
                        new Point(dVidaVeSogutmaDisMesafesi_Son_px,
                            this.panel_orta.Height - this.panel_orta.Height / 4),
                        CalculateCap7Son(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Son_mm, MmBoy),
                        dCap7Sag_Genislik);
                    this.panel_orta.Controls.Add(uc_cap7SonAlt_50mm);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7SonAlt_50mm.GenislikPos,
                        dVurmaPos = uc_cap7SonAlt_50mm.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sag
                    });

                    /////////////////////////////////////     Manivela Delikleri Baş      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    if (bManivelaDeligiSağAktif)
                    {
                        uc_ManivelaDeligi uc_ManivelaBas1 = new uc_ManivelaDeligi(
                            new Point(this.panel_ust.Width - dManivelaDelikDisMesafesi_px,
                                (this.panel_ust.Height / 2) - 1),
                            CalculateManivelaBas(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm));
                        this.panel_ust.Controls.Add(uc_ManivelaBas1);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {
                            dGenislikPos = 0.0,
                            dVurmaPos = uc_ManivelaBas1.VurmaPos,
                            EDelikTipi = DelikTipi.Manivela
                        });

                        uc_ManivelaDeligi uc_ManivelaBasAlt = new uc_ManivelaDeligi(
                            new Point(this.panel_ust.Width - dManivelaDelikDisMesafesi_px,
                                (this.panel_alt.Height / 2) + 1),
                            CalculateManivelaBas(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm));
                        this.panel_alt.Controls.Add(uc_ManivelaBasAlt);
                    }

                    /////////////////////////////////////     Manivela Delikleri Son      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    if (bManivelaDeligiSolAktif)
                    {
                        uc_ManivelaDeligi uc_ManivelaSon = new uc_ManivelaDeligi(
                            new Point(dManivelaDelikDisMesafesi_px, (this.panel_ust.Height / 2) - 1),
                            CalculateManivelaSon(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm, MmBoy));
                        this.panel_ust.Controls.Add(uc_ManivelaSon);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {
                            dGenislikPos = 0.0,
                            dVurmaPos = uc_ManivelaSon.VurmaPos,
                            EDelikTipi = DelikTipi.Manivela
                        });

                        uc_ManivelaDeligi uc_ManivelaSonAlt = new uc_ManivelaDeligi(
                            new Point(dManivelaDelikDisMesafesi_px, (this.panel_alt.Height / 2) + 1),
                            CalculateManivelaSon(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm, MmBoy));
                        this.panel_alt.Controls.Add(uc_ManivelaSonAlt);
                    }

                    ///////////////////////////////////////     Delik Aralık Adedi      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    delikAralıgı = CalculateDelikAralıgı(CalculateYaymaAlanı(dVidaVeSogutmaDisMesafesi_Bas_mm,
                        dVidaVeSogutmaDisMesafesi_Son_mm, MmBoy), dMontajDelikleriArasıBosluk_mm); //190

                    int delikAralıgı_px = cConfiguration.mm_to_pixel_cevir(delikAralıgı);

                    delikAralıkAdedi = CalculateDelikAralıkAdedi(
                        CalculateYaymaAlanı(dVidaVeSogutmaDisMesafesi_Bas_mm, dVidaVeSogutmaDisMesafesi_Son_mm, MmBoy),
                        dMontajDelikleriArasıBosluk_mm);

                    for (int i = 1; i < delikAralıkAdedi; i++)
                    {
                        if (i % 2 == 0)
                        {
                            uc_11x20Slot uc_11x20YaymaUst = new uc_11x20Slot(
                                new Point(dVidaVeSogutmaDisMesafesi_Bas_px - dVidaVeSogutmaInceTip_Bas_px + (i * delikAralıgı_px),
                                    this.panel_ust.Height / 2),
                                CalculateCap7Yayma(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm - dVidaVeSogutmaInceTip_Bas_mm,
                                    i * delikAralıgı) - KalipMesafeleri.Cap7 + KalipMesafeleri.Delik_11x20);

                            this.panel_ust.Controls.Add(uc_11x20YaymaUst);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = 0.0,
                                dVurmaPos = uc_11x20YaymaUst.VurmaPos,
                                EDelikTipi = DelikTipi.Delik_11x20
                            });

                            uc_11x20Slot uc_11x20YaymaAlt = new uc_11x20Slot(
                                new Point(dVidaVeSogutmaDisMesafesi_Bas_px - dVidaVeSogutmaInceTip_Bas_px + (i * delikAralıgı_px),
                                    this.panel_alt.Height / 2),
                                CalculateCap7Yayma(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm - dVidaVeSogutmaInceTip_Bas_mm, i * delikAralıgı));

                            this.panel_alt.Controls.Add(uc_11x20YaymaAlt);

                            uc_Cap7_Sol uc_cap7SolYaymaCiftBas = new uc_Cap7_Sol(
                                new Point(dVidaVeSogutmaDisMesafesi_Bas_px - dVidaVeSogutmaInceTip_Bas_px + (i * delikAralıgı_px),
                                    this.panel_orta.Height / 4),
                                CalculateCap7Yayma(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm - dVidaVeSogutmaInceTip_Bas_mm,
                                    i * delikAralıgı), dCap7Sol_Genislik);

                            this.panel_orta.Controls.Add(uc_cap7SolYaymaCiftBas);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = dCap7Sol_Genislik,
                                dVurmaPos = uc_cap7SolYaymaCiftBas.VurmaPos,
                                EDelikTipi = DelikTipi.Cap7Sol
                            });

                            uc_Cap7_Sag uc_cap7SolYaymaCiftSon = new uc_Cap7_Sag(
                                new Point(dVidaVeSogutmaDisMesafesi_Bas_px - dVidaVeSogutmaInceTip_Bas_px + (i * delikAralıgı_px),
                                    panel_orta.Height - this.panel_orta.Height / 4),
                                CalculateCap7Yayma(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm - dVidaVeSogutmaInceTip_Bas_mm,
                                    i * delikAralıgı), dCap7Sag_Genislik);

                            this.panel_orta.Controls.Add(uc_cap7SolYaymaCiftSon);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = dCap7Sag_Genislik,
                                dVurmaPos = uc_cap7SolYaymaCiftSon.VurmaPos,
                                EDelikTipi = DelikTipi.Cap7Sag
                            });
                        }
                        else
                        {
                            uc_11x20Slot uc_11x20YaymaUst = new uc_11x20Slot(
                                new Point(dVidaVeSogutmaDisMesafesi_Bas_px - dVidaVeSogutmaInceTip_Bas_px + (i * delikAralıgı_px),
                                    this.panel_ust.Height / 2),
                                CalculateCap7Yayma(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm - dVidaVeSogutmaInceTip_Bas_mm,
                                    i * delikAralıgı) - KalipMesafeleri.Cap7 + KalipMesafeleri.Delik_11x20);

                            this.panel_ust.Controls.Add(uc_11x20YaymaUst);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = 0.0,
                                dVurmaPos = uc_11x20YaymaUst.VurmaPos,
                                EDelikTipi = DelikTipi.Delik_11x20
                            });

                            uc_11x20Slot uc_11x20YaymaAlt = new uc_11x20Slot(
                                new Point(dVidaVeSogutmaDisMesafesi_Bas_px - dVidaVeSogutmaInceTip_Bas_px + (i * delikAralıgı_px),
                                    this.panel_alt.Height / 2),
                                CalculateCap7Yayma(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm - dVidaVeSogutmaInceTip_Bas_mm,
                                    i * delikAralıgı));

                            this.panel_alt.Controls.Add(uc_11x20YaymaAlt);

                            uc_Cap7_Sol uc_cap7SolYaymaUst = new uc_Cap7_Sol(
                                new Point(dVidaVeSogutmaDisMesafesi_Bas_px - dVidaVeSogutmaInceTip_Bas_px + (i * delikAralıgı_px),
                                    this.panel_orta.Height / 4),
                                CalculateCap7Yayma(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm - dVidaVeSogutmaInceTip_Bas_mm,
                                    i * delikAralıgı), dCap7Sol_Genislik);

                            this.panel_orta.Controls.Add(uc_cap7SolYaymaUst);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = dCap7Sol_Genislik,
                                dVurmaPos = uc_cap7SolYaymaUst.VurmaPos,
                                EDelikTipi = DelikTipi.Cap7Sol
                            });

                        }
                    }
                }

                #endregion
            }

            #region [////////////////////        Plug-In      \\\\\\\\\\\\\\\\\\\\]

            #region [LIMITS]
            if (this.PencereAdedi == ePencereAdedi.pencere_Bir)
            {
                //1 Pencere için
                pencere_Bir_MinLimit = Limit_PencereMin(pencere_Bir, dAnaBosaltmaBoy,
                   AnaBosaltmaSag_UstPanelArasıMesafe, dVidaVeSogutmaDisMesafesi_Bas_mm, bManivelaDeligiSağAktif,
                   dManivelaDelikDisMesafesi_mm);
                pencere_Bir_MaxLimit = Limit_PencereMax(pencere_Bir, dAnaBosaltmaBoy,
                   dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, dVidaVeSogutmaDisMesafesi_Son_mm, bManivelaDeligiSolAktif,
                   dManivelaDelikDisMesafesi_mm);
            }
            if (this.PencereAdedi == ePencereAdedi.pencere_Iki)
            {
                //1 Pencere için
                pencere_Bir_MinLimit = Limit_PencereMin(pencere_Bir, dAnaBosaltmaBoy,
                   AnaBosaltmaSag_UstPanelArasıMesafe, dVidaVeSogutmaDisMesafesi_Bas_mm, bManivelaDeligiSağAktif,
                   dManivelaDelikDisMesafesi_mm);
                //2 Pencere için
                pencereArasılimit_2 = Limit_PencerelerArası(pencere_Iki, pencere_Bir, dAnaBosaltmaBoy,
                   AnaBosaltmaSag_UstPanelArasıMesafe, dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);
                pencere_Iki_MaxLimit = Limit_PencereMax(pencere_Iki, dAnaBosaltmaBoy,
                   dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, dVidaVeSogutmaDisMesafesi_Son_mm, bManivelaDeligiSolAktif,
                   dManivelaDelikDisMesafesi_mm);
            }
            if (this.PencereAdedi == ePencereAdedi.pencere_Uc)
            {
                //1 Pencere için
                pencere_Bir_MinLimit = Limit_PencereMin(pencere_Bir, dAnaBosaltmaBoy,
                   AnaBosaltmaSag_UstPanelArasıMesafe, dVidaVeSogutmaDisMesafesi_Bas_mm, bManivelaDeligiSağAktif,
                   dManivelaDelikDisMesafesi_mm);
                //2 Pencere için
                pencereArasılimit_2 = Limit_PencerelerArası(pencere_Iki, pencere_Bir, dAnaBosaltmaBoy,
                   AnaBosaltmaSag_UstPanelArasıMesafe, dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);
                //3 Pencere için
                pencereArasılimit_3 = Limit_PencerelerArası(pencere_Uc, pencere_Iki, dAnaBosaltmaBoy,
                   AnaBosaltmaSag_UstPanelArasıMesafe, dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);
                pencere_Uc_MaxLimit = Limit_PencereMax(pencere_Uc, dAnaBosaltmaBoy,
                   dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, dVidaVeSogutmaDisMesafesi_Son_mm, bManivelaDeligiSolAktif,
                   dManivelaDelikDisMesafesi_mm);
            }
            if (this.PencereAdedi == ePencereAdedi.pencere_Dort)
            {
                //1 Pencere için
                pencere_Bir_MinLimit = Limit_PencereMin(pencere_Bir, dAnaBosaltmaBoy,
                   AnaBosaltmaSag_UstPanelArasıMesafe, dVidaVeSogutmaDisMesafesi_Bas_mm, bManivelaDeligiSağAktif,
                   dManivelaDelikDisMesafesi_mm);
                //2 Pencere için
                pencereArasılimit_2 = Limit_PencerelerArası(pencere_Iki, pencere_Bir, dAnaBosaltmaBoy,
                   AnaBosaltmaSag_UstPanelArasıMesafe, dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);
                //3 Pencere için
                pencereArasılimit_3 = Limit_PencerelerArası(pencere_Uc, pencere_Iki, dAnaBosaltmaBoy,
                   AnaBosaltmaSag_UstPanelArasıMesafe, dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);
                //4 Pencere için
                pencereArasılimit_4 = Limit_PencerelerArası(pencere_Dort, pencere_Uc, dAnaBosaltmaBoy,
                   AnaBosaltmaSag_UstPanelArasıMesafe, dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);
                pencere_Dort_MaxLimit = Limit_PencereMax(pencere_Dort, dAnaBosaltmaBoy,
                   dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, dVidaVeSogutmaDisMesafesi_Son_mm, bManivelaDeligiSolAktif,
                   dManivelaDelikDisMesafesi_mm);
            }
            if (this.PencereAdedi == ePencereAdedi.pencere_Bes)
            {
                //1 Pencere için
                pencere_Bir_MinLimit = Limit_PencereMin(pencere_Bir, dAnaBosaltmaBoy,
                   AnaBosaltmaSag_UstPanelArasıMesafe, dVidaVeSogutmaDisMesafesi_Bas_mm, bManivelaDeligiSağAktif,
                   dManivelaDelikDisMesafesi_mm);
                //2 Pencere için
                pencereArasılimit_2 = Limit_PencerelerArası(pencere_Iki, pencere_Bir, dAnaBosaltmaBoy,
                   AnaBosaltmaSag_UstPanelArasıMesafe, dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);
                //3 Pencere için
                pencereArasılimit_3 = Limit_PencerelerArası(pencere_Uc, pencere_Iki, dAnaBosaltmaBoy,
                   AnaBosaltmaSag_UstPanelArasıMesafe, dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);
                //4 Pencere için
                pencereArasılimit_4 = Limit_PencerelerArası(pencere_Dort, pencere_Uc, dAnaBosaltmaBoy,
                   AnaBosaltmaSag_UstPanelArasıMesafe, dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);
                //5 Pencere için
                pencereArasılimit_5 = Limit_PencerelerArası(pencere_Bes, pencere_Dort, dAnaBosaltmaBoy,
                   AnaBosaltmaSag_UstPanelArasıMesafe, dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);
                pencere_Bes_MaxLimit = Limit_PencereMax(pencere_Bes, dAnaBosaltmaBoy,
                   dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, dVidaVeSogutmaDisMesafesi_Son_mm, bManivelaDeligiSolAktif,
                   dManivelaDelikDisMesafesi_mm);
            }
            if (this.PencereAdedi == ePencereAdedi.pencere_Alti)
            {
                //1 Pencere için
                pencere_Bir_MinLimit = Limit_PencereMin(pencere_Bir, dAnaBosaltmaBoy,
                   AnaBosaltmaSag_UstPanelArasıMesafe, dVidaVeSogutmaDisMesafesi_Bas_mm, bManivelaDeligiSağAktif,
                   dManivelaDelikDisMesafesi_mm);
                //2 Pencere için
                pencereArasılimit_2 = Limit_PencerelerArası(pencere_Iki, pencere_Bir, dAnaBosaltmaBoy,
                   AnaBosaltmaSag_UstPanelArasıMesafe, dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);
                //3 Pencere için
                pencereArasılimit_3 = Limit_PencerelerArası(pencere_Uc, pencere_Iki, dAnaBosaltmaBoy,
                   AnaBosaltmaSag_UstPanelArasıMesafe, dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);
                //4 Pencere için
                pencereArasılimit_4 = Limit_PencerelerArası(pencere_Dort, pencere_Uc, dAnaBosaltmaBoy,
                   AnaBosaltmaSag_UstPanelArasıMesafe, dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);
                //5 Pencere için
                pencereArasılimit_5 = Limit_PencerelerArası(pencere_Bes, pencere_Dort, dAnaBosaltmaBoy,
                   AnaBosaltmaSag_UstPanelArasıMesafe, dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);
                //6 Pencere için
                pencereArasılimit_6 = Limit_PencerelerArası(pencere_Alti, pencere_Bes, dAnaBosaltmaBoy,
                   AnaBosaltmaSag_UstPanelArasıMesafe, dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);
                pencere_Alti_MaxLimit = Limit_PencereMax(pencere_Alti, dAnaBosaltmaBoy,
                   dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, dVidaVeSogutmaDisMesafesi_Son_mm, bManivelaDeligiSolAktif,
                   dManivelaDelikDisMesafesi_mm);
            }
            #endregion

            #region [////////////////////        pencere_Bir      \\\\\\\\\\\\\\\\\\\\]

            if (this.PencereAdedi == ePencereAdedi.pencere_Bir && this.MmBoy > 0 && pencere_Bir_MinLimit > 0 &&
                pencere_Bir_MaxLimit > 0 && !bYatayKöseLeft_Selected && !bYatayKöseRight_Selected)
            {
                #region [Baş Takoz ve Çap7'ler]
                uc_BasTakozSlotlari uc_BasTakozSon_PlugIn = new uc_BasTakozSlotlari(
                    new Point(dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                    CalculateBasTakozSon(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm, MmBoy));
                this.panel_ust.Controls.Add(uc_BasTakozSon_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = 0.0,
                    dVurmaPos = uc_BasTakozSon_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.BasTakoz
                });

                uc_BasTakozSlotlari_Ters uc_BasTakozTersSon_PlugIn =
                    new uc_BasTakozSlotlari_Ters(new Point(dBasTakozDisMesafesi_px, this.panel_alt.Height / 2));
                this.panel_alt.Controls.Add(uc_BasTakozTersSon_PlugIn);

                uc_BasTakozSlotlari uc_BasTakozBas_PlugIn = new uc_BasTakozSlotlari(
                    new Point(this.panel_ust.Width - dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                    CalculateBasTakozBas(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm));
                this.panel_ust.Controls.Add(uc_BasTakozBas_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = 0.0,
                    dVurmaPos = uc_BasTakozBas_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.BasTakoz
                });

                uc_BasTakozSlotlari_Ters uc_BasTakozTersBas_PlugIn =
                    new uc_BasTakozSlotlari_Ters(new Point(this.panel_alt.Width - dBasTakozDisMesafesi_px,
                        this.panel_alt.Height / 2));
                this.panel_alt.Controls.Add(uc_BasTakozTersBas_PlugIn);

                uc_Cap7_Sol uc_cap7BasUst_PlugIn =
                    new uc_Cap7_Sol(new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                        CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sol_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7BasUst_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7BasUst_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7BasUst_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sol
                });

                uc_Cap7_Sag uc_cap7BasAlt_PlugIn =
                    new uc_Cap7_Sag(
                        new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height - this.panel_orta.Height / 4),
                        CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sag_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7BasAlt_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7BasAlt_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7BasAlt_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sag
                });

                uc_Cap7_Sol uc_cap7SonUst_PlugIn =
                    new uc_Cap7_Sol(
                        new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                        CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sol_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7SonUst_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7SonUst_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7SonUst_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sol
                });

                uc_Cap7_Sag uc_cap7SonAlt_PlugIn = new uc_Cap7_Sag(
                    new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px,
                        this.panel_orta.Height - this.panel_orta.Height / 4),
                    CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sag_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7SonAlt_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7SonAlt_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7SonAlt_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sag
                });

                #endregion

                #region [50mm Sonrasına Vurulacak 11x20 ve Cap7 Delikleri]

                if (!b11x20VeCap7Disable_Min)
                {
                    ///////////////////////////////////////     50mm Sonrasına Vurulacak 11x20 ve Cap7 Delikleri Baş      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    List<arrProductionElement> listReturned11x20VeCap7 = BasaVurulacakCap7Ve11x20Delikleri(dVidaVeSogutmaDisMesafesi_Bas_px, dVidaVeSogutmaDisMesafesi_Bas_mm);
                    foreach (var item in listReturned11x20VeCap7)
                    {
                        returned_ListOfDelik.Add(item);
                    }
                }
                if (!b11x20VeCap7Disable_Max)
                {
                    /////////////////////////////////////     50mm Sonrasına Vurulacak 11x20 ve Cap7 Delikleri Son      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    List<arrProductionElement> listReturned11x20VeCap7 = SonaVurulacakCap7Ve11x20Delikleri(dVidaVeSogutmaDisMesafesi_Son_px, dVidaVeSogutmaDisMesafesi_Son_mm);
                    foreach (var item in listReturned11x20VeCap7)
                    {
                        returned_ListOfDelik.Add(item);
                    }
                }

                #endregion

                #region [Manivela Delikleri]

                /////////////////////////////////////     Manivela Delikleri Baş      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (bManivelaDeligiSağAktif)
                {
                    uc_ManivelaDeligi uc_ManivelaBas = new uc_ManivelaDeligi(
                        new Point(this.panel_ust.Width - dManivelaDelikDisMesafesi_px,
                            (this.panel_ust.Height / 2) - 1),
                        CalculateManivelaBas(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm));
                    this.panel_ust.Controls.Add(uc_ManivelaBas);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_ManivelaBas.VurmaPos,
                        EDelikTipi = DelikTipi.Manivela
                    });

                    uc_ManivelaDeligi uc_ManivelaBasAlt = new uc_ManivelaDeligi(
                        new Point(this.panel_ust.Width - dManivelaDelikDisMesafesi_px,
                            (this.panel_alt.Height / 2) + 1),
                        CalculateManivelaBas(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm));
                    this.panel_alt.Controls.Add(uc_ManivelaBasAlt);
                }

                /////////////////////////////////////     Manivela Delikleri Son      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (bManivelaDeligiSolAktif)
                {
                    uc_ManivelaDeligi uc_ManivelaSon = new uc_ManivelaDeligi(
                        new Point(dManivelaDelikDisMesafesi_px, (this.panel_ust.Height / 2) - 1),
                        CalculateManivelaSon(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm, MmBoy));
                    this.panel_ust.Controls.Add(uc_ManivelaSon);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_ManivelaSon.VurmaPos,
                        EDelikTipi = DelikTipi.Manivela
                    });

                    uc_ManivelaDeligi uc_ManivelaSonAlt = new uc_ManivelaDeligi(
                        new Point(dManivelaDelikDisMesafesi_px, (this.panel_alt.Height / 2) + 1),
                        CalculateManivelaSon(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm, MmBoy));
                    this.panel_alt.Controls.Add(uc_ManivelaSonAlt);
                }

                #endregion

                #region [Ana Boşaltma 1]

                //List<UserControl> listAnaBosaltma1 = new List<UserControl>();
                //listAnaBosaltma1 = ListAnaBosaltmaTuru(Pencere_Bir, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                //    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi);

                List<arrProductionElement> listReturnedAnaBosaltma = new List<arrProductionElement>(ListAnaBosaltmaTuru(Pencere_Bir, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm, dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi));
                foreach (var item in listReturnedAnaBosaltma)
                {
                    returned_ListOfDelik.Add(item);
                }
                //uc_AnaBosaltma _fooAnaBosaltma_1;

                //uc_Cap7_Sag _fooCap7sag_1_Pencere2;
                //uc_Cap7_Sol _fooCap7sol_1_Pencere2;

                //foreach (var item in listAnaBosaltma1)
                //{
                //    if (item is uc_AnaBosaltma)
                //    {
                //        _fooAnaBosaltma_1 = (uc_AnaBosaltma)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooAnaBosaltma_1.VurmaPos,
                //            EDelikTipi = DelikTipi.AnaBosaltma
                //        });
                //    }
                //    uc_IlaveBosaltma45_5 _fooIlaveBosaltma45_5;
                //    if (item is uc_IlaveBosaltma45_5)
                //    {
                //        _fooIlaveBosaltma45_5 = (uc_IlaveBosaltma45_5)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooIlaveBosaltma45_5.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_1
                //        });
                //    }

                //    uc_IlaveBosaltma6 fooIlaveBosaltma6;
                //    if (item is uc_IlaveBosaltma6)
                //    {
                //        fooIlaveBosaltma6 = (uc_IlaveBosaltma6)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = fooIlaveBosaltma6.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_2
                //        });
                //    }

                //    if (item is uc_Cap7_Sol)
                //    {
                //        _fooCap7sol_1_Pencere2 = (uc_Cap7_Sol)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sol_Genislik,
                //            dVurmaPos = _fooCap7sol_1_Pencere2.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sol
                //        });
                //    }
                //    if (item is uc_Cap7_Sag)
                //    {
                //        _fooCap7sag_1_Pencere2 = (uc_Cap7_Sag)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sag_Genislik,
                //            dVurmaPos = _fooCap7sag_1_Pencere2.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sag
                //        });
                //    }
                //}
                #endregion

                #region [Yayma Alanı 1]

                double YaymaAlanı_1 = CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, Pencere_Bir, dAnaBosaltmaBoy, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm)
                                      - CalculateCap7Bas(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm);
                int YaymaAlanı_1_px = cConfiguration.mm_to_pixel_cevir(YaymaAlanı_1);

                double delikAralıgı_1 = CalculateDelikAralıgı_Anabos(YaymaAlanı_1, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_1 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_1, dMontajDelikleriArasıBosluk_mm);


                List<UserControl> listofreturn_1 = new List<UserControl>();
                listofreturn_1 = ListYaymaTekCift(delikAralıkAdedi_1, delikAralıgı_1, dVidaVeSogutmaDisMesafesi_Bas_mm, "çift");

                uc_Cap7_Sag _fooCap7sag_1;
                uc_Cap7_Sol _fooCap7sol_1;

                if (listofreturn_1.Count().Equals(0))
                {
                    sonElemanTekCiftDurumu = "çift";
                }

                foreach (var item in listofreturn_1)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_1 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {
                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_1.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_1 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_1.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }

                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }

                    if (listofreturn_1.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }

                }

                #endregion

                #region [Yayma Alanı 2]

                double YaymaAlanı_2 = CalculateCap7Son(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Son_mm, MmBoy) -
                                      CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, Pencere_Bir, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);

                double delikAralıgı_2 = CalculateDelikAralıgı_Anabos(YaymaAlanı_2, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_2 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_2, dMontajDelikleriArasıBosluk_mm);

                double delikYaymaBaslangıcNoktası =
                    Pencere_Bir - 128 + dAnaBosaltmaBoy / 2 + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm;

                List<UserControl> listofreturn_2 = new List<UserControl>();
                listofreturn_2 = ListYaymaTekCift(delikAralıkAdedi_2, delikAralıgı_2, delikYaymaBaslangıcNoktası, sonElemanTekCiftDurumu);

                uc_Cap7_Sag _fooCap7sag_2;
                uc_Cap7_Sol _fooCap7sol_2;

                foreach (var item in listofreturn_2)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_2 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_2.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_2 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_2.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_2;
                    uc_11x20Slot2 _foo11x20Slot2_2;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_2 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_2.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_2 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                }

                #endregion
            }
            #endregion

            #region [////////////////////        pencere_Iki      \\\\\\\\\\\\\\\\\\\\]

            if (this.PencereAdedi == ePencereAdedi.pencere_Iki && this.MmBoy > 0 && pencere_Bir_MinLimit > 0 &&
                pencereArasılimit_2 > 0 && pencere_Iki_MaxLimit > 0 && !bYatayKöseLeft_Selected && !bYatayKöseRight_Selected)
            {
                #region [Baş Takoz ve Çap7'ler]
                uc_BasTakozSlotlari uc_BasTakozSon_PlugIn = new uc_BasTakozSlotlari(
                    new Point(dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                    CalculateBasTakozSon(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm, MmBoy));
                this.panel_ust.Controls.Add(uc_BasTakozSon_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = 0.0,
                    dVurmaPos = uc_BasTakozSon_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.BasTakoz
                });

                uc_BasTakozSlotlari_Ters uc_BasTakozTersSon_PlugIn =
                    new uc_BasTakozSlotlari_Ters(new Point(dBasTakozDisMesafesi_px, this.panel_alt.Height / 2));
                this.panel_alt.Controls.Add(uc_BasTakozTersSon_PlugIn);

                uc_BasTakozSlotlari uc_BasTakozBas_PlugIn = new uc_BasTakozSlotlari(
                    new Point(this.panel_ust.Width - dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                    CalculateBasTakozBas(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm));
                this.panel_ust.Controls.Add(uc_BasTakozBas_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = 0.0,
                    dVurmaPos = uc_BasTakozBas_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.BasTakoz
                });

                uc_BasTakozSlotlari_Ters uc_BasTakozTersBas_PlugIn =
                    new uc_BasTakozSlotlari_Ters(new Point(this.panel_alt.Width - dBasTakozDisMesafesi_px,
                        this.panel_alt.Height / 2));
                this.panel_alt.Controls.Add(uc_BasTakozTersBas_PlugIn);

                uc_Cap7_Sol uc_cap7BasUst_PlugIn =
                    new uc_Cap7_Sol(new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                        CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sol_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7BasUst_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7BasUst_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7BasUst_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sol
                });

                uc_Cap7_Sag uc_cap7BasAlt_PlugIn =
                    new uc_Cap7_Sag(
                        new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height - this.panel_orta.Height / 4),
                        CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sag_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7BasAlt_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7BasAlt_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7BasAlt_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sag
                });

                uc_Cap7_Sol uc_cap7SonUst_PlugIn =
                    new uc_Cap7_Sol(
                        new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                        CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sol_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7SonUst_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7SonUst_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7SonUst_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sol
                });

                uc_Cap7_Sag uc_cap7SonAlt_PlugIn = new uc_Cap7_Sag(
                    new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px,
                        this.panel_orta.Height - this.panel_orta.Height / 4),
                    CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sag_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7SonAlt_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7SonAlt_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7SonAlt_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sag
                });

                #endregion

                #region [50mm Sonrasına Vurulacak 11x20 ve Cap7 Delikleri]

                if (!b11x20VeCap7Disable_Min)
                {
                    ///////////////////////////////////////     50mm Sonrasına Vurulacak 11x20 ve Cap7 Delikleri Baş      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    List<arrProductionElement> listReturned11x20VeCap7 = BasaVurulacakCap7Ve11x20Delikleri(dVidaVeSogutmaDisMesafesi_Bas_px, dVidaVeSogutmaDisMesafesi_Bas_mm);
                    foreach (var item in listReturned11x20VeCap7)
                    {
                        returned_ListOfDelik.Add(item);
                    }
                }
                if (!b11x20VeCap7Disable_Max)
                {
                    /////////////////////////////////////     50mm Sonrasına Vurulacak 11x20 ve Cap7 Delikleri Son      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    List<arrProductionElement> listReturned11x20VeCap7 = SonaVurulacakCap7Ve11x20Delikleri(dVidaVeSogutmaDisMesafesi_Son_px, dVidaVeSogutmaDisMesafesi_Son_mm);
                    foreach (var item in listReturned11x20VeCap7)
                    {
                        returned_ListOfDelik.Add(item);
                    }
                }
                #endregion

                #region [Manivela Delikleri]

                /////////////////////////////////////     Manivela Delikleri Baş      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (bManivelaDeligiSağAktif)
                {
                    uc_ManivelaDeligi uc_ManivelaBas = new uc_ManivelaDeligi(
                        new Point(this.panel_ust.Width - dManivelaDelikDisMesafesi_px,
                            (this.panel_ust.Height / 2) - 1),
                        CalculateManivelaBas(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm));
                    this.panel_ust.Controls.Add(uc_ManivelaBas);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_ManivelaBas.VurmaPos,
                        EDelikTipi = DelikTipi.Manivela
                    });

                    uc_ManivelaDeligi uc_ManivelaBasAlt = new uc_ManivelaDeligi(
                        new Point(this.panel_ust.Width - dManivelaDelikDisMesafesi_px,
                            (this.panel_alt.Height / 2) + 1),
                        CalculateManivelaBas(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm));
                    this.panel_alt.Controls.Add(uc_ManivelaBasAlt);
                }

                /////////////////////////////////////     Manivela Delikleri Son      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (bManivelaDeligiSolAktif)
                {
                    uc_ManivelaDeligi uc_ManivelaSon = new uc_ManivelaDeligi(
                        new Point(dManivelaDelikDisMesafesi_px, (this.panel_ust.Height / 2) - 1),
                        CalculateManivelaSon(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm, MmBoy));
                    this.panel_ust.Controls.Add(uc_ManivelaSon);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_ManivelaSon.VurmaPos,
                        EDelikTipi = DelikTipi.Manivela
                    });

                    uc_ManivelaDeligi uc_ManivelaSonAlt = new uc_ManivelaDeligi(
                        new Point(dManivelaDelikDisMesafesi_px, (this.panel_alt.Height / 2) + 1),
                        CalculateManivelaSon(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm, MmBoy));
                    this.panel_alt.Controls.Add(uc_ManivelaSonAlt);
                }

                #endregion

                #region [Ana Boşaltma 1]
                List<arrProductionElement> listReturnedAnaBosaltma = new List<arrProductionElement>(ListAnaBosaltmaTuru(Pencere_Bir, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi));
                foreach (var item in listReturnedAnaBosaltma)
                {
                    returned_ListOfDelik.Add(item);
                }

                //List<UserControl> listAnaBosaltma1 = new List<UserControl>();
                //listAnaBosaltma1 = ListAnaBosaltmaTuru();

                //uc_AnaBosaltma _fooAnaBosaltma_1;
                //uc_Cap7_Sag _fooCap7sag_1_Pencere2;
                //uc_Cap7_Sol _fooCap7sol_1_Pencere2;

                //foreach (var item in listAnaBosaltma1)
                //{
                //    if (item is uc_AnaBosaltma)
                //    {
                //        _fooAnaBosaltma_1 = (uc_AnaBosaltma)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooAnaBosaltma_1.VurmaPos,
                //            EDelikTipi = DelikTipi.AnaBosaltma
                //        });
                //    }

                //    uc_IlaveBosaltma45_5 _fooIlaveBosaltma45_5;
                //    if (item is uc_IlaveBosaltma45_5)
                //    {
                //        _fooIlaveBosaltma45_5 = (uc_IlaveBosaltma45_5)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooIlaveBosaltma45_5.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_1
                //        });
                //    }

                //    uc_IlaveBosaltma6 fooIlaveBosaltma6;
                //    if (item is uc_IlaveBosaltma6)
                //    {
                //        fooIlaveBosaltma6 = (uc_IlaveBosaltma6)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = fooIlaveBosaltma6.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_2
                //        });
                //    }

                //    if (item is uc_Cap7_Sol)
                //    {
                //        _fooCap7sol_1_Pencere2 = (uc_Cap7_Sol)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sol_Genislik,
                //            dVurmaPos = _fooCap7sol_1_Pencere2.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sol
                //        });
                //    }
                //    if (item is uc_Cap7_Sag)
                //    {
                //        _fooCap7sag_1_Pencere2 = (uc_Cap7_Sag)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sag_Genislik,
                //            dVurmaPos = _fooCap7sag_1_Pencere2.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sag
                //        });
                //    }
                //}
                #endregion

                #region [Ana Boşaltma 2]
                List<arrProductionElement> listReturnedAnaBosaltma_2 = new List<arrProductionElement>(ListAnaBosaltmaTuru(Pencere_Iki, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi));
                foreach (var item in listReturnedAnaBosaltma_2)
                {
                    returned_ListOfDelik.Add(item);
                }
                //List<UserControl> listAnaBosaltma2 = new List<UserControl>();
                //listAnaBosaltma2 = ListAnaBosaltmaTuru();

                //uc_AnaBosaltma _fooAnaBosaltma_2;
                //uc_Cap7_Sag _fooCap7sag_2_Pencere2;
                //uc_Cap7_Sol _fooCap7sol_2_Pencere2;

                //foreach (var item in listAnaBosaltma2)
                //{
                //    if (item is uc_AnaBosaltma)
                //    {
                //        _fooAnaBosaltma_2 = (uc_AnaBosaltma)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooAnaBosaltma_2.VurmaPos,
                //            EDelikTipi = DelikTipi.AnaBosaltma
                //        });
                //    }
                //    uc_IlaveBosaltma45_5 _fooIlaveBosaltma45_5;
                //    if (item is uc_IlaveBosaltma45_5)
                //    {
                //        _fooIlaveBosaltma45_5 = (uc_IlaveBosaltma45_5)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooIlaveBosaltma45_5.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_1
                //        });
                //    }

                //    uc_IlaveBosaltma6 fooIlaveBosaltma6;
                //    if (item is uc_IlaveBosaltma6)
                //    {
                //        fooIlaveBosaltma6 = (uc_IlaveBosaltma6)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = fooIlaveBosaltma6.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_2
                //        });
                //    }
                //    if (item is uc_Cap7_Sol)
                //    {
                //        _fooCap7sol_2_Pencere2 = (uc_Cap7_Sol)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sol_Genislik,
                //            dVurmaPos = _fooCap7sol_2_Pencere2.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sol
                //        });
                //    }
                //    if (item is uc_Cap7_Sag)
                //    {
                //        _fooCap7sag_2_Pencere2 = (uc_Cap7_Sag)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sag_Genislik,
                //            dVurmaPos = _fooCap7sag_2_Pencere2.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sag
                //        });
                //    }
                //}
                #endregion

                #region [Yayma Alanı 1]

                double YaymaAlanı_1 = CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, Pencere_Bir, dAnaBosaltmaBoy, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm)
                                      - CalculateCap7Bas(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm);
                double delikAralıgı_1 = CalculateDelikAralıgı_Anabos(YaymaAlanı_1, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_1 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_1, dMontajDelikleriArasıBosluk_mm);


                List<UserControl> listofreturn_1 = new List<UserControl>();
                listofreturn_1 = ListYaymaTekCift(delikAralıkAdedi_1, delikAralıgı_1, dVidaVeSogutmaDisMesafesi_Bas_mm, "çift");

                uc_Cap7_Sag _fooCap7sag_1;
                uc_Cap7_Sol _fooCap7sol_1;
                if (listofreturn_1.Count().Equals(0))
                {
                    sonElemanTekCiftDurumu = "çift";
                }
                foreach (var item in listofreturn_1)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_1 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_1.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_1 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_1.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }

                    if (listofreturn_1.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }

                #endregion

                #region [Yayma Alanı 2]

                double YaymaAlanı_2 = CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, Pencere_Iki, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm) -
                                      CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, Pencere_Bir, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);

                double delikAralıgı_2 = CalculateDelikAralıgı_Anabos(YaymaAlanı_2, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_2 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_2, dMontajDelikleriArasıBosluk_mm);

                double delikYaymaBaslangıcNoktası =
                    Pencere_Bir - 128 + dAnaBosaltmaBoy / 2 + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm;

                List<UserControl> listofreturn_2 = new List<UserControl>();
                listofreturn_2 = ListYaymaTekCift(delikAralıkAdedi_2, delikAralıgı_2, delikYaymaBaslangıcNoktası, sonElemanTekCiftDurumu);

                uc_Cap7_Sag _fooCap7sag_2;
                uc_Cap7_Sol _fooCap7sol_2;

                foreach (var item in listofreturn_2)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_2 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_2.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_2 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_2.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_2.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }

                #endregion

                #region [Yayma Alanı 3]

                double YaymaAlanı_3 = CalculateCap7Son(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Son_mm, MmBoy) -
                                      CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, Pencere_Iki, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm);

                double delikAralıgı_3 = CalculateDelikAralıgı_Anabos(YaymaAlanı_3, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_3 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_3, dMontajDelikleriArasıBosluk_mm);

                double delikYaymaBaslangıcNoktası_3 =
                    Pencere_Iki - 128 + dAnaBosaltmaBoy / 2 + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm;

                List<UserControl> listofreturn_3 = new List<UserControl>();
                listofreturn_3 = ListYaymaTekCift(delikAralıkAdedi_3, delikAralıgı_3, delikYaymaBaslangıcNoktası_3, sonElemanTekCiftDurumu);

                uc_Cap7_Sag _fooCap7sag_3;
                uc_Cap7_Sol _fooCap7sol_3;

                foreach (var item in listofreturn_3)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_3 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_3.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_3 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_3.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_3.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }

                #endregion
            }
            #endregion

            #region [////////////////////        pencere_Uc       \\\\\\\\\\\\\\\\\\\\]

            if (this.PencereAdedi == ePencereAdedi.pencere_Uc && this.MmBoy > 0 && pencere_Bir_MinLimit > 0 &&
                pencereArasılimit_2 > 0 && pencereArasılimit_3 > 0 && pencere_Uc_MaxLimit > 0 && !bYatayKöseLeft_Selected && !bYatayKöseRight_Selected)
            {
                #region [Baş Takoz ve Çap7'ler]
                uc_BasTakozSlotlari uc_BasTakozSon_PlugIn = new uc_BasTakozSlotlari(
                    new Point(dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                    CalculateBasTakozSon(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm, MmBoy));
                this.panel_ust.Controls.Add(uc_BasTakozSon_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = 0.0,
                    dVurmaPos = uc_BasTakozSon_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.BasTakoz
                });

                uc_BasTakozSlotlari_Ters uc_BasTakozTersSon_PlugIn =
                    new uc_BasTakozSlotlari_Ters(new Point(dBasTakozDisMesafesi_px, this.panel_alt.Height / 2));
                this.panel_alt.Controls.Add(uc_BasTakozTersSon_PlugIn);

                uc_BasTakozSlotlari uc_BasTakozBas_PlugIn = new uc_BasTakozSlotlari(
                    new Point(this.panel_ust.Width - dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                    CalculateBasTakozBas(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm));
                this.panel_ust.Controls.Add(uc_BasTakozBas_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = 0.0,
                    dVurmaPos = uc_BasTakozBas_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.BasTakoz
                });

                uc_BasTakozSlotlari_Ters uc_BasTakozTersBas_PlugIn =
                    new uc_BasTakozSlotlari_Ters(new Point(this.panel_alt.Width - dBasTakozDisMesafesi_px,
                        this.panel_alt.Height / 2));
                this.panel_alt.Controls.Add(uc_BasTakozTersBas_PlugIn);

                uc_Cap7_Sol uc_cap7BasUst_PlugIn =
                    new uc_Cap7_Sol(new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                        CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sol_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7BasUst_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7BasUst_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7BasUst_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sol
                });

                uc_Cap7_Sag uc_cap7BasAlt_PlugIn =
                    new uc_Cap7_Sag(
                        new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height - this.panel_orta.Height / 4),
                        CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sag_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7BasAlt_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7BasAlt_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7BasAlt_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sag
                });

                uc_Cap7_Sol uc_cap7SonUst_PlugIn =
                    new uc_Cap7_Sol(
                        new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                        CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sol_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7SonUst_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7SonUst_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7SonUst_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sol
                });

                uc_Cap7_Sag uc_cap7SonAlt_PlugIn = new uc_Cap7_Sag(
                    new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px,
                        this.panel_orta.Height - this.panel_orta.Height / 4),
                    CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sag_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7SonAlt_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7SonAlt_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7SonAlt_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sag
                });

                #endregion

                #region [50mm Sonrasına Vurulacak 11x20 ve Cap7 Delikleri]

                if (!b11x20VeCap7Disable_Min)
                {
                    ///////////////////////////////////////     50mm Sonrasına Vurulacak 11x20 ve Cap7 Delikleri Baş      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    List<arrProductionElement> listReturned11x20VeCap7 = BasaVurulacakCap7Ve11x20Delikleri(dVidaVeSogutmaDisMesafesi_Bas_px, dVidaVeSogutmaDisMesafesi_Bas_mm);
                    foreach (var item in listReturned11x20VeCap7)
                    {
                        returned_ListOfDelik.Add(item);
                    }
                }
                if (!b11x20VeCap7Disable_Max)
                {
                    /////////////////////////////////////     50mm Sonrasına Vurulacak 11x20 ve Cap7 Delikleri Son      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    List<arrProductionElement> listReturned11x20VeCap7 = SonaVurulacakCap7Ve11x20Delikleri(dVidaVeSogutmaDisMesafesi_Son_px, dVidaVeSogutmaDisMesafesi_Son_mm);
                    foreach (var item in listReturned11x20VeCap7)
                    {
                        returned_ListOfDelik.Add(item);
                    }
                }
                #endregion

                #region [Manivela Delikleri]

                /////////////////////////////////////     Manivela Delikleri Baş      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (bManivelaDeligiSağAktif)
                {
                    uc_ManivelaDeligi uc_ManivelaBas = new uc_ManivelaDeligi(
                        new Point(this.panel_ust.Width - dManivelaDelikDisMesafesi_px,
                            (this.panel_ust.Height / 2) - 1),
                        CalculateManivelaBas(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm));
                    this.panel_ust.Controls.Add(uc_ManivelaBas);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_ManivelaBas.VurmaPos,
                        EDelikTipi = DelikTipi.Manivela
                    });

                    uc_ManivelaDeligi uc_ManivelaBasAlt = new uc_ManivelaDeligi(
                        new Point(this.panel_ust.Width - dManivelaDelikDisMesafesi_px,
                            (this.panel_alt.Height / 2) + 1),
                        CalculateManivelaBas(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm));
                    this.panel_alt.Controls.Add(uc_ManivelaBasAlt);
                }

                /////////////////////////////////////     Manivela Delikleri Son      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (bManivelaDeligiSolAktif)
                {
                    uc_ManivelaDeligi uc_ManivelaSon = new uc_ManivelaDeligi(
                        new Point(dManivelaDelikDisMesafesi_px, (this.panel_ust.Height / 2) - 1),
                        CalculateManivelaSon(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm, MmBoy));
                    this.panel_ust.Controls.Add(uc_ManivelaSon);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_ManivelaSon.VurmaPos,
                        EDelikTipi = DelikTipi.Manivela
                    });

                    uc_ManivelaDeligi uc_ManivelaSonAlt = new uc_ManivelaDeligi(
                        new Point(dManivelaDelikDisMesafesi_px, (this.panel_alt.Height / 2) + 1),
                        CalculateManivelaSon(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm, MmBoy));
                    this.panel_alt.Controls.Add(uc_ManivelaSonAlt);
                }

                #endregion

                #region [Ana Boşaltma 1]
                List<arrProductionElement> listReturnedAnaBosaltma = new List<arrProductionElement>(ListAnaBosaltmaTuru(Pencere_Bir, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi));
                foreach (var item in listReturnedAnaBosaltma)
                {
                    returned_ListOfDelik.Add(item);
                }
                //List<UserControl> listAnaBosaltma1 = new List<UserControl>();
                //listAnaBosaltma1 = ListAnaBosaltmaTuru(Pencere_Bir, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                //    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi);

                //uc_AnaBosaltma _fooAnaBosaltma_1;
                //uc_Cap7_Sag _fooCap7sag_1_Pencere2;
                //uc_Cap7_Sol _fooCap7sol_1_Pencere2;

                //foreach (var item in listAnaBosaltma1)
                //{
                //    if (item is uc_AnaBosaltma)
                //    {
                //        _fooAnaBosaltma_1 = (uc_AnaBosaltma)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooAnaBosaltma_1.VurmaPos,
                //            EDelikTipi = DelikTipi.AnaBosaltma
                //        });
                //    }
                //    uc_IlaveBosaltma45_5 _fooIlaveBosaltma45_5;
                //    if (item is uc_IlaveBosaltma45_5)
                //    {
                //        _fooIlaveBosaltma45_5 = (uc_IlaveBosaltma45_5)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooIlaveBosaltma45_5.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_1
                //        });
                //    }

                //    uc_IlaveBosaltma6 fooIlaveBosaltma6;
                //    if (item is uc_IlaveBosaltma6)
                //    {
                //        fooIlaveBosaltma6 = (uc_IlaveBosaltma6)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = fooIlaveBosaltma6.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_2
                //        });
                //    }
                //    if (item is uc_Cap7_Sol)
                //    {
                //        _fooCap7sol_1_Pencere2 = (uc_Cap7_Sol)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sol_Genislik,
                //            dVurmaPos = _fooCap7sol_1_Pencere2.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sol
                //        });
                //    }
                //    if (item is uc_Cap7_Sag)
                //    {
                //        _fooCap7sag_1_Pencere2 = (uc_Cap7_Sag)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sag_Genislik,
                //            dVurmaPos = _fooCap7sag_1_Pencere2.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sag
                //        });
                //    }
                //}
                #endregion

                #region [Ana Boşaltma 2]
                List<arrProductionElement> listReturnedAnaBosaltma_2 = new List<arrProductionElement>(ListAnaBosaltmaTuru(Pencere_Iki, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi));
                foreach (var item in listReturnedAnaBosaltma_2)
                {
                    returned_ListOfDelik.Add(item);
                }
                //List<UserControl> listAnaBosaltma2 = new List<UserControl>();
                //listAnaBosaltma2 = ListAnaBosaltmaTuru(Pencere_Iki, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                //    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi);

                //uc_AnaBosaltma _fooAnaBosaltma_2;
                //uc_Cap7_Sag _fooCap7sag_2_Pencere2;
                //uc_Cap7_Sol _fooCap7sol_2_Pencere2;

                //foreach (var item in listAnaBosaltma2)
                //{
                //    if (item is uc_AnaBosaltma)
                //    {
                //        _fooAnaBosaltma_2 = (uc_AnaBosaltma)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooAnaBosaltma_2.VurmaPos,
                //            EDelikTipi = DelikTipi.AnaBosaltma
                //        });
                //    }
                //    uc_IlaveBosaltma45_5 _fooIlaveBosaltma45_5;
                //    if (item is uc_IlaveBosaltma45_5)
                //    {
                //        _fooIlaveBosaltma45_5 = (uc_IlaveBosaltma45_5)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooIlaveBosaltma45_5.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_1
                //        });
                //    }

                //    uc_IlaveBosaltma6 fooIlaveBosaltma6;
                //    if (item is uc_IlaveBosaltma6)
                //    {
                //        fooIlaveBosaltma6 = (uc_IlaveBosaltma6)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = fooIlaveBosaltma6.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_2
                //        });
                //    }
                //    if (item is uc_Cap7_Sol)
                //    {
                //        _fooCap7sol_2_Pencere2 = (uc_Cap7_Sol)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sol_Genislik,
                //            dVurmaPos = _fooCap7sol_2_Pencere2.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sol
                //        });
                //    }
                //    if (item is uc_Cap7_Sag)
                //    {
                //        _fooCap7sag_2_Pencere2 = (uc_Cap7_Sag)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sag_Genislik,
                //            dVurmaPos = _fooCap7sag_2_Pencere2.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sag
                //        });
                //    }
                //}
                #endregion

                #region [Ana Boşaltma 3]
                List<arrProductionElement> listReturnedAnaBosaltma_3 = new List<arrProductionElement>(ListAnaBosaltmaTuru(Pencere_Uc, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi));
                foreach (var item in listReturnedAnaBosaltma_3)
                {
                    returned_ListOfDelik.Add(item);
                }
                //List<UserControl> listAnaBosaltma3 = new List<UserControl>();
                //listAnaBosaltma3 = ListAnaBosaltmaTuru();

                //uc_AnaBosaltma _fooAnaBosaltma_3;
                //uc_Cap7_Sag _fooCap7sag_Pencere3;
                //uc_Cap7_Sol _fooCap7sol_Pencere3;

                //foreach (var item in listAnaBosaltma3)
                //{
                //    if (item is uc_AnaBosaltma)
                //    {
                //        _fooAnaBosaltma_3 = (uc_AnaBosaltma)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooAnaBosaltma_3.VurmaPos,
                //            EDelikTipi = DelikTipi.AnaBosaltma
                //        });
                //    }
                //    uc_IlaveBosaltma45_5 _fooIlaveBosaltma45_5;
                //    if (item is uc_IlaveBosaltma45_5)
                //    {
                //        _fooIlaveBosaltma45_5 = (uc_IlaveBosaltma45_5)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooIlaveBosaltma45_5.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_1
                //        });
                //    }

                //    uc_IlaveBosaltma6 fooIlaveBosaltma6;
                //    if (item is uc_IlaveBosaltma6)
                //    {
                //        fooIlaveBosaltma6 = (uc_IlaveBosaltma6)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = fooIlaveBosaltma6.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_2
                //        });
                //    }
                //    if (item is uc_Cap7_Sol)
                //    {
                //        _fooCap7sol_Pencere3 = (uc_Cap7_Sol)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sol_Genislik,
                //            dVurmaPos = _fooCap7sol_Pencere3.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sol
                //        });
                //    }
                //    if (item is uc_Cap7_Sag)
                //    {
                //        _fooCap7sag_Pencere3 = (uc_Cap7_Sag)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sag_Genislik,
                //            dVurmaPos = _fooCap7sag_Pencere3.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sag
                //        });
                //    }
                //}
                #endregion

                #region [Yayma Alanı 1]

                double YaymaAlanı_1 = CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, Pencere_Bir, dAnaBosaltmaBoy, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm)
                                      - CalculateCap7Bas(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm);
                double delikAralıgı_1 = CalculateDelikAralıgı_Anabos(YaymaAlanı_1, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_1 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_1, dMontajDelikleriArasıBosluk_mm);


                List<UserControl> listofreturn_1 = new List<UserControl>();
                listofreturn_1 = ListYaymaTekCift(delikAralıkAdedi_1, delikAralıgı_1, dVidaVeSogutmaDisMesafesi_Bas_mm, "çift");

                uc_Cap7_Sag _fooCap7sag_1;
                uc_Cap7_Sol _fooCap7sol_1;
                if (listofreturn_1.Count().Equals(0))
                {
                    sonElemanTekCiftDurumu = "çift";
                }
                foreach (var item in listofreturn_1)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_1 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_1.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_1 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_1.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_1.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }

                #endregion

                #region [Yayma Alanı 2]

                double YaymaAlanı_2 = CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, Pencere_Iki, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm) -
                                      CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, Pencere_Bir, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);

                double delikAralıgı_2 = CalculateDelikAralıgı_Anabos(YaymaAlanı_2, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_2 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_2, dMontajDelikleriArasıBosluk_mm);

                double delikYaymaBaslangıcNoktası =
                    Pencere_Bir - 128 + dAnaBosaltmaBoy / 2 + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm;

                List<UserControl> listofreturn_2 = new List<UserControl>();
                listofreturn_2 = ListYaymaTekCift(delikAralıkAdedi_2, delikAralıgı_2, delikYaymaBaslangıcNoktası, sonElemanTekCiftDurumu);

                uc_Cap7_Sag _fooCap7sag_2;
                uc_Cap7_Sol _fooCap7sol_2;

                foreach (var item in listofreturn_2)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_2 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_2.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_2 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_2.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_2.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }

                #endregion

                #region [Yayma Alanı 3]

                double YaymaAlanı_3 = CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, Pencere_Uc, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm) -
                                      CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, Pencere_Iki, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);

                double delikAralıgı_3 = CalculateDelikAralıgı_Anabos(YaymaAlanı_3, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_3 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_3, dMontajDelikleriArasıBosluk_mm);

                double delikYaymaBaslangıcNoktası_3 =
                    Pencere_Iki - 128 + dAnaBosaltmaBoy / 2 + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm;

                List<UserControl> listofreturn_3 = new List<UserControl>();
                listofreturn_3 = ListYaymaTekCift(delikAralıkAdedi_3, delikAralıgı_3, delikYaymaBaslangıcNoktası_3, sonElemanTekCiftDurumu);

                uc_Cap7_Sag _fooCap7sag_3;
                uc_Cap7_Sol _fooCap7sol_3;

                foreach (var item in listofreturn_3)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_3 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_3.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_3 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_3.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_3.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }

                #endregion

                #region [Yayma Alanı 4]

                double YaymaAlanı_4 = CalculateCap7Son(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Son_mm, MmBoy) -
                                      CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, Pencere_Uc, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);

                double delikAralıgı_4 = CalculateDelikAralıgı_Anabos(YaymaAlanı_4, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_4 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_4, dMontajDelikleriArasıBosluk_mm);

                double delikYaymaBaslangıcNoktası_4 =
                    Pencere_Uc - 128 + dAnaBosaltmaBoy / 2 + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm;

                List<UserControl> listofreturn_4 = new List<UserControl>();
                listofreturn_4 = ListYaymaTekCift(delikAralıkAdedi_4, delikAralıgı_4, delikYaymaBaslangıcNoktası_4, sonElemanTekCiftDurumu);

                uc_Cap7_Sag _fooCap7sag_4;
                uc_Cap7_Sol _fooCap7sol_4;

                foreach (var item in listofreturn_4)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_4 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_4.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_4 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_4.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_4.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }

                #endregion

            }
            #endregion

            #region [////////////////////        pencere_Dort     \\\\\\\\\\\\\\\\\\\\]

            if (this.PencereAdedi == ePencereAdedi.pencere_Dort && this.MmBoy > 0 && pencere_Bir_MinLimit > 0 &&
                pencereArasılimit_2 > 0 && pencereArasılimit_3 > 0 && pencereArasılimit_4 > 0 &&
                pencere_Dort_MaxLimit > 0 && !bYatayKöseLeft_Selected && !bYatayKöseRight_Selected)
            {
                #region [Baş Takoz ve Çap7'ler]
                uc_BasTakozSlotlari uc_BasTakozSon_PlugIn = new uc_BasTakozSlotlari(
                    new Point(dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                    CalculateBasTakozSon(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm, MmBoy));
                this.panel_ust.Controls.Add(uc_BasTakozSon_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = 0.0,
                    dVurmaPos = uc_BasTakozSon_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.BasTakoz
                });

                uc_BasTakozSlotlari_Ters uc_BasTakozTersSon_PlugIn =
                    new uc_BasTakozSlotlari_Ters(new Point(dBasTakozDisMesafesi_px, this.panel_alt.Height / 2));
                this.panel_alt.Controls.Add(uc_BasTakozTersSon_PlugIn);

                uc_BasTakozSlotlari uc_BasTakozBas_PlugIn = new uc_BasTakozSlotlari(
                    new Point(this.panel_ust.Width - dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                    CalculateBasTakozBas(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm));
                this.panel_ust.Controls.Add(uc_BasTakozBas_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = 0.0,
                    dVurmaPos = uc_BasTakozBas_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.BasTakoz
                });

                uc_BasTakozSlotlari_Ters uc_BasTakozTersBas_PlugIn =
                    new uc_BasTakozSlotlari_Ters(new Point(this.panel_alt.Width - dBasTakozDisMesafesi_px,
                        this.panel_alt.Height / 2));
                this.panel_alt.Controls.Add(uc_BasTakozTersBas_PlugIn);

                uc_Cap7_Sol uc_cap7BasUst_PlugIn =
                    new uc_Cap7_Sol(new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                        CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sol_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7BasUst_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7BasUst_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7BasUst_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sol
                });

                uc_Cap7_Sag uc_cap7BasAlt_PlugIn =
                    new uc_Cap7_Sag(
                        new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height - this.panel_orta.Height / 4),
                        CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sag_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7BasAlt_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7BasAlt_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7BasAlt_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sag
                });

                uc_Cap7_Sol uc_cap7SonUst_PlugIn =
                    new uc_Cap7_Sol(
                        new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                        CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sol_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7SonUst_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7SonUst_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7SonUst_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sol
                });

                uc_Cap7_Sag uc_cap7SonAlt_PlugIn = new uc_Cap7_Sag(
                    new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px,
                        this.panel_orta.Height - this.panel_orta.Height / 4),
                    CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sag_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7SonAlt_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7SonAlt_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7SonAlt_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sag
                });

                #endregion

                #region [50mm Sonrasına Vurulacak 11x20 ve Cap7 Delikleri]

                if (!b11x20VeCap7Disable_Min)
                {
                    ///////////////////////////////////////     50mm Sonrasına Vurulacak 11x20 ve Cap7 Delikleri Baş      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    List<arrProductionElement> listReturned11x20VeCap7 = BasaVurulacakCap7Ve11x20Delikleri(dVidaVeSogutmaDisMesafesi_Bas_px, dVidaVeSogutmaDisMesafesi_Bas_mm);
                    foreach (var item in listReturned11x20VeCap7)
                    {
                        returned_ListOfDelik.Add(item);
                    }
                }
                if (!b11x20VeCap7Disable_Max)
                {
                    /////////////////////////////////////     50mm Sonrasına Vurulacak 11x20 ve Cap7 Delikleri Son      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    List<arrProductionElement> listReturned11x20VeCap7 = SonaVurulacakCap7Ve11x20Delikleri(dVidaVeSogutmaDisMesafesi_Son_px, dVidaVeSogutmaDisMesafesi_Son_mm);
                    foreach (var item in listReturned11x20VeCap7)
                    {
                        returned_ListOfDelik.Add(item);
                    }
                }
                #endregion

                #region [Manivela Delikleri]

                /////////////////////////////////////     Manivela Delikleri Baş      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (bManivelaDeligiSağAktif)
                {
                    uc_ManivelaDeligi uc_ManivelaBas = new uc_ManivelaDeligi(
                        new Point(this.panel_ust.Width - dManivelaDelikDisMesafesi_px,
                            (this.panel_ust.Height / 2) - 1),
                        CalculateManivelaBas(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm));
                    this.panel_ust.Controls.Add(uc_ManivelaBas);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_ManivelaBas.VurmaPos,
                        EDelikTipi = DelikTipi.Manivela
                    });

                    uc_ManivelaDeligi uc_ManivelaBasAlt = new uc_ManivelaDeligi(
                        new Point(this.panel_ust.Width - dManivelaDelikDisMesafesi_px,
                            (this.panel_alt.Height / 2) + 1),
                        CalculateManivelaBas(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm));
                    this.panel_alt.Controls.Add(uc_ManivelaBasAlt);
                }

                /////////////////////////////////////     Manivela Delikleri Son      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (bManivelaDeligiSolAktif)
                {
                    uc_ManivelaDeligi uc_ManivelaSon = new uc_ManivelaDeligi(
                        new Point(dManivelaDelikDisMesafesi_px, (this.panel_ust.Height / 2) - 1),
                        CalculateManivelaSon(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm, MmBoy));
                    this.panel_ust.Controls.Add(uc_ManivelaSon);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_ManivelaSon.VurmaPos,
                        EDelikTipi = DelikTipi.Manivela
                    });

                    uc_ManivelaDeligi uc_ManivelaSonAlt = new uc_ManivelaDeligi(
                        new Point(dManivelaDelikDisMesafesi_px, (this.panel_alt.Height / 2) + 1),
                        CalculateManivelaSon(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm, MmBoy));
                    this.panel_alt.Controls.Add(uc_ManivelaSonAlt);
                }

                #endregion

                #region [Ana Boşaltma 1]
                List<arrProductionElement> listReturnedAnaBosaltma_1 = new List<arrProductionElement>(ListAnaBosaltmaTuru(Pencere_Bir, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi));
                foreach (var item in listReturnedAnaBosaltma_1)
                {
                    returned_ListOfDelik.Add(item);
                }
                //List<UserControl> listAnaBosaltma1 = new List<UserControl>();
                //listAnaBosaltma1 = ListAnaBosaltmaTuru();

                //uc_AnaBosaltma _fooAnaBosaltma_1;
                //uc_Cap7_Sag _fooCap7sag_1_Pencere2;
                //uc_Cap7_Sol _fooCap7sol_1_Pencere2;

                //foreach (var item in listAnaBosaltma1)
                //{
                //    if (item is uc_AnaBosaltma)
                //    {
                //        _fooAnaBosaltma_1 = (uc_AnaBosaltma)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooAnaBosaltma_1.VurmaPos,
                //            EDelikTipi = DelikTipi.AnaBosaltma
                //        });
                //    }
                //    uc_IlaveBosaltma45_5 _fooIlaveBosaltma45_5;
                //    if (item is uc_IlaveBosaltma45_5)
                //    {
                //        _fooIlaveBosaltma45_5 = (uc_IlaveBosaltma45_5)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooIlaveBosaltma45_5.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_1
                //        });
                //    }

                //    uc_IlaveBosaltma6 fooIlaveBosaltma6;
                //    if (item is uc_IlaveBosaltma6)
                //    {
                //        fooIlaveBosaltma6 = (uc_IlaveBosaltma6)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = fooIlaveBosaltma6.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_2
                //        });
                //    }
                //    if (item is uc_Cap7_Sol)
                //    {
                //        _fooCap7sol_1_Pencere2 = (uc_Cap7_Sol)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sol_Genislik,
                //            dVurmaPos = _fooCap7sol_1_Pencere2.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sol
                //        });
                //    }
                //    if (item is uc_Cap7_Sag)
                //    {
                //        _fooCap7sag_1_Pencere2 = (uc_Cap7_Sag)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sag_Genislik,
                //            dVurmaPos = _fooCap7sag_1_Pencere2.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sag
                //        });
                //    }
                //}
                #endregion

                #region [Ana Boşaltma 2]
                List<arrProductionElement> listReturnedAnaBosaltma_2 = new List<arrProductionElement>(ListAnaBosaltmaTuru(Pencere_Iki, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi));
                foreach (var item in listReturnedAnaBosaltma_2)
                {
                    returned_ListOfDelik.Add(item);
                }
                //List<UserControl> listAnaBosaltma2 = new List<UserControl>();
                //listAnaBosaltma2 = ListAnaBosaltmaTuru();

                //uc_AnaBosaltma _fooAnaBosaltma_2;
                //uc_Cap7_Sag _fooCap7sag_2_Pencere2;
                //uc_Cap7_Sol _fooCap7sol_2_Pencere2;

                //foreach (var item in listAnaBosaltma2)
                //{
                //    if (item is uc_AnaBosaltma)
                //    {
                //        _fooAnaBosaltma_2 = (uc_AnaBosaltma)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooAnaBosaltma_2.VurmaPos,
                //            EDelikTipi = DelikTipi.AnaBosaltma
                //        });
                //    }
                //    uc_IlaveBosaltma45_5 _fooIlaveBosaltma45_5;
                //    if (item is uc_IlaveBosaltma45_5)
                //    {
                //        _fooIlaveBosaltma45_5 = (uc_IlaveBosaltma45_5)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooIlaveBosaltma45_5.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_1
                //        });
                //    }

                //    uc_IlaveBosaltma6 fooIlaveBosaltma6;
                //    if (item is uc_IlaveBosaltma6)
                //    {
                //        fooIlaveBosaltma6 = (uc_IlaveBosaltma6)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = fooIlaveBosaltma6.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_2
                //        });
                //    }
                //    if (item is uc_Cap7_Sol)
                //    {
                //        _fooCap7sol_2_Pencere2 = (uc_Cap7_Sol)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sol_Genislik,
                //            dVurmaPos = _fooCap7sol_2_Pencere2.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sol
                //        });
                //    }
                //    if (item is uc_Cap7_Sag)
                //    {
                //        _fooCap7sag_2_Pencere2 = (uc_Cap7_Sag)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sag_Genislik,
                //            dVurmaPos = _fooCap7sag_2_Pencere2.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sag
                //        });
                //    }
                //}
                #endregion

                #region [Ana Boşaltma 3]
                List<arrProductionElement> listReturnedAnaBosaltma_3 = new List<arrProductionElement>(ListAnaBosaltmaTuru(Pencere_Uc, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi));
                foreach (var item in listReturnedAnaBosaltma_3)
                {
                    returned_ListOfDelik.Add(item);
                }
                //List<UserControl> listAnaBosaltma3 = new List<UserControl>();
                //listAnaBosaltma3 = ListAnaBosaltmaTuru();

                //uc_AnaBosaltma _fooAnaBosaltma_3;
                //uc_Cap7_Sag _fooCap7sag_Pencere3;
                //uc_Cap7_Sol _fooCap7sol_Pencere3;

                //foreach (var item in listAnaBosaltma3)
                //{
                //    if (item is uc_AnaBosaltma)
                //    {
                //        _fooAnaBosaltma_3 = (uc_AnaBosaltma)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooAnaBosaltma_3.VurmaPos,
                //            EDelikTipi = DelikTipi.AnaBosaltma
                //        });
                //    }

                //    uc_IlaveBosaltma45_5 _fooIlaveBosaltma45_5;
                //    if (item is uc_IlaveBosaltma45_5)
                //    {
                //        _fooIlaveBosaltma45_5 = (uc_IlaveBosaltma45_5)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooIlaveBosaltma45_5.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_1
                //        });
                //    }

                //    uc_IlaveBosaltma6 fooIlaveBosaltma6;
                //    if (item is uc_IlaveBosaltma6)
                //    {
                //        fooIlaveBosaltma6 = (uc_IlaveBosaltma6)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = fooIlaveBosaltma6.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_2
                //        });
                //    }
                //    if (item is uc_Cap7_Sol)
                //    {
                //        _fooCap7sol_Pencere3 = (uc_Cap7_Sol)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sol_Genislik,
                //            dVurmaPos = _fooCap7sol_Pencere3.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sol
                //        });
                //    }
                //    if (item is uc_Cap7_Sag)
                //    {
                //        _fooCap7sag_Pencere3 = (uc_Cap7_Sag)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sag_Genislik,
                //            dVurmaPos = _fooCap7sag_Pencere3.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sag
                //        });
                //    }
                //}
                #endregion

                #region [Ana Boşaltma 4]
                List<arrProductionElement> listReturnedAnaBosaltma_4 = new List<arrProductionElement>(ListAnaBosaltmaTuru(Pencere_Dort, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi));
                foreach (var item in listReturnedAnaBosaltma_4)
                {
                    returned_ListOfDelik.Add(item);
                }
                //List<UserControl> listAnaBosaltma4 = new List<UserControl>();
                //listAnaBosaltma4 = ListAnaBosaltmaTuru();

                //uc_AnaBosaltma _fooAnaBosaltma_4;
                //uc_Cap7_Sag _fooCap7sag_Pencere4;
                //uc_Cap7_Sol _fooCap7sol_Pencere4;

                //foreach (var item in listAnaBosaltma4)
                //{
                //    if (item is uc_AnaBosaltma)
                //    {
                //        _fooAnaBosaltma_4 = (uc_AnaBosaltma)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooAnaBosaltma_4.VurmaPos,
                //            EDelikTipi = DelikTipi.AnaBosaltma
                //        });
                //    }
                //    uc_IlaveBosaltma45_5 _fooIlaveBosaltma45_5;
                //    if (item is uc_IlaveBosaltma45_5)
                //    {
                //        _fooIlaveBosaltma45_5 = (uc_IlaveBosaltma45_5)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooIlaveBosaltma45_5.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_1
                //        });
                //    }

                //    uc_IlaveBosaltma6 fooIlaveBosaltma6;
                //    if (item is uc_IlaveBosaltma6)
                //    {
                //        fooIlaveBosaltma6 = (uc_IlaveBosaltma6)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = fooIlaveBosaltma6.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_2
                //        });
                //    }
                //    if (item is uc_Cap7_Sol)
                //    {
                //        _fooCap7sol_Pencere4 = (uc_Cap7_Sol)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sol_Genislik,
                //            dVurmaPos = _fooCap7sol_Pencere4.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sol
                //        });
                //    }
                //    if (item is uc_Cap7_Sag)
                //    {
                //        _fooCap7sag_Pencere4 = (uc_Cap7_Sag)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sag_Genislik,
                //            dVurmaPos = _fooCap7sag_Pencere4.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sag
                //        });
                //    }
                //}
                #endregion

                #region [Yayma Alanı 1]

                double YaymaAlanı_1 = CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, Pencere_Bir, dAnaBosaltmaBoy, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm)
                                      - CalculateCap7Bas(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm);
                double delikAralıgı_1 = CalculateDelikAralıgı_Anabos(YaymaAlanı_1, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_1 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_1, dMontajDelikleriArasıBosluk_mm);


                List<UserControl> listofreturn_1 = new List<UserControl>();
                listofreturn_1 = ListYaymaTekCift(delikAralıkAdedi_1, delikAralıgı_1, dVidaVeSogutmaDisMesafesi_Bas_mm, "çift");

                uc_Cap7_Sag _fooCap7sag_1;
                uc_Cap7_Sol _fooCap7sol_1;
                if (listofreturn_1.Count().Equals(0))
                {
                    sonElemanTekCiftDurumu = "çift";
                }
                foreach (var item in listofreturn_1)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_1 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_1.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_1 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_1.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_1.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }

                if (listofreturn_1.Count.Equals(0))
                {
                    sonElemanTekCiftDurumu = "tek";
                }

                #endregion

                #region [Yayma Alanı 2]

                double YaymaAlanı_2 = CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, Pencere_Iki, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm) -
                                      CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, Pencere_Bir, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);

                double delikAralıgı_2 = CalculateDelikAralıgı_Anabos(YaymaAlanı_2, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_2 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_2, dMontajDelikleriArasıBosluk_mm);

                double delikYaymaBaslangıcNoktası =
                    Pencere_Bir - 128 + dAnaBosaltmaBoy / 2 + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm;

                List<UserControl> listofreturn_2 = new List<UserControl>();
                listofreturn_2 = ListYaymaTekCift(delikAralıkAdedi_2, delikAralıgı_2, delikYaymaBaslangıcNoktası, sonElemanTekCiftDurumu);

                uc_Cap7_Sag _fooCap7sag_2;
                uc_Cap7_Sol _fooCap7sol_2;

                foreach (var item in listofreturn_2)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_2 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_2.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_2 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_2.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_2.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }

                #endregion

                #region [Yayma Alanı 3]

                double YaymaAlanı_3 = CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, Pencere_Uc, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm) -
                                      CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, Pencere_Iki, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);

                double delikAralıgı_3 = CalculateDelikAralıgı_Anabos(YaymaAlanı_3, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_3 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_3, dMontajDelikleriArasıBosluk_mm);

                double delikYaymaBaslangıcNoktası_3 =
                    Pencere_Iki - 128 + dAnaBosaltmaBoy / 2 + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm;

                List<UserControl> listofreturn_3 = new List<UserControl>();
                listofreturn_3 = ListYaymaTekCift(delikAralıkAdedi_3, delikAralıgı_3, delikYaymaBaslangıcNoktası_3, sonElemanTekCiftDurumu);

                uc_Cap7_Sag _fooCap7sag_3;
                uc_Cap7_Sol _fooCap7sol_3;

                foreach (var item in listofreturn_3)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_3 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_3.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_3 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_3.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_3.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }

                #endregion

                #region [Yayma Alanı 4]

                double YaymaAlanı_4 = CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, Pencere_Dort, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm) -
                                      CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, Pencere_Uc, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);

                double delikAralıgı_4 = CalculateDelikAralıgı_Anabos(YaymaAlanı_4, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_4 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_4, dMontajDelikleriArasıBosluk_mm);

                double delikYaymaBaslangıcNoktası_4 =
                    Pencere_Uc - 128 + dAnaBosaltmaBoy / 2 + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm;

                List<UserControl> listofreturn_4 = new List<UserControl>();
                listofreturn_4 = ListYaymaTekCift(delikAralıkAdedi_4, delikAralıgı_4, delikYaymaBaslangıcNoktası_4, sonElemanTekCiftDurumu);

                uc_Cap7_Sag _fooCap7sag_4;
                uc_Cap7_Sol _fooCap7sol_4;

                foreach (var item in listofreturn_4)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_4 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_4.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_4 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_4.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_4.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }

                #endregion

                #region [Yayma Alanı 5]

                double YaymaAlanı_5 = CalculateCap7Son(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Son_mm, MmBoy) -
                                      CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, pencere_Dort, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);

                double delikAralıgı_5 = CalculateDelikAralıgı_Anabos(YaymaAlanı_5, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_5 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_5, dMontajDelikleriArasıBosluk_mm);

                double delikYaymaBaslangıcNoktası_5 =
                    pencere_Dort - 128 + dAnaBosaltmaBoy / 2 + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm;

                List<UserControl> listofreturn_5 = new List<UserControl>();
                listofreturn_5 = ListYaymaTekCift(delikAralıkAdedi_5, delikAralıgı_5, delikYaymaBaslangıcNoktası_5, sonElemanTekCiftDurumu);

                uc_Cap7_Sag _fooCap7sag_5;
                uc_Cap7_Sol _fooCap7sol_5;

                foreach (var item in listofreturn_5)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_5 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_5.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_5 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_5.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_5.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }

                #endregion
            }
            #endregion

            #region [////////////////////        pencere_Bes      \\\\\\\\\\\\\\\\\\\\]

            if (this.PencereAdedi == ePencereAdedi.pencere_Bes && this.MmBoy > 0 && pencere_Bir_MinLimit > 0 &&
                pencereArasılimit_2 > 0 && pencereArasılimit_3 > 0 && pencereArasılimit_4 > 0 &&
                pencereArasılimit_5 > 0 && pencere_Bes_MaxLimit > 0 && !bYatayKöseLeft_Selected && !bYatayKöseRight_Selected)
            {
                #region [Baş Takoz ve Çap7'ler]
                uc_BasTakozSlotlari uc_BasTakozSon_PlugIn = new uc_BasTakozSlotlari(
                    new Point(dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                    CalculateBasTakozSon(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm, MmBoy));
                this.panel_ust.Controls.Add(uc_BasTakozSon_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = 0.0,
                    dVurmaPos = uc_BasTakozSon_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.BasTakoz
                });

                uc_BasTakozSlotlari_Ters uc_BasTakozTersSon_PlugIn =
                    new uc_BasTakozSlotlari_Ters(new Point(dBasTakozDisMesafesi_px, this.panel_alt.Height / 2));
                this.panel_alt.Controls.Add(uc_BasTakozTersSon_PlugIn);

                uc_BasTakozSlotlari uc_BasTakozBas_PlugIn = new uc_BasTakozSlotlari(
                    new Point(this.panel_ust.Width - dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                    CalculateBasTakozBas(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm));
                this.panel_ust.Controls.Add(uc_BasTakozBas_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = 0.0,
                    dVurmaPos = uc_BasTakozBas_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.BasTakoz
                });

                uc_BasTakozSlotlari_Ters uc_BasTakozTersBas_PlugIn =
                    new uc_BasTakozSlotlari_Ters(new Point(this.panel_alt.Width - dBasTakozDisMesafesi_px,
                        this.panel_alt.Height / 2));
                this.panel_alt.Controls.Add(uc_BasTakozTersBas_PlugIn);

                uc_Cap7_Sol uc_cap7BasUst_PlugIn =
                    new uc_Cap7_Sol(new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                        CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sol_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7BasUst_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7BasUst_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7BasUst_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sol
                });

                uc_Cap7_Sag uc_cap7BasAlt_PlugIn =
                    new uc_Cap7_Sag(
                        new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height - this.panel_orta.Height / 4),
                        CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sag_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7BasAlt_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7BasAlt_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7BasAlt_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sag
                });

                uc_Cap7_Sol uc_cap7SonUst_PlugIn =
                    new uc_Cap7_Sol(
                        new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                        CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sol_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7SonUst_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7SonUst_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7SonUst_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sol
                });

                uc_Cap7_Sag uc_cap7SonAlt_PlugIn = new uc_Cap7_Sag(
                    new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px,
                        this.panel_orta.Height - this.panel_orta.Height / 4),
                    CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sag_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7SonAlt_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7SonAlt_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7SonAlt_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sag
                });

                #endregion

                #region [50mm Sonrasına Vurulacak 11x20 ve Cap7 Delikleri]

                if (!b11x20VeCap7Disable_Min)
                {
                    ///////////////////////////////////////     50mm Sonrasına Vurulacak 11x20 ve Cap7 Delikleri Baş      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    List<arrProductionElement> listReturned11x20VeCap7 = BasaVurulacakCap7Ve11x20Delikleri(dVidaVeSogutmaDisMesafesi_Bas_px, dVidaVeSogutmaDisMesafesi_Bas_mm);
                    foreach (var item in listReturned11x20VeCap7)
                    {
                        returned_ListOfDelik.Add(item);
                    }
                }
                if (!b11x20VeCap7Disable_Max)
                {
                    /////////////////////////////////////     50mm Sonrasına Vurulacak 11x20 ve Cap7 Delikleri Son      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    List<arrProductionElement> listReturned11x20VeCap7 = SonaVurulacakCap7Ve11x20Delikleri(dVidaVeSogutmaDisMesafesi_Son_px, dVidaVeSogutmaDisMesafesi_Son_mm);
                    foreach (var item in listReturned11x20VeCap7)
                    {
                        returned_ListOfDelik.Add(item);
                    }
                }
                #endregion

                #region [Manivela Delikleri]

                /////////////////////////////////////     Manivela Delikleri Baş      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (bManivelaDeligiSağAktif)
                {
                    uc_ManivelaDeligi uc_ManivelaBas = new uc_ManivelaDeligi(
                        new Point(this.panel_ust.Width - dManivelaDelikDisMesafesi_px,
                            (this.panel_ust.Height / 2) - 1),
                        CalculateManivelaBas(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm));
                    this.panel_ust.Controls.Add(uc_ManivelaBas);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_ManivelaBas.VurmaPos,
                        EDelikTipi = DelikTipi.Manivela
                    });

                    uc_ManivelaDeligi uc_ManivelaBasAlt = new uc_ManivelaDeligi(
                        new Point(this.panel_ust.Width - dManivelaDelikDisMesafesi_px,
                            (this.panel_alt.Height / 2) + 1),
                        CalculateManivelaBas(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm));
                    this.panel_alt.Controls.Add(uc_ManivelaBasAlt);
                }

                /////////////////////////////////////     Manivela Delikleri Son      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (bManivelaDeligiSolAktif)
                {
                    uc_ManivelaDeligi uc_ManivelaSon = new uc_ManivelaDeligi(
                        new Point(dManivelaDelikDisMesafesi_px, (this.panel_ust.Height / 2) - 1),
                        CalculateManivelaSon(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm, MmBoy));
                    this.panel_ust.Controls.Add(uc_ManivelaSon);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_ManivelaSon.VurmaPos,
                        EDelikTipi = DelikTipi.Manivela
                    });

                    uc_ManivelaDeligi uc_ManivelaSonAlt = new uc_ManivelaDeligi(
                        new Point(dManivelaDelikDisMesafesi_px, (this.panel_alt.Height / 2) + 1),
                        CalculateManivelaSon(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm, MmBoy));
                    this.panel_alt.Controls.Add(uc_ManivelaSonAlt);
                }

                #endregion

                #region [Ana Boşaltma 1]
                List<arrProductionElement> listReturnedAnaBosaltma_1 = new List<arrProductionElement>(ListAnaBosaltmaTuru(Pencere_Bir, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi));
                foreach (var item in listReturnedAnaBosaltma_1)
                {
                    returned_ListOfDelik.Add(item);
                }
                #endregion

                #region [Ana Boşaltma 2]
                List<arrProductionElement> listReturnedAnaBosaltma_2 = new List<arrProductionElement>(ListAnaBosaltmaTuru(Pencere_Iki, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi));
                foreach (var item in listReturnedAnaBosaltma_2)
                {
                    returned_ListOfDelik.Add(item);
                }
                #endregion

                #region [Ana Boşaltma 3]
                List<arrProductionElement> listReturnedAnaBosaltma_3 = new List<arrProductionElement>(ListAnaBosaltmaTuru(Pencere_Uc, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi));
                foreach (var item in listReturnedAnaBosaltma_3)
                {
                    returned_ListOfDelik.Add(item);
                }
                #endregion

                #region [Ana Boşaltma 4]
                List<arrProductionElement> listReturnedAnaBosaltma_4 = new List<arrProductionElement>(ListAnaBosaltmaTuru(Pencere_Dort, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi));
                foreach (var item in listReturnedAnaBosaltma_4)
                {
                    returned_ListOfDelik.Add(item);
                }

                #endregion

                #region [Ana Boşaltma 5]
                List<arrProductionElement> listReturnedAnaBosaltma_5 = new List<arrProductionElement>(ListAnaBosaltmaTuru(Pencere_Bes, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi));
                foreach (var item in listReturnedAnaBosaltma_5)
                {
                    returned_ListOfDelik.Add(item);
                }
                #endregion

                #region [Yayma Alanı 1]

                double YaymaAlanı_1 = CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, Pencere_Bir, dAnaBosaltmaBoy, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm)
                                      - CalculateCap7Bas(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm);
                double delikAralıgı_1 = CalculateDelikAralıgı_Anabos(YaymaAlanı_1, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_1 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_1, dMontajDelikleriArasıBosluk_mm);


                List<UserControl> listofreturn_1 = new List<UserControl>();
                listofreturn_1 = ListYaymaTekCift(delikAralıkAdedi_1, delikAralıgı_1, dVidaVeSogutmaDisMesafesi_Bas_mm, "çift");

                uc_Cap7_Sag _fooCap7sag_1;
                uc_Cap7_Sol _fooCap7sol_1;
                if (listofreturn_1.Count().Equals(0))
                {
                    sonElemanTekCiftDurumu = "çift";
                }
                foreach (var item in listofreturn_1)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_1 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_1.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_1 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_1.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_1.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }

                if (listofreturn_1.Count.Equals(0))
                {
                    sonElemanTekCiftDurumu = "tek";
                }

                #endregion

                #region [Yayma Alanı 2]

                double YaymaAlanı_2 = CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, Pencere_Iki, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm) -
                                      CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, Pencere_Bir, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);

                double delikAralıgı_2 = CalculateDelikAralıgı_Anabos(YaymaAlanı_2, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_2 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_2, dMontajDelikleriArasıBosluk_mm);

                double delikYaymaBaslangıcNoktası =
                    Pencere_Bir - 128 + dAnaBosaltmaBoy / 2 + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm;

                List<UserControl> listofreturn_2 = new List<UserControl>();
                listofreturn_2 = ListYaymaTekCift(delikAralıkAdedi_2, delikAralıgı_2, delikYaymaBaslangıcNoktası, sonElemanTekCiftDurumu);

                uc_Cap7_Sag _fooCap7sag_2;
                uc_Cap7_Sol _fooCap7sol_2;

                foreach (var item in listofreturn_2)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_2 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_2.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_2 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_2.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_2.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }

                #endregion

                #region [Yayma Alanı 3]

                double YaymaAlanı_3 = CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, Pencere_Uc, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm) -
                                      CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, Pencere_Iki, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);

                double delikAralıgı_3 = CalculateDelikAralıgı_Anabos(YaymaAlanı_3, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_3 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_3, dMontajDelikleriArasıBosluk_mm);

                double delikYaymaBaslangıcNoktası_3 =
                    Pencere_Iki - 128 + dAnaBosaltmaBoy / 2 + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm;

                List<UserControl> listofreturn_3 = new List<UserControl>();
                listofreturn_3 = ListYaymaTekCift(delikAralıkAdedi_3, delikAralıgı_3, delikYaymaBaslangıcNoktası_3, sonElemanTekCiftDurumu);

                uc_Cap7_Sag _fooCap7sag_3;
                uc_Cap7_Sol _fooCap7sol_3;

                foreach (var item in listofreturn_3)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_3 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_3.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_3 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_3.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_3.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }

                #endregion

                #region [Yayma Alanı 4]

                double YaymaAlanı_4 = CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, Pencere_Dort, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm) -
                                      CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, Pencere_Uc, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);

                double delikAralıgı_4 = CalculateDelikAralıgı_Anabos(YaymaAlanı_4, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_4 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_4, dMontajDelikleriArasıBosluk_mm);

                double delikYaymaBaslangıcNoktası_4 =
                    Pencere_Uc - 128 + dAnaBosaltmaBoy / 2 + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm;

                List<UserControl> listofreturn_4 = new List<UserControl>();
                listofreturn_4 = ListYaymaTekCift(delikAralıkAdedi_4, delikAralıgı_4, delikYaymaBaslangıcNoktası_4, sonElemanTekCiftDurumu);

                uc_Cap7_Sag _fooCap7sag_4;
                uc_Cap7_Sol _fooCap7sol_4;

                foreach (var item in listofreturn_4)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_4 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_4.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_4 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_4.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_4.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }

                #endregion

                #region [Yayma Alanı 5]

                double YaymaAlanı_5 = CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, Pencere_Bes, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm) -
                                      CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, Pencere_Dort, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);


                double delikAralıgı_5 = CalculateDelikAralıgı_Anabos(YaymaAlanı_5, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_5 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_5, dMontajDelikleriArasıBosluk_mm);

                double delikYaymaBaslangıcNoktası_5 =
                    pencere_Dort - 128 + dAnaBosaltmaBoy / 2 + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm;

                List<UserControl> listofreturn_5 = new List<UserControl>();
                listofreturn_5 = ListYaymaTekCift(delikAralıkAdedi_5, delikAralıgı_5, delikYaymaBaslangıcNoktası_5, sonElemanTekCiftDurumu);

                uc_Cap7_Sag _fooCap7sag_5;
                uc_Cap7_Sol _fooCap7sol_5;

                foreach (var item in listofreturn_5)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_5 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_5.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_5 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_5.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_5.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }

                #endregion

                #region [Yayma Alanı 6]

                double YaymaAlanı_6 = CalculateCap7Son(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Son_mm, MmBoy) -
                                      CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, Pencere_Bes, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);

                double delikAralıgı_6 = CalculateDelikAralıgı_Anabos(YaymaAlanı_6, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_6 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_6, dMontajDelikleriArasıBosluk_mm);

                double delikYaymaBaslangıcNoktası_6 =
                    Pencere_Bes - 128 + dAnaBosaltmaBoy / 2 + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm;

                List<UserControl> listofreturn_6 = new List<UserControl>();
                listofreturn_6 = ListYaymaTekCift(delikAralıkAdedi_6, delikAralıgı_6, delikYaymaBaslangıcNoktası_6, sonElemanTekCiftDurumu);

                uc_Cap7_Sag _fooCap7sag_6;
                uc_Cap7_Sol _fooCap7sol_6;

                foreach (var item in listofreturn_6)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_6 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_6.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_6 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_6.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_6.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }
                #endregion
            }
            #endregion

            #region [////////////////////        pencere_Alti     \\\\\\\\\\\\\\\\\\\\]

            if (this.PencereAdedi == ePencereAdedi.pencere_Alti && this.MmBoy > 0 && pencere_Bir_MinLimit > 0 &&
                pencereArasılimit_2 > 0 && pencereArasılimit_3 > 0 && pencereArasılimit_4 > 0 &&
                pencereArasılimit_5 > 0 && pencereArasılimit_6 > 0 && pencere_Alti_MaxLimit > 0 && !bYatayKöseLeft_Selected && !bYatayKöseRight_Selected)
            {
                #region [Baş Takoz ve Çap7'ler]
                uc_BasTakozSlotlari uc_BasTakozSon_PlugIn = new uc_BasTakozSlotlari(
                    new Point(dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                    CalculateBasTakozSon(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm, MmBoy));
                this.panel_ust.Controls.Add(uc_BasTakozSon_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = 0.0,
                    dVurmaPos = uc_BasTakozSon_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.BasTakoz
                });

                uc_BasTakozSlotlari_Ters uc_BasTakozTersSon_PlugIn =
                    new uc_BasTakozSlotlari_Ters(new Point(dBasTakozDisMesafesi_px, this.panel_alt.Height / 2));
                this.panel_alt.Controls.Add(uc_BasTakozTersSon_PlugIn);

                uc_BasTakozSlotlari uc_BasTakozBas_PlugIn = new uc_BasTakozSlotlari(
                    new Point(this.panel_ust.Width - dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                    CalculateBasTakozBas(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm));
                this.panel_ust.Controls.Add(uc_BasTakozBas_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = 0.0,
                    dVurmaPos = uc_BasTakozBas_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.BasTakoz
                });

                uc_BasTakozSlotlari_Ters uc_BasTakozTersBas_PlugIn =
                    new uc_BasTakozSlotlari_Ters(new Point(this.panel_alt.Width - dBasTakozDisMesafesi_px,
                        this.panel_alt.Height / 2));
                this.panel_alt.Controls.Add(uc_BasTakozTersBas_PlugIn);

                uc_Cap7_Sol uc_cap7BasUst_PlugIn =
                    new uc_Cap7_Sol(new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                        CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sol_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7BasUst_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7BasUst_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7BasUst_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sol
                });

                uc_Cap7_Sag uc_cap7BasAlt_PlugIn =
                    new uc_Cap7_Sag(
                        new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height - this.panel_orta.Height / 4),
                        CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sag_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7BasAlt_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7BasAlt_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7BasAlt_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sag
                });

                uc_Cap7_Sol uc_cap7SonUst_PlugIn =
                    new uc_Cap7_Sol(
                        new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                        CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sol_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7SonUst_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7SonUst_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7SonUst_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sol
                });

                uc_Cap7_Sag uc_cap7SonAlt_PlugIn = new uc_Cap7_Sag(
                    new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px,
                        this.panel_orta.Height - this.panel_orta.Height / 4),
                    CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sag_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7SonAlt_PlugIn);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7SonAlt_PlugIn.GenislikPos,
                    dVurmaPos = uc_cap7SonAlt_PlugIn.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sag
                });

                #endregion

                #region [50mm Sonrasına Vurulacak 11x20 ve Cap7 Delikleri]

                if (!b11x20VeCap7Disable_Min)
                {
                    ///////////////////////////////////////     50mm Sonrasına Vurulacak 11x20 ve Cap7 Delikleri Baş      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    List<arrProductionElement> listReturned11x20VeCap7 = BasaVurulacakCap7Ve11x20Delikleri(dVidaVeSogutmaDisMesafesi_Bas_px, dVidaVeSogutmaDisMesafesi_Bas_mm);
                    foreach (var item in listReturned11x20VeCap7)
                    {
                        returned_ListOfDelik.Add(item);
                    }
                }
                if (!b11x20VeCap7Disable_Max)
                {
                    /////////////////////////////////////     50mm Sonrasına Vurulacak 11x20 ve Cap7 Delikleri Son      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    List<arrProductionElement> listReturned11x20VeCap7 = SonaVurulacakCap7Ve11x20Delikleri(dVidaVeSogutmaDisMesafesi_Son_px, dVidaVeSogutmaDisMesafesi_Son_mm);
                    foreach (var item in listReturned11x20VeCap7)
                    {
                        returned_ListOfDelik.Add(item);
                    }
                }
                #endregion

                #region [Manivela Delikleri]

                /////////////////////////////////////     Manivela Delikleri Baş      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (bManivelaDeligiSağAktif)
                {
                    uc_ManivelaDeligi uc_ManivelaBas = new uc_ManivelaDeligi(
                        new Point(this.panel_ust.Width - dManivelaDelikDisMesafesi_px,
                            (this.panel_ust.Height / 2) - 1),
                        CalculateManivelaBas(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm));
                    this.panel_ust.Controls.Add(uc_ManivelaBas);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_ManivelaBas.VurmaPos,
                        EDelikTipi = DelikTipi.Manivela
                    });

                    uc_ManivelaDeligi uc_ManivelaBasAlt = new uc_ManivelaDeligi(
                        new Point(this.panel_ust.Width - dManivelaDelikDisMesafesi_px,
                            (this.panel_alt.Height / 2) + 1),
                        CalculateManivelaBas(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm));
                    this.panel_alt.Controls.Add(uc_ManivelaBasAlt);
                }

                /////////////////////////////////////     Manivela Delikleri Son      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                if (bManivelaDeligiSolAktif)
                {
                    uc_ManivelaDeligi uc_ManivelaSon = new uc_ManivelaDeligi(
                        new Point(dManivelaDelikDisMesafesi_px, (this.panel_ust.Height / 2) - 1),
                        CalculateManivelaSon(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm, MmBoy));
                    this.panel_ust.Controls.Add(uc_ManivelaSon);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_ManivelaSon.VurmaPos,
                        EDelikTipi = DelikTipi.Manivela
                    });

                    uc_ManivelaDeligi uc_ManivelaSonAlt = new uc_ManivelaDeligi(
                        new Point(dManivelaDelikDisMesafesi_px, (this.panel_alt.Height / 2) + 1),
                        CalculateManivelaSon(Mm_OncesindekiBoy, dManivelaDelikDisMesafesi_mm, MmBoy));
                    this.panel_alt.Controls.Add(uc_ManivelaSonAlt);
                }

                #endregion

                #region [Ana Boşaltma 1]
                List<arrProductionElement> listReturnedAnaBosaltma_1 = new List<arrProductionElement>(ListAnaBosaltmaTuru(Pencere_Bir, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi));
                foreach (var item in listReturnedAnaBosaltma_1)
                {
                    returned_ListOfDelik.Add(item);
                }
                //List<UserControl> listAnaBosaltma1 = new List<UserControl>();
                //listAnaBosaltma1 = ListAnaBosaltmaTuru();

                //uc_AnaBosaltma _fooAnaBosaltma_1;
                //uc_Cap7_Sag _fooCap7sag_1_Pencere2;
                //uc_Cap7_Sol _fooCap7sol_1_Pencere2;

                //foreach (var item in listAnaBosaltma1)
                //{
                //    if (item is uc_AnaBosaltma)
                //    {
                //        _fooAnaBosaltma_1 = (uc_AnaBosaltma)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooAnaBosaltma_1.VurmaPos,
                //            EDelikTipi = DelikTipi.AnaBosaltma
                //        });
                //    }
                //    uc_IlaveBosaltma45_5 _fooIlaveBosaltma45_5;
                //    if (item is uc_IlaveBosaltma45_5)
                //    {
                //        _fooIlaveBosaltma45_5 = (uc_IlaveBosaltma45_5)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooIlaveBosaltma45_5.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_1
                //        });
                //    }

                //    uc_IlaveBosaltma6 fooIlaveBosaltma6;
                //    if (item is uc_IlaveBosaltma6)
                //    {
                //        fooIlaveBosaltma6 = (uc_IlaveBosaltma6)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = fooIlaveBosaltma6.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_2
                //        });
                //    }
                //    if (item is uc_Cap7_Sol)
                //    {
                //        _fooCap7sol_1_Pencere2 = (uc_Cap7_Sol)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sol_Genislik,
                //            dVurmaPos = _fooCap7sol_1_Pencere2.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sol
                //        });
                //    }
                //    if (item is uc_Cap7_Sag)
                //    {
                //        _fooCap7sag_1_Pencere2 = (uc_Cap7_Sag)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sag_Genislik,
                //            dVurmaPos = _fooCap7sag_1_Pencere2.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sag
                //        });
                //    }
                //}
                #endregion

                #region [Ana Boşaltma 2]
                List<arrProductionElement> listReturnedAnaBosaltma_2 = new List<arrProductionElement>(ListAnaBosaltmaTuru(Pencere_Iki, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi));
                foreach (var item in listReturnedAnaBosaltma_2)
                {
                    returned_ListOfDelik.Add(item);
                }
                //List<UserControl> listAnaBosaltma2 = new List<UserControl>();
                //listAnaBosaltma2 = ListAnaBosaltmaTuru();

                //uc_AnaBosaltma _fooAnaBosaltma_2;
                //uc_Cap7_Sag _fooCap7sag_2_Pencere2;
                //uc_Cap7_Sol _fooCap7sol_2_Pencere2;

                //foreach (var item in listAnaBosaltma2)
                //{
                //    if (item is uc_AnaBosaltma)
                //    {
                //        _fooAnaBosaltma_2 = (uc_AnaBosaltma)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooAnaBosaltma_2.VurmaPos,
                //            EDelikTipi = DelikTipi.AnaBosaltma
                //        });
                //    }
                //    uc_IlaveBosaltma45_5 _fooIlaveBosaltma45_5;
                //    if (item is uc_IlaveBosaltma45_5)
                //    {
                //        _fooIlaveBosaltma45_5 = (uc_IlaveBosaltma45_5)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooIlaveBosaltma45_5.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_1
                //        });
                //    }

                //    uc_IlaveBosaltma6 fooIlaveBosaltma6;
                //    if (item is uc_IlaveBosaltma6)
                //    {
                //        fooIlaveBosaltma6 = (uc_IlaveBosaltma6)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = fooIlaveBosaltma6.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_2
                //        });
                //    }
                //    if (item is uc_Cap7_Sol)
                //    {
                //        _fooCap7sol_2_Pencere2 = (uc_Cap7_Sol)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sol_Genislik,
                //            dVurmaPos = _fooCap7sol_2_Pencere2.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sol
                //        });
                //    }
                //    if (item is uc_Cap7_Sag)
                //    {
                //        _fooCap7sag_2_Pencere2 = (uc_Cap7_Sag)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sag_Genislik,
                //            dVurmaPos = _fooCap7sag_2_Pencere2.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sag
                //        });
                //    }
                //}
                #endregion

                #region [Ana Boşaltma 3]
                List<arrProductionElement> listReturnedAnaBosaltma_3 = new List<arrProductionElement>(ListAnaBosaltmaTuru(Pencere_Uc, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi));
                foreach (var item in listReturnedAnaBosaltma_3)
                {
                    returned_ListOfDelik.Add(item);
                }

                #endregion

                #region [Ana Boşaltma 4]
                List<arrProductionElement> listReturnedAnaBosaltma_4 = new List<arrProductionElement>(ListAnaBosaltmaTuru(Pencere_Dort, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi));
                foreach (var item in listReturnedAnaBosaltma_4)
                {
                    returned_ListOfDelik.Add(item);
                }
                //List<UserControl> listAnaBosaltma4 = new List<UserControl>();
                //listAnaBosaltma4 = ListAnaBosaltmaTuru();

                //uc_AnaBosaltma _fooAnaBosaltma_4;
                //uc_Cap7_Sag _fooCap7sag_Pencere4;
                //uc_Cap7_Sol _fooCap7sol_Pencere4;

                //foreach (var item in listAnaBosaltma4)
                //{
                //    if (item is uc_AnaBosaltma)
                //    {
                //        _fooAnaBosaltma_4 = (uc_AnaBosaltma)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooAnaBosaltma_4.VurmaPos,
                //            EDelikTipi = DelikTipi.AnaBosaltma
                //        });
                //    }
                //    uc_IlaveBosaltma45_5 _fooIlaveBosaltma45_5;
                //    if (item is uc_IlaveBosaltma45_5)
                //    {
                //        _fooIlaveBosaltma45_5 = (uc_IlaveBosaltma45_5)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = _fooIlaveBosaltma45_5.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_1
                //        });
                //    }

                //    uc_IlaveBosaltma6 fooIlaveBosaltma6;
                //    if (item is uc_IlaveBosaltma6)
                //    {
                //        fooIlaveBosaltma6 = (uc_IlaveBosaltma6)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = 0.0,
                //            dVurmaPos = fooIlaveBosaltma6.VurmaPos,
                //            EDelikTipi = DelikTipi.IlaveBosaltma_2
                //        });
                //    }
                //    if (item is uc_Cap7_Sol)
                //    {
                //        _fooCap7sol_Pencere4 = (uc_Cap7_Sol)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sol_Genislik,
                //            dVurmaPos = _fooCap7sol_Pencere4.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sol
                //        });
                //    }
                //    if (item is uc_Cap7_Sag)
                //    {
                //        _fooCap7sag_Pencere4 = (uc_Cap7_Sag)item;
                //        this.panel_orta.Controls.Add(item);
                //        returned_ListOfDelik.Add(new arrProductionElement
                //        {

                //            dGenislikPos = dCap7Sag_Genislik,
                //            dVurmaPos = _fooCap7sag_Pencere4.VurmaPos,
                //            EDelikTipi = DelikTipi.Cap7Sag
                //        });
                //    }
                //}
                #endregion

                #region [Ana Boşaltma 5]
                List<arrProductionElement> listReturnedAnaBosaltma_5 = new List<arrProductionElement>(ListAnaBosaltmaTuru(Pencere_Bes, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi));
                foreach (var item in listReturnedAnaBosaltma_5)
                {
                    returned_ListOfDelik.Add(item);
                }

                #endregion

                #region [Ana Boşaltma 6]
                List<arrProductionElement> listReturnedAnaBosaltma_6 = new List<arrProductionElement>(ListAnaBosaltmaTuru(Pencere_Alti, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm,
                    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, IletkenTipi));
                foreach (var item in listReturnedAnaBosaltma_6)
                {
                    returned_ListOfDelik.Add(item);
                }

                #endregion

                #region [Yayma Alanı 1]

                double YaymaAlanı_1 = CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, Pencere_Bir, dAnaBosaltmaBoy, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm)
                                      - CalculateCap7Bas(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm);
                double delikAralıgı_1 = CalculateDelikAralıgı_Anabos(YaymaAlanı_1, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_1 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_1, dMontajDelikleriArasıBosluk_mm);


                List<UserControl> listofreturn_1 = new List<UserControl>();
                listofreturn_1 = ListYaymaTekCift(delikAralıkAdedi_1, delikAralıgı_1, dVidaVeSogutmaDisMesafesi_Bas_mm, "çift");

                uc_Cap7_Sag _fooCap7sag_1;
                uc_Cap7_Sol _fooCap7sol_1;
                if (listofreturn_1.Count().Equals(0))
                {
                    sonElemanTekCiftDurumu = "çift";
                }
                foreach (var item in listofreturn_1)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_1 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_1.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_1 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_1.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_1.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }

                if (listofreturn_1.Count.Equals(0))
                {
                    sonElemanTekCiftDurumu = "tek";
                }

                #endregion

                #region [Yayma Alanı 2]

                double YaymaAlanı_2 = CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, Pencere_Iki, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm) -
                                      CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, Pencere_Bir, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);

                double delikAralıgı_2 = CalculateDelikAralıgı_Anabos(YaymaAlanı_2, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_2 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_2, dMontajDelikleriArasıBosluk_mm);

                double delikYaymaBaslangıcNoktası =
                    Pencere_Bir - 128 + dAnaBosaltmaBoy / 2 + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm;

                List<UserControl> listofreturn_2 = new List<UserControl>();
                listofreturn_2 = ListYaymaTekCift(delikAralıkAdedi_2, delikAralıgı_2, delikYaymaBaslangıcNoktası, sonElemanTekCiftDurumu);

                uc_Cap7_Sag _fooCap7sag_2;
                uc_Cap7_Sol _fooCap7sol_2;

                foreach (var item in listofreturn_2)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_2 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_2.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_2 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_2.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_2.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }

                #endregion

                #region [Yayma Alanı 3]

                double YaymaAlanı_3 = CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, Pencere_Uc, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm) -
                                      CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, Pencere_Iki, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);

                double delikAralıgı_3 = CalculateDelikAralıgı_Anabos(YaymaAlanı_3, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_3 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_3, dMontajDelikleriArasıBosluk_mm);

                double delikYaymaBaslangıcNoktası_3 =
                    Pencere_Iki - 128 + dAnaBosaltmaBoy / 2 + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm;

                List<UserControl> listofreturn_3 = new List<UserControl>();
                listofreturn_3 = ListYaymaTekCift(delikAralıkAdedi_3, delikAralıgı_3, delikYaymaBaslangıcNoktası_3, sonElemanTekCiftDurumu);

                uc_Cap7_Sag _fooCap7sag_3;
                uc_Cap7_Sol _fooCap7sol_3;

                foreach (var item in listofreturn_3)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_3 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_3.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_3 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_3.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_3.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }

                #endregion

                #region [Yayma Alanı 4]

                double YaymaAlanı_4 = CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, Pencere_Dort, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm) -
                                      CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, Pencere_Uc, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);

                double delikAralıgı_4 = CalculateDelikAralıgı_Anabos(YaymaAlanı_4, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_4 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_4, dMontajDelikleriArasıBosluk_mm);

                double delikYaymaBaslangıcNoktası_4 =
                    Pencere_Uc - 128 + dAnaBosaltmaBoy / 2 + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm;

                List<UserControl> listofreturn_4 = new List<UserControl>();
                listofreturn_4 = ListYaymaTekCift(delikAralıkAdedi_4, delikAralıgı_4, delikYaymaBaslangıcNoktası_4, sonElemanTekCiftDurumu);

                uc_Cap7_Sag _fooCap7sag_4;
                uc_Cap7_Sol _fooCap7sol_4;

                foreach (var item in listofreturn_4)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_4 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_4.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_4 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_4.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_4.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }

                #endregion

                #region [Yayma Alanı 5]

                double YaymaAlanı_5 = CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, Pencere_Bes, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm) -
                                      CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, Pencere_Dort, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);


                double delikAralıgı_5 = CalculateDelikAralıgı_Anabos(YaymaAlanı_5, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_5 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_5, dMontajDelikleriArasıBosluk_mm);

                double delikYaymaBaslangıcNoktası_5 =
                    pencere_Dort - 128 + dAnaBosaltmaBoy / 2 + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm;

                List<UserControl> listofreturn_5 = new List<UserControl>();
                listofreturn_5 = ListYaymaTekCift(delikAralıkAdedi_5, delikAralıgı_5, delikYaymaBaslangıcNoktası_5, sonElemanTekCiftDurumu);

                uc_Cap7_Sag _fooCap7sag_5;
                uc_Cap7_Sol _fooCap7sol_5;

                foreach (var item in listofreturn_5)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_5 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_5.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_5 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_5.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_5.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }

                #endregion

                #region [Yayma Alanı 6]

                double YaymaAlanı_6 = CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, Pencere_Alti, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm) -
                                      CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, Pencere_Bes, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);

                double delikAralıgı_6 = CalculateDelikAralıgı_Anabos(YaymaAlanı_6, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_6 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_6, dMontajDelikleriArasıBosluk_mm);

                double delikYaymaBaslangıcNoktası_6 =
                    Pencere_Alti - 128 + dAnaBosaltmaBoy / 2 + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm;

                List<UserControl> listofreturn_6 = new List<UserControl>();
                listofreturn_6 = ListYaymaTekCift(delikAralıkAdedi_6, delikAralıgı_6, delikYaymaBaslangıcNoktası_6, sonElemanTekCiftDurumu);

                uc_Cap7_Sag _fooCap7sag_6;
                uc_Cap7_Sol _fooCap7sol_6;

                foreach (var item in listofreturn_6)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_6 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_6.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_6 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_6.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_6.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }
                #endregion

                #region [Yayma Alanı 7]

                double YaymaAlanı_7 = CalculateCap7Son(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Son_mm, MmBoy) -
                                      CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, Pencere_Bes, dAnaBosaltmaBoy,
                                          dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);

                double delikAralıgı_7 = CalculateDelikAralıgı_Anabos(YaymaAlanı_7, dMontajDelikleriArasıBosluk_mm);
                int delikAralıkAdedi_7 = CalculateDelikAralıkAdedi_AnaBos(YaymaAlanı_7, dMontajDelikleriArasıBosluk_mm);

                double delikYaymaBaslangıcNoktası_7 =
                    Pencere_Bes - 128 + dAnaBosaltmaBoy / 2 + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm;

                List<UserControl> listofreturn_7 = new List<UserControl>();
                listofreturn_6 = ListYaymaTekCift(delikAralıkAdedi_7, delikAralıgı_7, delikYaymaBaslangıcNoktası_7, sonElemanTekCiftDurumu);

                uc_Cap7_Sag _fooCap7sag_7;
                uc_Cap7_Sol _fooCap7sol_7;

                foreach (var item in listofreturn_7)
                {
                    if (item is uc_Cap7_Sag)
                    {
                        _fooCap7sag_7 = (uc_Cap7_Sag)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sag_Genislik,
                            dVurmaPos = _fooCap7sag_7.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }

                    if (item is uc_Cap7_Sol)
                    {
                        _fooCap7sol_7 = (uc_Cap7_Sol)item;
                        this.panel_orta.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = dCap7Sol_Genislik,
                            dVurmaPos = _fooCap7sol_7.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                    }
                    uc_11x20Slot _foo11x20Slot_1;
                    uc_11x20Slot2 _foo11x20Slot2_1;
                    if (item is uc_11x20Slot)
                    {
                        _foo11x20Slot_1 = (uc_11x20Slot)item;
                        this.panel_ust.Controls.Add(item);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {

                            dGenislikPos = 0.0,
                            dVurmaPos = _foo11x20Slot_1.VurmaPos,
                            EDelikTipi = DelikTipi.Delik_11x20
                        });
                    }
                    if (item is uc_11x20Slot2)
                    {
                        _foo11x20Slot2_1 = (uc_11x20Slot2)item;
                        this.panel_alt.Controls.Add(item);
                    }
                    if (listofreturn_7.Last() is uc_Cap7_Sag)
                    {
                        sonElemanTekCiftDurumu = "çift";
                    }
                    else
                    {
                        sonElemanTekCiftDurumu = "tek";
                    }
                }
                #endregion
            }
            #endregion

            #endregion

            #region [////////////////////        Yatay Köşe    \\\\\\\\\\\\\\\\\\\\]

            #region Yatay Köşe İç
            if (bYatayKöseIc_Selected && this.MmBoy > 0 && (bYatayKöseRight_Selected || bYatayKöseLeft_Selected))
            {
                #region Standart olarak vurulan Baş takoz ve çap 7 ler
                uc_BasTakozSlotlari uc_BasTakozSon = new uc_BasTakozSlotlari(
                    new Point(dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                    CalculateBasTakozSon(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm, this.MmBoy));
                this.panel_ust.Controls.Add(uc_BasTakozSon);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = 0.0,
                    dVurmaPos = uc_BasTakozSon.VurmaPos,
                    EDelikTipi = DelikTipi.BasTakoz
                });

                uc_BasTakozSlotlari_Ters uc_BasTakozTersSon =
                    new uc_BasTakozSlotlari_Ters(new Point(dBasTakozDisMesafesi_px, this.panel_alt.Height / 2));
                this.panel_alt.Controls.Add(uc_BasTakozTersSon);

                uc_BasTakozSlotlari uc_BasTakozBas = new uc_BasTakozSlotlari(
                    new Point(this.panel_ust.Width - dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                    CalculateBasTakozBas(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm));
                this.panel_ust.Controls.Add(uc_BasTakozBas);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = 0.0,
                    dVurmaPos = uc_BasTakozBas.VurmaPos,
                    EDelikTipi = DelikTipi.BasTakoz
                });

                uc_BasTakozSlotlari_Ters uc_BasTakozTersBas =
                    new uc_BasTakozSlotlari_Ters(new Point(this.panel_alt.Width - dBasTakozDisMesafesi_px,
                        this.panel_alt.Height / 2));
                this.panel_alt.Controls.Add(uc_BasTakozTersBas);

                uc_Cap7_Sol uc_cap7BasUst =
                    new uc_Cap7_Sol(new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sol_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7BasUst);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7BasUst.GenislikPos,
                    dVurmaPos = uc_cap7BasUst.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sol
                });

                uc_Cap7_Sag uc_cap7BasAl =
                    new uc_Cap7_Sag(
                        new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height - this.panel_orta.Height / 4),
                        CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sag_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7BasAl);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7BasAl.GenislikPos,
                    dVurmaPos = uc_cap7BasAl.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sag
                });

                uc_Cap7_Sol uc_cap7SonUst =
                    new uc_Cap7_Sol(
                        new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                        CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sol_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7SonUst);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7SonUst.GenislikPos,
                    dVurmaPos = uc_cap7SonUst.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sol
                });

                uc_Cap7_Sag uc_cap7SonAlt = new uc_Cap7_Sag(
                    new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px,
                        this.panel_orta.Height - this.panel_orta.Height / 4),
                    CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, MmBoy), dCap7Sag_Genislik_Takoz);
                this.panel_orta.Controls.Add(uc_cap7SonAlt);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = uc_cap7SonAlt.GenislikPos,
                    dVurmaPos = uc_cap7SonAlt.VurmaPos,
                    EDelikTipi = DelikTipi.Cap7Sag
                });
                #endregion

                if (bYatayKöseLeft_Selected)
                {
                    Pencere_Bir = 0;
                    Pencere_Iki = 0;
                    Pencere_Uc = 0;
                    Pencere_Dort = 0;
                    Pencere_Bes = 0;
                    Pencere_Alti = 0;
                    #region Yatay köşe offseti cap 7
                    if (this.MmBoy >= 200)
                    {
                        uc_Cap7_Sol uc_cap7kose_sol =
                            new uc_Cap7_Sol(
                                new Point(this.panel_orta.Width - dIcKöse_Offseti_px, this.panel_orta.Height / 4),
                                CalculateCap7_YatayKose_Left(Mm_OncesindekiBoy, dIcKöse_Offseti_mm), dCap7Sol_Genislik);
                        this.panel_orta.Controls.Add(uc_cap7kose_sol);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {
                            dGenislikPos = uc_cap7kose_sol.GenislikPos,
                            dVurmaPos = uc_cap7kose_sol.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                        uc_Cap7_Sag uc_cap7kose_sag =
                            new uc_Cap7_Sag(
                                new Point(this.panel_orta.Width - dIcKöse_Offseti_px, this.panel_orta.Height - this.panel_orta.Height / 4),
                                CalculateCap7_YatayKose_Left(Mm_OncesindekiBoy, dIcKöse_Offseti_mm), dCap7Sag_Genislik);
                        this.panel_orta.Controls.Add(uc_cap7kose_sag);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {
                            dGenislikPos = uc_cap7kose_sag.GenislikPos,
                            dVurmaPos = uc_cap7kose_sag.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }
                    #endregion
                    List<arrProductionElement> listReturned = Calcul_YaymaAlanıYatayKose_Ic("Left", dBasTakozDisMesafesi_mm, dIcKöse_Offseti_mm, dYatayKose_DelikAraligi_mm);
                    foreach (var item in listReturned)
                    {
                        returned_ListOfDelik.Add(item);
                    }

                }
                else if (bYatayKöseRight_Selected)
                {
                    Pencere_Bir = 0;
                    Pencere_Iki = 0;
                    Pencere_Uc = 0;
                    Pencere_Dort = 0;
                    Pencere_Bes = 0;
                    Pencere_Alti = 0;
                    #region Yatay köşe offseti cap 7
                    if (this.MmBoy >= 200)
                    {
                        uc_Cap7_Sol uc_cap7kose_sol =
                            new uc_Cap7_Sol(
                                new Point(dIcKöse_Offseti_px, this.panel_orta.Height / 4),
                                CalculateCap7_YatayKose_Right(Mm_OncesindekiBoy, dIcKöse_Offseti_mm, this.MmBoy), dCap7Sol_Genislik);
                        this.panel_orta.Controls.Add(uc_cap7kose_sol);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {
                            dGenislikPos = uc_cap7kose_sol.GenislikPos,
                            dVurmaPos = uc_cap7kose_sol.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sol
                        });
                        uc_Cap7_Sag uc_cap7kose_sag =
                            new uc_Cap7_Sag(
                                new Point(dIcKöse_Offseti_px, this.panel_orta.Height - this.panel_orta.Height / 4),
                                CalculateCap7_YatayKose_Right(Mm_OncesindekiBoy, dIcKöse_Offseti_mm, this.MmBoy), dCap7Sag_Genislik);
                        this.panel_orta.Controls.Add(uc_cap7kose_sag);
                        returned_ListOfDelik.Add(new arrProductionElement
                        {
                            dGenislikPos = uc_cap7kose_sag.GenislikPos,
                            dVurmaPos = uc_cap7kose_sag.VurmaPos,
                            EDelikTipi = DelikTipi.Cap7Sag
                        });
                    }
                    #endregion
                    List<arrProductionElement> listReturned = Calcul_YaymaAlanıYatayKose_Ic("Right", dBasTakozDisMesafesi_mm, dIcKöse_Offseti_mm, dYatayKose_DelikAraligi_mm);
                    foreach (var item in listReturned)
                    {
                        returned_ListOfDelik.Add(item);
                    }

                }
            }
            #endregion

            #region Yatay Köşe Dış
            if (bYatayKöseDis_Selected && this.MmBoy > 0)
            {
                if (bYatayKöseLeft_Selected)
                {
                    Pencere_Bir = 0;
                    Pencere_Iki = 0;
                    Pencere_Uc = 0;
                    Pencere_Dort = 0;
                    Pencere_Bes = 0;
                    Pencere_Alti = 0;
                    #region Standart Baş Takozlar
                    uc_BasTakozSlotlari uc_BasTakozSon = new uc_BasTakozSlotlari(
                        new Point(dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                        CalculateBasTakozSon(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm, this.MmBoy));
                    this.panel_ust.Controls.Add(uc_BasTakozSon);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_BasTakozSon.VurmaPos,
                        EDelikTipi = DelikTipi.BasTakoz
                    });

                    uc_BasTakozSlotlari_Ters uc_BasTakozTersSon =
                        new uc_BasTakozSlotlari_Ters(new Point(dBasTakozDisMesafesi_px, this.panel_alt.Height / 2));
                    this.panel_alt.Controls.Add(uc_BasTakozTersSon);

                    uc_Cap7_Sol uc_cap7BasUst =
                        new uc_Cap7_Sol(new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                            CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, this.MmBoy), dCap7Sol_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7BasUst);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7BasUst.GenislikPos,
                        dVurmaPos = uc_cap7BasUst.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sol
                    });

                    uc_Cap7_Sag uc_cap7BasAl =
                        new uc_Cap7_Sag(
                            new Point(dTakozDelikDisMesafesi_px, this.panel_orta.Height - this.panel_orta.Height / 4),
                            CalculateCap7Son(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm, this.MmBoy), dCap7Sag_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7BasAl);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7BasAl.GenislikPos,
                        dVurmaPos = uc_cap7BasAl.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sag
                    });


                    uc_Cap7_Sol uc_cap7OffsetDelikSol =
                        new uc_Cap7_Sol(new Point(cConfiguration.mm_to_pixel_cevir(this.MmBoy - dDisKöse_Offseti_mm), this.panel_orta.Height / 4),
                            dDisKöse_Offseti_mm + this.Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sol_Genislik);
                    this.panel_orta.Controls.Add(uc_cap7OffsetDelikSol);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7OffsetDelikSol.GenislikPos,
                        dVurmaPos = uc_cap7OffsetDelikSol.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sol
                    });

                    uc_Cap7_Sag uc_cap7OffSetDelikSag =
                        new uc_Cap7_Sag(
                            new Point(cConfiguration.mm_to_pixel_cevir(this.MmBoy - dDisKöse_Offseti_mm), this.panel_orta.Height - this.panel_orta.Height / 4),
                            dDisKöse_Offseti_mm + this.Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sag_Genislik);
                    this.panel_orta.Controls.Add(uc_cap7OffSetDelikSag);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7OffSetDelikSag.GenislikPos,
                        dVurmaPos = uc_cap7OffSetDelikSag.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sag
                    });

                    //Köşebent Çap7 ler
                    uc_Cap7_Sol uc_cap7KosebentSol =
                        new uc_Cap7_Sol(new Point(cConfiguration.mm_to_pixel_cevir(this.MmBoy - dKosebentDelikDisMesafesi_px), this.panel_ust.Height / 2),
                            dKosebentDelikDisMesafesi_mm + this.Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sol_Genislik_Kosebent);
                    this.panel_ust.Controls.Add(uc_cap7KosebentSol);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7KosebentSol.GenislikPos,
                        dVurmaPos = uc_cap7KosebentSol.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sol
                    });

                    uc_Cap7_Sag uc_cap7KosebentSag =
                        new uc_Cap7_Sag(
                            new Point(cConfiguration.mm_to_pixel_cevir(this.MmBoy - dKosebentDelikDisMesafesi_px), this.panel_alt.Height - this.panel_alt.Height / 2),
                            dKosebentDelikDisMesafesi_mm + this.Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sag_Genislik_Kosebent);
                    this.panel_alt.Controls.Add(uc_cap7KosebentSag);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7KosebentSag.GenislikPos,
                        dVurmaPos = uc_cap7KosebentSag.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sag
                    });

                    #endregion
                    List<arrProductionElement> listReturned = Calcul_YaymaAlanıYatayKose_Dis("Right", dBasTakozDisMesafesi_mm, dDisKöse_Offseti_mm,
                        dYatayKose_DelikAraligi_mm);
                    foreach (var item in listReturned)
                    {
                        returned_ListOfDelik.Add(item);
                    }

                }
                else if (bYatayKöseRight_Selected)
                {
                    Pencere_Bir = 0;
                    Pencere_Iki = 0;
                    Pencere_Uc = 0;
                    Pencere_Dort = 0;
                    Pencere_Bes = 0;
                    Pencere_Alti = 0;
                    #region Standart Baş Takozlar
                    uc_BasTakozSlotlari uc_BasTakozBas = new uc_BasTakozSlotlari(
                        new Point(this.panel_ust.Width - dBasTakozDisMesafesi_px, this.panel_ust.Height / 2),
                        CalculateBasTakozBas(Mm_OncesindekiBoy, dBasTakozDisMesafesi_mm));
                    this.panel_ust.Controls.Add(uc_BasTakozBas);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = 0.0,
                        dVurmaPos = uc_BasTakozBas.VurmaPos,
                        EDelikTipi = DelikTipi.BasTakoz
                    });

                    uc_BasTakozSlotlari_Ters uc_BasTakozTersBas =
                        new uc_BasTakozSlotlari_Ters(new Point(this.panel_alt.Width - dBasTakozDisMesafesi_px,
                            this.panel_alt.Height / 2));
                    this.panel_alt.Controls.Add(uc_BasTakozTersBas);

                    uc_Cap7_Sol uc_cap7SonUst =
                        new uc_Cap7_Sol(
                            new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px, this.panel_orta.Height / 4),
                            CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sol_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7SonUst);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7SonUst.GenislikPos,
                        dVurmaPos = uc_cap7SonUst.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sol
                    });

                    uc_Cap7_Sag uc_cap7SonAlt = new uc_Cap7_Sag(
                        new Point(this.panel_orta.Width - dTakozDelikDisMesafesi_px,
                            this.panel_orta.Height - this.panel_orta.Height / 4),
                        CalculateCap7Bas(Mm_OncesindekiBoy, dTakozDelikDisMesafesi_mm), dCap7Sag_Genislik_Takoz);
                    this.panel_orta.Controls.Add(uc_cap7SonAlt);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7SonAlt.GenislikPos,
                        dVurmaPos = uc_cap7SonAlt.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sag
                    });

                    uc_Cap7_Sol uc_cap7OffsetDelikSol =
                        new uc_Cap7_Sol(new Point(cConfiguration.mm_to_pixel_cevir(dDisKöse_Offseti_mm), this.panel_orta.Height / 4),
                            this.MmBoy - dDisKöse_Offseti_mm + this.Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sol_Genislik);
                    this.panel_orta.Controls.Add(uc_cap7OffsetDelikSol);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7OffsetDelikSol.GenislikPos,
                        dVurmaPos = uc_cap7OffsetDelikSol.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sol
                    });

                    uc_Cap7_Sag uc_cap7OffSetDelikSag =
                        new uc_Cap7_Sag(
                            new Point(cConfiguration.mm_to_pixel_cevir(dDisKöse_Offseti_mm), this.panel_orta.Height - this.panel_orta.Height / 4),
                            this.MmBoy - dDisKöse_Offseti_mm + this.Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sag_Genislik);
                    this.panel_orta.Controls.Add(uc_cap7OffSetDelikSag);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7OffSetDelikSag.GenislikPos,
                        dVurmaPos = uc_cap7OffSetDelikSag.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sag
                    });

                    //Köşebent Çap7 ler
                    uc_Cap7_Sol uc_cap7KosebentSol =
                        new uc_Cap7_Sol(new Point(cConfiguration.mm_to_pixel_cevir(dKosebentDelikDisMesafesi_px), this.panel_ust.Height / 2),
                            this.MmBoy - dKosebentDelikDisMesafesi_mm + this.Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sol_Genislik_Kosebent);
                    this.panel_ust.Controls.Add(uc_cap7KosebentSol);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7KosebentSol.GenislikPos,
                        dVurmaPos = uc_cap7KosebentSol.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sol
                    });

                    uc_Cap7_Sag uc_cap7KosebentSag =
                        new uc_Cap7_Sag(
                            new Point(cConfiguration.mm_to_pixel_cevir(dKosebentDelikDisMesafesi_px), this.panel_alt.Height - this.panel_alt.Height / 2),
                            this.MmBoy - dKosebentDelikDisMesafesi_mm + this.Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sag_Genislik_Kosebent);
                    this.panel_alt.Controls.Add(uc_cap7KosebentSag);
                    returned_ListOfDelik.Add(new arrProductionElement
                    {
                        dGenislikPos = uc_cap7KosebentSag.GenislikPos,
                        dVurmaPos = uc_cap7KosebentSag.VurmaPos,
                        EDelikTipi = DelikTipi.Cap7Sag
                    });


                    #endregion
                    List<arrProductionElement> listReturned = Calcul_YaymaAlanıYatayKose_Dis("Left", dBasTakozDisMesafesi_mm, dDisKöse_Offseti_mm,
                        dYatayKose_DelikAraligi_mm);
                    foreach (var item in listReturned)
                    {
                        returned_ListOfDelik.Add(item);
                    }

                }
            }
            #endregion
            #endregion

            return returned_ListOfDelik;
        }

        //private eChangedTableLayout fooChangedTableLayout;

        private double delikAralıgı;
        private int delikAralıkAdedi;
        private void Read_InitialValues_FromMachinePars(eIletkenTipi seletectedEIletkenTipi, ePencereAdedi selecEPencereAdedi)
        {
            KalipMesafeleri.Cap7 = MachinePars_ToPLC.dicMachinePars_Nums[54].Value;
            KalipMesafeleri.Delik_11x20 = MachinePars_ToPLC.dicMachinePars_Nums[57].Value;
            KalipMesafeleri.BasTakoz = MachinePars_ToPLC.dicMachinePars_Nums[60].Value;
            KalipMesafeleri.Manivela = MachinePars_ToPLC.dicMachinePars_Nums[63].Value;
            KalipMesafeleri.AnaBosaltma = MachinePars_ToPLC.dicMachinePars_Nums[66].Value;
            KalipMesafeleri.IlaveBosaltma_1 = MachinePars_ToPLC.dicMachinePars_Nums[69].Value;
            KalipMesafeleri.IlaveBosaltma_2 = MachinePars_ToPLC.dicMachinePars_Nums[72].Value;
            KalipMesafeleri.Kesme = MachinePars_ToPLC.dicMachinePars_Nums[75].Value;

            #region Cap7 İletken Parametreleri

            //Çap 7 Sol Sağ
            Cap7Sol_Genislik.Home = MachinePars_ToPLC.dicMachinePars_Nums[55].Value;
            Cap7Sol_Genislik.Iletken_3 = MachinePars_ToPLC.dicMachinePars_Nums[58].Value;
            Cap7Sol_Genislik.Iletken_4 = MachinePars_ToPLC.dicMachinePars_Nums[61].Value;
            Cap7Sol_Genislik.Iletken_45 = MachinePars_ToPLC.dicMachinePars_Nums[64].Value;
            Cap7Sol_Genislik.Iletken_5 = MachinePars_ToPLC.dicMachinePars_Nums[67].Value;
            Cap7Sol_Genislik.Iletken_55 = MachinePars_ToPLC.dicMachinePars_Nums[70].Value;
            Cap7Sol_Genislik.Iletken_6 = MachinePars_ToPLC.dicMachinePars_Nums[73].Value;
            Cap7Sol_Genislik.ServoHomePos = MachinePars_ToPLC.dicMachinePars_Nums[84].Value;

            Cap7Sag_Genislik.Home = MachinePars_ToPLC.dicMachinePars_Nums[76].Value;
            Cap7Sag_Genislik.Iletken_3 = MachinePars_ToPLC.dicMachinePars_Nums[79].Value;
            Cap7Sag_Genislik.Iletken_4 = MachinePars_ToPLC.dicMachinePars_Nums[56].Value;
            Cap7Sag_Genislik.Iletken_45 = MachinePars_ToPLC.dicMachinePars_Nums[59].Value;
            Cap7Sag_Genislik.Iletken_5 = MachinePars_ToPLC.dicMachinePars_Nums[62].Value;
            Cap7Sag_Genislik.Iletken_55 = MachinePars_ToPLC.dicMachinePars_Nums[65].Value;
            Cap7Sag_Genislik.Iletken_6 = MachinePars_ToPLC.dicMachinePars_Nums[68].Value;
            Cap7Sag_Genislik.ServoHomePos = MachinePars_ToPLC.dicMachinePars_Nums[85].Value;

            //Yatay Köşe Sol Sağ
            Cap7Sol_Genislik_YatayKose.Home = MachinePars_ToPLC.dicMachinePars_Nums[71].Value;
            Cap7Sol_Genislik_YatayKose.Iletken_3 = MachinePars_ToPLC.dicMachinePars_Nums[74].Value;
            Cap7Sol_Genislik_YatayKose.Iletken_4 = MachinePars_ToPLC.dicMachinePars_Nums[77].Value;
            Cap7Sol_Genislik_YatayKose.Iletken_45 = MachinePars_ToPLC.dicMachinePars_Nums[80].Value;
            Cap7Sol_Genislik_YatayKose.Iletken_5 = MachinePars_ToPLC.dicMachinePars_Nums[83].Value;
            Cap7Sol_Genislik_YatayKose.Iletken_55 = MachinePars_ToPLC.dicMachinePars_Nums[53].Value;
            Cap7Sol_Genislik_YatayKose.Iletken_6 = MachinePars_ToPLC.dicMachinePars_Nums[52].Value;
            Cap7Sol_Genislik_YatayKose.ServoHomePos = MachinePars_ToPLC.dicMachinePars_Nums[86].Value;

            Cap7Sag_Genislik_YatayKose.Home = MachinePars_ToPLC.dicMachinePars_Nums[51].Value;
            Cap7Sag_Genislik_YatayKose.Iletken_3 = MachinePars_ToPLC.dicMachinePars_Nums[50].Value;
            Cap7Sag_Genislik_YatayKose.Iletken_4 = MachinePars_ToPLC.dicMachinePars_Nums[49].Value;
            Cap7Sag_Genislik_YatayKose.Iletken_45 = MachinePars_ToPLC.dicMachinePars_Nums[48].Value;
            Cap7Sag_Genislik_YatayKose.Iletken_5 = MachinePars_ToPLC.dicMachinePars_Nums[47].Value;
            Cap7Sag_Genislik_YatayKose.Iletken_55 = MachinePars_ToPLC.dicMachinePars_Nums[46].Value;
            Cap7Sag_Genislik_YatayKose.Iletken_6 = MachinePars_ToPLC.dicMachinePars_Nums[45].Value;
            Cap7Sag_Genislik_YatayKose.ServoHomePos = MachinePars_ToPLC.dicMachinePars_Nums[87].Value;

            //Takoz Sol Sağ
            Cap7Sol_Genislik_Takoz.Home = MachinePars_ToPLC.dicMachinePars_Nums[29].Value;
            Cap7Sol_Genislik_Takoz.Iletken_3 = MachinePars_ToPLC.dicMachinePars_Nums[31].Value;
            Cap7Sol_Genislik_Takoz.Iletken_4 = MachinePars_ToPLC.dicMachinePars_Nums[33].Value;
            Cap7Sol_Genislik_Takoz.Iletken_45 = MachinePars_ToPLC.dicMachinePars_Nums[35].Value;
            Cap7Sol_Genislik_Takoz.Iletken_5 = MachinePars_ToPLC.dicMachinePars_Nums[37].Value;
            Cap7Sol_Genislik_Takoz.Iletken_55 = MachinePars_ToPLC.dicMachinePars_Nums[39].Value;
            Cap7Sol_Genislik_Takoz.Iletken_6 = MachinePars_ToPLC.dicMachinePars_Nums[41].Value;
            Cap7Sol_Genislik_Takoz.ServoHomePos = MachinePars_ToPLC.dicMachinePars_Nums[88].Value;

            Cap7Sag_Genislik_Takoz.Home = MachinePars_ToPLC.dicMachinePars_Nums[30].Value;
            Cap7Sag_Genislik_Takoz.Iletken_3 = MachinePars_ToPLC.dicMachinePars_Nums[32].Value;
            Cap7Sag_Genislik_Takoz.Iletken_4 = MachinePars_ToPLC.dicMachinePars_Nums[34].Value;
            Cap7Sag_Genislik_Takoz.Iletken_45 = MachinePars_ToPLC.dicMachinePars_Nums[36].Value;
            Cap7Sag_Genislik_Takoz.Iletken_5 = MachinePars_ToPLC.dicMachinePars_Nums[38].Value;
            Cap7Sag_Genislik_Takoz.Iletken_55 = MachinePars_ToPLC.dicMachinePars_Nums[40].Value;
            Cap7Sag_Genislik_Takoz.Iletken_6 = MachinePars_ToPLC.dicMachinePars_Nums[42].Value;
            Cap7Sag_Genislik_Takoz.ServoHomePos = MachinePars_ToPLC.dicMachinePars_Nums[89].Value;

            #endregion

            switch (seletectedEIletkenTipi)
            {
                case eIletkenTipi.Iletken_3:

                    dCap7Sol_Genislik_Takoz = Cap7Sol_Genislik_Takoz.Iletken_3 - Cap7Sol_Genislik_Takoz.Home + Cap7Sol_Genislik.ServoHomePos;
                    dCap7Sag_Genislik_Takoz = Cap7Sag_Genislik_Takoz.Iletken_3 - Cap7Sag_Genislik_Takoz.Home + Cap7Sag_Genislik.ServoHomePos;

                    if (bYatayKöseDis_Selected || bYatayKöseIc_Selected)
                    {
                        dCap7Sol_Genislik = Cap7Sol_Genislik_YatayKose.Iletken_3 - Cap7Sol_Genislik_YatayKose.Home + Cap7Sol_Genislik_YatayKose.ServoHomePos;
                        dCap7Sag_Genislik = Cap7Sag_Genislik_YatayKose.Iletken_3 - Cap7Sag_Genislik_YatayKose.Home + Cap7Sag_Genislik_YatayKose.ServoHomePos;

                    }
                    else
                    {
                        dCap7Sol_Genislik = Cap7Sol_Genislik.Iletken_3 - Cap7Sol_Genislik.Home + Cap7Sol_Genislik.ServoHomePos;
                        dCap7Sag_Genislik = Cap7Sag_Genislik.Iletken_3 - Cap7Sag_Genislik.Home + Cap7Sag_Genislik.ServoHomePos;
                    }
                    break;

                case eIletkenTipi.Iletken_4:

                    dCap7Sol_Genislik_Takoz = Cap7Sol_Genislik_Takoz.Iletken_4 - Cap7Sol_Genislik_Takoz.Home + Cap7Sol_Genislik.ServoHomePos;
                    dCap7Sag_Genislik_Takoz = Cap7Sag_Genislik_Takoz.Iletken_4 - Cap7Sag_Genislik_Takoz.Home + Cap7Sag_Genislik.ServoHomePos;

                    if (bYatayKöseDis_Selected || bYatayKöseIc_Selected)
                    {
                        dCap7Sol_Genislik = Cap7Sol_Genislik_YatayKose.Iletken_4 - Cap7Sol_Genislik_YatayKose.Home + Cap7Sol_Genislik_YatayKose.ServoHomePos;
                        dCap7Sag_Genislik = Cap7Sag_Genislik_YatayKose.Iletken_4 - Cap7Sag_Genislik_YatayKose.Home + Cap7Sag_Genislik_YatayKose.ServoHomePos;
                    }
                    else
                    {
                        dCap7Sol_Genislik = Cap7Sol_Genislik.Iletken_4 - Cap7Sol_Genislik.Home + Cap7Sol_Genislik.ServoHomePos;
                        dCap7Sag_Genislik = Cap7Sag_Genislik.Iletken_4 - Cap7Sag_Genislik.Home + Cap7Sag_Genislik.ServoHomePos;
                    }
                    break;

                case eIletkenTipi.Iletken_45:

                    dCap7Sol_Genislik_Takoz = Cap7Sol_Genislik_Takoz.Iletken_45 - Cap7Sol_Genislik_Takoz.Home + Cap7Sol_Genislik.ServoHomePos;
                    dCap7Sag_Genislik_Takoz = Cap7Sag_Genislik_Takoz.Iletken_45 - Cap7Sag_Genislik_Takoz.Home + Cap7Sag_Genislik.ServoHomePos;

                    if (bYatayKöseDis_Selected || bYatayKöseIc_Selected)
                    {
                        dCap7Sol_Genislik = Cap7Sol_Genislik_YatayKose.Iletken_45 - Cap7Sol_Genislik_YatayKose.Home + Cap7Sol_Genislik_YatayKose.ServoHomePos;
                        dCap7Sag_Genislik = Cap7Sag_Genislik_YatayKose.Iletken_45 - Cap7Sag_Genislik_YatayKose.Home + Cap7Sag_Genislik_YatayKose.ServoHomePos;
                    }
                    else
                    {
                        dCap7Sol_Genislik = Cap7Sol_Genislik.Iletken_45 - Cap7Sol_Genislik.Home + Cap7Sol_Genislik.ServoHomePos;
                        dCap7Sag_Genislik = Cap7Sag_Genislik.Iletken_45 - Cap7Sag_Genislik.Home + Cap7Sag_Genislik.ServoHomePos;
                    }

                    break;

                case eIletkenTipi.Iletken_5:

                    dCap7Sol_Genislik_Takoz = Cap7Sol_Genislik_Takoz.Iletken_5 - Cap7Sol_Genislik_Takoz.Home + Cap7Sol_Genislik.ServoHomePos;
                    dCap7Sag_Genislik_Takoz = Cap7Sag_Genislik_Takoz.Iletken_5 - Cap7Sag_Genislik_Takoz.Home + Cap7Sag_Genislik.ServoHomePos;

                    if (bYatayKöseDis_Selected || bYatayKöseIc_Selected)
                    {
                        dCap7Sol_Genislik = Cap7Sol_Genislik_YatayKose.Iletken_5 - Cap7Sol_Genislik_YatayKose.Home + Cap7Sol_Genislik_YatayKose.ServoHomePos;
                        dCap7Sag_Genislik = Cap7Sag_Genislik_YatayKose.Iletken_5 - Cap7Sag_Genislik_YatayKose.Home + Cap7Sag_Genislik_YatayKose.ServoHomePos;
                    }
                    else
                    {
                        dCap7Sol_Genislik = Cap7Sol_Genislik.Iletken_5 - Cap7Sol_Genislik.Home + Cap7Sol_Genislik.ServoHomePos;
                        dCap7Sag_Genislik = Cap7Sag_Genislik.Iletken_5 - Cap7Sag_Genislik.Home + Cap7Sag_Genislik.ServoHomePos;
                    }
                    break;

                case eIletkenTipi.Iletken_55:

                    dCap7Sol_Genislik_Takoz = Cap7Sol_Genislik_Takoz.Iletken_55 - Cap7Sol_Genislik_Takoz.Home + Cap7Sol_Genislik.ServoHomePos;
                    dCap7Sag_Genislik_Takoz = Cap7Sag_Genislik_Takoz.Iletken_55 - Cap7Sag_Genislik_Takoz.Home + Cap7Sag_Genislik.ServoHomePos;

                    if (bYatayKöseDis_Selected || bYatayKöseIc_Selected)
                    {
                        dCap7Sol_Genislik = Cap7Sol_Genislik_YatayKose.Iletken_55 - Cap7Sol_Genislik_YatayKose.Home + Cap7Sol_Genislik_YatayKose.ServoHomePos;
                        dCap7Sag_Genislik = Cap7Sag_Genislik_YatayKose.Iletken_55 - Cap7Sag_Genislik_YatayKose.Home + Cap7Sag_Genislik_YatayKose.ServoHomePos;
                    }
                    else
                    {
                        dCap7Sol_Genislik = Cap7Sol_Genislik.Iletken_55 - Cap7Sol_Genislik.Home + Cap7Sol_Genislik.ServoHomePos;
                        dCap7Sag_Genislik = Cap7Sag_Genislik.Iletken_55 - Cap7Sag_Genislik.Home + Cap7Sag_Genislik.ServoHomePos;
                    }
                    break;

                case eIletkenTipi.Iletken_6:

                    dCap7Sol_Genislik_Takoz = Cap7Sol_Genislik_Takoz.Iletken_6 - Cap7Sol_Genislik_Takoz.Home + Cap7Sol_Genislik.ServoHomePos;
                    dCap7Sag_Genislik_Takoz = Cap7Sag_Genislik_Takoz.Iletken_6 - Cap7Sag_Genislik_Takoz.Home + Cap7Sag_Genislik.ServoHomePos;

                    if (bYatayKöseDis_Selected || bYatayKöseIc_Selected)
                    {
                        dCap7Sol_Genislik = Cap7Sol_Genislik_YatayKose.Iletken_6 - Cap7Sol_Genislik_YatayKose.Home + Cap7Sol_Genislik_YatayKose.ServoHomePos;
                        dCap7Sag_Genislik = Cap7Sag_Genislik_YatayKose.Iletken_6 - Cap7Sag_Genislik_YatayKose.Home + Cap7Sag_Genislik_YatayKose.ServoHomePos;
                    }
                    else
                    {
                        dCap7Sol_Genislik = Cap7Sol_Genislik.Iletken_6 - Cap7Sol_Genislik.Home + Cap7Sol_Genislik.ServoHomePos;
                        dCap7Sag_Genislik = Cap7Sag_Genislik.Iletken_6 - Cap7Sag_Genislik.Home + Cap7Sag_Genislik.ServoHomePos;
                    }
                    break;

                default:
                    //Alarm
                    break;
            }
        }

        #region [fieldsOfWindowPos]

        private double pencere_Yok;

        public double Pencere_Yok
        {
            get { return pencere_Yok; }
            set { pencere_Yok = value; }
        }

        private double pencere_Bir;

        public double Pencere_Bir
        {
            get { return pencere_Bir; }
            set { pencere_Bir = value; }
        }

        private double pencere_Iki;

        public double Pencere_Iki
        {
            get { return pencere_Iki; }
            set { pencere_Iki = value; }
        }

        private double pencere_Uc;

        public double Pencere_Uc
        {
            get { return pencere_Uc; }
            set { pencere_Uc = value; }
        }

        private double pencere_Dort;

        public double Pencere_Dort
        {
            get { return pencere_Dort; }
            set { pencere_Dort = value; }
        }


        private double pencere_Bes;

        public double Pencere_Bes
        {
            get { return pencere_Bes; }
            set { pencere_Bes = value; }
        }

        private double pencere_Alti;

        public double Pencere_Alti
        {
            get { return pencere_Alti; }
            set { pencere_Alti = value; }
        }

        #endregion

        #region [Calculations]

        /// <summary>
        /// ilkDışMesafe, sonDışMesafe, subPartBoy
        /// </summary>
        /// <param name="basDelik"></param>
        /// <param name="sonDelik"></param>
        /// <param name="subbPartBoy"></param>
        /// <returns></returns>
        ///
        ///
        ///
        private List<arrProductionElement> Calcul_YaymaAlanıYatayKose_Ic(string RightOrLeft, double basTakozParametresi, double offSetParametresi, double yaymaAraligi)
        {
            List<arrProductionElement> returned_ListOfDelik = new List<arrProductionElement>();
            double KalanBoy = 0;
            double SoldanEklenenBoy = basTakozParametresi;
            double SagdanEklenenBoy = basTakozParametresi;
            double subbPartIcindekiPos = 0;
            switch (RightOrLeft)
            {
                case "Right":
                    KalanBoy = this.MmBoy - SagdanEklenenBoy - offSetParametresi;
                    if (yaymaAraligi != 0)
                    {
                        while (KalanBoy >= yaymaAraligi * 2)
                        {
                            subbPartIcindekiPos = this.MmBoy - (yaymaAraligi + SagdanEklenenBoy);
                            uc_11x20Slot uc11X20SlotUst = new uc_11x20Slot(new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos), panel_ust.Height / 2),
                                (this.MmBoy - subbPartIcindekiPos) + Mm_OncesindekiBoy + KalipMesafeleri.Delik_11x20);
                            this.panel_ust.Controls.Add(uc11X20SlotUst);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = 0.0,
                                dVurmaPos = uc11X20SlotUst.VurmaPos,
                                EDelikTipi = DelikTipi.Delik_11x20
                            });

                            uc_11x20Slot uc11X20SlotAlt = new uc_11x20Slot(new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos), panel_alt.Height / 2),
                                (this.MmBoy - subbPartIcindekiPos) + Mm_OncesindekiBoy + KalipMesafeleri.Delik_11x20);
                            this.panel_alt.Controls.Add(uc11X20SlotAlt);

                            uc_Cap7_Sol uc_cap7SonUst =
                                new uc_Cap7_Sol(
                                    new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos), this.panel_orta.Height / 4),
                                    (this.MmBoy - subbPartIcindekiPos) + Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sol_Genislik);
                            this.panel_orta.Controls.Add(uc_cap7SonUst);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = uc_cap7SonUst.GenislikPos,
                                dVurmaPos = uc_cap7SonUst.VurmaPos,
                                EDelikTipi = DelikTipi.Cap7Sol
                            });

                            uc_Cap7_Sag uc_cap7SonAlt = new uc_Cap7_Sag(
                                new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos),
                                    this.panel_orta.Height - this.panel_orta.Height / 4),
                                (this.MmBoy - subbPartIcindekiPos) + Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sag_Genislik);
                            this.panel_orta.Controls.Add(uc_cap7SonAlt);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = uc_cap7SonAlt.GenislikPos,
                                dVurmaPos = uc_cap7SonAlt.VurmaPos,
                                EDelikTipi = DelikTipi.Cap7Sag
                            });
                            KalanBoy = KalanBoy - yaymaAraligi;
                            SagdanEklenenBoy = SagdanEklenenBoy + yaymaAraligi;
                        }

                        if (KalanBoy > yaymaAraligi)
                        {
                            if (subbPartIcindekiPos == 0)
                            {
                                subbPartIcindekiPos = (this.MmBoy - basTakozParametresi + (offSetParametresi)) / 2;
                            }
                            else
                            {
                                subbPartIcindekiPos = (subbPartIcindekiPos + (offSetParametresi)) / 2;
                            }

                            uc_11x20Slot uc11X20SlotUst = new uc_11x20Slot(new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos), panel_ust.Height / 2),
                                (this.MmBoy - subbPartIcindekiPos) + Mm_OncesindekiBoy + KalipMesafeleri.Delik_11x20);
                            this.panel_ust.Controls.Add(uc11X20SlotUst);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = 0.0,
                                dVurmaPos = uc11X20SlotUst.VurmaPos,
                                EDelikTipi = DelikTipi.Delik_11x20
                            });

                            uc_11x20Slot uc11X20SlotAlt = new uc_11x20Slot(new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos), panel_alt.Height / 2),
                                (this.MmBoy - subbPartIcindekiPos) + Mm_OncesindekiBoy + KalipMesafeleri.Delik_11x20);
                            this.panel_alt.Controls.Add(uc11X20SlotAlt);

                            uc_Cap7_Sol uc_cap7SonUst =
                            new uc_Cap7_Sol(
                                new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos), this.panel_orta.Height / 4),
                                (this.MmBoy - subbPartIcindekiPos) + Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sol_Genislik);
                            this.panel_orta.Controls.Add(uc_cap7SonUst);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = uc_cap7SonUst.GenislikPos,
                                dVurmaPos = uc_cap7SonUst.VurmaPos,
                                EDelikTipi = DelikTipi.Cap7Sol
                            });

                            uc_Cap7_Sag uc_cap7SonAlt = new uc_Cap7_Sag(
                                new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos),
                                    this.panel_orta.Height - this.panel_orta.Height / 4),
                                (this.MmBoy - subbPartIcindekiPos) + Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sag_Genislik);
                            this.panel_orta.Controls.Add(uc_cap7SonAlt);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = uc_cap7SonAlt.GenislikPos,
                                dVurmaPos = uc_cap7SonAlt.VurmaPos,
                                EDelikTipi = DelikTipi.Cap7Sag
                            });
                        }
                    }
                    else
                    {
                        MyMessageBox.ShowMessageBox(
                            "Makine parametrelerinden yatay köşe yayma alanını kontrol ediniz.Yayma alani 0 olamaz.Son eklenen parçayı siliniz.");
                    }

                    break;

                case "Left":
                    KalanBoy = this.MmBoy - SoldanEklenenBoy - offSetParametresi;
                    if (yaymaAraligi != 0)
                    {
                        while (KalanBoy >= yaymaAraligi * 2)
                        {
                            subbPartIcindekiPos = yaymaAraligi + SoldanEklenenBoy;
                            uc_11x20Slot uc11X20SlotUst = new uc_11x20Slot(new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos), panel_ust.Height / 2),
                                (this.MmBoy - subbPartIcindekiPos) + Mm_OncesindekiBoy + KalipMesafeleri.Delik_11x20);
                            this.panel_ust.Controls.Add(uc11X20SlotUst);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = 0.0,
                                dVurmaPos = uc11X20SlotUst.VurmaPos,
                                EDelikTipi = DelikTipi.Delik_11x20
                            });

                            uc_11x20Slot uc11X20SlotAlt = new uc_11x20Slot(new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos), panel_alt.Height / 2),
                                this.MmBoy - subbPartIcindekiPos + Mm_OncesindekiBoy + KalipMesafeleri.Delik_11x20);
                            this.panel_alt.Controls.Add(uc11X20SlotAlt);

                            uc_Cap7_Sol uc_cap7SonUst =
                                new uc_Cap7_Sol(
                                    new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos), this.panel_orta.Height / 4),
                                    this.MmBoy - subbPartIcindekiPos + Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sol_Genislik);
                            this.panel_orta.Controls.Add(uc_cap7SonUst);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = uc_cap7SonUst.GenislikPos,
                                dVurmaPos = uc_cap7SonUst.VurmaPos,
                                EDelikTipi = DelikTipi.Cap7Sol
                            });

                            uc_Cap7_Sag uc_cap7SonAlt = new uc_Cap7_Sag(
                                new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos),
                                    this.panel_orta.Height - this.panel_orta.Height / 4),
                                this.MmBoy - subbPartIcindekiPos + Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sag_Genislik);
                            this.panel_orta.Controls.Add(uc_cap7SonAlt);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = uc_cap7SonAlt.GenislikPos,
                                dVurmaPos = uc_cap7SonAlt.VurmaPos,
                                EDelikTipi = DelikTipi.Cap7Sag
                            });
                            KalanBoy = KalanBoy - yaymaAraligi;
                            SoldanEklenenBoy = SoldanEklenenBoy + yaymaAraligi;
                        }

                        if (KalanBoy > yaymaAraligi)
                        {
                            if (subbPartIcindekiPos == 0)
                            {
                                subbPartIcindekiPos = (basTakozParametresi + (this.MmBoy - offSetParametresi)) / 2;
                            }
                            else
                            {
                                subbPartIcindekiPos = (subbPartIcindekiPos + (this.MmBoy - offSetParametresi)) / 2;
                            }
                            uc_11x20Slot uc11X20SlotUst = new uc_11x20Slot(new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos), panel_ust.Height / 2),
                                this.MmBoy - subbPartIcindekiPos + Mm_OncesindekiBoy + KalipMesafeleri.Delik_11x20);
                            this.panel_ust.Controls.Add(uc11X20SlotUst);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = 0.0,
                                dVurmaPos = uc11X20SlotUst.VurmaPos,
                                EDelikTipi = DelikTipi.Delik_11x20
                            });

                            uc_11x20Slot uc11X20SlotAlt = new uc_11x20Slot(new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos), panel_alt.Height / 2),
                                this.MmBoy - subbPartIcindekiPos + Mm_OncesindekiBoy + KalipMesafeleri.Delik_11x20);
                            this.panel_alt.Controls.Add(uc11X20SlotAlt);

                            uc_Cap7_Sol uc_cap7SonUst =
                            new uc_Cap7_Sol(
                                new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos), this.panel_orta.Height / 4),
                                this.MmBoy - subbPartIcindekiPos + Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sol_Genislik);
                            this.panel_orta.Controls.Add(uc_cap7SonUst);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = uc_cap7SonUst.GenislikPos,
                                dVurmaPos = uc_cap7SonUst.VurmaPos,
                                EDelikTipi = DelikTipi.Cap7Sol
                            });

                            uc_Cap7_Sag uc_cap7SonAlt = new uc_Cap7_Sag(
                                new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos),
                                    this.panel_orta.Height - this.panel_orta.Height / 4),
                                this.MmBoy - subbPartIcindekiPos + Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sag_Genislik);
                            this.panel_orta.Controls.Add(uc_cap7SonAlt);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = uc_cap7SonAlt.GenislikPos,
                                dVurmaPos = uc_cap7SonAlt.VurmaPos,
                                EDelikTipi = DelikTipi.Cap7Sag
                            });
                        }
                    }
                    else
                    {
                        MyMessageBox.ShowMessageBox(
                            "Makine parametrelerinden yatay köşe yayma alanını kontrol ediniz.Yayma alani 0 olamaz.Son eklenen parçayı siliniz.");
                    }

                    break;


                default:
                    break;
            }
            return returned_ListOfDelik;
        }
        private List<arrProductionElement> Calcul_YaymaAlanıYatayKose_Dis(string RightOrLeft, double basTakozParametresi, double offSetParametresi, double yaymaAraligi)
        {
            List<arrProductionElement> returned_ListOfDelik = new List<arrProductionElement>();
            double KalanBoy = 0;
            double SoldanEklenenBoy = basTakozParametresi;
            double SagdanEklenenBoy = basTakozParametresi;
            double subbPartIcindekiPos = 0;
            switch (RightOrLeft)
            {
                case "Left":
                    KalanBoy = this.MmBoy - SagdanEklenenBoy - offSetParametresi;
                    if (yaymaAraligi != 0)
                    {
                        while (KalanBoy >= yaymaAraligi * 2)
                        {
                            subbPartIcindekiPos = this.MmBoy - (yaymaAraligi + SagdanEklenenBoy);
                            uc_11x20Slot uc11X20SlotUst = new uc_11x20Slot(new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos), panel_ust.Height / 2),
                                (this.MmBoy - subbPartIcindekiPos) + Mm_OncesindekiBoy + KalipMesafeleri.Delik_11x20);
                            this.panel_ust.Controls.Add(uc11X20SlotUst);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = 0.0,
                                dVurmaPos = uc11X20SlotUst.VurmaPos,
                                EDelikTipi = DelikTipi.Delik_11x20
                            });

                            uc_11x20Slot uc11X20SlotAlt = new uc_11x20Slot(new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos), panel_alt.Height / 2),
                                (this.MmBoy - subbPartIcindekiPos) + Mm_OncesindekiBoy + KalipMesafeleri.Delik_11x20);
                            this.panel_alt.Controls.Add(uc11X20SlotAlt);

                            uc_Cap7_Sol uc_cap7SonUst =
                                new uc_Cap7_Sol(
                                    new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos), this.panel_orta.Height / 4),
                                    (this.MmBoy - subbPartIcindekiPos) + Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sol_Genislik);
                            this.panel_orta.Controls.Add(uc_cap7SonUst);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = uc_cap7SonUst.GenislikPos,
                                dVurmaPos = uc_cap7SonUst.VurmaPos,
                                EDelikTipi = DelikTipi.Cap7Sol
                            });

                            uc_Cap7_Sag uc_cap7SonAlt = new uc_Cap7_Sag(
                                new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos),
                                    this.panel_orta.Height - this.panel_orta.Height / 4),
                                (this.MmBoy - subbPartIcindekiPos) + Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sag_Genislik);
                            this.panel_orta.Controls.Add(uc_cap7SonAlt);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = uc_cap7SonAlt.GenislikPos,
                                dVurmaPos = uc_cap7SonAlt.VurmaPos,
                                EDelikTipi = DelikTipi.Cap7Sag
                            });
                            KalanBoy = KalanBoy - yaymaAraligi;
                            SagdanEklenenBoy = SagdanEklenenBoy + yaymaAraligi;
                        }

                        if (KalanBoy > yaymaAraligi)
                        {
                            if (subbPartIcindekiPos == 0)
                            {
                                subbPartIcindekiPos = (this.MmBoy - basTakozParametresi + (offSetParametresi)) / 2;
                            }
                            else
                            {
                                subbPartIcindekiPos = (subbPartIcindekiPos + (offSetParametresi)) / 2;
                            }

                            uc_Cap7_Sol uc_cap7SonUst =
                            new uc_Cap7_Sol(
                                new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos), this.panel_orta.Height / 4),
                                (this.MmBoy - subbPartIcindekiPos) + Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sol_Genislik);
                            this.panel_orta.Controls.Add(uc_cap7SonUst);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = uc_cap7SonUst.GenislikPos,
                                dVurmaPos = uc_cap7SonUst.VurmaPos,
                                EDelikTipi = DelikTipi.Cap7Sol
                            });

                            uc_Cap7_Sag uc_cap7SonAlt = new uc_Cap7_Sag(
                                new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos),
                                    this.panel_orta.Height - this.panel_orta.Height / 4),
                                (this.MmBoy - subbPartIcindekiPos) + Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sag_Genislik);
                            this.panel_orta.Controls.Add(uc_cap7SonAlt);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = uc_cap7SonAlt.GenislikPos,
                                dVurmaPos = uc_cap7SonAlt.VurmaPos,
                                EDelikTipi = DelikTipi.Cap7Sag
                            });
                        }
                    }
                    else
                    {
                        MyMessageBox.ShowMessageBox(
                            "Makine parametrelerinden yatay köşe yayma alanını kontrol ediniz.Yayma alani 0 olamaz.Son eklenen parçayı siliniz.");
                    }

                    break;

                case "Right":
                    KalanBoy = this.MmBoy - SoldanEklenenBoy - offSetParametresi;
                    if (yaymaAraligi != 0)
                    {
                        while (KalanBoy >= yaymaAraligi * 2)
                        {
                            subbPartIcindekiPos = yaymaAraligi + SoldanEklenenBoy;
                            uc_11x20Slot uc11X20SlotUst = new uc_11x20Slot(new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos), panel_ust.Height / 2),
                                (this.MmBoy - subbPartIcindekiPos) + Mm_OncesindekiBoy + KalipMesafeleri.Delik_11x20);
                            this.panel_ust.Controls.Add(uc11X20SlotUst);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = 0.0,
                                dVurmaPos = uc11X20SlotUst.VurmaPos,
                                EDelikTipi = DelikTipi.Delik_11x20
                            });

                            uc_11x20Slot uc11X20SlotAlt = new uc_11x20Slot(new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos), panel_alt.Height / 2),
                                (this.MmBoy - subbPartIcindekiPos) + Mm_OncesindekiBoy + KalipMesafeleri.Delik_11x20);
                            this.panel_alt.Controls.Add(uc11X20SlotAlt);

                            uc_Cap7_Sol uc_cap7SonUst =
                                new uc_Cap7_Sol(
                                    new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos), this.panel_orta.Height / 4),
                                    (this.MmBoy - subbPartIcindekiPos) + Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sol_Genislik);
                            this.panel_orta.Controls.Add(uc_cap7SonUst);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = uc_cap7SonUst.GenislikPos,
                                dVurmaPos = uc_cap7SonUst.VurmaPos,
                                EDelikTipi = DelikTipi.Cap7Sol
                            });

                            uc_Cap7_Sag uc_cap7SonAlt = new uc_Cap7_Sag(
                                new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos),
                                    this.panel_orta.Height - this.panel_orta.Height / 4),
                                (this.MmBoy - subbPartIcindekiPos) + Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sag_Genislik);
                            this.panel_orta.Controls.Add(uc_cap7SonAlt);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = uc_cap7SonAlt.GenislikPos,
                                dVurmaPos = uc_cap7SonAlt.VurmaPos,
                                EDelikTipi = DelikTipi.Cap7Sag
                            });
                            KalanBoy = KalanBoy - yaymaAraligi;
                            SoldanEklenenBoy = SoldanEklenenBoy + yaymaAraligi;
                        }

                        if (KalanBoy > yaymaAraligi)
                        {
                            if (subbPartIcindekiPos == 0)
                            {
                                subbPartIcindekiPos = (basTakozParametresi + (this.MmBoy - offSetParametresi)) / 2;
                            }
                            else
                            {
                                subbPartIcindekiPos = (subbPartIcindekiPos + (this.MmBoy - offSetParametresi)) / 2;
                            }

                            uc_Cap7_Sol uc_cap7SonUst =
                            new uc_Cap7_Sol(
                                new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos), this.panel_orta.Height / 4),
                                (this.MmBoy - subbPartIcindekiPos) + Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sol_Genislik);
                            this.panel_orta.Controls.Add(uc_cap7SonUst);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = uc_cap7SonUst.GenislikPos,
                                dVurmaPos = uc_cap7SonUst.VurmaPos,
                                EDelikTipi = DelikTipi.Cap7Sol
                            });

                            uc_Cap7_Sag uc_cap7SonAlt = new uc_Cap7_Sag(
                                new Point(cConfiguration.mm_to_pixel_cevir(subbPartIcindekiPos),
                                    this.panel_orta.Height - this.panel_orta.Height / 4),
                                (this.MmBoy - subbPartIcindekiPos) + Mm_OncesindekiBoy + KalipMesafeleri.Cap7, dCap7Sag_Genislik);
                            this.panel_orta.Controls.Add(uc_cap7SonAlt);
                            returned_ListOfDelik.Add(new arrProductionElement
                            {
                                dGenislikPos = uc_cap7SonAlt.GenislikPos,
                                dVurmaPos = uc_cap7SonAlt.VurmaPos,
                                EDelikTipi = DelikTipi.Cap7Sag
                            });
                        }
                    }
                    else
                    {
                        MyMessageBox.ShowMessageBox(
                            "Makine parametrelerinden yatay köşe yayma alanını kontrol ediniz.Yayma alani 0 olamaz.Son eklenen parçayı siliniz.");
                    }

                    break;


                default:
                    break;
            }
            return returned_ListOfDelik;
        }
        private double CalculateYaymaAlanıOrta(double basDelik, double sonDelik, double subbPartBoy)    //Yayma alanının ortasından sağ tarafa(parçanın ön ucu) olan uzaklığını verir.
        {
            return ((subbPartBoy - (basDelik + sonDelik)) / 2) + basDelik;
        }
        private double CalculateYaymaAlanı(double basDelik, double sonDelik, double _mmBoy)             //Yayma alanı uzunluğunu verir
        {
            return (_mmBoy - (basDelik + sonDelik));
        }
        private double CalculateBasTakozBas(double OncekiBoy, double machinePar)
        {
            return OncekiBoy + machinePar + KalipMesafeleri.BasTakoz;
        }
        private double CalculateBasTakozSon(double OncekiBoy, double machinePar, double subbPartBoy)
        {
            return ((OncekiBoy + (subbPartBoy) - machinePar) + KalipMesafeleri.BasTakoz);
        }
        private double CalculateCap7Bas(double OncekiBoy, double machinePar)
        {
            return OncekiBoy + machinePar + KalipMesafeleri.Cap7;
        }
        private double CalculateCap7_YatayKose_Left(double OncekiBoy, double machinePar)
        {
            return OncekiBoy + machinePar + KalipMesafeleri.Cap7;
        }
        private double CalculateCap7_YatayKose_Right(double OncekiBoy, double machinePar, double subbPartBoy)
        {
            return OncekiBoy + (subbPartBoy - machinePar) + KalipMesafeleri.Cap7;
        }
        private double CalculateCap7Son(double OncekiBoy, double machinePar, double subbPartBoy)
        {
            return ((OncekiBoy + (subbPartBoy) - machinePar) + KalipMesafeleri.Cap7);
        }
        private double Calculate11x20Orta(double OncekiBoy, double _CalculateYaymaAlanı)
        {
            return OncekiBoy + _CalculateYaymaAlanı + KalipMesafeleri.Delik_11x20;
        }
        private double Calculate11x20(double OncekiBoy, double machinePar)
        {
            return OncekiBoy + machinePar + KalipMesafeleri.Delik_11x20;
        }
        private double CalculateCap7Orta(double OncekiBoy, double _CalculateYaymaAlanı)
        {
            return OncekiBoy + _CalculateYaymaAlanı + KalipMesafeleri.Cap7;
        }
        private double CalculateManivelaBas(double OncekiBoy, double machinePar)
        {
            return OncekiBoy + machinePar + KalipMesafeleri.Manivela;
        }
        private double CalculateManivelaSon(double OncekiBoy, double machinePar, double _subbPartBoy)
        {
            return ((OncekiBoy + (_subbPartBoy - machinePar)) + KalipMesafeleri.Manivela);
        }

        #region [ANA BOŞALTMA] //////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// öncekiBoy, pencerePos_1
        /// </summary>
        /// <param name="OncekiBoy"></param>
        /// <param name="machinePar"></param>
        /// <returns></returns>
        private double CalculateAnaBosaltma(double OncekiBoy, double pencerePos)
        {
            return OncekiBoy + (pencerePos - 128) + KalipMesafeleri.AnaBosaltma;
        }
        private double CalculateIlaveBosaltma(double OncekiBoy, double pencerePos, double anaBosaltmaBoy, double ilaveBosaltmaBoy)
        {
            return OncekiBoy + (pencerePos - 128) + (anaBosaltmaBoy / 2) - (ilaveBosaltmaBoy / 2) + KalipMesafeleri.IlaveBosaltma_1;
        }

        /// <summary>
        /// OncekiBoy, MmBoy, pencerePos, dVida...
        /// </summary>
        /// <param name="OncekiBoy"></param>
        /// <param name="pencerePos"></param>
        /// <param name="machinePar"></param>
        /// <returns></returns>
        private double Calculate11x20_AnaBos(double OncekiBoy, double pencerePos, double AnaBosBoy, double machinePar)
        {
            return OncekiBoy + (pencerePos - 128) + (AnaBosBoy / 2) + machinePar + KalipMesafeleri.Delik_11x20;
        }
        private double CalculateCap7_AnaBos_Sag(double OncekiBoy, double pencerePos, double AnaBosBoy, double machinePar)
        {
            return OncekiBoy + (pencerePos - 128) - (AnaBosBoy / 2) - machinePar + KalipMesafeleri.Cap7;
        }

        private double CalculateCap7_AnaBos_Sol(double OncekiBoy, double pencerePos, double AnaBosBoy, double machinePar)
        {
            return OncekiBoy + (pencerePos - 128) + (AnaBosBoy / 2) + machinePar + KalipMesafeleri.Cap7;
        }

        /// <summary>
        /// Pencere_1 Yayma alanı uzunluğunu verir
        /// </summary>
        /// <returns></returns>
        private double CalculateYaymaAlanı1_AnaBos(double basDelik, double sonDelik) //Pencere Yayma alanı uzunluğunu verir
        {

            return (sonDelik - basDelik);
        }

        #endregion /////////////////////////////////////////////////////////////////////////////////////////////////

        private double CalculateDelikAralıgı(double _CalculateYaymaAlanı, double montajDelikleriArasıBosluk)
        {
            return _CalculateYaymaAlanı / CalculateDelikAralıkAdedi(_CalculateYaymaAlanı, montajDelikleriArasıBosluk);
            //Delik Aralığı
        }
        private int CalculateDelikAralıkAdedi(double _CalculateYaymaAlanı, double montajDelikleriArasıBosluk)
        {
            try
            {
                double _delikAralıkAdedi = (Math.Floor(_CalculateYaymaAlanı / montajDelikleriArasıBosluk));
                if (((_delikAralıkAdedi + 1) % 2) == 0)
                { //Even 

                    return Convert.ToInt32(_delikAralıkAdedi + 1);        //Delik Aralığı Adedi
                }
                else
                { //Odd
                    return Convert.ToInt32(_delikAralıkAdedi + 2);    //Delik Aralığı Adedi
                }
            }
            catch (Exception e)
            {
                uc_TekUretimPage.parameters.AltGovdeBoyu = 0;
                MyMessageBox.ShowMessageBox("HATA! *Makine Parametreleri* sayfasındaki *Montaj Delikleri Arası Yatay Boşluk* parametresi sıfırdan büyük bir değer olmak zorundadır.");
                throw;
            }
        }
        private double CalculateDelikAralıgı_Anabos(double _CalculateYaymaAlanı, double montajDelikleriArasıBosluk)
        {
            return _CalculateYaymaAlanı / CalculateDelikAralıkAdedi_AnaBos(_CalculateYaymaAlanı, montajDelikleriArasıBosluk);
            //Delik Aralığı
        }
        private int CalculateDelikAralıkAdedi_AnaBos(double _CalculateYaymaAlanı, double montajDelikleriArasıBosluk)
        {
            try
            {
                double _delikAralıkAdedi = (Math.Ceiling(_CalculateYaymaAlanı / montajDelikleriArasıBosluk));
                return Convert.ToInt32(_delikAralıkAdedi);        //Delik Aralığı Adedi
            }
            catch (Exception e)
            {
                uc_TekUretimPage.parameters.AltGovdeBoyu = 0;
                MyMessageBox.ShowMessageBox("HATA! *Makine Parametreleri* sayfasındaki *Montaj Delikleri Arası Yatay Boşluk* parametresi sıfırdan büyük bir değer olmak zorundadır.");
                throw;
            }
        }
        private double CalculateCap7Yayma(double OncekiBoy, double delikYaymaBaslangıcNoktası, double _delikAralıgı)
        {
            return OncekiBoy + delikYaymaBaslangıcNoktası + _delikAralıgı + KalipMesafeleri.Cap7;
        }
        private double Calculate11x20Yayma(double OncekiBoy, double delikYaymaBaslangıcNoktası, double _delikAralıgı)
        {
            return OncekiBoy + delikYaymaBaslangıcNoktası + _delikAralıgı + KalipMesafeleri.Delik_11x20;
        }

        private double ClaculateCap7Yayma_AnaBosSol(double OncekiBoy, double _vidaVeSogutmaDisMesafesi,
            double _delikAralıgı)
        {
            return OncekiBoy + (MmBoy - _vidaVeSogutmaDisMesafesi) - _delikAralıgı + KalipMesafeleri.Cap7;
        }
        private double ManivelaVe11x20ArasıMesafe(double _manivelaVurmaPos, double _11x20VurmaPos, int manivelaBoy, int _11x20Boy)
        {
            return (_manivelaVurmaPos - KalipMesafeleri.Manivela) - (_11x20VurmaPos - KalipMesafeleri.Delik_11x20) - (_11x20Boy / 2) - (manivelaBoy / 2);
        }
        private double _11x20VeManivelaArasıMesafe(double _manivelaVurmaPos, double _11x20VurmaPos, int manivelaBoy, int _11x20Boy)
        {
            return (_11x20VurmaPos - KalipMesafeleri.Delik_11x20) - (_manivelaVurmaPos - KalipMesafeleri.Manivela) - (manivelaBoy / 2) - (_11x20Boy / 2);
        }

        #endregion

        private List<UserControl> ListYaymaTekCift(int delikAralıkAdedi, double delikAralıgı, double delikYaymaBaslangıcNoktası, string sonElemanTekMiCifMi)
        {
            List<UserControl> listofreturn = new List<UserControl>();

            for (int i = 1; i < delikAralıkAdedi; i++)
            {

                if (sonElemanTekMiCifMi == "çift")
                {
                    if (i % 2 == 0)
                    {
                        int CalculateCap7Yayma_px = cConfiguration.mm_to_pixel_cevir(CalculateCap7Yayma(Mm_OncesindekiBoy, delikYaymaBaslangıcNoktası,
                            i * delikAralıgı) - Mm_OncesindekiBoy - KalipMesafeleri.Cap7);

                        uc_11x20Slot uc_11x20SlotYaymaBas = new uc_11x20Slot(
                            new Point(this.panel_ust.Width - CalculateCap7Yayma_px, this.panel_ust.Height / 2),
                            Calculate11x20Yayma(Mm_OncesindekiBoy, delikYaymaBaslangıcNoktası, i * delikAralıgı));

                        listofreturn.Add(uc_11x20SlotYaymaBas);

                        uc_11x20Slot2 uc_11x20SlotYaymaSon = new uc_11x20Slot2(
                            new Point(this.panel_alt.Width - CalculateCap7Yayma_px, this.panel_alt.Height / 2),
                            Calculate11x20Yayma(Mm_OncesindekiBoy, delikYaymaBaslangıcNoktası, i * delikAralıgı));

                        listofreturn.Add(uc_11x20SlotYaymaSon);

                        uc_Cap7_Sol uc_cap7SolYaymaCiftBas = new uc_Cap7_Sol(
                            new Point(this.panel_orta.Width - CalculateCap7Yayma_px, this.panel_orta.Height / 4),
                            CalculateCap7Yayma(Mm_OncesindekiBoy, delikYaymaBaslangıcNoktası, i * delikAralıgı), dCap7Sol_Genislik);

                        listofreturn.Add(uc_cap7SolYaymaCiftBas);

                        uc_Cap7_Sag uc_cap7SolYaymaCiftSon = new uc_Cap7_Sag(
                            new Point(this.panel_orta.Width - CalculateCap7Yayma_px, panel_orta.Height - this.panel_orta.Height / 4),
                            CalculateCap7Yayma(Mm_OncesindekiBoy, delikYaymaBaslangıcNoktası, i * delikAralıgı), dCap7Sag_Genislik);

                        listofreturn.Add(uc_cap7SolYaymaCiftSon);


                    }
                    else
                    {
                        int CalculateCap7Yayma_px = cConfiguration.mm_to_pixel_cevir(CalculateCap7Yayma(Mm_OncesindekiBoy, delikYaymaBaslangıcNoktası,
                            i * delikAralıgı) - Mm_OncesindekiBoy - KalipMesafeleri.Cap7);

                        uc_11x20Slot uc_11x20SlotYaymaBas = new uc_11x20Slot(
                            new Point(this.panel_ust.Width - CalculateCap7Yayma_px, this.panel_ust.Height / 2),
                            Calculate11x20Yayma(Mm_OncesindekiBoy, delikYaymaBaslangıcNoktası, i * delikAralıgı));

                        listofreturn.Add(uc_11x20SlotYaymaBas);

                        uc_11x20Slot2 uc_11x20SlotYaymaSon = new uc_11x20Slot2(
                            new Point(this.panel_alt.Width - CalculateCap7Yayma_px, this.panel_alt.Height / 2),
                            Calculate11x20Yayma(Mm_OncesindekiBoy, delikYaymaBaslangıcNoktası, i * delikAralıgı));

                        listofreturn.Add(uc_11x20SlotYaymaSon);

                        uc_Cap7_Sol uc_cap7SolYaymaUst = new uc_Cap7_Sol(
                            new Point(this.panel_orta.Width - CalculateCap7Yayma_px, this.panel_orta.Height / 4),
                            CalculateCap7Yayma(Mm_OncesindekiBoy, delikYaymaBaslangıcNoktası, i * delikAralıgı), dCap7Sol_Genislik);

                        listofreturn.Add(uc_cap7SolYaymaUst);
                    }
                }

                if (sonElemanTekMiCifMi == "tek")
                {
                    if (i % 2 == 0)
                    {
                        int CalculateCap7Yayma_px = cConfiguration.mm_to_pixel_cevir(CalculateCap7Yayma(Mm_OncesindekiBoy, delikYaymaBaslangıcNoktası,
                            i * delikAralıgı) - Mm_OncesindekiBoy - KalipMesafeleri.Cap7);

                        uc_11x20Slot uc_11x20SlotYaymaBas = new uc_11x20Slot(
                            new Point(this.panel_ust.Width - CalculateCap7Yayma_px, this.panel_ust.Height / 2),
                            Calculate11x20Yayma(Mm_OncesindekiBoy, delikYaymaBaslangıcNoktası, i * delikAralıgı));

                        listofreturn.Add(uc_11x20SlotYaymaBas);

                        uc_11x20Slot2 uc_11x20SlotYaymaSon = new uc_11x20Slot2(
                            new Point(this.panel_alt.Width - CalculateCap7Yayma_px, this.panel_alt.Height / 2),
                            Calculate11x20Yayma(Mm_OncesindekiBoy, delikYaymaBaslangıcNoktası, i * delikAralıgı));

                        listofreturn.Add(uc_11x20SlotYaymaSon);

                        uc_Cap7_Sol uc_cap7SolYaymaCiftBas = new uc_Cap7_Sol(
                            new Point(this.panel_orta.Width - CalculateCap7Yayma_px, this.panel_orta.Height / 4),
                            CalculateCap7Yayma(Mm_OncesindekiBoy, delikYaymaBaslangıcNoktası,
                                i * delikAralıgı), dCap7Sol_Genislik);

                        listofreturn.Add(uc_cap7SolYaymaCiftBas);
                    }
                    else
                    {
                        int CalculateCap7Yayma_px = cConfiguration.mm_to_pixel_cevir(CalculateCap7Yayma(Mm_OncesindekiBoy, delikYaymaBaslangıcNoktası,
                            i * delikAralıgı) - Mm_OncesindekiBoy - KalipMesafeleri.Cap7);

                        uc_11x20Slot uc_11x20SlotYaymaBas = new uc_11x20Slot(
                            new Point(this.panel_ust.Width - CalculateCap7Yayma_px, this.panel_ust.Height / 2),
                            Calculate11x20Yayma(Mm_OncesindekiBoy, delikYaymaBaslangıcNoktası, i * delikAralıgı));

                        listofreturn.Add(uc_11x20SlotYaymaBas);

                        uc_11x20Slot2 uc_11x20SlotYaymaSon = new uc_11x20Slot2(
                            new Point(this.panel_alt.Width - CalculateCap7Yayma_px, this.panel_alt.Height / 2),
                            Calculate11x20Yayma(Mm_OncesindekiBoy, delikYaymaBaslangıcNoktası, i * delikAralıgı));

                        listofreturn.Add(uc_11x20SlotYaymaSon);

                        uc_Cap7_Sol uc_cap7SolYaymaUst = new uc_Cap7_Sol(
                            new Point(this.panel_orta.Width - CalculateCap7Yayma_px, this.panel_orta.Height / 4),
                            CalculateCap7Yayma(Mm_OncesindekiBoy, delikYaymaBaslangıcNoktası,
                                i * delikAralıgı), dCap7Sol_Genislik);

                        listofreturn.Add(uc_cap7SolYaymaUst);

                        uc_Cap7_Sag uc_cap7SolYaymaAlt = new uc_Cap7_Sag(
                            new Point(this.panel_orta.Width - CalculateCap7Yayma_px, panel_orta.Height - this.panel_orta.Height / 4),
                            CalculateCap7Yayma(Mm_OncesindekiBoy, delikYaymaBaslangıcNoktası,
                                i * delikAralıgı), dCap7Sag_Genislik);

                        listofreturn.Add(uc_cap7SolYaymaAlt);
                    }
                }

            }
            return listofreturn;
        }
        private List<arrProductionElement> ListAnaBosaltmaTuru(double PencereTuru, double dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm, double dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm, eIletkenTipi iletkenTipi)
        {
            List<arrProductionElement> returned_ListOfDelik = new List<arrProductionElement>();


            #region [Ana Boşaltma]

            ///////////////////////////////////     Ana Boşaltma      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            double dAnaBosaltmaBoy = 312.5;
            double dIlaveBosaltmaBoy = 112;
            int dAnaBosaltmaBoy_px = cConfiguration.mm_to_pixel_cevir(dAnaBosaltmaBoy);

            int CalculateAnaBosaltma1_px = cConfiguration.mm_to_pixel_cevir(CalculateAnaBosaltma(Mm_OncesindekiBoy, PencereTuru) - Mm_OncesindekiBoy - KalipMesafeleri.AnaBosaltma);

            int dVidaVeSogutmaDisMesafesi_Son_AnaBos_px = cConfiguration.mm_to_pixel_cevir(dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm);
            int dVidaVeSogutmaDisMesafesi_Bas_AnaBos_px = cConfiguration.mm_to_pixel_cevir(dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm);

            if (iletkenTipi == eIletkenTipi.Iletken_45 || iletkenTipi == eIletkenTipi.Iletken_5)
            {
                uc_IlaveBosaltma45_5 uc_IlaveBosaltma45_5 = new uc_IlaveBosaltma45_5(
                    new Point(this.panel_orta.Width - CalculateAnaBosaltma1_px, this.panel_orta.Height / 2),
                    CalculateIlaveBosaltma(Mm_OncesindekiBoy, PencereTuru, dAnaBosaltmaBoy, dIlaveBosaltmaBoy));
                this.panel_orta.Controls.Add(uc_IlaveBosaltma45_5);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = 0.0,
                    dVurmaPos = uc_IlaveBosaltma45_5.VurmaPos,
                    EDelikTipi = DelikTipi.IlaveBosaltma_1
                });

                uc_AnaBosaltma uc_AnaBosaltma = new uc_AnaBosaltma(
                    new Point(this.panel_orta.Width - CalculateAnaBosaltma1_px, this.panel_orta.Height / 2),
                    CalculateAnaBosaltma(Mm_OncesindekiBoy, PencereTuru));
                //this.panel_orta.Controls.Add(uc_AnaBosaltma);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = 0.0,
                    dVurmaPos = uc_AnaBosaltma.VurmaPos,
                    EDelikTipi = DelikTipi.AnaBosaltma
                });

                uc_AnaBosaltmaUst uc_AnaBosaltma_UstPanel = new uc_AnaBosaltmaUst(
                    new Point(this.panel_ust.Width - CalculateAnaBosaltma1_px + 27, this.panel_ust.Height / 2));
                this.panel_ust.Controls.Add(uc_AnaBosaltma_UstPanel);

                uc_AnaBosaltmaAlt uc_AnaBosaltma_AltPanel = new uc_AnaBosaltmaAlt(
                    new Point(this.panel_alt.Width - CalculateAnaBosaltma1_px + 27, this.panel_alt.Height / 2));
                this.panel_alt.Controls.Add(uc_AnaBosaltma_AltPanel);
            }
            else if (iletkenTipi == eIletkenTipi.Iletken_6)
            {
                uc_IlaveBosaltma45_5 uc_IlaveBosaltma45_5 = new uc_IlaveBosaltma45_5(
                    new Point(this.panel_orta.Width - CalculateAnaBosaltma1_px, this.panel_orta.Height / 2),
                    CalculateIlaveBosaltma(Mm_OncesindekiBoy, PencereTuru, dAnaBosaltmaBoy, dIlaveBosaltmaBoy));
                //this.panel_orta.Controls.Add(uc_IlaveBosaltma45_5);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = 0.0,
                    dVurmaPos = uc_IlaveBosaltma45_5.VurmaPos,
                    EDelikTipi = DelikTipi.IlaveBosaltma_1
                });

                uc_IlaveBosaltma6 uc_IlaveBosaltma6 = new uc_IlaveBosaltma6(
                    new Point(this.panel_orta.Width - CalculateAnaBosaltma1_px, this.panel_orta.Height / 2),
                    CalculateIlaveBosaltma(Mm_OncesindekiBoy, PencereTuru, dAnaBosaltmaBoy, dIlaveBosaltmaBoy));
                this.panel_orta.Controls.Add(uc_IlaveBosaltma6);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = 0.0,
                    dVurmaPos = uc_IlaveBosaltma6.VurmaPos,
                    EDelikTipi = DelikTipi.IlaveBosaltma_2
                });

                uc_AnaBosaltma uc_AnaBosaltma = new uc_AnaBosaltma(
                    new Point(this.panel_orta.Width - CalculateAnaBosaltma1_px, this.panel_orta.Height / 2),
                    CalculateAnaBosaltma(Mm_OncesindekiBoy, PencereTuru));
                //this.panel_orta.Controls.Add(uc_AnaBosaltma);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = 0.0,
                    dVurmaPos = uc_AnaBosaltma.VurmaPos,
                    EDelikTipi = DelikTipi.AnaBosaltma
                });

                uc_AnaBosaltmaUst uc_AnaBosaltma_UstPanel = new uc_AnaBosaltmaUst(
                    new Point(this.panel_ust.Width - CalculateAnaBosaltma1_px + 27, this.panel_ust.Height / 2));
                this.panel_ust.Controls.Add(uc_AnaBosaltma_UstPanel);

                uc_AnaBosaltmaAlt uc_AnaBosaltma_AltPanel = new uc_AnaBosaltmaAlt(
                    new Point(this.panel_alt.Width - CalculateAnaBosaltma1_px + 27, this.panel_alt.Height / 2));
                this.panel_alt.Controls.Add(uc_AnaBosaltma_AltPanel);
            }
            else
            {
                uc_AnaBosaltma uc_AnaBosaltma = new uc_AnaBosaltma(
                    new Point(this.panel_orta.Width - CalculateAnaBosaltma1_px, this.panel_orta.Height / 2),
                    CalculateAnaBosaltma(Mm_OncesindekiBoy, PencereTuru));
                this.panel_orta.Controls.Add(uc_AnaBosaltma);
                returned_ListOfDelik.Add(new arrProductionElement
                {
                    dGenislikPos = 0.0,
                    dVurmaPos = uc_AnaBosaltma.VurmaPos,
                    EDelikTipi = DelikTipi.AnaBosaltma
                });

                uc_AnaBosaltmaUst uc_AnaBosaltma_UstPanel = new uc_AnaBosaltmaUst(
                    new Point(this.panel_ust.Width - CalculateAnaBosaltma1_px + 27, this.panel_ust.Height / 2));
                this.panel_ust.Controls.Add(uc_AnaBosaltma_UstPanel);

                uc_AnaBosaltmaAlt uc_AnaBosaltma_AltPanel = new uc_AnaBosaltmaAlt(
                    new Point(this.panel_alt.Width - CalculateAnaBosaltma1_px + 27, this.panel_alt.Height / 2));
                this.panel_alt.Controls.Add(uc_AnaBosaltma_AltPanel);
            }
            #endregion

            #region [Ana Boşaltma Soluna Vurulacak Delikler]

            uc_11x20Slot uc_11x20Slot_AnaBos = new uc_11x20Slot(
                new Point(this.panel_ust.Width - CalculateAnaBosaltma1_px - dAnaBosaltmaBoy_px / 2 - dVidaVeSogutmaDisMesafesi_Son_AnaBos_px, this.panel_ust.Height / 2),
                Calculate11x20_AnaBos(Mm_OncesindekiBoy, PencereTuru, dAnaBosaltmaBoy,
                    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm));
            this.panel_ust.Controls.Add(uc_11x20Slot_AnaBos);
            returned_ListOfDelik.Add(new arrProductionElement
            {
                dGenislikPos = 0.0,
                dVurmaPos = uc_11x20Slot_AnaBos.VurmaPos,
                EDelikTipi = DelikTipi.Delik_11x20
            });

            uc_11x20Slot uc_11x20SlotTers_AnaBos = new uc_11x20Slot(
                new Point(this.panel_alt.Width - CalculateAnaBosaltma1_px - dAnaBosaltmaBoy_px / 2 - dVidaVeSogutmaDisMesafesi_Son_AnaBos_px,
                    this.panel_alt.Height / 2),
                Calculate11x20_AnaBos(Mm_OncesindekiBoy, PencereTuru, dAnaBosaltmaBoy,
                    dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm));
            this.panel_alt.Controls.Add(uc_11x20SlotTers_AnaBos);

            ////////////////////////   Çap7   \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            uc_Cap7_Sol uc_cap7Ust_AnaBos1 = new uc_Cap7_Sol(
                new Point(this.panel_orta.Width - CalculateAnaBosaltma1_px - dAnaBosaltmaBoy_px / 2 - dVidaVeSogutmaDisMesafesi_Son_AnaBos_px, this.panel_orta.Height / 4),
                CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, PencereTuru,
                    dAnaBosaltmaBoy, dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm), dCap7Sol_Genislik);
            this.panel_orta.Controls.Add(uc_cap7Ust_AnaBos1);
            returned_ListOfDelik.Add(new arrProductionElement
            {
                dGenislikPos = uc_cap7Ust_AnaBos1.GenislikPos,
                dVurmaPos = uc_cap7Ust_AnaBos1.VurmaPos,
                EDelikTipi = DelikTipi.Cap7Sol
            });

            uc_Cap7_Sag uc_cap7Alt_AnaBos1 = new uc_Cap7_Sag(
                new Point(this.panel_orta.Width - CalculateAnaBosaltma1_px - dAnaBosaltmaBoy_px / 2 - dVidaVeSogutmaDisMesafesi_Son_AnaBos_px, this.panel_orta.Height - this.panel_orta.Height / 4),
                CalculateCap7_AnaBos_Sol(Mm_OncesindekiBoy, PencereTuru,
                    dAnaBosaltmaBoy, dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm), dCap7Sag_Genislik);
            this.panel_orta.Controls.Add(uc_cap7Alt_AnaBos1);
            returned_ListOfDelik.Add(new arrProductionElement
            {
                dGenislikPos = uc_cap7Alt_AnaBos1.GenislikPos,
                dVurmaPos = uc_cap7Alt_AnaBos1.VurmaPos,
                EDelikTipi = DelikTipi.Cap7Sag
            });

            #endregion

            #region [Ana Boşaltma Sağına Vurulacak Delikler]

            uc_Cap7_Sol uc_cap7UstSag_AnaBos = new uc_Cap7_Sol(
                new Point(this.panel_orta.Width - CalculateAnaBosaltma1_px + dAnaBosaltmaBoy_px / 2 + dVidaVeSogutmaDisMesafesi_Bas_AnaBos_px, this.panel_orta.Height / 4),
                CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, PencereTuru,
                    dAnaBosaltmaBoy, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm), dCap7Sol_Genislik);
            this.panel_orta.Controls.Add(uc_cap7UstSag_AnaBos);
            returned_ListOfDelik.Add(new arrProductionElement
            {
                dGenislikPos = uc_cap7UstSag_AnaBos.GenislikPos,
                dVurmaPos = uc_cap7UstSag_AnaBos.VurmaPos,
                EDelikTipi = DelikTipi.Cap7Sol
            });

            uc_Cap7_Sag uc_cap7AltSag_AnaBos = new uc_Cap7_Sag(
                new Point(this.panel_orta.Width - CalculateAnaBosaltma1_px + dAnaBosaltmaBoy_px / 2 + dVidaVeSogutmaDisMesafesi_Bas_AnaBos_px, this.panel_orta.Height - this.panel_orta.Height / 4),
                CalculateCap7_AnaBos_Sag(Mm_OncesindekiBoy, PencereTuru,
                    dAnaBosaltmaBoy, dVidaVeSogutmaDisMesafesi_Bas_AnaBos_mm), dCap7Sag_Genislik);
            this.panel_orta.Controls.Add(uc_cap7AltSag_AnaBos);
            returned_ListOfDelik.Add(new arrProductionElement
            {
                dGenislikPos = uc_cap7AltSag_AnaBos.GenislikPos,
                dVurmaPos = uc_cap7AltSag_AnaBos.VurmaPos,
                EDelikTipi = DelikTipi.Cap7Sag
            });

            #endregion

            return returned_ListOfDelik;
        }

        private uc_MachParsPage ucMachParsPage;
        private double Limit_PencerelerArası(double soldakiPencerePos, double sagdakiPencerePos, double AnabosBoy, double AnaBosaltmaSag_UstPanelArasıMesafe, double dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm)
        {
            return (soldakiPencerePos - 128 - (AnabosBoy / 2) - AnaBosaltmaSag_UstPanelArasıMesafe) - (sagdakiPencerePos - 128 + (AnabosBoy / 2) + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm + 10);
        }
        private double Limit_PencereMin(double istenenPencerePos, double AnabosBoy, double AnaBosaltmaSag_UstPanelArasıMesafe,
            double dVidaVeSogutmaDisMesafesi_Bas_mm, bool bManivelaDeligiSağAktif, double dManivelaDelikDisMesafesi_mm)
        {
            double maniveleyaUzaklık = ((istenenPencerePos - 128) - (AnabosBoy / 2) - AnaBosaltmaSag_UstPanelArasıMesafe) - (dManivelaDelikDisMesafesi_mm + 10);
            if (bManivelaDeligiSağAktif)
            {
                if (maniveleyaUzaklık <= 0 && maniveleyaUzaklık >= -20)
                {
                    b11x20VeCap7Disable_Min = false;
                    this.bManivelaDeligiSağAktif = false;
                    double x = ((istenenPencerePos - 128) - (AnabosBoy / 2) - AnaBosaltmaSag_UstPanelArasıMesafe) - (dVidaVeSogutmaDisMesafesi_Bas_mm + 10);
                    return ((istenenPencerePos - 128) - (AnabosBoy / 2) - AnaBosaltmaSag_UstPanelArasıMesafe) - (dVidaVeSogutmaDisMesafesi_Bas_mm + 10);
                }
                else if (maniveleyaUzaklık < -20)
                {
                    b11x20VeCap7Disable_Min = true;
                    this.bManivelaDeligiSağAktif = false;
                    return ((istenenPencerePos - 128) - (AnabosBoy / 2) - AnaBosaltmaSag_UstPanelArasıMesafe) - (dVidaVeSogutmaDisMesafesi_Bas_mm - 15);
                }
                else
                {
                    b11x20VeCap7Disable_Min = false;
                    return ((istenenPencerePos - 128) - (AnabosBoy / 2) - AnaBosaltmaSag_UstPanelArasıMesafe) - (dManivelaDelikDisMesafesi_mm + 10);
                }
            }
            else
            {
                if (maniveleyaUzaklık < -20)
                {
                    b11x20VeCap7Disable_Min = true;
                }
                else
                {
                    b11x20VeCap7Disable_Min = false;
                }
                return ((istenenPencerePos - 128) - (AnabosBoy / 2) - AnaBosaltmaSag_UstPanelArasıMesafe) - (dVidaVeSogutmaDisMesafesi_Bas_mm - 15);
            }
        }
        private double Limit_PencereMax(double istenenPencerePos, double AnabosBoy, double dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm,
            double dVidaVeSogutmaDisMesafesi_Son_mm, bool bManivelaDeligiSolAktif, double dManivelaDelikDisMesafesi_mm)
        {
            double maxLimit = (MmBoy - (dManivelaDelikDisMesafesi_mm + 10)) - ((istenenPencerePos - 128) + (AnabosBoy / 2) + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm + 10);
            if (bManivelaDeligiSolAktif)
            {
                if (maxLimit <= 0 && maxLimit >= -20)
                {
                    b11x20VeCap7Disable_Max = false;
                    this.bManivelaDeligiSolAktif = false;
                    return (MmBoy - dVidaVeSogutmaDisMesafesi_Son_mm - 10) - ((istenenPencerePos - 128) + (AnabosBoy / 2) + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm + 10);
                }
                else if (maxLimit < -20)
                {
                    b11x20VeCap7Disable_Max = true;
                    this.bManivelaDeligiSolAktif = false;
                    return (MmBoy - dVidaVeSogutmaDisMesafesi_Son_mm + 10) - ((istenenPencerePos - 128) + (AnabosBoy / 2) + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm + 10);
                }
                else
                {
                    b11x20VeCap7Disable_Max = false;
                    return (MmBoy - (dManivelaDelikDisMesafesi_mm + 10)) - ((istenenPencerePos - 128) + (AnabosBoy / 2) + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm + 10);
                }
            }
            else
            {
                if (maxLimit < -20)
                {
                    b11x20VeCap7Disable_Max = true;
                }
                else
                {
                    b11x20VeCap7Disable_Max = false;
                }
                return (MmBoy - dVidaVeSogutmaDisMesafesi_Son_mm + 10) - ((istenenPencerePos - 128) + (AnabosBoy / 2) + dVidaVeSogutmaDisMesafesi_Son_AnaBos_mm + 10);
            }
        }
        private List<arrProductionElement> BasaVurulacakCap7Ve11x20Delikleri(int dVidaVeSogutmaDisMesafesi_Bas_px, double dVidaVeSogutmaDisMesafesi_Bas_mm)
        {
            List<arrProductionElement> returned_ListOfDelik = new List<arrProductionElement>();

            uc_11x20Slot uc_11x20SlotBas_50mm =
                        new uc_11x20Slot(
                            new Point(this.panel_ust.Width - dVidaVeSogutmaDisMesafesi_Bas_px,
                                this.panel_ust.Height / 2),
                            Calculate11x20(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm));
            this.panel_ust.Controls.Add(uc_11x20SlotBas_50mm);
            returned_ListOfDelik.Add(new arrProductionElement
            {
                dGenislikPos = 0.0,
                dVurmaPos = uc_11x20SlotBas_50mm.VurmaPos,
                EDelikTipi = DelikTipi.Delik_11x20
            });

            uc_11x20Slot uc_11x20SlotTersBas_50mm = new uc_11x20Slot(
                new Point(this.panel_alt.Width - dVidaVeSogutmaDisMesafesi_Bas_px, this.panel_alt.Height / 2),
                Calculate11x20(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm));
            this.panel_alt.Controls.Add(uc_11x20SlotTersBas_50mm);

            ///////
            uc_Cap7_Sol uc_cap7BasUst_50mm = new uc_Cap7_Sol(
                new Point(panel_ust.Width - dVidaVeSogutmaDisMesafesi_Bas_px, this.panel_orta.Height / 4),
                CalculateCap7Bas(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm), dCap7Sol_Genislik);
            this.panel_orta.Controls.Add(uc_cap7BasUst_50mm);
            returned_ListOfDelik.Add(new arrProductionElement
            {
                dGenislikPos = uc_cap7BasUst_50mm.GenislikPos,
                dVurmaPos = uc_cap7BasUst_50mm.VurmaPos,
                EDelikTipi = DelikTipi.Cap7Sol
            });

            uc_Cap7_Sag uc_cap7BasAlt_50mm = new uc_Cap7_Sag(
                new Point(panel_alt.Width - dVidaVeSogutmaDisMesafesi_Bas_px,
                    this.panel_orta.Height - this.panel_orta.Height / 4),
                CalculateCap7Bas(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Bas_mm), dCap7Sag_Genislik);
            this.panel_orta.Controls.Add(uc_cap7BasAlt_50mm);
            returned_ListOfDelik.Add(new arrProductionElement
            {
                dGenislikPos = uc_cap7BasAlt_50mm.GenislikPos,
                dVurmaPos = uc_cap7BasAlt_50mm.VurmaPos,
                EDelikTipi = DelikTipi.Cap7Sag
            });
            return returned_ListOfDelik;
        }
        private List<arrProductionElement> SonaVurulacakCap7Ve11x20Delikleri(int dVidaVeSogutmaDisMesafesi_Son_px, double dVidaVeSogutmaDisMesafesi_Son_mm)
        {
            List<arrProductionElement> returned_ListOfDelik = new List<arrProductionElement>();

            uc_11x20Slot uc_11x20SlotSon_50mm =
                    new uc_11x20Slot(new Point(dVidaVeSogutmaDisMesafesi_Son_px, this.panel_ust.Height / 2),
                        Calculate11x20(Mm_OncesindekiBoy, MmBoy - dVidaVeSogutmaDisMesafesi_Son_mm));
            this.panel_ust.Controls.Add(uc_11x20SlotSon_50mm);
            returned_ListOfDelik.Add(new arrProductionElement
            {
                dGenislikPos = 0.0,
                dVurmaPos = uc_11x20SlotSon_50mm.VurmaPos,
                EDelikTipi = DelikTipi.Delik_11x20
            });

            uc_11x20Slot uc_11x20SlotTersSon_50mm = new uc_11x20Slot(
                new Point(dVidaVeSogutmaDisMesafesi_Son_px, this.panel_alt.Height / 2),
                Calculate11x20(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Son_mm));
            this.panel_alt.Controls.Add(uc_11x20SlotTersSon_50mm);

            /////////
            uc_Cap7_Sol uc_cap7SonUst_50mm = new uc_Cap7_Sol(
                new Point(dVidaVeSogutmaDisMesafesi_Son_px, this.panel_orta.Height / 4),
                CalculateCap7Son(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Son_mm, MmBoy),
                dCap7Sol_Genislik);
            this.panel_orta.Controls.Add(uc_cap7SonUst_50mm);
            returned_ListOfDelik.Add(new arrProductionElement
            {
                dGenislikPos = uc_cap7SonUst_50mm.GenislikPos,
                dVurmaPos = uc_cap7SonUst_50mm.VurmaPos,
                EDelikTipi = DelikTipi.Cap7Sol
            });

            uc_Cap7_Sag uc_cap7SonAlt_50mm = new uc_Cap7_Sag(
                new Point(dVidaVeSogutmaDisMesafesi_Son_px,
                    this.panel_orta.Height - this.panel_orta.Height / 4),
                CalculateCap7Son(Mm_OncesindekiBoy, dVidaVeSogutmaDisMesafesi_Son_mm, MmBoy),
                dCap7Sag_Genislik);
            this.panel_orta.Controls.Add(uc_cap7SonAlt_50mm);
            returned_ListOfDelik.Add(new arrProductionElement
            {
                dGenislikPos = uc_cap7SonAlt_50mm.GenislikPos,
                dVurmaPos = uc_cap7SonAlt_50mm.VurmaPos,
                EDelikTipi = DelikTipi.Cap7Sag
            });

            return returned_ListOfDelik;
        }

    }

    public static class KalipMesafeleri
    {
        public static double Cap7;
        public static double Delik_11x20;
        public static double BasTakoz;
        public static double Manivela;
        public static double AnaBosaltma;
        public static double IlaveBosaltma_1;
        public static double IlaveBosaltma_2;
        public static double Kesme;
    }

    public class IletkeneGoreGenislik
    {
        public double Home;
        public double Iletken_3;
        public double Iletken_4;
        public double Iletken_45;
        public double Iletken_5;
        public double Iletken_55;
        public double Iletken_6;
        public double ServoHomePos;
    }

}
