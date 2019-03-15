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
        public void StringToDecimalValidator_Validate_SetNull_ThrowsArgumentNullException()
        {
            var validator = new StringToDecimalValidator();

            Assert.ThrowsException<ArgumentNullException>(() => validator.Validate(null));
        }

        [TestMethod]
        public void StringToDecimalValidator_Validate_SetEmptyString_ThrowsValidationException()
        {
            var validator = new StringToDecimalValidator();

            Assert.ThrowsException<ValidationException>(() => validator.Validate(string.Empty));
        }

        [TestMethod]
        public void StringToDecimalValidator_Validate_SetStringWithLetters_ThrowsValidationException()
        {
            var validator = new StringToDecimalValidator();

            Assert.ThrowsException<ValidationException>(() => validator.Validate("a"));
        }

        [TestMethod]
        public void StringToDecimalValidator_Validate_SetUnsupportedCharacters_ThrowsValidationException()
        {
            var validator = new StringToDecimalValidator();

            Assert.ThrowsException<ValidationException>(() => validator.Validate(","));
        }

        [TestMethod]
        public void StringToDecimalValidator_Validate_SetOnlyADot_ThrowsValidationException()
        {
            var validator = new StringToDecimalValidator();

            Assert.ThrowsException<ValidationException>(() => validator.Validate("."));
        }

        [TestMethod]
        public void StringToDecimalValidator_Validate_SetNumberStartingWithDot_ThrowsValidationException()
        {
            var validator = new StringToDecimalValidator();

            Assert.ThrowsException<ValidationException>(() => validator.Validate(".1"));
        }

        [TestMethod]
        public void StringToDecimalValidator_Validate_SetNumberEndingWithDot_ThrowsValidationException()
        {
            var validator = new StringToDecimalValidator();

            Assert.ThrowsException<ValidationException>(() => validator.Validate("1."));
        }

        [TestMethod]
        public void StringToDecimalValidator_Validate_SetWhiteSpaces_ThrowsValidationException()
        {
            var validator = new StringToDecimalValidator();

            Assert.ThrowsException<ValidationException>(() => validator.Validate(" "));
        }

        [TestMethod]
        public void StringToDecimalValidator_Validate_SetNumberWithTwoDots_ThrowsValidationException()
        {
            var validator = new StringToDecimalValidator();

            Assert.ThrowsException<ValidationException>(() => validator.Validate("1.1."));
        }

        [TestMethod]
        public void StringToDecimalValidator_Validate_SetNumber_Success()
        {
            var validator = new StringToDecimalValidator();

           validator.Validate("1");
        }

        [TestMethod]
        public void StringToDecimalValidator_Validate_SetNumberWithDot_Success()
        {
            var validator = new StringToDecimalValidator();

            validator.Validate("1.1");
        }
    }   
}
