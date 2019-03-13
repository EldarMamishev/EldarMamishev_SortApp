using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.SortStrategy.Base;
using Business.Sort.SortType.Interface;

namespace Business.Sort.SortStrategy
{
    public sealed class MergeSort : SortStrategyBase
    {
        public MergeSort(ISortType sortType) : base(sortType)
        { }

        protected override IEnumerable<decimal> HandleSorting(IList<decimal> sequence)
        {
            decimal[] copySequence = sequence.ToArray();
            return this.RecursiveMergeSort(copySequence);
        }

        private decimal[] RecursiveMergeSort(decimal[] sequence)
        {
            if (sequence.Length <= 1)
                return sequence;

            int middleIndex = sequence.Length/2;
            int leftPartSize = middleIndex;
            int rightPartSize = sequence.Length - leftPartSize;

            decimal[] leftPart = new decimal[leftPartSize];
            decimal[] rightPart = new decimal[rightPartSize];

            for (int i = 0; i < leftPartSize; i++)
            {
                leftPart[i] = sequence[i];
            }

            for (int i = 0; i < rightPartSize; i++)
            {
                rightPart[i] = sequence[middleIndex + i];
            }

            leftPart = this.RecursiveMergeSort(leftPart);
            rightPart = this.RecursiveMergeSort(rightPart);
            return this.Merge(leftPart, rightPart);
        }

        private decimal[] Merge(decimal[] leftPart, decimal[] rightPart)
        {
            decimal[] mergedSequence = new decimal[leftPart.Length + rightPart.Length];
            int leftIndex = 0;
            int rightIndex = 0;

            for (int i = 0; i < mergedSequence.Length; i++)
            {
                if (leftIndex < leftPart.Length && rightIndex < rightPart.Length)
                {
                    if (this.CompareFirstBigger(leftPart[leftIndex], rightPart[rightIndex]))
                    {
                        mergedSequence[i] = rightPart[rightIndex];
                        rightIndex++;
                    }
                    else
                    {
                        mergedSequence[i] = leftPart[leftIndex];
                        leftIndex++;
                    }
                }
                else
                {
                    if (rightIndex < rightPart.Length)
                    {
                        mergedSequence[i] = rightPart[rightIndex];
                        rightIndex++;
                    }

                    if (leftIndex < leftPart.Length)
                    {
                        mergedSequence[i] = leftPart[leftIndex];
                        leftIndex++;
                    }
                }
            }

            return mergedSequence;
        }
    }
}
