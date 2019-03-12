using System;

namespace ViewModel
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
