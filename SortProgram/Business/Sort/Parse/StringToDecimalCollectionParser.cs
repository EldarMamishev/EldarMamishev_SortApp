using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.Parse.Interface;

namespace Business.Sort.Parse
{
    public sealed class StringToDecimalCollectionParser : IStringToCollectionParser<decimal>
    {
        public string ParseCollectionToString(IEnumerable<decimal> sequence)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<decimal> ParseStringToCollection(string sequence)
        {
            throw new NotImplementedException();
        }
    }
}
