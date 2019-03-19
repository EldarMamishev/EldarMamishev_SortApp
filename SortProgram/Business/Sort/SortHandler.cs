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
using Business.Sort.SortStrategy.StepCounter.Interface;

namespace Business.Sort
{
    public sealed class SortHandler : ISortHandler
    {
        private ISortStrategyFactory sortStrategyFactory;
        private IStringToCollectionParser<decimal> stringToDecimalCollectionParser;


        public SortHandler(IStringToCollectionParser<decimal> stringParser, ISortStrategyFactory sortStrategyFactory)
        {
            this.sortStrategyFactory = sortStrategyFactory;
            this.stringToDecimalCollectionParser = stringParser;
        }

        public ISortResult Handle(string sequence, SortAlgorithmEnum sortAlgorithm, SortTypeEnum sortType, IStepCounter stepCounter)
        {
            if (sequence == null)
                throw new ArgumentNullException(nameof(sequence));

            if (stepCounter == null)
                throw new ArgumentNullException(nameof(sequence));

            IEnumerable<decimal> numbersSequence = this.stringToDecimalCollectionParser.ParseStringToCollection(sequence);            

            ISortResult sortResult = this.sortStrategyFactory.CreateSort(sortAlgorithm, sortType, stepCounter).Sort(numbersSequence);

            return sortResult;
        }
    }
}
