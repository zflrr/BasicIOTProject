using System;
using System.Windows.Input;

namespace BasicIOT
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> executed;
        private readonly Predicate<object?>? canExecuted;

        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
        {
            executed = execute ?? throw new ArgumentNullException(nameof(execute));
            canExecuted = canExecute;
        }

        public bool CanExecute(object? parameter) => canExecuted?.Invoke(parameter) ?? true;
        public void Execute(object? parameter) => executed(parameter);

        // WPF listens to this to re-query CanExecute
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value ?? throw new ArgumentNullException(nameof(value));
            remove => CommandManager.RequerySuggested -= value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
