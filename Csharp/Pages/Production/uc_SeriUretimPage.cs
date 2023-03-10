using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Csharp.EventsAggregator;
using Csharp.Pages.General;
using Csharp.Pages.Production.usercontrols;
using Csharp.OptimizationAlgorithm;
using Csharp.Ios;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using System.Windows;
using Csharp.Pages.RecipePars;
using Csharp.Pages.MachinePars;
using System.Runtime.InteropServices.ComTypes;
using System.IO;
using System.Linq.Expressions;
using System.Security.Cryptography;
using static Csharp.Ios.IO;
using System.Net;

namespace Csharp.Pages.Production
{
    public partial class uc_SeriUretimPage : UserControl
    {
        private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();
        Dictionary<int, UserControl> ListUretilecekParts = new Dictionary<int, UserControl>();
        public static List<arrProductionElement> SortedlstArrProductionElements;
        public eDelikCakismaDeleteSubPart fooDeleteSubPart;
        int nCounter_UretilecekSeriUretimGovdeSayisi = 1;
        private CuttingPlan ct_Plan;
        public static OperatorParameters parameters;
        private uc_SubbPart _DisplayingSubPart;
        private uc_SubbPart _LibrarySubPart;
        private Thread threatProduction;
        public bool OnSeriUretim { get; set; }
        public uc_SeriUretimPage()
        {
            InitializeComponent();

            parameters.YatayDisSelected = false;
            parameters.YatayIcSelected = false;
            parameters.LeftSelected = false;
            parameters.RightSelected = false;

            //listView1.FullRowSelect = true;


            ////////---------------------- Binding Operations---------------------------------
            #region ////////---------------------- Binding Operations---------------------------------
            
            #endregion

            //panel_hamgovde.DataBindings.Add(nameof(FlowLayoutPanel.Width), parameters, nameof(parameters.TopluhamGovdeBoy_pixel));
            //panel_hamgovde.DataBindings.Add(nameof(FlowLayoutPanel.Location), parameters, nameof(parameters.PTopluGövdeLocation));

            eMachineParameterChanged.eChanged -= EMachineParameterChanged_eChanged;
            eMachineParameterChanged.eChanged += EMachineParameterChanged_eChanged;
        }
        private void EMachineParameterChanged_eChanged(object sender, eMachineParameterChanged e)
        {
            
		}
	}
}