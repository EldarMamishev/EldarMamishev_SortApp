using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Sort.Interface
{
    interface ISortResult
    {
        IEnumerable<decimal> SortedNumbers { get; }
        int SwapOperationsCount { get; }
        int CompareOperationsCount { get; }
    }
}
