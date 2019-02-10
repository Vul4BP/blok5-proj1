using Blok5_P1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Blok5_P1.Command.MainWindowViewCommand
{
    public abstract class SwitchViewCommand : ICommand
    {
        protected MainWindowViewModel _mainWindowViewModel;
        protected LoggedInUser _loggedInUser;

        public SwitchViewCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _loggedInUser = LoggedInUser.getInstance();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public abstract bool CanExecute(object parameter);
        public void Execute(object parameter)
        {
            if ((string)parameter == "LogOutView")
            {
                //LOGOUT
                _loggedInUser.User = null;
                _mainWindowViewModel.SwitchView = "LogInView"; //prebaci na logIn view
                return;
            }
            _mainWindowViewModel.SwitchView = (string)parameter;
        }
    }
}
