using Blok5_P1.Model;
using Blok5_P1.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Blok5_P1.Command.AddPhotoViewCommand
{
    public class TryAddPhotoCommand : ICommand
    {
        private AddPhotoViewModel _addPhotoViewModel;
        private LoggedInUser _loggedInUser;
        private ListFromXml _usersList;
        public TryAddPhotoCommand(AddPhotoViewModel addPhotoViewModel)
        {
            _addPhotoViewModel = addPhotoViewModel;
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
                string emptyImagePath =Directory.GetCurrentDirectory() + Config.EmptyImagePath;

                if (_addPhotoViewModel.ImagePath == emptyImagePath)
                {
                    _addPhotoViewModel.Message = "Image can't be empty.";
                    return;
                }
                if (_addPhotoViewModel.Title.Length == 0)
                {
                    _addPhotoViewModel.Message = "Image title can't be empty.";
                    return;
                }

                Photo photo = new Photo();
                photo.Location = _addPhotoViewModel.ImagePath;
                photo.Title = _addPhotoViewModel.Title;
                photo.Description = _addPhotoViewModel.Description;
                photo.Timestamp = DateTime.Now.ToString();
                _loggedInUser.User.Photos.Add(photo);
                _usersList.SaveToXml();

                _addPhotoViewModel.Message = "";
                _addPhotoViewModel.Description = "";
                _addPhotoViewModel.ImagePath = Directory.GetCurrentDirectory() + Config.EmptyImagePath;
                _addPhotoViewModel.Title = "";
            }
            catch (Exception e)
            {
                _addPhotoViewModel.Message = "Some error occured!";
            }

        }
    }
}
