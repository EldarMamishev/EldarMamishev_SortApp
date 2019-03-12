using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Enum;
using Business.Sort.SortStrategy.Interface;

namespace Business.Sort.SortStrategy.Factory.Interface
{
    public interface ISortStrategyFactory
    {
        ISortStrategy CreateSort(SortAlgorithmEnum sortAlgorithm, SortTypeEnum sortType);
    }
}
