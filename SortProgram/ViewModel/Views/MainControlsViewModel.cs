using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Base;
using ViewModel.Command;

namespace ViewModel.Views
{
    public sealed class MainControlsViewModel : ViewModelBase
    {
        private InputControlsViewModel inputControlsVM;
        private OutputControlsViewModel outputControlsVM;
        private SettingControlsViewModel settingControlsVM;
        private RelayCommand sortCommand;

        public InputControlsViewModel InputControlsVM
        {
            get
            {
                return inputControlsVM ?? 
                    (inputControlsVM = new InputControlsViewModel());
            }
        }

        public OutputControlsViewModel OutputControlsVM
        {
            get
            {
                return outputControlsVM ??
                    (outputControlsVM = new OutputControlsViewModel());
            }
        }

        public SettingControlsViewModel SettingControlsVM
        {
            get
            {
                return settingControlsVM ??
                    (settingControlsVM = new SettingControlsViewModel());
            }
        }

        private RelayCommand SortCommand
        {
            get
            {
                return sortCommand ?? 
                    (sortCommand = new RelayCommand(
                        obj => OutputControlsVM.Sort(InputControlsVM.InputSequence, SettingControlsVM.SelectedSortAlgorithm, SettingControlsVM.SelectedSortType), 
                        obj => InputControlsVM.InputSequence.Length > 0));
            }
        }
    }
}
