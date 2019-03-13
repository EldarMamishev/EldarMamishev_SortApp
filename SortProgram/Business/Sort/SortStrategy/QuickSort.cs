using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.SortStrategy.Base;
using Business.Sort.SortType.Interface;

namespace Business.Sort.SortStrategy
{
    public sealed class QuickSort : SortStrategyBase
    {
        protected override IEnumerable<decimal> HandleSorting(IList<decimal> sequence)
        {
            decimal[] copySequence = sequence.ToArray();

            this.RecursiveQuickSort(copySequence, 0, copySequence.Length - 1);

            return copySequence;
        }

        public QuickSort(ISortType sortType) : base(sortType)
        { }

        private void RecursiveQuickSort(decimal[] sequence, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
                return;

            int pivotPosition = this.MakePartitionAndGivePivotPosition(sequence, startIndex, endIndex);
            this.RecursiveQuickSort(sequence, startIndex, pivotPosition - 1);
            this.RecursiveQuickSort(sequence, pivotPosition + 1, endIndex);
        }

        private int MakePartitionAndGivePivotPosition(decimal[] sequence, int startIndex, int endIndex)
        {
            int markedIndex = startIndex;

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (this.CompareFirstBigger(sequence[endIndex], sequence[i]))
                {
                    this.Swap(sequence, markedIndex, i);
                    markedIndex++;
                }
            }

            this.Swap(sequence, markedIndex, endIndex);
            return markedIndex;
        }
    }
}
