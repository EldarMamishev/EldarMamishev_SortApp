using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Sort.SortStrategy.StepCounter.Interface
{
    public interface IStepCounter
    {
        int CompareOperationsCount { get; }
        void CountSwapOperation();
        void CountCompareOperation();
        int SwapOperationsCount { get; }
    }
}
