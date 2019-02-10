using Blok5_P1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok5_P1
{
    public class LoggedInUser
    {
        private static LoggedInUser _instance;
        private static object _syncLock = new object();
        public static LoggedInUser getInstance()
        {
            lock (_syncLock)
            {
                if (_instance == null)
                {
                    _instance = new LoggedInUser();
                }
            }
            return _instance;
        }
        public User User { get; set; } = null;

    }
}
