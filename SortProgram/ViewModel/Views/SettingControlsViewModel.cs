using System;
using Business.Enum;
using ViewModel.Base;

namespace ViewModel.Views
{
    public sealed class SettingControlsViewModel : ViewModelBase
    {
        private SortAlgorithmEnum selectedSortAlgorithm;
        private SortTypeEnum selectedSortType;

        public SortAlgorithmEnum SelectedSortAlgorithm
        {
            get
            {
                return this.selectedSortAlgorithm;
            }
            set
            {
                this.selectedSortAlgorithm = value;
                this.OnPropertyChanged("SelectedSortAlgorithm");
            }
        }

        public SortTypeEnum SelectedSortType
        {
            get
            {
                return this.selectedSortType;
            }
            set
            {
                this.selectedSortType = value;
                this.OnPropertyChanged("SelectedSortType");
            }
        }  

        
    }
}
