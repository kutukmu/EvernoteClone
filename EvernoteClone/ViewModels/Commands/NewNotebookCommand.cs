using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModels.Commands
{
    public class NewNotebookCommand : ICommand
    {
        public NotebookVM Vm { get; set; }

        public NewNotebookCommand(NotebookVM vm)
        {
            Vm = vm;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Vm.CreateNoteBook();
        }
    }
}
