using System;
using System.Collections.Generic;
using Business.Sort.Enum;
using ViewModel.Base;

namespace ViewModel.Views
{
    public sealed class SettingControlsViewModel : ViewModelBase
    {        
        private Dictionary<string, SortAlgorithmEnum> sortAlgorithms;
        private Dictionary<string, SortTypeEnum> sortTypes;

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
                this.OnPropertyChanged(nameof(this.SelectedSortAlgorithm));
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
                this.OnPropertyChanged(nameof(this.SelectedSortType));
            }
        }

        public SettingControlsViewModel()
        {
            sortAlgorithms = new Dictionary<string, SortAlgorithmEnum>();
            sortTypes = new Dictionary<string, SortTypeEnum>();
            foreach(SortAlgorithmEnum sort in Enum.GetValues(typeof(SortAlgorithmEnum)))
            {
                sortAlgorithms.Add(sort.ToString(), sort);
            }

            foreach (SortTypeEnum sort in Enum.GetValues(typeof(SortTypeEnum)))
            {
                sortTypes.Add(sort.ToString(), sort);
            }
        }

        public Dictionary<string, SortAlgorithmEnum> SortAlgorithms => this.sortAlgorithms;

        public Dictionary<string, SortTypeEnum> SortTypes => this.sortTypes;

    }
}
