using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Enum;

namespace Business.Sort.Interface
{
    interface ISortHandler
    {
        ISortResult Handle (string sequence, SortAlgorithmEnum sortAlgorithm, SortTypeEnum sortType);
    }
}
