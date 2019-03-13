using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.SortStrategy.Base;
using Business.Sort.SortType.Interface;

namespace Business.Sort.SortStrategy
{
    public sealed class InsertionSort : SortStrategyBase
    {
        protected override IEnumerable<decimal> HandleSorting(IList<decimal> sequence)
        {
            decimal[] copySequence = sequence.ToArray();

            for (int i = 0; i < copySequence.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (this.CompareFirstBigger(copySequence[j - 1], copySequence[j]))
                        this.Swap(copySequence, j, j - 1);
                    else
                        break;
                }
            }

            return copySequence;
        }

        public InsertionSort(ISortType sortType) : base(sortType)
        { }
    }
}
