using EvernoteClone.Abstraction;
using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands;
using SQLite;
using System;
using System.Collections.ObjectModel;

namespace EvernoteClone.ViewModel
{
    public class NotesVM : PropertyChangedBase
    {
        private bool isEditing;

        public bool IsEditing
        {
            get { return isEditing; }
            set { isEditing = value; OnPropertyChanged(); }
        }


        private Notebook selectedNotebook;
        public Notebook SelectedNotebook
        {
            get { return selectedNotebook; }
            set
            {
                selectedNotebook = value; //TODO get notes
                ReadNotes();
            }
        }

        private Note selectedNote;
        public Note SelectedNote
        {
            get { return selectedNote; }
            set
            {
                selectedNote = value; //TODO get notes
                SelectedNoteChanged?.Invoke(this, new EventArgs());
            }
        }

        public ObservableCollection<Notebook> Notebooks { get; set; }
        public ObservableCollection<Note> Notes { get; set; }

        public NewNotebookCommand NewNotebookCommand { get; set; }

        public NewNoteCommand NewNoteCommand { get; set; }
        public ExitCommand ExitCommand { get; set; }
        public BeginEditCommand BeginEditCommand { get; set; }
        public HasEditedCommand HasEditedCommand { get; set; }

        public event EventHandler SelectedNoteChanged;
        public NotesVM()
        {
            NewNotebookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);
            ExitCommand = new ExitCommand();
            BeginEditCommand = new BeginEditCommand(this);
            HasEditedCommand = new HasEditedCommand(this);
            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();

            ReadNotebooks();
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
            ReadNotes();
        }

        public void CreateNewNotebook()
        {
            Notebook notebook = new Notebook()
            {
                Name = "New notebook",
                Id = int.Parse(App.userID)
            };
            DatabaseHelper.Insert(notebook);
            Notebooks.Add(notebook);
        }

        public void ReadNotebooks()
        {
            using (SQLiteConnection conn = new SQLiteConnection(DatabaseHelper.dbFile))
            {
                var notebooks = conn.Table<Notebook>().ToList();

                Notebooks.Clear();
                foreach (var notebook in notebooks)
                {
                    Notebooks.Add(notebook);
                }
            }
        }

        public void ReadNotes()
        {
            if (SelectedNotebook == null) return;

            using (SQLiteConnection conn = new SQLiteConnection(DatabaseHelper.dbFile))
            {
                var notes = conn.Table<Note>().Where(n => n.NotebookId.Equals(SelectedNotebook.Id)).ToList();

                Notes.Clear();

                foreach (var note in notes)
                {
                    Notes.Add(note);
                }
            }
        }

        public void StartEdition()
        {
            IsEditing = true;
        }

        public void HasRenamed(Notebook notebook)
        {
            if (notebook != null)
            {
                DatabaseHelper.Update(notebook);
            }
            IsEditing = false;
        }

        public void UpdateSelectedNote()
        {
            DatabaseHelper.Update(SelectedNote);
        }
    }
}
