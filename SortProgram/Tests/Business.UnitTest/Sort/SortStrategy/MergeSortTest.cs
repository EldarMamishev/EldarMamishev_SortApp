using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.SortStrategy;
using Business.Sort.SortStrategy.Base;
using Business.Sort.SortStrategy.StepCounter.Interface;
using Business.Sort.SortType.Interface;
using Business.UnitTest.Sort.SortStrategy.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Business.UnitTest.Sort.SortStrategy
{
    [TestClass]
    public class MergeSortTest : SortStrategyBaseTest
    {
        protected override SortStrategyBase GetSortStrategy(ISortType sortType, IStepCounter stepCounter) => new MergeSort(sortType, stepCounter);
    }
}
