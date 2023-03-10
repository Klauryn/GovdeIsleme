
using System;
using System.Linq;

namespace Csharp.OptimizationAlgorithm
{
    public static class Heuristics
    {
        public static CuttingPlan FirstFitDecreasing(double[] lengths, int[] amounts, int waste, double maxLength)
        {
            // Execute the First Fit Heurisitc, which assings the actual considered
            // length to the first bar (used or unused) where it fits.

            
        }

        public static CuttingPlan BestFitDecreasing(double[] lengths, int[] amounts, double waste, double maxLength)
        {
            // Execute the Best Fit Heurisitc, which assings the actual considered
            // length to the bar (used or unused) where the remaining length is minimal.

            
        }

        public static int FFmin(double[] rlengths, double actLength, double maxLength)
        {
            // Find the index of the first bar of all where "actLength" fits.

            
        }

        public static int BFmax(double[] rlengths, double actLength, double maxLength)
        {
            // Find the index of the bar where "actLength" fits and the remaining length is minimal.

            
        }

        private static int UpperBound(int[] lengths, int[] amounts, int maxLength)
        {
            
        }
    }
}
