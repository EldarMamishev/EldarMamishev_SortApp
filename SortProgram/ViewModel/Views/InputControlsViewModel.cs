using System;
using ViewModel.Base;

namespace ViewModel.Views
{
    public sealed class InputControlsViewModel : ViewModelBase
    {
        private string inputSequence;

        public string InputSequence
        {
            get
            {
                return this.inputSequence ?? (inputSequence = string.Empty);
            }
            set
            {
                this.inputSequence = value;
                this.OnPropertyChanged(nameof(this.InputSequence));
            }
        }
    }
}
