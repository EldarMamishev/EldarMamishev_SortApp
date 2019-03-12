using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.Interface;
using Business.Sort.SortStrategy.Interface;
using Business.Sort.SortStrategy.StepCounter.Interface;
using Business.Sort.SortType.Interface;
using Business.Sort.SortStrategy.StepCounter;

namespace Business.Sort.SortStrategy.Base
{
    public abstract class SortStrategyBase : ISortStrategy
    {
        protected readonly ISortType sortType;
        protected readonly IStepCounter stepCounter;

        protected abstract IEnumerable<decimal> HandleSorting(IList<decimal> sequence);

        public ISortResult Sort(IEnumerable<decimal> sequence, ISortType sortType)
        {
            ISortResult sortResult;
            IEnumerable<decimal> sortedSequence;
            var copySequence = sequence.ToArray();
                        
            sortedSequence = HandleSorting(copySequence);
            sortedSequence = sortType.Update(sortedSequence);

            sortResult = new SortResult(sortedSequence, stepCounter.CompareOperationsCount, stepCounter.SwapOperationsCount);

            return sortResult;
        }

        public SortStrategyBase(ISortType sortType)
        {
            this.sortType = sortType;
            this.stepCounter = new StepCounter.StepCounter();
        }

        protected void Swap(IList<decimal> sequence, int firstIndex, int secondIndex)
        {
            throw new NotImplementedException();
        }

        protected bool Compare(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber > secondNumber;
        }
    }
}
