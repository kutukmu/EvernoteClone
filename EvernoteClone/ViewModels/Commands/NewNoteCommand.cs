using EvernoteClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModels.Commands
{
    public class NewNoteCommand : ICommand
    {
        public NotebookVM Vm { get; set; }

        public NewNoteCommand(NotebookVM vm)
        {
            Vm = vm;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var selectednotebook = parameter as Notebook;
            if(selectednotebook != null)
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            Notebook selectedNotebook = parameter as Notebook;
            Vm.CreateNewNote(selectedNotebook.Id);
            
        }
    }
}
