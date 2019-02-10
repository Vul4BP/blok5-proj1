using Blok5_P1.Command.EditProfileViewCommand;
using Blok5_P1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok5_P1.ViewModel
{
    public class EditProfileViewModel : ObservableObject
    {
        public TryEditProfileCommand TryEditProfileCmd { get; set; }
        //-------------------------------------------------------------
        private string _message;
        private User _user;
        public EditProfileViewModel()
        {
            _user = new User();
            Message = "";
            Username = "";
            Password = "";
            TryEditProfileCmd = new TryEditProfileCommand(this);
        }
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
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
