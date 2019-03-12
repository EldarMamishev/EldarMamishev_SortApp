using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.Interface;

namespace Business.Sort
{
    public sealed class SortResult : ISortResult
    {
        private readonly int compareOperationsCount;
        private readonly IEnumerable<decimal> sortedNumbers;
        private readonly int swapOperationsCount;

        public int CompareOperationsCount => this.compareOperationsCount;
            
        public IEnumerable<decimal> SortedNumbers => this.sortedNumbers;

        public SortResult(IEnumerable<decimal> sortedSequence, int compareOperationsCount, int swapOperationsCount)
        {
            if (sortedSequence == null)
            {
                throw new ArgumentNullException(nameof(sortedSequence));
            }
            
            this.sortedNumbers = sortedSequence;
            this.compareOperationsCount = compareOperationsCount;
            this.swapOperationsCount = swapOperationsCount;
        }

        public int SwapOperationsCount => this.swapOperationsCount;
    }
}
