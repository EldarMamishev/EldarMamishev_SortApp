using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.Parse.Exception;
using Business.Sort.Parse.Interface;

namespace Business.Sort.Parse
{
    public sealed class StringToDecimalValidator : IStringValidator
    {
        public void Validate(string sequence)
        {
            if(sequence.Any(ch => !(char.IsDigit(ch)|| char.IsWhiteSpace(ch) || ch.Equals('.'))))
                throw new ValidationException(nameof(sequence));
            if(sequence.Split('.').Any(str => !str.Contains(' ') && !str.Contains('\n') && !str.Contains('\t') && !str.Any(ch => char.IsDigit(ch))))
                throw new ValidationException(nameof(char.IsPunctuation));
        }
    }
}
