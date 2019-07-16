using EvernoteClone.Abstraction;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.Model
{
    public class Note : PropertyChangedBase
    {
        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        private int notebookId;
        [Indexed]
        public int NotebookId
        {
            get { return notebookId; }
            set { notebookId = value; OnPropertyChanged(); }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        private DateTime createdTime;

        public DateTime CreatedTime
        {
            get { return createdTime; }
            set { createdTime = value; OnPropertyChanged(); }
        }

        private DateTime updatedTime;

        public DateTime UpdatedTime
        {
            get { return updatedTime; }
            set { updatedTime = value; OnPropertyChanged(); }
        }

        private string fileLocation;

        public string FileLocation
        {
            get { return fileLocation; }
            set { fileLocation = value; OnPropertyChanged(); }
        }

    }
}
