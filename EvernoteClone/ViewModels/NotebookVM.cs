using EvernoteClone.Models;
using EvernoteClone.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModels
{
    public class NotebookVM
    {

        public ObservableCollection<Notebook> Notebooks { get; set; }

        public ObservableCollection<Note> Notes { get; set; }

        public NewNotebookCommand newNotebookCommand { get; set; }
        public NewNoteCommand newNoteCommand { get; set; }

        private Note selectedNote;

        public Note SelectedNote
        {
            get { return selectedNote; }
            set { 
                selectedNote = value; 
            }
        }

        public NotebookVM()
        {
            newNotebookCommand = new NewNotebookCommand(this);
            newNoteCommand = new NewNoteCommand(this);
        }



        









    }
}
