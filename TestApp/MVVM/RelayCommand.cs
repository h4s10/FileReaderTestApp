using System;
using System.Windows.Input;

namespace TestApp
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add => CommandManager.RequerySuggested += value; remove => CommandManager.RequerySuggested -= value; }
        private Action<object> _action;
        private Func<object, bool> _func;
        public RelayCommand(Action<object> action, Func<object, bool> func)
        {
            _action = action;
            _func = func;
        }

        public bool CanExecute(object parameter) => _func?.Invoke(parameter) == true;
        public void Execute(object parameter) => _action?.Invoke(parameter);
    }
}
