using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Sort.SortType.Interface
{
    public interface ISortType
    {
        IEnumerable<decimal> Update(IEnumerable<decimal> sortedSequence);
    }
}
