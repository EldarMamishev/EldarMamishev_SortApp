using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.SortType.Interface;

namespace Business.Sort.SortType
{
    public sealed class AscendingSortType : ISortType 
    {
        public IEnumerable<decimal> Update(IEnumerable<decimal> sortedSequence)
        {
            if (sortedSequence == null)
                throw new ArgumentNullException();

            return sortedSequence;
        }
    }
}
