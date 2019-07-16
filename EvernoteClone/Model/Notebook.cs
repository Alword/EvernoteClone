using EvernoteClone.Abstraction;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.Model
{
    public class Notebook : PropertyChangedBase
    {
        private int id;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        private int userId;
        [Indexed]
        public int UserId
        {
            get { return userId; }
            set { userId = value; OnPropertyChanged(); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

    }
}
