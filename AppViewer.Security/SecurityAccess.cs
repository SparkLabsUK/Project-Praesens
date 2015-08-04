using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppViewer;

namespace AppViewer.Security
{
    public static class SecurityAccess
    {
        private static AppViewer.Data.IRepository _repository = AppViewer.Data.RepositoryFactory.CreateInstance();

        public static AppViewer.Entities.Security.Enums.AccessType GetSecurityAccessForUserForApp(Entities.App app)
        {
            return _repository.GetSecurityAccessForUserForApp(app, Security.User.GetLoggedInUser());
        }
    }
}
