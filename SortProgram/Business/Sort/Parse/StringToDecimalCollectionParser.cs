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
        private IStringValidator stringValidator;

        public StringToDecimalCollectionParser(IStringValidator stringValidator)
        {
            this.stringValidator = stringValidator;
        }

        public string ParseCollectionToString(IEnumerable<decimal> sequence)
        {
            if (sequence == null)
                throw new ArgumentNullException(nameof(sequence));

            decimal[] copySequence = sequence.ToArray();
            string stringSequence = string.Join(" ", copySequence);

            return stringSequence;
        }

        public IEnumerable<decimal> ParseStringToCollection(string sequence)
        {
            if (sequence == null)
                throw new ArgumentNullException(nameof(sequence));

            stringValidator.Validate(sequence);
            decimal[] arraySequence = sequence.Split(' ', '\t', '\n').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => decimal.Parse(x)).ToArray();

            return arraySequence;
        }
    }
}
