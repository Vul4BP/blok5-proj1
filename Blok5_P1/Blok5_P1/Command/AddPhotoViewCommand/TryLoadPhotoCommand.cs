using Blok5_P1.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Blok5_P1.Command.AddPhotoViewCommand
{
    public class TryLoadPhotoCommand : ICommand
    {
        private AddPhotoViewModel _addPhotoViewModel;
        private LoggedInUser _loggedInUser;
        public TryLoadPhotoCommand(AddPhotoViewModel addPhotoViewModel)
        {
            _addPhotoViewModel = addPhotoViewModel;
            _loggedInUser = LoggedInUser.getInstance();
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
                OpenFileDialog dlg = new OpenFileDialog();

                dlg.Title = "Open Image";
                dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _addPhotoViewModel.ImagePath = dlg.FileName;
                }
                
                dlg.Dispose();
            }
            catch (Exception e)
            {
                _addPhotoViewModel.Message = "Some error occured!";
                _addPhotoViewModel.ImagePath = Directory.GetCurrentDirectory() + Config.EmptyImagePath;
            }

        }
    }
}
