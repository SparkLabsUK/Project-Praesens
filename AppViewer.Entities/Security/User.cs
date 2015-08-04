using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViewer.Entities.Security
{
    [Serializable]
    public class User
    {
        public Guid UserID { get; set; }
        public Enums.UserType UserType { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public DateTime LastLogon { get; set; }
        public int FailedLogins { get; set; }
        public DateTime? LockTime { get; set; }
        public AppViewer.Entities.Enums.LoginResult LoginResult { get; set; }

        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", Forename, Surname);
            }
        }

    }
}
