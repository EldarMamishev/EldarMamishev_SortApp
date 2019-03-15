using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
