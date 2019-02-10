using Blok5_P1.Model;
using Blok5_P1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Blok5_P1.Command.EditProfileViewCommand
{
    public class TryEditProfileCommand : ICommand
    {
        private EditProfileViewModel _editProfileViewModel;
        private LoggedInUser _loggedInUser;
        private ListFromXml _usersList;
        public TryEditProfileCommand(EditProfileViewModel editProfileViewModel)
        {
            _editProfileViewModel = editProfileViewModel;
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
                User currentUser = _loggedInUser.User;
                User u = _usersList.Users.Find(x => x.Username == _editProfileViewModel.Username);
                
                if(u == null || u.Username == currentUser.Username)
                {
                    if (_editProfileViewModel.Username.Length == 0)
                    {
                        _editProfileViewModel.Message = "Username can't be empty.";
                        return;
                    }
                    if (_editProfileViewModel.Username[0] >= 48 && _editProfileViewModel.Username[0] <= 57)
                    {
                        _editProfileViewModel.Message = "Username can't start with number.";
                        return;
                    }
                    if (_editProfileViewModel.Password.Length <= 6)
                    {
                        _editProfileViewModel.Message = "Password must have more than 6 characters.";
                        return;
                    }
                }
                else
                {
                    _editProfileViewModel.Message = "Username exists.";
                    return;
                }

                currentUser.Username = _editProfileViewModel.Username;
                currentUser.Password = _editProfileViewModel.Password;
                _editProfileViewModel.Message = "";
                _editProfileViewModel.Password = "";
                _editProfileViewModel.Username = "";
                _usersList.SaveToXml();
            }
            catch (Exception e)
            {
                _editProfileViewModel.Message = "Some error occured!";
            }
        }
    }
}
