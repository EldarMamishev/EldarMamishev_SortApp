using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort.Enum;
using Business.Sort.Interface;
using Business.Sort.Parse;
using Business.Sort.Parse.Interface;
using Business.Sort.SortStrategy.Factory;
using Business.Sort.SortStrategy.Factory.Interface;

namespace Business.Sort
{
    public sealed class SortHandler : ISortHandler
    {
        private ISortStrategyFactory sortStrategyFactory;
        private IStringToCollectionParser<decimal> stringToDecimalCollectionParser;
        public IStringValidator stringValidator;


        public SortHandler()
        {
            this.sortStrategyFactory = new SortStrategyFactory();
            this.stringToDecimalCollectionParser = new StringToDecimalCollectionParser(this.stringValidator);
        }

        public ISortResult Handle(string sequence, SortAlgorithmEnum sortAlgorithm, SortTypeEnum sortType)
        {
            IEnumerable<decimal> numbersSequence = stringToDecimalCollectionParser.ParseStringToCollection(sequence);            

            ISortResult sortResult = sortStrategyFactory.CreateSort(sortAlgorithm, sortType).Sort(numbersSequence);

            return sortResult;
        }
    }
}
