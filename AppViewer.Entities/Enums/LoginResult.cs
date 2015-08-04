using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViewer.Entities.Enums
{
    public enum LoginResult
    {
        LoginPassed = 1,
        UsernameNotFound = -1,
        InvalidPassword = -2,
        AccountLocked = -3,
        LoginFailed = 0
    }
}
