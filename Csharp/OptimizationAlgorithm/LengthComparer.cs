using System.Collections.Generic;

namespace Csharp.OptimizationAlgorithm
{
    public struct LengthComparer : IComparer<Bar>
    {
        public int Compare(Bar a, Bar b)
        {
            int r = (int)(b.Length - a.Length);
            return r > 0 ? r : b.Amount - a.Amount;
        }
    }
}
