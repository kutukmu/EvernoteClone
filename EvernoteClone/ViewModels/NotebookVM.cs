using EvernoteClone.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModels
{
    class NotebookVM
    {

        public ObservableCollection<Notebook> Notebooks { get; set; }

        private Note selectedNote;

        public Note SelectedNote
        {
            get { return selectedNote; }
            set { 
                selectedNote = value; 
            }
        }

        public ObservableCollection<Note> Notes { get; set; }









    }
}
