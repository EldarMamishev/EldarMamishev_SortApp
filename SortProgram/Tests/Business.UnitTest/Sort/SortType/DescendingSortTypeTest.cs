using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business.Sort.SortType;

namespace Business.UnitTest.Sort.SortType
{
    [TestClass]
    public class DescendingSortTypeTest
    {
        [TestMethod]
        public void DescendingSortType_Update_SequenceIsNull_ThrowsArgumentNullException()
        {
            var descendingSortType = new DescendingSortType();

            Assert.ThrowsException<ArgumentNullException>(() => descendingSortType.Update(null));
        }

        [TestMethod]
        public void DescendingSortType_Update_SequenceHasNumbers_ReturnsSequenceInReverseOrder()
        {
            var descendingSortType = new DescendingSortType();
            decimal[] primarySequence = new decimal[] {1, 2, 4, 3};
            decimal[] expectedSequence = new decimal[] { 3, 4, 2, 1 };

            IEnumerable<decimal> updatedSequence = descendingSortType.Update(primarySequence);

            Assert.IsTrue(expectedSequence.SequenceEqual(updatedSequence));
        }
    }
}
