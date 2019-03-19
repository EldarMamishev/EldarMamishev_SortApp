using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Business.Sort.SortStrategy;
using Business.Sort.SortStrategy.StepCounter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseStepCounter = Business.Sort.SortStrategy.StepCounter;


namespace Business.UnitTest.Sort.SortStrategy.StepCounter
{
    [TestClass]
    public class StepCounterTest
    {
        [TestMethod]
        public void StepCounter_CountCompareOperation_WhenCalled_IncrementCompareOperationsCounter()
        {
            var stepCounter = new BaseStepCounter.StepCounter();

            stepCounter.CountCompareOperation();

            Assert.AreEqual(1, stepCounter.CompareOperationsCount);
        }

        [TestMethod]
        public void StepCounter_CountCompareOperation_WhenNotCalled_CompareOperationsCountIsZero()
        {
            var stepCounter = new BaseStepCounter.StepCounter();

            Assert.AreEqual(0, stepCounter.CompareOperationsCount);
        }

        [TestMethod]
        public void StepCounter_CountSwapOperation_WhenCalled_IncrementSwapOperationsCounter()
        {
            var stepCounter = new BaseStepCounter.StepCounter();

            stepCounter.CountSwapOperation();

            Assert.AreEqual(1, stepCounter.SwapOperationsCount);
        }

        [TestMethod]
        public void StepCounter_CountSwapOperation_WhenNotCalled_SwapOperationsCountIsZero()
        {
            var stepCounter = new BaseStepCounter.StepCounter();

            Assert.AreEqual(0, stepCounter.SwapOperationsCount);
        }
    }
}
