using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort;
using Business.Sort.Enum;
using Business.Sort.Interface;
using Business.Sort.Parse;
using Business.Sort.Parse.Exception;
using Business.Sort.Parse.Interface;
using Business.Sort.SortStrategy.Factory;
using Business.Sort.SortStrategy.Factory.Interface;
using Business.Sort.SortStrategy.StepCounter;
using Business.Sort.SortStrategy.StepCounter.Interface;
using Business.Sort.SortType.Factory;
using Business.Sort.SortType.Factory.Interface;
using ViewModel.Base;

namespace ViewModel.Views
{
    public sealed class OutputControlsViewModel : ViewModelBase
    {
        private ISortResult sortResult;
        private ISortHandler sortHandler;
        private IStringToCollectionParser<decimal> stringToCollectionParser;
        private string errorMessage;
        
        public int? CompareOperationsCount => this.sortResult?.CompareOperationsCount;

        public string ErrorMessage => errorMessage ?? string.Empty;

        public OutputControlsViewModel()
        {
            ISortTypeFactory sortTypeFactory = new SortTypeFactory();
            ISortStrategyFactory sortStrategyFactory = new SortStrategyFactory(sortTypeFactory);
            IStringValidator stringValidator = new StringToDecimalValidator();
            this.stringToCollectionParser = new StringToDecimalCollectionParser(stringValidator);
            this.sortHandler = new SortHandler(this.stringToCollectionParser, sortStrategyFactory);
        }

        public string OutputSequence
        {
            get
            {
                if (sortResult == null)
                    return string.Empty;
                return this.stringToCollectionParser.ParseCollectionToString(this.sortResult.SortedNumbers);
            }
        }
        
        public void Sort(string sequence, SortAlgorithmEnum sortAlgorithm, SortTypeEnum sortType)
        {
            this.errorMessage = string.Empty;

            try
            {   
                this.sortResult = this.sortHandler.Handle(sequence, sortAlgorithm, sortType, new StepCounter()); 
            }
            catch (ValidationException)
            {
                errorMessage = "Not validating sequence";
            }

            this.OnPropertyChanged(string.Empty);
        }

        public int? SwapOperationsCount => this.sortResult?.SwapOperationsCount;
    }
}
