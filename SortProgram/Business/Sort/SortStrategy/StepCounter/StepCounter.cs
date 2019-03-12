using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.SortStrategy.StepCounter.Interface;

namespace Business.Sort.SortStrategy.StepCounter
{
    class StepCounter : IStepCounter
    {
        private int compareOperationsCount;
        private int swapOperationsCount;

        public int CompareOperationsCount
        {
            get
            {
                return this.compareOperationsCount;
            }
        }        

        public void CountCompareOperation()
        {
            compareOperationsCount++;
        }

        public void CountSwapOperation()
        {
            swapOperationsCount++;
        }

        public int SwapOperationsCount
        {
            get
            {
                return this.swapOperationsCount;
            }
        }
    }
}
