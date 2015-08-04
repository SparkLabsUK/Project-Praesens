using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace AppViewer.Security
{
    public static class User
    {
        private static AppViewer.Data.IRepository _repository = AppViewer.Data.RepositoryFactory.CreateInstance();

        public static void Add(Entities.Security.User user)
        {
            _repository.Add(user);
        }

        public static Entities.Security.User GetUser(Guid userID)
        {
            return _repository.GetUser(userID);
        }

        public static List<Entities.Security.User> GetUsers()
        {
            return _repository.GetUsers();
        }

        public static AppViewer.Entities.Enums.LoginResult Login(Entities.Security.User user)
        {
            user = _repository.Login(user);

            switch (user.LoginResult)
            {
                case AppViewer.Entities.Enums.LoginResult.LoginPassed:
                    HttpContext.Current.Session["User"] = user;
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    AppViewer.Audit.SystemAudit.AddAudit(Entities.Audit.Enums.AuditType.LoginPassed, user);
                    break;
                case AppViewer.Entities.Enums.LoginResult.UsernameNotFound:
                case AppViewer.Entities.Enums.LoginResult.InvalidPassword:
                case AppViewer.Entities.Enums.LoginResult.AccountLocked:
                case AppViewer.Entities.Enums.LoginResult.LoginFailed:
                    AppViewer.Audit.SystemAudit.AddAudit(Entities.Audit.Enums.AuditType.LoginFailed, user);
                    break;
                default:
                    break;
            }


            return user.LoginResult;

        }

        public static Entities.Security.User GetLoggedInUser()
        {
            Entities.Security.User user = new Entities.Security.User();
            if (HttpContext.Current.Session["User"] != null)
            {
                user = (Entities.Security.User)HttpContext.Current.Session["User"];
            }
            return user;

        }
       
        public static Entities.Security.User UpdateUser(Entities.Security.User user)
        {
            _repository.UpdateUser(user);
            return user;

        }
        
        public static Entities.Security.User DeleteUser(Entities.Security.User user)
        {
            _repository.DeleteUser(user);
            return user;

        }
       
        public static bool ResetPassword(Entities.Security.User user)
        {
           return _repository.ResetPassword(user);

        }
    }
}

