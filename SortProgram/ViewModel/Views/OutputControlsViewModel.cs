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
        
        public int CompareOperationsCount
        {
            get
            {
                return sortResult.CompareOperationsCount;
            }
        }

        public OutputControlsViewModel()
        {
            sortHandler = new SortHandler();
            stringToCollectionParser = new StringToDecimalCollectionParser();
        }

        public string OutputSequence
        {
            get
            {
                return stringToCollectionParser.ParseCollectionToString(sortResult.SortedNumbers);
            }
        }

        public int SwapOperationsCount
        {
            get
            {
                return sortResult.SwapOperationsCount;
            }
        }               

        public void Sort(string sequence, SortAlgorithmEnum sortAlgorithm, SortTypeEnum sortType)
        {
            sortResult = sortHandler.Handle(sequence, sortAlgorithm, sortType);
        }
    }
}
