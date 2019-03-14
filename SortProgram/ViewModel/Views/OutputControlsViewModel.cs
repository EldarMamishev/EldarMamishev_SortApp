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
        private string outputSequence;
        private int swapOperationsCount;
        private int compareOperationsCount;


        public int CompareOperationsCount => this.compareOperationsCount;

        public OutputControlsViewModel()
        {
            this.sortHandler = new SortHandler();
            this.stringToCollectionParser = new StringToDecimalCollectionParser();
        }

        public string OutputSequence => this.outputSequence;

        public int SwapOperationsCount => this.swapOperationsCount;

        public void Sort(string sequence, SortAlgorithmEnum sortAlgorithm, SortTypeEnum sortType)
        {
            this.sortResult = this.sortHandler.Handle(sequence, sortAlgorithm, sortType);
            this.outputSequence = this.stringToCollectionParser.ParseCollectionToString(this.sortResult.SortedNumbers);
            this.compareOperationsCount = this.sortResult.CompareOperationsCount;
            this.swapOperationsCount = this.sortResult.SwapOperationsCount;
            this.OnPropertyChanged(string.Empty);
        }
    }
}
