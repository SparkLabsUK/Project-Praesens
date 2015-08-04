using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViewer.Business
{
    public static class App
    {
        private static AppViewer.Data.IRepository _repository = AppViewer.Data.RepositoryFactory.CreateInstance();

        public static void AddApp(AppViewer.Entities.App app)
        {
            app = _repository.AddApp(app, Security.User.GetLoggedInUser());
            AppViewer.Audit.AppAudit.AddAudit(Entities.Audit.Enums.AuditType.AppInsert, app, Security.User.GetLoggedInUser());
        }

        public static AppViewer.Entities.AppWizard AddAppWizard(AppViewer.Entities.AppWizard appWizard)
        {
            appWizard = _repository.AddAppWizard(appWizard, Security.User.GetLoggedInUser());

            //AppViewer.Audit.AppAudit.AddAudit(Entities.Audit.Enums.AuditType.AppInsert, app, Security.User.GetLoggedInUser());
            return appWizard;
        }

        public static AppViewer.Entities.App GetApp(int AppID)
        {
            return _repository.GetApp(AppID);
        }
        
        public static AppViewer.Entities.App GetApp(string URL)
        {
            return _repository.GetAppByURL(URL);
        }

        public static void DeleteApp(AppViewer.Entities.App app)
        {
            Audit.AppAudit.AddAudit(Entities.Audit.Enums.AuditType.AppDelete, app, Security.User.GetLoggedInUser());
            _repository.DeleteApp(app);
        }

        public static void SaveApp(AppViewer.Entities.App app)
        {
            Audit.AppAudit.AddAudit(Entities.Audit.Enums.AuditType.AppUpdate, app, Security.User.GetLoggedInUser());
            _repository.SaveApp(app);
        }

        public static List<AppViewer.Entities.App> GetApps()
        {
            return _repository.GetApps();
        }

        public static List<AppViewer.Entities.AppType> GetAppTypes()
        {
            return _repository.GetAppTypes();
        }


        public static List<Entities.App> GetAppsForUser()
        {
            return _repository.GetAppsForUser(Security.User.GetLoggedInUser());
        }
      
        public static List<AppViewer.Entities.App> GetActiveApps()
        {
            return _repository.GetActiveApps();
        }

        public static Entities.App GetAppWithPages(string URL) 
        {
            Entities.App app = GetApp(URL);
            if (app != new Entities.App())
            {
                app.Pages = Business.Page.GetPages(app);
            }
            return app;
        }

        public static void SetThumbPage(Entities.App app)
        {
            _repository.SetThumbPage(app);
        }

        public static void SetFirstPage(Entities.App app)
        {
            _repository.SetFirstPage(app);
        }
    }
}
