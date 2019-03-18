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
    public class AscendingSortTypeTest
    {
        [TestMethod]
        public void AscendingSortType_Update_SequenceIsNull_ReturnsNull()
        {
            var ascendingSortType = new AscendingSortType();

            Assert.ThrowsException<ArgumentNullException>(() => ascendingSortType.Update(null));
        }

        [TestMethod]
        public void AscendingSortType_Update_SequenceHasNumbers_ReturnsSequenceInSameOrder()
        {
            var ascendingSortType = new AscendingSortType();
            decimal[] expectedSequence = new decimal[] {1, 2, 4, 3};
            
            IEnumerable<decimal> updatedSequence = ascendingSortType.Update(expectedSequence);

            Assert.IsTrue(expectedSequence.SequenceEqual(updatedSequence));
        }
    }
}
