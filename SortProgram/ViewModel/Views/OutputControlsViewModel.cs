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
using ViewModel.Base;

namespace ViewModel.Views
{
    public sealed class OutputControlsViewModel : ViewModelBase
    {
        private ISortResult sortResult;
        private ISortHandler sortHandler;
        private IStringToCollectionParser<decimal> stringToCollectionParser;
        private string errorMessage;
        private IStringValidator stringValidator;
        
        public int? CompareOperationsCount => this.sortResult?.CompareOperationsCount;

        public string ErrorMessage => errorMessage ?? string.Empty;

        public OutputControlsViewModel()
        {
            this.sortHandler = new SortHandler();
            this.stringValidator = new StringToDecimalValidator();
            this.stringToCollectionParser = new StringToDecimalCollectionParser(this.stringValidator);
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
            try
            {   
                this.errorMessage = string.Empty;
                this.sortResult = this.sortHandler.Handle(sequence, sortAlgorithm, sortType); 
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
