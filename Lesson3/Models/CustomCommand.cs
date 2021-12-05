using System;
using System.Windows.Input;

namespace Lesson3.Models
{
    internal sealed class CustomCommand : ICustomCommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public CustomCommand(Action<object> execute) : this(execute, null!) { }
        public CustomCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute is null) throw new ArgumentNullException(nameof(execute));
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter)
            => _canExecute is null || _canExecute(parameter!);

        public void Execute(object? parameter)
            => _execute(parameter!);
    }
}
