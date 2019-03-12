using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Enum;
using Business.Sort.SortType.Interface;

namespace Business.Sort.SortType.Factory.Interface
{
    public interface ISortTypeFactory
    {
        ISortType CreateSortType(SortTypeEnum sortType);
    }
}