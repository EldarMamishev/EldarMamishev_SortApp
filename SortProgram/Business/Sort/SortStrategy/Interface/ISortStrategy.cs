using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.Interface;
using Business.Sort.SortType.Interface;

namespace Business.Sort.SortStrategy.Interface
{
    public interface ISortStrategy
    {
        ISortResult Sort(IEnumerable<decimal> sequence, ISortType sortType);
    }
}
