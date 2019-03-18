using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.Enum;
using Business.Sort.SortStrategy.Interface;
using Business.Sort.SortStrategy.StepCounter.Interface;

namespace Business.Sort.SortStrategy.Factory.Interface
{
    public interface ISortStrategyFactory
    {
        ISortStrategy CreateSort(SortAlgorithmEnum sortAlgorithm, SortTypeEnum sortType, IStepCounter stepCounter);
    }
}
