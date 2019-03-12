using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.Interface;

namespace Business.Sort
{
    class SortResult : ISortResult
    {
        private readonly int compareOperationsCount;
        private readonly IEnumerable<decimal> sortedNumbers;
        private readonly int swapOperationsCount;

        public int CompareOperationsCount
        {
            get
            {
                return this.compareOperationsCount;
            }
        }

        public IEnumerable<decimal> SortedNumbers
        {
            get
            {
                return this.sortedNumbers;
            }
        }

        public SortResult(IEnumerable<decimal> sortedFrequence, int compareOperationsCount, int swapOperationsCount)
        {
            this.sortedNumbers = sortedFrequence;
            this.compareOperationsCount = compareOperationsCount;
            this.swapOperationsCount = swapOperationsCount;
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
