using Csharp.Ios;
using Csharp.Pages.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Pages.MachinePars
{
    public static class MachinePars_ToPLC
    {
        public static Dictionary<int, MachineParameters.Bool> dicMachinePars_Bools = new Dictionary<int, MachineParameters.Bool>(32); // Alias and Boolean Value - Number Of Parameter = 32
        public static Dictionary<int, MachineParameters.Num> dicMachinePars_Nums = new Dictionary<int, MachineParameters.Num>(125); // Alias and Num Value - Number Of Parameter = 64
        public static DataSet ds_machinePars = new DataSet();
        public static DataTable dt_Nums = new DataTable();
        public static DataTable dt_Bools = new DataTable();

        static string filename = System.Threading.Thread.GetDomain().BaseDirectory + "//MachineParameters.xml";
        public static void WritePLC()
        {
            #region[Bools]
            IO.Bits.Write_MachinePars0(Convert.ToBoolean(dicMachinePars_Bools[0].Value));
            IO.Bits.Write_MachinePars1(Convert.ToBoolean(dicMachinePars_Bools[1].Value));
            IO.Bits.Write_MachinePars2(Convert.ToBoolean(dicMachinePars_Bools[2].Value));
            IO.Bits.Write_MachinePars3(Convert.ToBoolean(dicMachinePars_Bools[3].Value));
            IO.Bits.Write_MachinePars4(Convert.ToBoolean(dicMachinePars_Bools[4].Value));
            IO.Bits.Write_MachinePars5(Convert.ToBoolean(dicMachinePars_Bools[5].Value));
            IO.Bits.Write_MachinePars6(Convert.ToBoolean(dicMachinePars_Bools[6].Value));
            IO.Bits.Write_MachinePars7(Convert.ToBoolean(dicMachinePars_Bools[7].Value));
            IO.Bits.Write_MachinePars8(Convert.ToBoolean(dicMachinePars_Bools[8].Value));
            IO.Bits.Write_MachinePars9(Convert.ToBoolean(dicMachinePars_Bools[9].Value));
            IO.Bits.Write_MachinePars10(Convert.ToBoolean(dicMachinePars_Bools[10].Value));
            IO.Bits.Write_MachinePars11(Convert.ToBoolean(dicMachinePars_Bools[11].Value));
            IO.Bits.Write_MachinePars12(Convert.ToBoolean(dicMachinePars_Bools[12].Value));
            IO.Bits.Write_MachinePars13(Convert.ToBoolean(dicMachinePars_Bools[14].Value));
            IO.Bits.Write_MachinePars15(Convert.ToBoolean(dicMachinePars_Bools[15].Value));
            IO.Bits.Write_MachinePars16(Convert.ToBoolean(dicMachinePars_Bools[16].Value));
            IO.Bits.Write_MachinePars17(Convert.ToBoolean(dicMachinePars_Bools[17].Value));
            IO.Bits.Write_MachinePars18(Convert.ToBoolean(dicMachinePars_Bools[18].Value));
            IO.Bits.Write_MachinePars19(Convert.ToBoolean(dicMachinePars_Bools[19].Value));
            IO.Bits.Write_MachinePars20(Convert.ToBoolean(dicMachinePars_Bools[20].Value));
            IO.Bits.Write_MachinePars21(Convert.ToBoolean(dicMachinePars_Bools[21].Value));
            IO.Bits.Write_MachinePars22(Convert.ToBoolean(dicMachinePars_Bools[22].Value));
            IO.Bits.Write_MachinePars23(Convert.ToBoolean(dicMachinePars_Bools[23].Value));
            IO.Bits.Write_MachinePars24(Convert.ToBoolean(dicMachinePars_Bools[24].Value));
            IO.Bits.Write_MachinePars25(Convert.ToBoolean(dicMachinePars_Bools[25].Value));
            IO.Bits.Write_MachinePars26(Convert.ToBoolean(dicMachinePars_Bools[26].Value));
            IO.Bits.Write_MachinePars27(Convert.ToBoolean(dicMachinePars_Bools[27].Value));
            IO.Bits.Write_MachinePars28(Convert.ToBoolean(dicMachinePars_Bools[28].Value));
            IO.Bits.Write_MachinePars29(Convert.ToBoolean(dicMachinePars_Bools[29].Value));
            IO.Bits.Write_MachinePars30(Convert.ToBoolean(dicMachinePars_Bools[30].Value));
            IO.Bits.Write_MachinePars31(Convert.ToBoolean(dicMachinePars_Bools[31].Value));
            #endregion
            #region[Nums]
            IO.Words.Write_MachinePars0(Convert.ToUInt16(dicMachinePars_Nums[108].Value));
            IO.Words.Write_MachinePars1(Convert.ToUInt16(dicMachinePars_Nums[109].Value));
            IO.Words.Write_MachinePars2(Convert.ToUInt16(dicMachinePars_Nums[110].Value));
            IO.Words.Write_MachinePars3(Convert.ToUInt16(dicMachinePars_Nums[111].Value));
            IO.Words.Write_MachinePars4(Convert.ToUInt16(dicMachinePars_Nums[112].Value));
            IO.Words.Write_MachinePars5(Convert.ToUInt16(dicMachinePars_Nums[113].Value));
            IO.Words.Write_MachinePars6(Convert.ToUInt16(dicMachinePars_Nums[114].Value));
            IO.Words.Write_MachinePars7(Convert.ToUInt16(dicMachinePars_Nums[115].Value));
            IO.Words.Write_MachinePars8(Convert.ToUInt16(dicMachinePars_Nums[116].Value));
            IO.Words.Write_MachinePars9(Convert.ToUInt16(dicMachinePars_Nums[9].Value));
            IO.Words.Write_MachinePars10(Convert.ToUInt16(dicMachinePars_Nums[10].Value));
            IO.Words.Write_MachinePars11(Convert.ToUInt16(dicMachinePars_Nums[11].Value));
            IO.Words.Write_MachinePars12(Convert.ToUInt16(dicMachinePars_Nums[12].Value));
            IO.Words.Write_MachinePars13(Convert.ToUInt16(dicMachinePars_Nums[13].Value));
            IO.Words.Write_MachinePars14(Convert.ToUInt16(dicMachinePars_Nums[14].Value));
            IO.Words.Write_MachinePars15(Convert.ToUInt16(dicMachinePars_Nums[15].Value));
            //IO.Words.Write_MachinePars16(Convert.ToUInt16(dicMachinePars_Nums[16].Value));
            //IO.Words.Write_MachinePars17(Convert.ToUInt16(dicMachinePars_Nums[17].Value));
            //IO.Words.Write_MachinePars18(Convert.ToUInt16(dicMachinePars_Nums[18].Value));
            //IO.Words.Write_MachinePars19(Convert.ToUInt16(dicMachinePars_Nums[19].Value));
            //IO.Words.Write_MachinePars20(Convert.ToUInt16(dicMachinePars_Nums[20].Value));
            //IO.Words.Write_MachinePars21(Convert.ToUInt16(dicMachinePars_Nums[21].Value));
            //IO.Words.Write_MachinePars22(Convert.ToUInt16(dicMachinePars_Nums[22].Value));
            //IO.Words.Write_MachinePars23(Convert.ToUInt16(dicMachinePars_Nums[23].Value));
            //IO.Words.Write_MachinePars24(Convert.ToUInt16(dicMachinePars_Nums[24].Value));
            //IO.Words.Write_MachinePars25(Convert.ToUInt16(dicMachinePars_Nums[25].Value));
            //IO.Words.Write_MachinePars26(Convert.ToUInt16(dicMachinePars_Nums[26].Value));
            //IO.Words.Write_MachinePars27(Convert.ToUInt16(dicMachinePars_Nums[27].Value));
            //IO.Words.Write_MachinePars28(Convert.ToUInt16(dicMachinePars_Nums[28].Value));
            //IO.Words.Write_MachinePars29(Convert.ToUInt16(dicMachinePars_Nums[29].Value));
            //IO.Words.Write_MachinePars30(Convert.ToUInt16(dicMachinePars_Nums[30].Value));
            //IO.Words.Write_MachinePars31(Convert.ToUInt16(dicMachinePars_Nums[31].Value));
            #endregion
            #region[Floats]
            IO.Floats.Write_MachinePars0(Convert.ToSingle(dicMachinePars_Nums[0].Value));
            IO.Floats.Write_MachinePars1(Convert.ToSingle(dicMachinePars_Nums[1].Value));
            IO.Floats.Write_MachinePars2(Convert.ToSingle(dicMachinePars_Nums[2].Value));
            IO.Floats.Write_MachinePars3(Convert.ToSingle(dicMachinePars_Nums[3].Value));
            IO.Floats.Write_MachinePars4(Convert.ToSingle(dicMachinePars_Nums[4].Value));
            IO.Floats.Write_MachinePars5(Convert.ToSingle(dicMachinePars_Nums[5].Value));
            IO.Floats.Write_MachinePars6(Convert.ToSingle(dicMachinePars_Nums[6].Value));
            IO.Floats.Write_MachinePars7(Convert.ToSingle(dicMachinePars_Nums[7].Value));
            IO.Floats.Write_MachinePars8(Convert.ToSingle(dicMachinePars_Nums[8].Value));
            IO.Floats.Write_MachinePars9(Convert.ToSingle(dicMachinePars_Nums[9].Value));
            IO.Floats.Write_MachinePars10(Convert.ToSingle(dicMachinePars_Nums[10].Value));
            IO.Floats.Write_MachinePars11(Convert.ToSingle(dicMachinePars_Nums[11].Value));
            IO.Floats.Write_MachinePars12(Convert.ToSingle(dicMachinePars_Nums[12].Value));
            IO.Floats.Write_MachinePars13(Convert.ToSingle(dicMachinePars_Nums[13].Value));
            IO.Floats.Write_MachinePars14(Convert.ToSingle(dicMachinePars_Nums[14].Value));
            IO.Floats.Write_MachinePars15(Convert.ToSingle(dicMachinePars_Nums[15].Value));
            IO.Floats.Write_MachinePars16(Convert.ToSingle(dicMachinePars_Nums[16].Value));
            IO.Floats.Write_MachinePars17(Convert.ToSingle(dicMachinePars_Nums[17].Value));
            IO.Floats.Write_MachinePars18(Convert.ToSingle(dicMachinePars_Nums[18].Value));
            IO.Floats.Write_MachinePars19(Convert.ToSingle(dicMachinePars_Nums[19].Value));
            IO.Floats.Write_MachinePars20(Convert.ToSingle(dicMachinePars_Nums[20].Value));
            IO.Floats.Write_MachinePars21(Convert.ToSingle(dicMachinePars_Nums[21].Value));
            IO.Floats.Write_MachinePars22(Convert.ToSingle(dicMachinePars_Nums[22].Value));
            IO.Floats.Write_MachinePars23(Convert.ToSingle(dicMachinePars_Nums[23].Value));
            IO.Floats.Write_MachinePars24(Convert.ToSingle(dicMachinePars_Nums[24].Value));
            IO.Floats.Write_MachinePars25(Convert.ToSingle(dicMachinePars_Nums[25].Value));
            IO.Floats.Write_MachinePars26(Convert.ToSingle(dicMachinePars_Nums[26].Value));
            IO.Floats.Write_MachinePars27(Convert.ToSingle(dicMachinePars_Nums[27].Value));
            IO.Floats.Write_MachinePars28(Convert.ToSingle(dicMachinePars_Nums[28].Value));
            IO.Floats.Write_MachinePars29(Convert.ToSingle(dicMachinePars_Nums[29].Value));
            IO.Floats.Write_MachinePars30(Convert.ToSingle(dicMachinePars_Nums[30].Value));
            IO.Floats.Write_MachinePars31(Convert.ToSingle(dicMachinePars_Nums[31].Value));
            IO.Floats.Write_MachinePars32(Convert.ToSingle(dicMachinePars_Nums[32].Value));
            IO.Floats.Write_MachinePars33(Convert.ToSingle(dicMachinePars_Nums[33].Value));
            IO.Floats.Write_MachinePars34(Convert.ToSingle(dicMachinePars_Nums[34].Value));
            IO.Floats.Write_MachinePars35(Convert.ToSingle(dicMachinePars_Nums[35].Value));
            IO.Floats.Write_MachinePars36(Convert.ToSingle(dicMachinePars_Nums[36].Value));
            IO.Floats.Write_MachinePars37(Convert.ToSingle(dicMachinePars_Nums[37].Value));
            IO.Floats.Write_MachinePars38(Convert.ToSingle(dicMachinePars_Nums[38].Value));
            IO.Floats.Write_MachinePars39(Convert.ToSingle(dicMachinePars_Nums[39].Value));
            IO.Floats.Write_MachinePars40(Convert.ToSingle(dicMachinePars_Nums[40].Value));
            IO.Floats.Write_MachinePars41(Convert.ToSingle(dicMachinePars_Nums[41].Value));
            IO.Floats.Write_MachinePars42(Convert.ToSingle(dicMachinePars_Nums[42].Value));
            IO.Floats.Write_MachinePars43(Convert.ToSingle(dicMachinePars_Nums[43].Value));
            IO.Floats.Write_MachinePars44(Convert.ToSingle(dicMachinePars_Nums[44].Value));
            IO.Floats.Write_MachinePars45(Convert.ToSingle(dicMachinePars_Nums[45].Value));
            IO.Floats.Write_MachinePars46(Convert.ToSingle(dicMachinePars_Nums[46].Value));
            IO.Floats.Write_MachinePars47(Convert.ToSingle(dicMachinePars_Nums[47].Value));
            IO.Floats.Write_MachinePars48(Convert.ToSingle(dicMachinePars_Nums[48].Value));
            IO.Floats.Write_MachinePars49(Convert.ToSingle(dicMachinePars_Nums[49].Value));
            IO.Floats.Write_MachinePars50(Convert.ToSingle(dicMachinePars_Nums[50].Value));
            IO.Floats.Write_MachinePars51(Convert.ToSingle(dicMachinePars_Nums[51].Value));
            IO.Floats.Write_MachinePars52(Convert.ToSingle(dicMachinePars_Nums[52].Value));
            IO.Floats.Write_MachinePars53(Convert.ToSingle(dicMachinePars_Nums[53].Value));

            ////Yaglama Vurus Sayisi Set Degerleri
            //IO.Floats.Write_MachinePars54(Convert.ToSingle(dicMachinePars_Nums[108].Value));
            //IO.Floats.Write_MachinePars55(Convert.ToSingle(dicMachinePars_Nums[109].Value));
            //IO.Floats.Write_MachinePars56(Convert.ToSingle(dicMachinePars_Nums[110].Value));
            //IO.Floats.Write_MachinePars57(Convert.ToSingle(dicMachinePars_Nums[111].Value));
            //IO.Floats.Write_MachinePars58(Convert.ToSingle(dicMachinePars_Nums[112].Value));
            //IO.Floats.Write_MachinePars59(Convert.ToSingle(dicMachinePars_Nums[113].Value));
            //IO.Floats.Write_MachinePars60(Convert.ToSingle(dicMachinePars_Nums[114].Value));
            //IO.Floats.Write_MachinePars61(Convert.ToSingle(dicMachinePars_Nums[115].Value));
            //IO.Floats.Write_MachinePars62(Convert.ToSingle(dicMachinePars_Nums[116].Value));

            #endregion
        }
        public static void ReadMachinePars_WithXml()
        {
            //Check whether file is exist or not.
            
        }
        private static void makeDefaultXmlFile()
        {
            

            //Create bools table
           
        }
        public static void FillDictionaries()
        {
            
        }
    }
}
