using System;

namespace Lesson3.Models
{
    public interface ICustomCommand
    {
        bool CanExecute(object? parameter);
        void Execute(object? parameter);

        event EventHandler? CanExecuteChanged;
    }
}
