using Blok5_P1.Command.AddPhotoViewCommand;
using Blok5_P1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok5_P1.ViewModel
{
    public class AddPhotoViewModel : ObservableObject
    {
        public TryLoadPhotoCommand TryLoadPhotoCmd { get; set; }
        public TryAddPhotoCommand TryAddPhotoCmd { get; set; }
        //-------------------------------------------------------------
        private string _message;
        private string _title;
        private string _description;
        private string _imgPath;
        public AddPhotoViewModel()
        {
            Message = "";
            Title = "";
            Description = "";
            ImagePath = Directory.GetCurrentDirectory() + Config.EmptyImagePath;
            TryLoadPhotoCmd = new TryLoadPhotoCommand(this);
            TryAddPhotoCmd = new TryAddPhotoCommand(this);
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
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public string ImagePath
        {
            get { return _imgPath; }
            set
            {
                _imgPath = value;
                OnPropertyChanged("ImagePath");
            }
        }
    }
}
