using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.Enum;
using Business.Sort.SortStrategy.Factory.Interface;
using Business.Sort.SortStrategy.Interface;
using Business.Sort.SortType.Factory;
using Business.Sort.SortType.Factory.Interface;
using Business.Sort.SortType.Interface;

namespace Business.Sort.SortStrategy.Factory
{
    public sealed class SortStrategyFactory : ISortStrategyFactory
    {
        private ISortTypeFactory sortTypeFactory;
        public ISortStrategy CreateSort(SortAlgorithmEnum sortAlgorithm, SortTypeEnum sortType)
        {
            sortTypeFactory = new SortTypeFactory();
            ISortType neededSortType = sortTypeFactory.CreateSortType(sortType);
            switch (sortAlgorithm)
            {
                case SortAlgorithmEnum.InsertionSort :
                {
                    return new InsertionSort(neededSortType);
                }
                case SortAlgorithmEnum.MergeSort :
                {
                    return new MergeSort(neededSortType);
                }
                case SortAlgorithmEnum.QuickSort :
                {
                    return new QuickSort(neededSortType);
                }
                case SortAlgorithmEnum.SelectionSort :
                {
                    return new SelectionSort(neededSortType);
                }
                default :
                    return null;
            }
        }
    }
}
