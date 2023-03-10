using Csharp.Ios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp.Pages.Production;
namespace Csharp.MyLibs
{
    public static class StopButtonResetSignals
    {
        public static void Reset()
        {
            IO.Bits.stopButton_TekUretim.Reset_WhenElapsedTimeExceeds(1500);
        }
    }
}
