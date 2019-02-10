using Blok5_P1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok5_P1.Command.MainWindowViewCommand
{
    public class LogInCommand : SwitchViewCommand
    {
        public LogInCommand(MainWindowViewModel mainWindowViewModel) : base(mainWindowViewModel) { }
        public override bool CanExecute(object parameter)
        {
            if (_loggedInUser.User == null)
                return true;

            if (_mainWindowViewModel.SwitchView == "LogInView")
                _mainWindowViewModel.SwitchView = "PhotosView"; //na PhotosView

            return false;
        }
    }
}
