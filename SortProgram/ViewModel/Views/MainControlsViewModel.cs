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

        public InputControlsViewModel InputControlsVM => this.inputControlsVM ?? 
                    (this.inputControlsVM = new InputControlsViewModel());

        private void Execute() => 
            this.OutputControlsVM.Sort(InputControlsVM.InputSequence, 
                SettingControlsVM.SelectedSortAlgorithm, 
                SettingControlsVM.SelectedSortType);

        private bool CanExecute() => this.InputControlsVM.InputSequence.Length > 0;

        public OutputControlsViewModel OutputControlsVM => this.outputControlsVM ??
                    (this.outputControlsVM = new OutputControlsViewModel());

        public SettingControlsViewModel SettingControlsVM => this.settingControlsVM ??
                    (this.settingControlsVM = new SettingControlsViewModel());

        public RelayCommand SortCommand => this.sortCommand ?? 
                    (this.sortCommand = new RelayCommand(
                        obj => this.Execute()));
    }
}
