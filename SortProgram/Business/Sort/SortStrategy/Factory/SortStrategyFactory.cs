using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.Enum;
using Business.Sort.SortStrategy.Factory.Interface;
using Business.Sort.SortStrategy.Interface;
using Business.Sort.SortStrategy.StepCounter.Interface;
using Business.Sort.SortType.Factory;
using Business.Sort.SortType.Factory.Interface;
using Business.Sort.SortType.Interface;

namespace Business.Sort.SortStrategy.Factory
{
    public sealed class SortStrategyFactory : ISortStrategyFactory
    {
        private ISortTypeFactory sortTypeFactory;

        public SortStrategyFactory(ISortTypeFactory sortTypeFactory)
        {
            this.sortTypeFactory = sortTypeFactory;
        }

        public ISortStrategy CreateSort(SortAlgorithmEnum sortAlgorithm, SortTypeEnum sortType, IStepCounter stepCounter)
        {
            ISortType neededSortType = this.sortTypeFactory.CreateSortType(sortType);

            switch (sortAlgorithm)
            {
                case SortAlgorithmEnum.InsertionSort:
                {
                    return new InsertionSort(neededSortType, stepCounter);
                }
                case SortAlgorithmEnum.MergeSort:
                {
                    return new MergeSort(neededSortType, stepCounter);
                }
                case SortAlgorithmEnum.QuickSort:
                {
                    return new QuickSort(neededSortType, stepCounter);
                }
                case SortAlgorithmEnum.SelectionSort:
                {
                    return new SelectionSort(neededSortType, stepCounter);
                }
                default:
                    return null;
            }
        }
    }
}
