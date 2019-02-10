using Blok5_P1.Command.RegisterViewCommand;
using Blok5_P1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok5_P1.ViewModel
{
    public class RegisterUserViewModel : ObservableObject
    {
        public TryRegisterCommand TryRegisterCmd { get; set; }
        //-------------------------------------------------------------
        private string _registerMessage;
        private User _user;
        public RegisterUserViewModel()
        {
            _user = new User();
            RegisterMessage = "";
            TryRegisterCmd = new TryRegisterCommand(this);
        }
        public string RegisterMessage
        {
            get { return _registerMessage; }
            set
            {
                _registerMessage = value;
                OnPropertyChanged("RegisterMessage");
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
