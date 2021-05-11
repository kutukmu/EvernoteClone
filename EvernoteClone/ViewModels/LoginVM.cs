using EvernoteClone.Models;
using EvernoteClone.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModels
{
    class LoginVM
    {
        private User user;
        public LoginCommand LoginCommand { get; set; }
        public RegisterCommand RegisterCommand { get; set; }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public LoginVM()
        {
            LoginCommand = new LoginCommand(this);
            RegisterCommand = new RegisterCommand(this);
        }



    }
}
