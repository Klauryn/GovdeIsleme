using Csharp.Ios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.MyLibs
{
    public static class StartButtonResetSignals
    {
        public static void Reset()
        {
            IO.Bits.startButton_TekUretim.Reset_WhenElapsedTimeExceeds(1500);
        }
    }
}
