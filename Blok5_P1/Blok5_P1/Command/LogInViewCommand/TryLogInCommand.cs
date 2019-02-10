using Blok5_P1.Model;
using Blok5_P1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Blok5_P1.Command.LogInViewCommand
{
    public class TryLogInCommand : ICommand
    {
        private LogInViewModel _logInViewModel;
        private LoggedInUser _loggedInUser;
        private ListFromXml _usersList;
        public TryLogInCommand(LogInViewModel logInViewModel)
        {
            _logInViewModel = logInViewModel;
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
                //-------------------------------------------------------

                if (_logInViewModel.Username.Length == 0)
                {
                    _logInViewModel.LoginMessage = "Username can't be empty.";
                    return;
                }

                User u = _usersList.Users.Find(x => x.Username == _logInViewModel.Username);
                
                //-------------------------------------------------------
                if (u != null)
                {
                    if (u.Password == password)
                    {
                        _loggedInUser.User = u;
                        _logInViewModel.LoginMessage = "";
                        return;
                    }
                    else
                    {
                        _logInViewModel.LoginMessage = "Incorect Password.";
                        return;
                    }
                }
                else
                {
                    _logInViewModel.LoginMessage = "Username doesn't exist.";
                    return;
                }
            }
            catch (Exception e)
            {
                _logInViewModel.LoginMessage = "Some error occured!";
            }

        }
    }
}
