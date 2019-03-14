using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Sort;
using Business.Sort.Enum;
using Business.Sort.Interface;
using Business.Sort.Parse;
using Business.Sort.Parse.Interface;
using ViewModel.Base;

namespace ViewModel.Views
{
    public sealed class OutputControlsViewModel : ViewModelBase
    {
        private ISortResult sortResult;
        private ISortHandler sortHandler;
        private IStringToCollectionParser<decimal> stringToCollectionParser;
        
        public int CompareOperationsCount => sortResult.CompareOperationsCount;

        public OutputControlsViewModel()
        {
            this.sortHandler = new SortHandler();
            this.stringToCollectionParser = new StringToDecimalCollectionParser();
        }

        public string OutputSequence => this.stringToCollectionParser.ParseCollectionToString(this.sortResult.SortedNumbers);

        public int SwapOperationsCount => this.sortResult.SwapOperationsCount;

        public void Sort(string sequence, SortAlgorithmEnum sortAlgorithm, SortTypeEnum sortType)
        {
            this.sortResult = this.sortHandler.Handle(sequence, sortAlgorithm, sortType);
            this.OnPropertyChanged(string.Empty);
        }
    }
}
