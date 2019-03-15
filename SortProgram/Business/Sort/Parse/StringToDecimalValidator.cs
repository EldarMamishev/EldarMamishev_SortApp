using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Business.Sort.Parse.Exception;
using Business.Sort.Parse.Interface;

namespace Business.Sort.Parse
{
    public sealed class StringToDecimalValidator : IStringValidator
    {
        public void Validate(string sequence)
        {           
            string pattern = @"^((\d+(\.\d+(\s|$))?\s*)+)$";

            if (!Regex.IsMatch(sequence, pattern))
                throw new ValidationException(nameof(sequence));
        }
    }
}
