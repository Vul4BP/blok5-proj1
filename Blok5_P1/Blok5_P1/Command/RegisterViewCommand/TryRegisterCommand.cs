using Blok5_P1.Model;
using Blok5_P1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Blok5_P1.Command.RegisterViewCommand
{
    public class TryRegisterCommand : ICommand
    {
        private RegisterUserViewModel _registerViewModel;
        private LoggedInUser _loggedInUser;
        private ListFromXml _usersList;
        public TryRegisterCommand(RegisterUserViewModel registerViewModel)
        {
            _registerViewModel = registerViewModel;
            _loggedInUser = LoggedInUser.getInstance();
            _usersList = ListFromXml.getInstance();
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                PasswordBox ps = (PasswordBox)parameter;
                string password = ps.Password;
                User u = _usersList.Users.Find(x => x.Username == _registerViewModel.Username);
                if (u != null)
                {
                    _registerViewModel.RegisterMessage = "Username exists.";
                    return;
                }
                else
                {
                    if(_registerViewModel.Username.Length == 0)
                    {
                        _registerViewModel.RegisterMessage = "Username can't be empty.";
                        return;
                    }
                    if(_registerViewModel.Username[0] >= 48 && _registerViewModel.Username[0] <= 57)
                    {
                        _registerViewModel.RegisterMessage = "Username can't start with number.";
                        return;
                    }
                    if(password.Length <= 6)
                    {
                        _registerViewModel.RegisterMessage = "Password must have more than 6 characters.";
                        return;
                    }
                }

                User newUser = new User();
                newUser.Username = _registerViewModel.Username;
                newUser.Password = password;
                newUser.Photos = new List<Photo>();
                _loggedInUser.User = newUser;
                _registerViewModel.RegisterMessage = "";
                _usersList.Users.Add(newUser);
                _usersList.SaveToXml();
            }
            catch (Exception e)
            {
                _registerViewModel.RegisterMessage = "Some error occured!";
            }

        }
    }
}
