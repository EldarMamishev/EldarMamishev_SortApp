﻿using System;
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

        public ISortResult Sort(IEnumerable<decimal> sequence)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence));
            }
            
            decimal[] copySequence = sequence.ToArray();

            IEnumerable<decimal> sortedSequence = HandleSorting(copySequence);
            sortedSequence = this.sortType.Update(sortedSequence);

            var sortResult = new SortResult(sortedSequence, this.stepCounter.CompareOperationsCount, this.stepCounter.SwapOperationsCount);

            return sortResult;
        }

        public SortStrategyBase(ISortType sortType, IStepCounter stepCounter)
        {
            this.sortType = sortType ?? throw new ArgumentNullException(nameof(sortType));
            this.stepCounter = stepCounter ?? throw new ArgumentNullException(nameof(stepCounter));
        }

        protected void Swap(IList<decimal> sequence, int firstIndex, int secondIndex)
        {
            decimal tempSequenceElement = sequence[firstIndex];
            sequence[firstIndex] = sequence[secondIndex];
            sequence[secondIndex] = tempSequenceElement;
            this.stepCounter.CountSwapOperation();
        }

        protected bool CompareFirstBigger(decimal firstNumber, decimal secondNumber)
        {
            this.stepCounter.CountCompareOperation();
            return firstNumber > secondNumber;
        }
    }
}
