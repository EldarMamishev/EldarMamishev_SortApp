﻿using System;
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

namespace Business.UnitTest.Sort.SortStrategy.Base
{
    [TestClass]
    public abstract class SortStrategyBaseTest
    {
        protected abstract SortStrategyBase GetSortStrategy(ISortType sortType, IStepCounter stepCounter);

        [TestMethod]        
        public void SortStrategy_Sort_SequenceIsNull_ThrowArgumentNullException()
        {
            ISortType sortType = new Business.Sort.SortType.Interface.Fakes.StubISortType()
            {
                UpdateIEnumerableOfDecimal = (notUpdatedSequence) => { return notUpdatedSequence; }
            };

            IStepCounter stepCounter = new StubIStepCounter()
            {
                CountSwapOperation = () => { return; },
                CountCompareOperation = () => { return; }
            };

            var sortStrategy = GetSortStrategy(sortType, stepCounter);

            Assert.ThrowsException<ArgumentNullException>(() => sortStrategy.Sort(null));
        }

        [TestMethod]
        public void SortStrategy_Sort_SequenceIsEmpty_ReturnEmptySequence()
        {
            ISortType sortType = new Business.Sort.SortType.Interface.Fakes.StubISortType()
            {
                UpdateIEnumerableOfDecimal = (notUpdatedSequence) => { return notUpdatedSequence; }
            };

            IStepCounter stepCounter = new StubIStepCounter()
            {
                CountSwapOperation = () => { return; },
                CountCompareOperation = () => { return; }
            };

            var sortStrategy = GetSortStrategy(sortType, stepCounter);
            var expectedSequence = new decimal[1];

            ISortResult sortResult = sortStrategy.Sort((new decimal[1]));

            Assert.IsTrue(expectedSequence.SequenceEqual(sortResult.SortedNumbers));
        }

        [TestMethod]
        public void SortStrategy_Sort_SequenceWithUnsortedNumbers_ReturnSortedSequence()
        {
            ISortType sortType = new Business.Sort.SortType.Interface.Fakes.StubISortType()
            {
                UpdateIEnumerableOfDecimal = (notUpdatedSequence) => { return notUpdatedSequence; }
            };

            IStepCounter stepCounter = new StubIStepCounter()
            {
                CountSwapOperation = () => { return; },
                CountCompareOperation = () => { return; }
            };

            var sortStrategy = GetSortStrategy(sortType, stepCounter);
            var expectedSequence = new decimal[] {1, 2, 3, 4};
            var primarySequence = new decimal[] {4, 2, 1, 3};

            ISortResult sortResult = sortStrategy.Sort(primarySequence);

            Assert.IsTrue(expectedSequence.SequenceEqual(sortResult.SortedNumbers));
        }
    }    
}
