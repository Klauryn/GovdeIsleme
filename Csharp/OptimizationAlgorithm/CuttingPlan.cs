
using System;
using System.Linq;

namespace Csharp.OptimizationAlgorithm
{
    public class CuttingPlan
    {          
                  // desired lengths to cut
               // desired amounts of each length
                  // parameter to indicate if the cutting process produces a loss with length "waste"
                  // length of the raw material bar
                  // lengths + waste
               // mapping to indicate which length is cut from which raw material bar 
               // "length[i]" will be cut from bar "cutSchemeMapping[i]"
                  // total used length of the raw material bars
                  // remaining lengths of the raw material bar, which are not used
               // number of used bars

        

        public CuttingPlan()
        {
            
        }

        public CuttingPlan(double[] lengths, int[] amounts, double waste, double rawMaterial)
        {
            
        }

        public static void SortDecreasing(double[] lengths, int[] amounts)
        {
            // Sort the lengths and the corresponding amounts in noincreasing order.
            
        }

    }
}
