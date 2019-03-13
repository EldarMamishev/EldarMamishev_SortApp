using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.Enum;
using Business.Sort.SortType.Factory.Interface;
using Business.Sort.SortType.Interface;

namespace Business.Sort.SortType.Factory
{
    public sealed class SortTypeFactory : ISortTypeFactory
    {
        public ISortType CreateSortType(SortTypeEnum sortType)
        {
            switch (sortType)
            { 
                case SortTypeEnum.Ascending:
                {
                    return new AscendingSortType();
                }
                case SortTypeEnum.Descending:
                {
                    return new DescendingSortType();
                }
                default:
                {
                    return null;
                }
            }
        }
    }
}
