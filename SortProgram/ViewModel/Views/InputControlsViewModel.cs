using System;
using ViewModel.Base;

namespace ViewModel.Views
{
    class InputControlsViewModel : ViewModelBase
    {
        public string InputSequence
        {
            get
            {
                return this.InputSequence;
            }

            set
            {
                this.InputSequence = value;
                OnPropertyChanged("InputSequence");
            }
        }

    }
}
