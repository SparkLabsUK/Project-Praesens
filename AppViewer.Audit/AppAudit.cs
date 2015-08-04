using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppViewer.Entities;
using System.Data;

namespace AppViewer.Audit
{
    public class AppAudit
    {
        private static AppViewer.Data.IRepository _repository = AppViewer.Data.RepositoryFactory.CreateInstance();

        public static void AddAudit(Entities.Audit.Enums.AuditType auditType, AppViewer.Entities.App app, Entities.Security.User currentUser)
        {
            AppViewer.Entities.Audit.AuditApp audit = new Entities.Audit.AuditApp();

            audit.AuditType = auditType;
            audit.UserID = currentUser.UserID;
            audit.AppID = app.AppID;

            switch (auditType)
            {
                case AppViewer.Entities.Audit.Enums.AuditType.AppInsert:
                    audit.Description = String.Format("App Created: {0}", app.Name);
                    break;
                case AppViewer.Entities.Audit.Enums.AuditType.AppUpdate:
                    AppViewer.Entities.App oldApp = _repository.GetApp(app.AppID);
                    audit.Description = string.Format("App Updated: {0}Name: {1}{0}Description: {2}{0}URL: {3}", Environment.NewLine, oldApp.Name, oldApp.Description, oldApp.URL);
                    oldApp = null;
                    break;
                case AppViewer.Entities.Audit.Enums.AuditType.AppDelete:
                    AppViewer.Entities.App deletedApp = _repository.GetApp(app.AppID);
                    audit.Description = string.Format("App Deleted: {0}Name: {1}{0}Description: {2}{0}URL: {3}", Environment.NewLine, deletedApp.Name, deletedApp.Description, deletedApp.URL);
                    deletedApp = null;
                    break;
                default:
                    break;
            }

            _repository.AddAppAudit(audit);

        }
        public static AppViewer.Entities.Audit.AuditApp GetAudit(Guid AuditID)
        {
            return _repository.GetAppAudit(AuditID);
        }
        public static DataTable GetAudits()
        {
            return _repository.GetAppAudits();
        }
        public static DataTable GetAuditAppForApp(int appID)
        {
            return _repository.GetAuditAppForApp(appID);
        }

    }
}
