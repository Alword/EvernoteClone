using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class BeginEditCommand : ICommand
    {
        public NotesVM vM { get; set; }

        public event EventHandler CanExecuteChanged;
        public BeginEditCommand(NotesVM vM)
        {
            this.vM = vM;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            vM.StartEdition();
        }
    }
}
