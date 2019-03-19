using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business.Sort.SortType.Interface;
using Business.Sort.SortStrategy;
using Business.Sort;
using Business.Sort.Interface;
using Business.Sort.SortStrategy.Base;
using Business.Sort.SortStrategy.StepCounter.Interface;
using Business.Sort.SortStrategy.StepCounter.Interface.Fakes;
using Business.Sort.SortType.Interface.Fakes;

namespace Business.UnitTest.Sort.SortStrategy.Base
{
    [TestClass]
    public abstract class SortStrategyBaseTest
    {
        protected abstract SortStrategyBase GetSortStrategy(ISortType sortType, IStepCounter stepCounter);

        [TestMethod]        
        public void SortStrategy_Sort_SequenceIsNull_ThrowArgumentNullException()
        {
            ISortType sortType = new StubISortType()
            {
                UpdateIEnumerableOfDecimal = (notUpdatedSequence) => notUpdatedSequence
            };

            IStepCounter stepCounter = new StubIStepCounter()
            {
                CountSwapOperation = () => { },
                CountCompareOperation = () => { }
            };

            var sortStrategy = GetSortStrategy(sortType, stepCounter);

            Assert.ThrowsException<ArgumentNullException>(() => sortStrategy.Sort(null));
        }

        [TestMethod]
        public void SortStrategy_ConstructorISortTypeIStepCounter_SortTypeIsNull_ThrowArgumentNullException()
        {            
            IStepCounter stepCounter = new StubIStepCounter()
            {
                CountSwapOperation = () => { },
                CountCompareOperation = () => { }
            };

            Assert.ThrowsException<ArgumentNullException>(() => GetSortStrategy(null, stepCounter));
        }

        [TestMethod]
        public void SortStrategy_ConstructorISortTypeIStepCounter_StepCounterIsNull_ThrowArgumentNullException()
        {
            ISortType sortType = new StubISortType()
            {
                UpdateIEnumerableOfDecimal = (notUpdatedSequence) => notUpdatedSequence
            };

            Assert.ThrowsException<ArgumentNullException>(() => GetSortStrategy(sortType, null));
        }

        [TestMethod]
        public void SortStrategy_Sort_SequenceIsEmpty_ReturnEmptySequence()
        {
            ISortType sortType = new StubISortType()
            {
                UpdateIEnumerableOfDecimal = (notUpdatedSequence) => notUpdatedSequence
            };

            IStepCounter stepCounter = new StubIStepCounter()
            {
                CountSwapOperation = () => { },
                CountCompareOperation = () => { }
            };

            var sortStrategy = GetSortStrategy(sortType, stepCounter);
            var expectedSequence = new decimal[1];

            ISortResult sortResult = sortStrategy.Sort((new decimal[1]));

            CollectionAssert.AreEqual(expectedSequence, sortResult.SortedNumbers.ToArray());
        }

        [TestMethod]
        public void SortStrategy_Sort_SequenceWithUnsortedNumbers_ReturnSortedSequence()
        {
            ISortType sortType = new StubISortType()
            {
                UpdateIEnumerableOfDecimal = (notUpdatedSequence) => notUpdatedSequence
            };

            IStepCounter stepCounter = new StubIStepCounter()
            {
                CountSwapOperation = () => { },
                CountCompareOperation = () => { }
            };

            var sortStrategy = GetSortStrategy(sortType, stepCounter);
            var expectedSequence = new decimal[] { 1, 2, 3, 4 };
            var primarySequence = new decimal[] { 4, 2, 1, 3 };

            ISortResult sortResult = sortStrategy.Sort(primarySequence);

            CollectionAssert.AreEqual(expectedSequence, sortResult.SortedNumbers.ToArray());
        }
    }    
}
