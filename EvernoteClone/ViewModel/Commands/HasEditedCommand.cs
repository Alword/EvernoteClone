using EvernoteClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class HasEditedCommand : ICommand
    {
        public NotesVM vM { get; set; }

        public event EventHandler CanExecuteChanged;
        public HasEditedCommand(NotesVM vM)
        {
            this.vM = vM;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Notebook notebook = (Notebook)parameter;
            vM.HasRenamed(notebook);
        }
    }
}
