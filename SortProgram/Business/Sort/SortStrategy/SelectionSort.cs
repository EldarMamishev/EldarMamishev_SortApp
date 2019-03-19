using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.SortStrategy.Base;
using Business.Sort.SortStrategy.StepCounter.Interface;
using Business.Sort.SortType.Interface;

namespace Business.Sort.SortStrategy
{
    public sealed class SelectionSort : SortStrategyBase
    { 
        protected override IEnumerable<decimal> HandleSorting(IList<decimal> sequence)
        {
            decimal[] copySequence = sequence.ToArray();

            for (int i = 0; i < copySequence.Length; i++)
            {
                int indexOfMin = i;

                for (int j = i + 1; j < copySequence.Length; j++)
                {
                    if (this.CompareFirstBigger(copySequence[indexOfMin], copySequence[j]))
                        indexOfMin = j;
                }

                this.Swap(copySequence, i, indexOfMin);
            }

            return copySequence;
        }

        public SelectionSort(ISortType sortType, IStepCounter stepCounter) : base(sortType, stepCounter)
        { }
    }
}
