using Blok5_P1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok5_P1.ViewModel
{
    public class PhotosViewModel : ObservableObject
    {
        private LoggedInUser _loggedInUser;
        private List<Photo> _photos = new List<Photo>();
        public PhotosViewModel()
        {
            _loggedInUser = LoggedInUser.getInstance();
        }

        public List<Photo> UserPhotos
        {
            get
            {
                //slike ulogovanog korisnika, ne smemo menjati, vec pravimo novu listu slika, koja ce biti ista
                //samo ce se razlikovati lokacije slike, gde cemo zbog prikazivanja na ekranu dodati lokaciju naseg SavedImages foldera
                //na taj nacin ovo resenje radi na svim racunarima, i sa bilo kojim putanjama
                _photos.Clear();
                foreach (Photo p in _loggedInUser.User.Photos)
                {
                    _photos.Add(new Photo
                    {
                        Description = p.Description,
                        Title = p.Title, Timestamp = p.Timestamp,
                        Location = Directory.GetCurrentDirectory() + Config.ImgFolderName + "\\" + p.Location
                    });
                }
                return _photos; //lista koja je bindovana na prikaz u PhotosView-u
            }
            set
            {
                _loggedInUser.User.Photos = value;
                OnPropertyChanged("UserPhotos");
            }
        }
    }
}
