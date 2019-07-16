using EvernoteClone.Abstraction;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.Model
{
    public class User : PropertyChangedBase
    {
        private int  id;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        private string name;
        [MaxLength(50)]
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private string lastName;

        [MaxLength(50)]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged(); }
        }


        private string username;

        public string UserNameme
        {
            get { return username; }
            set { username = value; OnPropertyChanged(); }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(); }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }

    }
}
