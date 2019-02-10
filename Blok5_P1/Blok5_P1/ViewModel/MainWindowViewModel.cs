using Blok5_P1.Command.MainWindowViewCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok5_P1.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        public LogInCommand LogInCmd { get; set; }
        public EditProfileCommand EditProfileCmd { get; set; }
        public RegisterUserCommand RegisterUserCmd { get; set; }
        public LogOutCommand LogOutCmd { get; set; }
        public PhotosCommand PhotosCmd { get; set; }
        public AddPhotoCommand AddPhotoCmd { get; set; }
        //--------------------------------------------
        private string _switchView;

        public string SwitchView
        {
            get { return _switchView; }
            set
            {
                _switchView = value;
                OnPropertyChanged("SwitchView");
            }
        }

        public MainWindowViewModel()
        {
            SwitchView = "LogInView"; //pocetni view na LogInView

            LogInCmd = new LogInCommand(this);
            EditProfileCmd = new EditProfileCommand(this);
            RegisterUserCmd = new RegisterUserCommand(this);
            LogOutCmd = new LogOutCommand(this);
            PhotosCmd = new PhotosCommand(this);
            AddPhotoCmd = new AddPhotoCommand(this);
        }
    }
}
