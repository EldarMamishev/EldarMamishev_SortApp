using System;
using Business.Enum;
using ViewModel.Base;

namespace ViewModel.Views
{
    class SettingControlsViewModel : ViewModelBase
    {
        public SortTypeEnum SelectedSortType
        {
            get
            {
                return this.SelectedSortType;
            }
            set
            {
                this.SelectedSortType = value;
                OnPropertyChanged("SelectedSortType");
            }
        }  

        public SortAlgorithmEnum SelectedSortAlgorithm
        {
            get
            {
                return this.SelectedSortAlgorithm;
            }
            set
            {
                this.SelectedSortAlgorithm = value;
                OnPropertyChanged("SelectedSortAlgorithm");
            }
        }
    }
}
