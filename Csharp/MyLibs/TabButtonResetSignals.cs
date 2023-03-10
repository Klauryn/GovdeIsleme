using Csharp.Ios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.MyLibs
{
    public static class TabButtonResetSignals
    {
        public static void Reset()
        {
            IO.Bits.JogReq_TabButton.Reset_WhenElapsedTimeExceeds(1500);

        }
    }
}
