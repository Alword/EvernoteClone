using EvernoteClone.Abstraction;
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

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        private int userId;

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
