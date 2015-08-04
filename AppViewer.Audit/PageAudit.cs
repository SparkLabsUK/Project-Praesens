using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppViewer.Entities;
using System.Data;

namespace AppViewer.Audit
{
    public class PageAudit
    {
        private static AppViewer.Data.IRepository _repository = AppViewer.Data.RepositoryFactory.CreateInstance();

        public static void AddAudit(Entities.Audit.Enums.AuditType auditType, AppViewer.Entities.Page page, Entities.Security.User currentUser)
        {
            AppViewer.Entities.Audit.AuditPage audit = new Entities.Audit.AuditPage();

            audit.AuditType = auditType;
            audit.UserID = currentUser.UserID;
            audit.PageID = page.PageID;

            switch (auditType)
            {
                case AppViewer.Entities.Audit.Enums.AuditType.PageInsert:
                    audit.AppID = page.AppID;
                    audit.Description = String.Format("Page Created: {0}", page.Name);
                    break;
                case AppViewer.Entities.Audit.Enums.AuditType.PageUpdate:
                    AppViewer.Entities.Page oldPage = _repository.GetPage(page.PageID);
                    audit.AppID = oldPage.AppID;
                    audit.Description = String.Format("Page Updated: {0}Name: {1}{0}Page Notes: {2}", Environment.NewLine, oldPage.Name, oldPage.PageNotes);
                    oldPage = null;
                    break;
                case AppViewer.Entities.Audit.Enums.AuditType.PageDelete:
                    AppViewer.Entities.Page deletedPage = _repository.GetPage(page.PageID);
                    audit.AppID = deletedPage.AppID;
                    audit.Description = String.Format("Page Deleted: {0}Name: {1}{0}Page Notes: {2}", Environment.NewLine, deletedPage.Name, deletedPage.PageNotes);
                    deletedPage = null;
                    break;
                default:
                    break;
            }

            _repository.AddPageAudit(audit);

        }

        public static AppViewer.Entities.Audit.AuditPage GetAudit(Guid auditID)
        {
            return _repository.GetPageAudit(auditID);
        }
        public static DataTable GetAuditPageForPage(int pageID)
        {
            return _repository.GetAuditPageForPage(pageID);
        }
        public static DataTable GetAudits()
        {
            return _repository.GetPageAudits();
        }

    }
}
