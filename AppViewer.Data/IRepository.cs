using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AppViewer.Data
{
    public interface IRepository
    {
        # region App

        Entities.App AddApp(Entities.App app, Entities.Security.User user);

        Entities.AppWizard AddAppWizard(Entities.AppWizard app, Entities.Security.User user);

        void DeleteApp(Entities.App app);

        void SaveApp(Entities.App app);

        AppViewer.Entities.App GetApp(int AppID);

        List<Entities.AppType> GetAppTypes();

        Entities.App GetAppByURL(string URL);

        List<AppViewer.Entities.App> GetApps();

        List<Entities.App> GetAppsForUser(Entities.Security.User user);
        
        List<AppViewer.Entities.App> GetActiveApps();

        void SetThumbPage(Entities.App app);

        void SetFirstPage(Entities.App app);

        #endregion

        #region All Audits
        DataTable GetTop30Audits();
        int GetAppCount();
        int GetPageCount();
        int GetUserCount();
        int GetLinkCount();
        #endregion

        # region App Audits

        void AddAppAudit(AppViewer.Entities.Audit.AuditApp audit);

        AppViewer.Entities.Audit.AuditApp GetAppAudit(Guid auditID);

        DataTable GetAppAudits();

        DataTable GetAuditAppForApp(int appID);

        #endregion

        # region Page Audits

        void AddPageAudit(AppViewer.Entities.Audit.AuditPage audit);

        AppViewer.Entities.Audit.AuditPage GetPageAudit(Guid auditID);

        DataTable GetPageAudits();

        DataTable GetAuditPageForPage(int pageID);

        #endregion

        # region System Audits

        void AddSystemAudit(AppViewer.Entities.Audit.AuditSystem audit);

        AppViewer.Entities.Audit.AuditSystem GetSystemAudit(Guid auditID);

        DataTable GetSystemAudits();

        #endregion

        # region User Audits

        void AddUserAudit(AppViewer.Entities.Audit.AuditUser audit);

        AppViewer.Entities.Audit.AuditUser GetUserAudit(Guid auditID);

        DataTable GetUserAudits();

        #endregion

        #region Demo

        #endregion

        # region Link

        void AddLink(AppViewer.Entities.Link link);

        void SaveLink(AppViewer.Entities.Link link);

        void DeleteLink(AppViewer.Entities.Link link);

        AppViewer.Entities.Link GetLink(int linkID);

        List<AppViewer.Entities.Link> GetLinks(Entities.Page page);

        List<Entities.Transition> GetLinkTransitions();
        # endregion
        
        # region Page
        Entities.Page Add(AppViewer.Entities.Page page);

        Entities.Page UpdatePage(Entities.Page page);

        Entities.Page UpdatePageNotes(Entities.Page page);

        AppViewer.Entities.Page GetPage(int pageID);

        List<Entities.Page> GetPages(Entities.App app);

        Entities.Page GetPageImage(int pageID, AppViewer.Entities.Enums.ImageSize size);

        void DeletePage(Entities.Page page);
        # endregion

        #region Security Access

        Entities.Security.Enums.AccessType GetSecurityAccessForUserForApp(Entities.App app, Entities.Security.User user);

        #endregion

        #region Team

        Entities.Security.Team GetTeam(Guid TeamID);

        List<Entities.Security.Team> GetTeams();

        #endregion

        # region User

        void Add(Entities.Security.User user);

        Entities.Security.User GetUser(Guid userID);

        List<Entities.Security.User> GetUsers();

        Entities.Security.User Login(Entities.Security.User user);

        Entities.Security.User UpdateUser(Entities.Security.User user);

        Entities.Security.User DeleteUser(Entities.Security.User user);

        bool ResetPassword(Entities.Security.User user);

        #endregion

        #region Device

        List<AppViewer.Entities.Device> GetDevices();
        AppViewer.Entities.Device GetDevice(int DeviceID);

        #endregion

    }
}
