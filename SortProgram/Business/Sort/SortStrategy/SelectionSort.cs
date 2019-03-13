using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.SortStrategy.Base;
using Business.Sort.SortType.Interface;

namespace Business.Sort.SortStrategy
{
    public sealed class SelectionSort : SortStrategyBase
    {
        public SelectionSort(ISortType sortType) : base(sortType)
        { }

        protected override IEnumerable<decimal> HandleSorting(IList<decimal> sequence)
        {
            decimal[] copySequence = sequence.ToArray();

            for (int i = 0; i < copySequence.Length; i++)
            {
                int indexOfMin = i;

                for (int j = i + 1; j < copySequence.Length; j++)
                {
                    if (CompareFirstBigger(copySequence[i], copySequence[j]))
                        indexOfMin = j;
                }

                Swap(copySequence, i, indexOfMin);
            }

            return copySequence;
        }
    }
}
