using EvernoteClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        public LoginVM VM { get; set; }

        public event EventHandler CanExecuteChanged;

        public LoginCommand(LoginVM vm)
        {
            this.VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            User user = parameter as User;
            
            return !(user.Equals(null) || string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Password));
        }

        public void Execute(object parameter)
        {
            VM.Login();
        }
    }
}
