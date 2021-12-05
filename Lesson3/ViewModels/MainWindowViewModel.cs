using Lesson3.Models;

namespace Lesson3.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private ICommand? _command;
        private string? _text;

        public ICommand? Command 
        { 
            get
            {
                if(_command is null) _command = new Command(obj => ChangeText());
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
