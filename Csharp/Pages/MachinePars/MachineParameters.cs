using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.Pages.MachinePars
{
    public class MachineParameters
    {
        public class Bool
        {
            public string Alias {get;set;}
            public bool Value { get; set; }
        }
        public class Num
        {
            public string Alias { get; set; }
            public double Value { get; set; }
        }
    }
}
