using System;
using Business.Enums;

namespace ViewModel
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
