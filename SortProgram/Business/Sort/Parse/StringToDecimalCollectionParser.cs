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
            decimal[] copySequence = sequence.ToArray();
            string stringSequence = "";

            for (int i = 0; i < copySequence.Length - 1; i++)
            {
                stringSequence += copySequence[i] + " ";
            }

            stringSequence += copySequence.Last();

            return stringSequence;
        }

        public IEnumerable<decimal> ParseStringToCollection(string sequence)
        {
            decimal[] arraySequence = sequence.Split(' ', '\t', '\n').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => decimal.Parse(x)).ToArray();

            return arraySequence;
        }
    }
}
