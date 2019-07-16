using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.Model
{
    public class Note
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int notebookId;

        public int NotebookId
        {
            get { return notebookId; }
            set { notebookId = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private DateTime createdTime;

        public DateTime CreatedTime
        {
            get { return createdTime; }
            set { createdTime = value; }
        }

        private DateTime updatedTime;

        public DateTime UpdatedTime
        {
            get { return updatedTime; }
            set { updatedTime = value; }
        }

        private string fileLocation;

        public string FileLocation
        {
            get { return fileLocation; }
            set { fileLocation = value; }
        }


    }
}
