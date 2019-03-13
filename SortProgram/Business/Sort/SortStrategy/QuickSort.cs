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
        public QuickSort(ISortType sortType) : base(sortType)
        { }

        protected override IEnumerable<decimal> HandleSorting(IList<decimal> sequence)
        {
            decimal[] copySequence = sequence.ToArray();

            RecursiveQuickSort(copySequence, 0, copySequence.Length);

            return copySequence;
        }

        private void RecursiveQuickSort(decimal[] sequence, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
                return;

            int markedPosition = ReturnMarkedPosition(sequence, startIndex, endIndex);
            RecursiveQuickSort(sequence, startIndex, markedPosition - 1);
            RecursiveQuickSort(sequence, markedPosition + 1, endIndex);
        }

        private int ReturnMarkedPosition(decimal[] sequence, int startIndex, int endIndex)
        {
            int markedIndex = startIndex;

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (this.CompareFirstBigger(sequence[i], sequence[endIndex]))
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
