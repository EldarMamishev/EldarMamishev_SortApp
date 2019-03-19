using System;
using System.Collections.Generic;
using System.Text;
using Business.Sort.Parse.Exception;
using Business.Sort.Parse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Business.UnitTest.Sort.Parse
{
    [TestClass]
    public class StringToDecimalValidatorTest
    {
        [TestMethod]
        public void StringToDecimalValidator_Validate_SequenceNull_ThrowsArgumentNullException()
        {
            var validator = new StringToDecimalValidator();

            Assert.ThrowsException<ArgumentNullException>(() => validator.Validate(null));
        }

        [TestMethod]
        public void StringToDecimalValidator_Validate_SequenceEmptyString_ThrowsValidationException()
        {
            var validator = new StringToDecimalValidator();

            Assert.ThrowsException<ValidationException>(() => validator.Validate(string.Empty));
        }

        [TestMethod]
        public void StringToDecimalValidator_Validate_SequenceWithLetters_ThrowsValidationException()
        {
            var validator = new StringToDecimalValidator();

            Assert.ThrowsException<ValidationException>(() => validator.Validate("1 a"));
        }

        [TestMethod]
        public void StringToDecimalValidator_Validate_SequenceWithUnsupportedCharacters_ThrowsValidationException()
        {
            var validator = new StringToDecimalValidator();

            Assert.ThrowsException<ValidationException>(() => validator.Validate("1 3 ,"));
        }

        [TestMethod]
        public void StringToDecimalValidator_Validate_SequenceOfNumberStartingWithDot_ThrowsValidationException()
        {
            var validator = new StringToDecimalValidator();

            Assert.ThrowsException<ValidationException>(() => validator.Validate(".1"));
        }

        [TestMethod]
        public void StringToDecimalValidator_Validate_SequenceOfNumberEndingWithDot_ThrowsValidationException()
        {
            var validator = new StringToDecimalValidator();

            Assert.ThrowsException<ValidationException>(() => validator.Validate("2 0.5 1."));
        }

        [TestMethod]
        public void StringToDecimalValidator_Validate_SequenceOfWhiteSpaces_ThrowsValidationException()
        {
            var validator = new StringToDecimalValidator();

            Assert.ThrowsException<ValidationException>(() => validator.Validate(" "));
        }

        [TestMethod]
        public void StringToDecimalValidator_Validate_SequenceOfNumberWithTwoDots_ThrowsValidationException()
        {
            var validator = new StringToDecimalValidator();

            Assert.ThrowsException<ValidationException>(() => validator.Validate("1.1."));
        }

        [TestMethod]
        public void StringToDecimalValidator_Validate_SequenceOfNumber_Success()
        {
            var validator = new StringToDecimalValidator();

            validator.Validate("1 0 3");
        }

        [TestMethod]
        public void StringToDecimalValidator_Validate_SequenceOfNumbersWithDot_Success()
        {
            var validator = new StringToDecimalValidator();

            validator.Validate("1.1 2.5 3");
        }
    }
}
