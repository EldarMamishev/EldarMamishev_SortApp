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
                return this.inputSequence;
            }

            set
            {
                this.inputSequence = value;
                this.OnPropertyChanged("InputSequence");
            }
        }
    }
}
