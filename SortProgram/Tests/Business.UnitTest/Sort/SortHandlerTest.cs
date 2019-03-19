using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business.Sort.Parse.Interface.Fakes;
using Business.Sort.SortStrategy.Factory.Interface.Fakes;
using Business.Sort.SortStrategy.StepCounter.Interface.Fakes;
using Business.Sort.Enum;
using Business.Sort.Parse.Interface;
using Business.Sort.SortStrategy.Factory.Interface;
using Business.Sort.SortStrategy.StepCounter.Interface;
using Business.Sort.SortStrategy.Interface.Fakes;
using Business.Sort.Interface.Fakes;
using Business.Sort.Interface;

namespace Business.UnitTest.Sort
{
    [TestClass]
    public class SortHandlerTest
    {
        [TestMethod]
        public void SortHandler_Handle_SequenceIsNull_ThrowArgumentNullException()
        {
            IStringToCollectionParser<decimal> parser = new StubIStringToCollectionParser<decimal>();
            IStepCounter stepCounter = new StubIStepCounter();
            ISortStrategyFactory factory = new StubISortStrategyFactory();

            var handler = new SortHandler(parser, factory);

            Assert.ThrowsException<ArgumentNullException>(() => handler.Handle(null, SortAlgorithmEnum.InsertionSort, SortTypeEnum.Ascending, stepCounter));
        }

        [TestMethod]
        public void SortHandler_Handle_SequenceHasNumbers_()
        {
            IStringToCollectionParser<decimal> parser = new StubIStringToCollectionParser<decimal>()
            {
                ParseStringToCollectionString = (strSeq) => new decimal[] { 2, 1, 3 }
            };
            IStepCounter stepCounter = new StubIStepCounter()
            {
                CountSwapOperation = () => { },
                CountCompareOperation = () => { }
            };
            ISortStrategyFactory factory = new StubISortStrategyFactory()
            {
                CreateSortSortAlgorithmEnumSortTypeEnumIStepCounter = (alg, type, counter) => new StubISortStrategy()
                {
                    SortIEnumerableOfDecimal = (seq) => new StubISortResult()
                    {
                        CompareOperationsCountGet = () => 2,
                        SwapOperationsCountGet = () => 1,
                        SortedNumbersGet = () => new decimal[] { 1, 2, 3 }
                    }
                }
            };
            decimal[] expectedSequence = new decimal[] {1, 2, 3};
            int expectedCompareCount = 2;
            int expectedSwapCount = 1;
            var handler = new SortHandler(parser, factory);
            
            ISortResult sortResult = handler.Handle("2 1 3", SortAlgorithmEnum.InsertionSort, SortTypeEnum.Ascending, stepCounter);

            Assert.AreEqual(expectedCompareCount, sortResult.CompareOperationsCount, "Comapare operations are not equal");
            Assert.AreEqual(expectedSwapCount, sortResult.SwapOperationsCount, "Swap counts are not equal");
            Assert.IsTrue(expectedSequence.SequenceEqual(sortResult.SortedNumbers), "Sequences are not equal.");
        }
    }
}
