using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.SortStrategy.StepCounter.Interface;

namespace Business.Sort.SortStrategy.StepCounter
{
    public sealed class StepCounter : IStepCounter
    {
        private int compareOperationsCount;
        private int swapOperationsCount;

        public int CompareOperationsCount => this.compareOperationsCount;

        public void CountCompareOperation() => this.compareOperationsCount++;

        public void CountSwapOperation() => this.swapOperationsCount++;

        public int SwapOperationsCount => this.swapOperationsCount;
    }
}
