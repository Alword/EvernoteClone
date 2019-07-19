using EvernoteClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class RegisterCommand : ICommand
    {
        public LoginVM VM { get; set; }
        public event EventHandler CanExecuteChanged;

        public RegisterCommand(LoginVM vm)
        {
            this.VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            //User user = parameter as User;
            //if (user is null)
            //    return false;
            //if (string.IsNullOrEmpty(user.Name))
            //    return false;
            //if (string.IsNullOrEmpty(user.Password))
            //    return false;
            //if (string.IsNullOrEmpty(user.Email))
            //    return false;
            //if (string.IsNullOrEmpty(user.LastName))
            //    return false;

            return true;
        }

        public void Execute(object parameter)
        {
            VM.Register();
        }
    }
}
