using Blok5_P1.Command.LogInViewCommand;
using Blok5_P1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok5_P1.ViewModel
{
    public class LogInViewModel : ObservableObject
    {
        public TryLogInCommand TryLogInCmd { get; set; }
        //-------------------------------------------------------------
        private string _loginMessage;
        private User _user;
        public LogInViewModel()
        {
            _user = new User();
            LoginMessage = "";
            TryLogInCmd = new TryLogInCommand(this);
        }
        public string LoginMessage
        {
            get { return _loginMessage; }
            set
            {
                _loginMessage = value;
                OnPropertyChanged("LoginMessage");
            }
        }
        public string Username
        {
            get { return _user.Username; }
            set
            {
                _user.Username = value;
                OnPropertyChanged("Username");
            }
        }
        public string Password
        {
            get { return _user.Password; }
            set
            {
                _user.Password = value;
                OnPropertyChanged("Password");
            }
        }
    }
}
