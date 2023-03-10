using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Csharp.Pages.Production.usercontrols;
using Csharp.Pages.General;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;
using Csharp.EventsAggregator;
using Csharp.Ios;
using Csharp.Pages.MachinePars;

namespace Csharp.Pages.Production
{
    public partial class uc_TekUretimPage : UserControl
    {
        string SendingDelikStatus;
        public bool onTekUretim { get; set; }
        public static OperatorParameters parameters;
        public uc_TekUretimPage()
        {
		}
	}
}