﻿using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModel
{
    public class LoginVM
    {
        private User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public RegisterCommand RegisterCommand { get; set; }
        public LoginCommand LoginCommand { get; set; }

        public LoginVM()
        {
            RegisterCommand = new RegisterCommand(this);
            LoginCommand = new LoginCommand(this);
        }

        public void Login()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                conn.CreateTable<User>();
                User user = conn.Table<User>().Where(u => u.Username == User.Username).FirstOrDefault();

                if (user.Password == User.Password)
                {
                    // TODO: Login
                }
            }
        }

        public void Register()
        {
            var result = DatabaseHelper.Insert(User);
            if (result)
            {
                // TODO: establish server
            }
        }
    }
}
