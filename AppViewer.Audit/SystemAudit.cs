using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppViewer.Entities;
using System.Data;

namespace AppViewer.Audit
{
    public class SystemAudit
    {
        private static AppViewer.Data.IRepository _repository = AppViewer.Data.RepositoryFactory.CreateInstance();

        public static void AddAudit(Entities.Audit.Enums.AuditType auditType, AppViewer.Entities.Security.User user)
        {
            AppViewer.Entities.Audit.AuditSystem audit = new Entities.Audit.AuditSystem();

            audit.AuditType = auditType;

            switch (auditType)
            {
                case AppViewer.Entities.Audit.Enums.AuditType.LoginFailed:
                    audit.Description = String.Format("Username: {0}", user.Username);
                    audit.UserID = Guid.Empty;
                    break;
                case AppViewer.Entities.Audit.Enums.AuditType.LoginPassed:
                    audit.Description = String.Format("{0} has logged in.", user.Username );
                    audit.UserID = user.UserID;
                    break;
                case AppViewer.Entities.Audit.Enums.AuditType.Logout:
                    audit.Description = String.Format("{0} has logged out.", user.Username);
                    audit.UserID = user.UserID;
                    break;
                default:
                    break;
            }

            _repository.AddSystemAudit(audit);

        }

        public static AppViewer.Entities.Audit.AuditSystem GetAudit(Guid AuditID)
        {
            return _repository.GetSystemAudit(AuditID);
        }
        public static DataTable GetAudits()
        {
            return _repository.GetSystemAudits();
        }

    }
}
