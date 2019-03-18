using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.Enum;
using Business.Sort.SortStrategy.StepCounter.Interface;

namespace Business.Sort.Interface
{
    public interface ISortHandler
    {
        ISortResult Handle(string sequence, SortAlgorithmEnum sortAlgorithm, SortTypeEnum sortType, IStepCounter stepCounter);
    }
}
