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
        public InsertionSort(ISortType sortType) : base(sortType)
        { }

        protected override IEnumerable<decimal> HandleSorting(IList<decimal> sequence)
        {
            decimal[] copySequence = sequence.ToArray();

            for(int i = 0; i < copySequence.Length; i++)
            {
                for(int j = i - 1; j >= 0; j--)
                {
                    if (this.CompareFirstBigger(copySequence[j], copySequence[i]))
                        Swap(copySequence, i, j);
                }
            }

            return copySequence;
        }
    }
}
