using EvernoteClone.Models;
using EvernoteClone.ViewModels.Commands;
using EvernoteClone.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModels
{
    public class NotebookVM:INotifyPropertyChanged
    {

        public ObservableCollection<Notebook> Notebooks { get; set; }

        public ObservableCollection<Note> Notes { get; set; }

        public NewNotebookCommand newNotebookCommand { get; set; }
        public NewNoteCommand newNoteCommand { get; set; }

        private Notebook selectedNotebook;

        

        public Notebook SelectedNotebook
        {
            get { return selectedNotebook; }
            set {
                selectedNotebook = value;

                GetNotes();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public NotebookVM()
        {
            newNotebookCommand = new NewNotebookCommand(this);
            newNoteCommand = new NewNoteCommand(this);
            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();

            GetNoteBooks();
        }


        public void CreateNoteBook()
        {
            Notebook newNotebook = new Notebook()
            {
                Name = "First notebook",
            };

            Notebooks.Add(newNotebook);

            DatabaseHelper.AddItem<Notebook>(newNotebook);
        }

        public void CreateNewNote(int id)
        {
            Note newNote = new Note()
            {
                NotebookId = id,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Title = "New Note"
            };

            DatabaseHelper.AddItem<Note>(newNote);
        }

        private void GetNoteBooks()
        {
            var notebooks = DatabaseHelper.GetItems<Notebook>();

            Notebooks.Clear();
            foreach(var notebook in notebooks)
            {
                Notebooks.Add(notebook);
            }


        }

        private void GetNotes()
        {
            if(selectedNotebook != null)
            {
                var notes = DatabaseHelper.GetItems<Note>().Where(item => item.NotebookId == selectedNotebook.Id);

                Notes.Clear();
                foreach (var note in notes)
                {
                    Notes.Add(note);
                }
            }
            


        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }













    }
}
