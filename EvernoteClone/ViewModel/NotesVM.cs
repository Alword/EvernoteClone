using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands;
using System;
using System.Collections.ObjectModel;

namespace EvernoteClone.ViewModel
{
    public class NotesVM
    {
        public Notebook SelectedNotebook
        {
            get { return selectedNotebook; }
            set
            {
                selectedNotebook = value; //TODO get notes
            }
        }
        private Notebook selectedNotebook;
        public ObservableCollection<Notebook> Notebooks { get; set; }
        public ObservableCollection<Note> Notes { get; set; }

        public NewNotebookCommand NewNotebookCommand { get; set; }

        public NewNoteCommand NewNoteCommand { get; set; }
        public ExitCommand ExitCommand { get; set; }

        public NotesVM()
        {
            NewNotebookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);
            ExitCommand = new ExitCommand();
        }

        public void CreateNewNote(int notebookId)
        {
            Note note = new Note()
            {
                NotebookId = notebookId,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                Title = "New note"
            };

            DatabaseHelper.Insert(note);
        }

        public void CreateNewNotebook()
        {
            Notebook notebook = new Notebook()
            {
                Name = "New notebook"
            };
            DatabaseHelper.Insert(notebook);
        }
    }
}
