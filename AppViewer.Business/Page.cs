using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViewer.Business
{
    public static class Page
    {
        private static AppViewer.Data.IRepository _repository = AppViewer.Data.RepositoryFactory.CreateInstance();

        public static Entities.Page Add(AppViewer.Entities.Page page)
        {
            page = _repository.Add(page);
            Audit.PageAudit.AddAudit(Entities.Audit.Enums.AuditType.PageInsert, page, Security.User.GetLoggedInUser());
            return page;
        }

        public static AppViewer.Entities.Page UpdatePage(AppViewer.Entities.Page page)
        {
            Audit.PageAudit.AddAudit(Entities.Audit.Enums.AuditType.PageUpdate, page, Security.User.GetLoggedInUser());
            return _repository.UpdatePage(page);
        }

        public static AppViewer.Entities.Page UpdatePageNotes(AppViewer.Entities.Page page)
        {
            return _repository.UpdatePageNotes(page);
        }

        public static AppViewer.Entities.Page GetPage(int pageID)
        {
            return _repository.GetPage(pageID);
        }

        public static List<AppViewer.Entities.Page> GetPages(Entities.App app)
        {
            return _repository.GetPages(app);
        }

        public static AppViewer.Entities.Page GetPageImage(int pageID, AppViewer.Entities.Enums.ImageSize size)
        {
            return _repository.GetPageImage(pageID, size);
        }

        public static void Delete(Entities.Page page)
        {
            Audit.PageAudit.AddAudit(Entities.Audit.Enums.AuditType.PageDelete, page, Security.User.GetLoggedInUser());
            _repository.DeletePage(page);
        }
    }
}

