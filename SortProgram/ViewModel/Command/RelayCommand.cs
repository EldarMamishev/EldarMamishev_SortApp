using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.Command
{
    public sealed class RelayCommand : ICommand
    {
        private readonly Func<object, bool> canExecute;
        private readonly Action<object> execute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => this.canExecute == null || this.canExecute(parameter);

        public void Execute(object parameter) => this.execute(parameter);

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;            
        }        
    }
}
