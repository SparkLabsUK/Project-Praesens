using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppViewer.Entities;
using System.Data;

namespace AppViewer.Audit
{
    public class UserAudit
    {
        private static AppViewer.Data.IRepository _repository = AppViewer.Data.RepositoryFactory.CreateInstance();

        public static void AddAudit(String AuditType)
        {
            //Entities.Security.User CurrentUser = new Entities.Security.User();
            //AppViewer.Entities.Audit.AuditUser NewAudit = new Entities.Audit.AuditUser();
            //CurrentUser = Security.User.GetLoggedInUser();
            //switch (AuditType)
            //{
            //    case "ChangedPassword":
            //         NewAudit.UserID = CurrentUser.UserID;

            //        NewAudit.AuditType = Entities.Audit.Enums.AuditType.Login;
            //        NewAudit.Description = "User: " + CurrentUser.Username + " (ID: " + CurrentUser.UserID + ") has changed their password.";
            //        break;
            //    case "ChangedDetails":
            //        NewAudit.UserID = CurrentUser.UserID;

            //        NewAudit.AuditType = Entities.Audit.Enums.AuditType.Login;
            //        NewAudit.Description = "User: " + CurrentUser.Username + " (ID: " + CurrentUser.UserID + ") has changed their details.";
            //        break;
            //}
            //_repository.AddUserAudit(NewAudit);
        }
        public static AppViewer.Entities.Audit.AuditUser GetAudit(Guid AuditID)
        {
            return _repository.GetUserAudit(AuditID);
        }
        public static DataTable GetAudits()
        {
            return _repository.GetUserAudits();
        }

    }
}
