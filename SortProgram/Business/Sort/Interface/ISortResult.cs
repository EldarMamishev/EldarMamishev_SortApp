using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Sort.Interface
{
    public interface ISortResult
    {
        int CompareOperationsCount { get; }
        IEnumerable<decimal> SortedNumbers { get; }
        int SwapOperationsCount { get; }
    }
}
