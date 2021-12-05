using Lesson3.Models;

namespace Lesson3.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private ICustomCommand? _command;
        private string? _text = "Hello World";

        public ICustomCommand? Command 
        { 
            get
            {
                if(_command is null) _command = new CustomCommand(obj => ChangeText());
                return _command;
            }
        }

        public string Text 
        { 
            get => _text!; 
            set => SetField(ref _text, value); 
        }

        private void ChangeText() => _text = "Hello World";
    }
}
