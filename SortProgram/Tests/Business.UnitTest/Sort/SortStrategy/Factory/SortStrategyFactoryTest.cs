using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.SortStrategy.Factory;
using Business.Sort.SortType.Factory.Interface;
using Business.Sort.SortType.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business.Sort.Enum;
using Business.Sort.SortStrategy.StepCounter.Interface;
using Business.Sort.SortStrategy.Interface;
using Business.Sort.SortStrategy;

namespace Business.UnitTest.Sort.SortStrategy.Factory
{
    [TestClass]
    public class SortStrategyFactoryTest
    {
        private ISortTypeFactory CreateSortTypeFactory()
        {
            ISortTypeFactory sortTypeFactory = new Business.Sort.SortType.Factory.Interface.Fakes.StubISortTypeFactory()
            {
                CreateSortTypeSortTypeEnum = (sortTypeEnum) => 
                    new Business.Sort.SortType.Interface.Fakes.StubISortType()
                    {
                        UpdateIEnumerableOfDecimal = (notUpdatedSequence) => { return notUpdatedSequence; }

                    }                
            };

            return sortTypeFactory;
        }

        [TestMethod]
        public void SortStrategyFactory_CreateSort_InsertionSortValue_CreateInsertionSortInstance()
        {
            ISortTypeFactory sortTypeFactory = CreateSortTypeFactory();

            var sortStrategyFactory = new SortStrategyFactory(sortTypeFactory);

            IStepCounter stepCounter = new Business.Sort.SortStrategy.StepCounter.Interface.Fakes.StubIStepCounter()
            {
                CountSwapOperation = () => { return; },
                CountCompareOperation = () => { return; }
            };

            ISortStrategy sortStrategy = sortStrategyFactory.CreateSort(SortAlgorithmEnum.InsertionSort, SortTypeEnum.Ascending, stepCounter);

            Assert.IsInstanceOfType(sortStrategy, typeof(InsertionSort));
        }

        [TestMethod]
        public void SortStrategyFactory_CreateSort_SelectionSortValue_CreateSelectionSortInstance()
        {
            ISortTypeFactory sortTypeFactory = CreateSortTypeFactory();

            var sortStrategyFactory = new SortStrategyFactory(sortTypeFactory);

            IStepCounter stepCounter = new Business.Sort.SortStrategy.StepCounter.Interface.Fakes.StubIStepCounter()
            {
                CountSwapOperation = () => { return; },
                CountCompareOperation = () => { return; }
            };

            ISortStrategy sortStrategy = sortStrategyFactory.CreateSort(SortAlgorithmEnum.SelectionSort, SortTypeEnum.Ascending, stepCounter);

            Assert.IsInstanceOfType(sortStrategy, typeof(SelectionSort));
        }

        [TestMethod]
        public void SortStrategyFactory_CreateSort_QuickSortValue_CreateQuickSortInstance()
        {
            ISortTypeFactory sortTypeFactory = CreateSortTypeFactory();

            var sortStrategyFactory = new SortStrategyFactory(sortTypeFactory);

            IStepCounter stepCounter = new Business.Sort.SortStrategy.StepCounter.Interface.Fakes.StubIStepCounter()
            {
                CountSwapOperation = () => { return; },
                CountCompareOperation = () => { return; }
            };

            ISortStrategy sortStrategy = sortStrategyFactory.CreateSort(SortAlgorithmEnum.QuickSort, SortTypeEnum.Ascending, stepCounter);

            Assert.IsInstanceOfType(sortStrategy, typeof(QuickSort));
        }

        [TestMethod]
        public void SortStrategyFactory_CreateSort_MergeSortValue_CreateMergeSortInstance()
        {
            ISortTypeFactory sortTypeFactory = CreateSortTypeFactory();

            var sortStrategyFactory = new SortStrategyFactory(sortTypeFactory);

            IStepCounter stepCounter = new Business.Sort.SortStrategy.StepCounter.Interface.Fakes.StubIStepCounter()
            {
                CountSwapOperation = () => { return; },
                CountCompareOperation = () => { return; }
            };

            ISortStrategy sortStrategy = sortStrategyFactory.CreateSort(SortAlgorithmEnum.MergeSort, SortTypeEnum.Ascending, stepCounter);

            Assert.IsInstanceOfType(sortStrategy, typeof(MergeSort));
        }
    }
}
