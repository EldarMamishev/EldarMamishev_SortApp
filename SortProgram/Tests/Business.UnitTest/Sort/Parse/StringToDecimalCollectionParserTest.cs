using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business.Sort.Parse.Exception;
using Business.Sort.Parse;
using Business.Sort.Parse.Interface;
using Microsoft.QualityTools.Testing.Fakes;
using Business.Sort.Parse.Interface.Fakes;

namespace Business.UnitTest.Sort.Parse
{
    [TestClass]
    public class StringToDecimalCollectionParserTest
    {
        [TestMethod]
        public void StringToDecimalCollectionParser_ParseCollectionToString_SequenceIsNull_ThrowArgumentNullException()
        {            
            IStringValidator validator = new StubIStringValidator();
            IStringToCollectionParser<decimal> parser = new StringToDecimalCollectionParser(validator);

            Assert.ThrowsException<ArgumentNullException>(() => parser.ParseCollectionToString(null));            
        }
                
        [TestMethod]
        public void StringToDecimalCollectionParser_ParseCollectionToString_SequenceWithElements_ReturnsString()
        {
            IStringValidator validator = new StubIStringValidator();
            IStringToCollectionParser<decimal> parser = new StringToDecimalCollectionParser(validator);
            decimal[] collectionSequence = new decimal[]{ 1, 2 };

            string stringSequence = parser.ParseCollectionToString(collectionSequence);

            Assert.AreEqual("1 2", stringSequence);
        }

        [TestMethod]
        public void StringToDecimalCollectionParser_ParseStringToCollection_StringIsNull_ThrowArgumentNullException()
        {
            IStringValidator validator = new StubIStringValidator();
            IStringToCollectionParser<decimal> parser = new StringToDecimalCollectionParser(validator);

            Assert.ThrowsException<ArgumentNullException>(() => parser.ParseStringToCollection(null));
        }

        [TestMethod]
        public void StringToDecimalCollectionParser_ParseStringToCollection_StringIsNotEmpty_ReturnsSequenceOfNumbers()
        {
            IStringValidator validator = new StubIStringValidator();
            IStringToCollectionParser<decimal> parser = new StringToDecimalCollectionParser(validator);
            string stringSequence = "1 2";

            IEnumerable<decimal> collectionSequence = parser.ParseStringToCollection(stringSequence);
            IEnumerable<decimal> expectedSequence = new decimal[] { 1, 2 };

            Assert.IsTrue(expectedSequence.SequenceEqual(collectionSequence));
        }
    }
}
