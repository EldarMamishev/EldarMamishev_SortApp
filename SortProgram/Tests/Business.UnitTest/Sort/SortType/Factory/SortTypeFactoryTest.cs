using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.SortType.Factory;
using Business.Sort.SortType.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business.Sort.Enum;
using Business.Sort.SortType;

namespace Business.UnitTest.Sort.SortType.Factory
{
    [TestClass]
    public class SortTypeFactoryTest
    {
        [TestMethod]
        public void SortTypeFactory_CreateSortType_AscendingTypeValue_CreateAscendingTypeInstance()
        {
            var sortTypeFactory = new SortTypeFactory();

            ISortType sortType = sortTypeFactory.CreateSortType(SortTypeEnum.Ascending);

            Assert.IsInstanceOfType(sortType, typeof(AscendingSortType));
        }

        [TestMethod]
        public void SortTypeFactory_CreateSortType_DescendingTypeValue_CreateDescendingTypeInstance()
        {
            var sortTypeFactory = new SortTypeFactory();

            ISortType sortType = sortTypeFactory.CreateSortType(SortTypeEnum.Descending);

            Assert.IsInstanceOfType(sortType, typeof(DescendingSortType));
        }
    }
}
