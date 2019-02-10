using Blok5_P1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok5_P1.ViewModel
{
    public class PhotosViewModel : ObservableObject
    {
        private LoggedInUser _loggedInUser;
        public PhotosViewModel()
        {
            _loggedInUser = LoggedInUser.getInstance();
        }

        public List<Photo> UserPhotos
        {
            get { return _loggedInUser.User.Photos; }
            set
            {
                _loggedInUser.User.Photos = value;
                OnPropertyChanged("UserPhotos");
            }
        }
    }
}
