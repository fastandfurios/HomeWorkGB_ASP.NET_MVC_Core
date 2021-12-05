using Lesson3.Models;

namespace Lesson3.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IClickCommand? _command;
        private string? _description = "Click Me";
        private string? _name = "Click";
        private string? _text;

        public IClickCommand? Command
        {
            get
            {
                if (_command is null) _command = new ClickCommand(obj => ChangeText());
                return _command;
            }
        }

        public string? Description
        {
            get => _description;
            set => SetField(ref _description, value);
        }

        public string? Name 
        { 
            get => _name; 
            set => SetField(ref _name, value); 
        }

        public string Text 
        { 
            get => _text!; 
            set => SetField(ref _text, value); 
        }

        private void ChangeText() 
        { 
            Text = "Hello World";
            Name = "Chanel";
        }
    }
}
