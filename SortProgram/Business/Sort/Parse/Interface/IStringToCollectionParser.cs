using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Sort.Parse.Interface
{
    public interface IStringToCollectionParser<T>
    {
        string ParseCollectionToString(IEnumerable<T> frequence);
        IEnumerable<T> ParseStringToCollection(string frequence);
    }
}
