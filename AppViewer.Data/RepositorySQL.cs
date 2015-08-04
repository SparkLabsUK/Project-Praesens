using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppViewer;

namespace AppViewer.Data
{
    public class RepositorySQL : IRepository
    {
        # region App

        public Entities.App AddApp(Entities.App app, Entities.Security.User user)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();

            try
            {
                sqlConnectionProvider.AddParameter("Name", SqlDbType.VarChar, 50, ParameterDirection.Input, app.Name);
                sqlConnectionProvider.AddParameter("Description", SqlDbType.VarChar, 200, ParameterDirection.Input, app.Description);
                sqlConnectionProvider.AddParameter("URL", SqlDbType.VarChar, 50, ParameterDirection.Input, app.URL);
                sqlConnectionProvider.AddParameter("ImgWidth", SqlDbType.Int, 4, ParameterDirection.Input, app.ImgWidth);
                sqlConnectionProvider.AddParameter("ImgHeight", SqlDbType.Int, 4, ParameterDirection.Input, app.ImgHeight);
                sqlConnectionProvider.AddParameter("ImgFullscreenSize", SqlDbType.Int, 4, ParameterDirection.Input, app.FullscreenSize);
                sqlConnectionProvider.AddParameter("AppTypeID", SqlDbType.Int, 1, ParameterDirection.Input, app.AppType);
                sqlConnectionProvider.AddParameter("UserID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, user.UserID);
                sqlConnectionProvider.AddParameter("AppID", SqlDbType.Int, 4, ParameterDirection.Output, 0);

                sqlConnectionProvider.ExecuteCommand("spAppInsert", System.Data.CommandType.StoredProcedure);

                app.AppID = int.Parse(sqlConnectionProvider.GetParameter("AppID").ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return app;
        }

        public Entities.AppWizard AddAppWizard(Entities.AppWizard appWizard, Entities.Security.User user)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();

            try
            {
                sqlConnectionProvider.AddParameter("Name", SqlDbType.VarChar, 50, ParameterDirection.Input, appWizard.App.Name);
                sqlConnectionProvider.AddParameter("Description", SqlDbType.VarChar, 200, ParameterDirection.Input, appWizard.App.Description);
                sqlConnectionProvider.AddParameter("URL", SqlDbType.VarChar, 50, ParameterDirection.Input, appWizard.App.URL);
                sqlConnectionProvider.AddParameter("AppTypeID", SqlDbType.Int, 1, ParameterDirection.Input, appWizard.App.AppType);
                sqlConnectionProvider.AddParameter("UserID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, user.UserID);

                appWizard.AppWizardID = Guid.Parse(sqlConnectionProvider.ExecuteScalar("spAppWizardInsert", System.Data.CommandType.StoredProcedure).ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return appWizard;
        }

        public void DeleteApp(Entities.App app)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();

            try
            {
                sqlConnectionProvider.AddParameter("AppID", SqlDbType.Int, 4, ParameterDirection.Input, app.AppID);


                sqlConnectionProvider.ExecuteCommand("spAppDelete", System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();
        }

        public void SaveApp(Entities.App app)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();

            try
            {
                sqlConnectionProvider.AddParameter("AppID", SqlDbType.Int, 4, ParameterDirection.Input, app.AppID);
                sqlConnectionProvider.AddParameter("Name", SqlDbType.VarChar, 50, ParameterDirection.Input, app.Name);
                sqlConnectionProvider.AddParameter("Description", SqlDbType.VarChar, 200, ParameterDirection.Input, app.Description);
                sqlConnectionProvider.AddParameter("URL", SqlDbType.VarChar, 50, ParameterDirection.Input, app.URL);
                sqlConnectionProvider.AddParameter("IsActive", SqlDbType.Bit, 1, ParameterDirection.Input, app.IsActive);
                sqlConnectionProvider.AddParameter("ShowLinks", SqlDbType.Bit, 1, ParameterDirection.Input, app.ShowLinks);
                sqlConnectionProvider.AddParameter("LinkColour", SqlDbType.VarChar, 10, ParameterDirection.Input, app.LinkColour);
                sqlConnectionProvider.AddParameter("ShowInstructions", SqlDbType.Bit, 1, ParameterDirection.Input, app.ShowInstructions);
                sqlConnectionProvider.AddParameter("Instructions", SqlDbType.VarChar, -1, ParameterDirection.Input, app.Instructions);
                sqlConnectionProvider.AddParameter("ShowLinkBackground", SqlDbType.Bit, 1, ParameterDirection.Input, app.ShowLinkBackground);
                sqlConnectionProvider.AddParameter("LinkBackgroundColour", SqlDbType.VarChar, 10, ParameterDirection.Input, app.LinkBackgroundColour);

                sqlConnectionProvider.ExecuteCommand("spAppUpdate", System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();
        }

        public Entities.App GetApp(int AppID)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            AppViewer.Entities.App app = new Entities.App();

            try
            {
                sqlConnectionProvider.AddParameter("AppID", SqlDbType.Int, 4, ParameterDirection.Input, AppID);

                dt = sqlConnectionProvider.GetDataset("spAppSelect", System.Data.CommandType.StoredProcedure);

                app = (from a in dt.AsEnumerable()
                       select new AppViewer.Entities.App
                       {
                           AppID = a.Field<int>("AppID"),
                           Name = a.Field<string>("Name"),
                           URL = a.Field<string>("URL"),
                           ThumbPageID = a.IsNull("ThumbPageID") ? -1 : a.Field<int>("ThumbPageID"),
                           FirstPageID = a.IsNull("FirstPageID") ? -1 : a.Field<int>("FirstPageID"),
                           IsActive = a.Field<bool>("IsActive"),
                           ShowLinks = a.Field<bool>("ShowLinks"),
                           LinkColour = a.Field<string>("LinkColour"),
                           ShowInstructions = a.Field<bool>("ShowInstructions"),
                           Instructions = a.IsNull("Instructions") ? "" : a.Field<string>("Instructions"),
                           ImgWidth = a.Field<int>("ImgWidth"),
                           ImgHeight = a.Field<int>("ImgHeight"),
                           FullscreenSize = a.Field<int>("ImgFullscreenSize"),
                           ShowLinkBackground = a.Field<bool>("ShowLinkBackground"),
                           LinkBackgroundColour = a.Field<string>("LinkBackgroundColour"),
                           AppType = a.Field<Entities.Enums.AppType>("AppTypeID")

                       }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return app;
        }

        public List<Entities.AppType> GetAppTypes()
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            List<AppViewer.Entities.AppType> appType = new List<Entities.AppType>();

            try
            {
                dt = sqlConnectionProvider.GetDataset("spAppTypeSelectAll", System.Data.CommandType.StoredProcedure);

                appType = (from t in dt.AsEnumerable()
                               select new AppViewer.Entities.AppType
                               {
                                   AppTypeID = t.Field<int>("AppTypeID"),
                                   Description = t.Field<string>("Description")
                               }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return appType;
        }

        public Entities.App GetAppByURL(string URL)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            AppViewer.Entities.App app = new Entities.App();

            try
            {
                sqlConnectionProvider.AddParameter("URL", SqlDbType.VarChar, 50, ParameterDirection.Input, URL);

                dt = sqlConnectionProvider.GetDataset("spAppSelectByURL", System.Data.CommandType.StoredProcedure);

                app = (from a in dt.AsEnumerable()
                       select new AppViewer.Entities.App
                       {
                           AppID = a.Field<int>("AppID"),
                           Name = a.Field<string>("Name"),
                           Description = a.Field<string>("Description"),
                           URL = a.Field<string>("URL"),
                           ThumbPageID = a.IsNull("ThumbPageID") ? -1 : a.Field<int>("ThumbPageID"),
                           FirstPageID = a.IsNull("FirstPageID") ? -1 : a.Field<int>("FirstPageID"),
                           IsActive = a.Field<bool>("IsActive"),
                           ShowLinks = a.Field<bool>("ShowLinks"),
                           LinkColour = a.Field<string>("LinkColour"),
                           ShowInstructions = a.Field<bool>("ShowInstructions"),
                           Instructions = a.IsNull("Instructions") ? "" : a.Field<string>("Instructions"),
                           ImgWidth = a.Field<int>("ImgWidth"),
                           ImgHeight = a.Field<int>("ImgHeight"),
                           FullscreenSize = a.Field<int>("ImgFullscreenSize"),
                           ShowLinkBackground = a.Field<bool>("ShowLinkBackground"),
                           LinkBackgroundColour = a.Field<string>("LinkBackgroundColour"),
                           AppType = a.Field<Entities.Enums.AppType>("AppTypeID")

                       }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return app;
        }

        public List<Entities.App> GetApps()
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            List<AppViewer.Entities.App> apps = new List<Entities.App>();

            try
            {
                dt = sqlConnectionProvider.GetDataset("spAppSelectAll", System.Data.CommandType.StoredProcedure);


                apps = (from a in dt.AsEnumerable()
                        select new AppViewer.Entities.App
                        {
                            AppID = a.Field<int>("AppID"),
                            Name = a.Field<string>("Name"),
                            Description = a.Field<string>("Description"),
                            URL = a.Field<string>("URL"),
                            ThumbPageID = a.IsNull("ThumbPageID") ? -1 : a.Field<int>("ThumbPageID"),
                            FirstPageID = a.IsNull("FirstPageID") ? -1 : a.Field<int>("FirstPageID"),
                            IsActive = a.Field<bool>("IsActive"),
                            AppType = a.Field<Entities.Enums.AppType>("AppTypeID")

                        }).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return apps;
        }

        public List<Entities.App> GetAppsForUser(Entities.Security.User user)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            List<AppViewer.Entities.App> apps = new List<Entities.App>();

            try
            {
                sqlConnectionProvider.AddParameter("UserID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, user.UserID);

                dt = sqlConnectionProvider.GetDataset("spAppSelectAllForUser", System.Data.CommandType.StoredProcedure);


                apps = (from a in dt.AsEnumerable()
                        select new AppViewer.Entities.App
                        {
                            AppID = a.Field<int>("AppID"),
                            Name = a.Field<string>("Name"),
                            Description = a.Field<string>("Description"),
                            URL = a.Field<string>("URL"),
                            ThumbPageID = a.IsNull("ThumbPageID") ? -1 : a.Field<int>("ThumbPageID"),
                            FirstPageID = a.IsNull("FirstPageID") ? -1 : a.Field<int>("FirstPageID"),
                            IsActive = a.Field<bool>("IsActive"),
                            ShowLinks = a.Field<bool>("ShowLinks"),
                            LinkColour = a.Field<string>("LinkColour"),
                            ShowInstructions = a.Field<bool>("ShowInstructions"),
                            Instructions = a.IsNull("Instructions") ? "" : a.Field<string>("Instructions"),
                            ImgWidth = a.Field<int>("ImgWidth"),
                            ImgHeight = a.Field<int>("ImgHeight"),
                            FullscreenSize = a.Field<int>("ImgFullscreenSize"),
                            ShowLinkBackground = a.Field<bool>("ShowLinkBackground"),
                            LinkBackgroundColour = a.Field<string>("LinkBackgroundColour"),
                            AppType = a.Field<Entities.Enums.AppType>("AppTypeID")

                        }).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return apps;
        }

        public List<Entities.App> GetActiveApps()
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            List<AppViewer.Entities.App> apps = new List<Entities.App>();

            try
            {
                dt = sqlConnectionProvider.GetDataset("spAppSelectActive", System.Data.CommandType.StoredProcedure);


                apps = (from a in dt.AsEnumerable()
                        select new AppViewer.Entities.App
                        {
                            AppID = a.Field<int>("AppID"),
                            Name = a.Field<string>("Name"),
                            Description = a.Field<string>("Description"),
                            URL = a.Field<string>("URL"),
                            ThumbPageID = a.IsNull("ThumbPageID") ? -1 : a.Field<int>("ThumbPageID"),
                            FirstPageID = a.IsNull("FirstPageID") ? -1 : a.Field<int>("FirstPageID"),
                            IsActive = a.Field<bool>("IsActive"),
                            AppType = a.Field<Entities.Enums.AppType>("AppTypeID")
                        }).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return apps;
        }

        public void SetThumbPage(Entities.App app)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();

            try
            {
                sqlConnectionProvider.AddParameter("AppID", SqlDbType.Int, 4, ParameterDirection.Input, app.AppID);
                sqlConnectionProvider.AddParameter("ThumbPageID", SqlDbType.Int, 4, ParameterDirection.Input, app.ThumbPageID);

                sqlConnectionProvider.ExecuteCommand("spAppSetThumbPage", System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();
        }

        public void SetFirstPage(Entities.App app)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();

            try
            {
                sqlConnectionProvider.AddParameter("AppID", SqlDbType.Int, 4, ParameterDirection.Input, app.AppID);
                sqlConnectionProvider.AddParameter("FirstPageID", SqlDbType.Int, 4, ParameterDirection.Input, app.FirstPageID);

                sqlConnectionProvider.ExecuteCommand("spAppSetFirstPage", System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();
        }

        # endregion

        #region All Audits

        public DataTable GetTop30Audits()
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();

            //List<AppViewer.Entities.Audit.Audits> audits = new List<Entities.Audit.Audits>();

            try
            {
                dt = sqlConnectionProvider.GetDataset("spAuditTop30", System.Data.CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return dt;
        }
        public int GetAppCount()
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            int val;
            //List<AppViewer.Entities.Audit.Audits> audits = new List<Entities.Audit.Audits>();

            try
            {
                dt = sqlConnectionProvider.GetDataset("spAuditAppCount", System.Data.CommandType.StoredProcedure);
                //val = Convert.ToInt32(dt);
                val = dt.Rows[0].Field<int>("TotalApps");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return val;
        }
        public int GetPageCount()
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            int val;
            //List<AppViewer.Entities.Audit.Audits> audits = new List<Entities.Audit.Audits>();

            try
            {
                dt = sqlConnectionProvider.GetDataset("spAuditPageCount", System.Data.CommandType.StoredProcedure);
                //val = Convert.ToInt32(dt);
                val = dt.Rows[0].Field<int>("TotalPages");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return val;
        }

        public int GetUserCount()
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            int val;
            //List<AppViewer.Entities.Audit.Audits> audits = new List<Entities.Audit.Audits>();

            try
            {
                dt = sqlConnectionProvider.GetDataset("spAuditUserCount", System.Data.CommandType.StoredProcedure);
                //val = Convert.ToInt32(dt);
                val = dt.Rows[0].Field<int>("TotalUsers");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return val;
        }
        public int GetLinkCount()
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            int val;
            //List<AppViewer.Entities.Audit.Audits> audits = new List<Entities.Audit.Audits>();

            try
            {
                dt = sqlConnectionProvider.GetDataset("spAuditLinkCount", System.Data.CommandType.StoredProcedure);
                //val = Convert.ToInt32(dt);
                val = dt.Rows[0].Field<int>("TotalLinks");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return val;
        }
        #endregion

        # region App Audit

        public void AddAppAudit(AppViewer.Entities.Audit.AuditApp audit)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();

            try
            {
                sqlConnectionProvider.AddParameter("AuditTypeID", SqlDbType.Int, 4, ParameterDirection.Input, (int)audit.AuditType);
                sqlConnectionProvider.AddParameter("UserID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, audit.UserID);
                sqlConnectionProvider.AddParameter("AppID", SqlDbType.Int, 4, ParameterDirection.Input, audit.AppID);
                sqlConnectionProvider.AddParameter("Description", SqlDbType.VarChar, -1, ParameterDirection.Input, audit.Description);

                sqlConnectionProvider.ExecuteCommand("spAuditAppInsert", System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();
        }

        public AppViewer.Entities.Audit.AuditApp GetAppAudit(Guid auditID)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            AppViewer.Entities.Audit.AuditApp audit = new Entities.Audit.AuditApp();

            try
            {
                sqlConnectionProvider.AddParameter("AuditID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, auditID);

                dt = sqlConnectionProvider.GetDataset("spAuditAppSelect", System.Data.CommandType.StoredProcedure);

                audit = (from a in dt.AsEnumerable()
                         select new AppViewer.Entities.Audit.AuditApp
                         {
                             AuditID = a.Field<Guid>("AuditID"),
                             AuditType = a.Field<AppViewer.Entities.Audit.Enums.AuditType>("AuditTypeID"),
                             AuditDate = a.Field<DateTime>("AuditDate"),
                             UserID = a.Field<Guid>("UserID"),
                             AppID = a.Field<int>("AppID"),
                             Description = a.Field<string>("Description")
                         }).FirstOrDefault();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return audit;
        }

        public DataTable GetAppAudits()
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();

            //List<AppViewer.Entities.Audit.Audits> audits = new List<Entities.Audit.Audits>();

            try
            {
                dt = sqlConnectionProvider.GetDataset("spAuditAppSelectAll", System.Data.CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return dt;
        }

        public DataTable GetAuditAppForApp(int appID)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            sqlConnectionProvider.AddParameter("AppID", SqlDbType.Int, 4, ParameterDirection.Input, appID);
            //List<AppViewer.Entities.Audit.Audits> audits = new List<Entities.Audit.Audits>();

            try
            {
                dt = sqlConnectionProvider.GetDataset("spAuditAppSelectForApp", System.Data.CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return dt;
        }

        # endregion

        # region Page Audit

        public void AddPageAudit(AppViewer.Entities.Audit.AuditPage audit)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();

            try
            {
                sqlConnectionProvider.AddParameter("AuditTypeID", SqlDbType.Int, 4, ParameterDirection.Input, (int)audit.AuditType);
                sqlConnectionProvider.AddParameter("UserID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, audit.UserID);
                sqlConnectionProvider.AddParameter("AppID", SqlDbType.Int, 4, ParameterDirection.Input, audit.AppID);
                sqlConnectionProvider.AddParameter("PageID", SqlDbType.Int, 4, ParameterDirection.Input, audit.PageID);
                sqlConnectionProvider.AddParameter("Description", SqlDbType.VarChar, -1, ParameterDirection.Input, audit.Description);

                sqlConnectionProvider.ExecuteCommand("spAuditPageInsert", System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();
        }

        public AppViewer.Entities.Audit.AuditPage GetPageAudit(Guid auditID)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            AppViewer.Entities.Audit.AuditPage audit = new Entities.Audit.AuditPage();

            try
            {
                sqlConnectionProvider.AddParameter("AuditID", SqlDbType.UniqueIdentifier, 4, ParameterDirection.Input, auditID);

                dt = sqlConnectionProvider.GetDataset("spAuditPageSelect", System.Data.CommandType.StoredProcedure);

                audit = (from a in dt.AsEnumerable()
                         select new AppViewer.Entities.Audit.AuditPage
                         {
                             AuditID = a.Field<Guid>("AuditID"),
                             AuditType = a.Field<AppViewer.Entities.Audit.Enums.AuditType>("AuditTypeID"),
                             AuditDate = a.Field<DateTime>("AuditDate"),
                             UserID = a.Field<Guid>("UserID"),
                             AppID = a.Field<int>("AppID"),
                             PageID = a.Field<int>("PageID"),
                             Description = a.Field<string>("Description")
                         }).FirstOrDefault();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return audit;
        }

        public DataTable GetPageAudits()
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();

            try
            {
                dt = sqlConnectionProvider.GetDataset("spAuditPageSelectAll", System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return dt;
        }

        public DataTable GetAuditPageForPage(int pageID)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            AppViewer.Entities.Audit.AuditPage audit = new Entities.Audit.AuditPage();

            try
            {
                sqlConnectionProvider.AddParameter("PageID", SqlDbType.Int, 4, ParameterDirection.Input, pageID);

                dt = sqlConnectionProvider.GetDataset("spAuditPageSelectForPage", System.Data.CommandType.StoredProcedure);
            }

            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return dt;
        }

        # endregion

        # region System Audit

        public void AddSystemAudit(AppViewer.Entities.Audit.AuditSystem audit)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();

            try
            {
                sqlConnectionProvider.AddParameter("AuditTypeID", SqlDbType.Int, 4, ParameterDirection.Input, (int)audit.AuditType);
                sqlConnectionProvider.AddParameter("UserID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, audit.UserID);
                sqlConnectionProvider.AddParameter("Description", SqlDbType.VarChar, -1, ParameterDirection.Input, audit.Description == null ? "" : audit.Description);

                sqlConnectionProvider.ExecuteCommand("spAuditSystemInsert", System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();
        }

        public AppViewer.Entities.Audit.AuditSystem GetSystemAudit(Guid auditID)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            AppViewer.Entities.Audit.AuditSystem audit = new Entities.Audit.AuditSystem();

            try
            {
                sqlConnectionProvider.AddParameter("AuditID", SqlDbType.UniqueIdentifier, 32, ParameterDirection.Input, auditID);

                dt = sqlConnectionProvider.GetDataset("spAuditSystemSelect", System.Data.CommandType.StoredProcedure);

                audit = (from a in dt.AsEnumerable()
                         select new AppViewer.Entities.Audit.AuditSystem
                         {
                             AuditID = a.Field<Guid>("AuditID"),
                             AuditType = a.Field<AppViewer.Entities.Audit.Enums.AuditType>("AuditTypeID"),
                             AuditDate = a.Field<DateTime>("AuditDate"),
                             UserID = a.Field<Guid>("UserID"),
                             Description = a.Field<string>("Description")
                         }).FirstOrDefault();

            }

            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return audit;
        }

        public DataTable GetSystemAudits()
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();

            try
            {
                dt = sqlConnectionProvider.GetDataset("spAuditSystemSelectAll", System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return dt;
        }

        # endregion

        # region User Audit

        public void AddUserAudit(AppViewer.Entities.Audit.AuditUser audit)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();

            try
            {
                sqlConnectionProvider.AddParameter("AuditTypeID", SqlDbType.Int, 4, ParameterDirection.Input, (int)audit.AuditType);
                sqlConnectionProvider.AddParameter("UserID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, audit.UserID);
                sqlConnectionProvider.AddParameter("Description", SqlDbType.VarChar, -1, ParameterDirection.Input, audit.Description);

                sqlConnectionProvider.ExecuteCommand("spAuditUserInsert", System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();
        }

        public AppViewer.Entities.Audit.AuditUser GetUserAudit(Guid auditID)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            AppViewer.Entities.Audit.AuditUser audit = new Entities.Audit.AuditUser();

            try
            {
                sqlConnectionProvider.AddParameter("AuditID", SqlDbType.Int, 4, ParameterDirection.Input, auditID);

                dt = sqlConnectionProvider.GetDataset("spAuditUserSelect", System.Data.CommandType.StoredProcedure);

                audit = (from a in dt.AsEnumerable()
                         select new AppViewer.Entities.Audit.AuditUser
                         {
                             AuditID = a.Field<Guid>("AuditID"),
                             AuditType = a.Field<AppViewer.Entities.Audit.Enums.AuditType>("AuditTypeID"),
                             AuditDate = a.Field<DateTime>("AuditDate"),
                             UserID = a.Field<Guid>("UserID"),
                             Description = a.Field<string>("Description")
                         }).FirstOrDefault();

            }

            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return audit;
        }

        public DataTable GetUserAudits()
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();

            try
            {
                dt = sqlConnectionProvider.GetDataset("spAuditUserSelectAll", System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return dt;
        }

        # endregion

        #region Demo

        #endregion

        # region Link

        public void AddLink(Entities.Link link)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();

            try
            {
                sqlConnectionProvider.AddParameter("PageID", SqlDbType.Int, 4, ParameterDirection.Input, link.PageID);
                sqlConnectionProvider.AddParameter("Xcoordinate", SqlDbType.Int, 4, ParameterDirection.Input, link.Xcoordinate);
                sqlConnectionProvider.AddParameter("Ycoordinate", SqlDbType.Int, 4, ParameterDirection.Input, link.Ycoordinate);
                sqlConnectionProvider.AddParameter("Width", SqlDbType.Int, 4, ParameterDirection.Input, link.Width);
                sqlConnectionProvider.AddParameter("Height", SqlDbType.Int, 4, ParameterDirection.Input, link.Height);
                sqlConnectionProvider.AddParameter("Transition", SqlDbType.Int, 4, ParameterDirection.Input, link.Transition);
                sqlConnectionProvider.AddParameter("ToPageID", SqlDbType.Int, 4, ParameterDirection.Input, link.ToPageID);

                sqlConnectionProvider.ExecuteCommand("spLinkInsert", System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();
        }

        public void SaveLink(Entities.Link link)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();

            try
            {
                sqlConnectionProvider.AddParameter("LinkID", SqlDbType.Int, 4, ParameterDirection.Input, link.LinkID);
                sqlConnectionProvider.AddParameter("Xcoordinate", SqlDbType.Int, 4, ParameterDirection.Input, link.Xcoordinate);
                sqlConnectionProvider.AddParameter("Ycoordinate", SqlDbType.Int, 4, ParameterDirection.Input, link.Ycoordinate);
                sqlConnectionProvider.AddParameter("Width", SqlDbType.Int, 4, ParameterDirection.Input, link.Width);
                sqlConnectionProvider.AddParameter("Height", SqlDbType.Int, 4, ParameterDirection.Input, link.Height);
                sqlConnectionProvider.AddParameter("Transition", SqlDbType.Int, 4, ParameterDirection.Input, link.Transition);
                sqlConnectionProvider.AddParameter("ToPageID", SqlDbType.Int, 4, ParameterDirection.Input, link.ToPageID);

                sqlConnectionProvider.ExecuteCommand("spLinkUpdate", System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();
        }

        public void DeleteLink(Entities.Link link)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();

            try
            {
                sqlConnectionProvider.AddParameter("LinkID", SqlDbType.Int, 4, ParameterDirection.Input, link.LinkID);


                sqlConnectionProvider.ExecuteCommand("spLinkDelete", System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();
        }

        public Entities.Link GetLink(int linkID)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            AppViewer.Entities.Link link = new Entities.Link();

            try
            {
                sqlConnectionProvider.AddParameter("LinkID", SqlDbType.Int, 4, ParameterDirection.Input, linkID);

                dt = sqlConnectionProvider.GetDataset("spLinkSelect", System.Data.CommandType.StoredProcedure);

                link = (from l in dt.AsEnumerable()
                        select new AppViewer.Entities.Link
                        {
                            LinkID = l.Field<int>("LinkID"),
                            PageID = l.Field<int>("PageID"),
                            Xcoordinate = l.Field<int>("Xcoordinate"),
                            Ycoordinate = l.Field<int>("Ycoordinate"),
                            Width = l.Field<int>("Width"),
                            Height = l.Field<int>("Height"),
                            Transition = l.Field<Entities.Enums.Transition>("Transition"),
                            ToPageID = l.Field<int>("ToPageID")
                        }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return link;
        }

        public List<Entities.Link> GetLinks(Entities.Page page)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            List<AppViewer.Entities.Link> links = new List<Entities.Link>();

            try
            {
                sqlConnectionProvider.AddParameter("PageID", SqlDbType.Int, 4, ParameterDirection.Input, page.PageID);

                dt = sqlConnectionProvider.GetDataset("spLinkSelectAll", System.Data.CommandType.StoredProcedure);

                links = (from l in dt.AsEnumerable()
                         select new AppViewer.Entities.Link
                         {
                             LinkID = l.Field<int>("LinkID"),
                             PageID = l.Field<int>("PageID"),
                             Xcoordinate = l.Field<int>("Xcoordinate"),
                             Ycoordinate = l.Field<int>("Ycoordinate"),
                             Width = l.Field<int>("Width"),
                             Height = l.Field<int>("Height"),
                             Transition = l.Field<Entities.Enums.Transition>("Transition"),
                             ToPageID = l.Field<int>("ToPageID")
                         }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return links;
        }

        public List<Entities.Transition> GetLinkTransitions()
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            List<AppViewer.Entities.Transition> transitions = new List<Entities.Transition>();

            try
            {
                dt = sqlConnectionProvider.GetDataset("spLinkSelectAllTransitions", System.Data.CommandType.StoredProcedure);

                transitions = (from t in dt.AsEnumerable()
                               select new AppViewer.Entities.Transition
                               {
                                   TransitionID = t.Field<int>("TransitionID"),
                                   Name = t.Field<string>("Name")
                               }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return transitions;
        }


        # endregion

        # region Page

        public Entities.Page Add(Entities.Page page)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();

            try
            {
                sqlConnectionProvider.AddParameter("Name", SqlDbType.NChar, 2000, ParameterDirection.Input, page.Name);
                sqlConnectionProvider.AddParameter("DataLargeImage", SqlDbType.VarBinary, -1, ParameterDirection.Input, page.Data);
                sqlConnectionProvider.AddParameter("DataSmallImage", SqlDbType.VarBinary, -1, ParameterDirection.Input, page.Data);
                sqlConnectionProvider.AddParameter("DataThumbImage", SqlDbType.VarBinary, -1, ParameterDirection.Input, page.Data);
                sqlConnectionProvider.AddParameter("AppID", SqlDbType.Int, 4, ParameterDirection.Input, page.AppID);
                sqlConnectionProvider.AddParameter("PageNotes", SqlDbType.VarChar, 250, ParameterDirection.Input, page.PageNotes);
                sqlConnectionProvider.AddParameter("PageTypeID", SqlDbType.Int, 1, ParameterDirection.Input, page.PageType);


                sqlConnectionProvider.AddParameter("PageID", SqlDbType.Int, 4, ParameterDirection.Output, DBNull.Value);

                sqlConnectionProvider.ExecuteCommand("spPageInsert", System.Data.CommandType.StoredProcedure);

                page.PageID = int.Parse(sqlConnectionProvider.GetParameter("PageID").ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();
            return page;

        }

        public Entities.Page UpdatePage(Entities.Page page)
        {
            Convert.ToInt32(page.PageID);
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();

            try
            {
                sqlConnectionProvider.AddParameter("PageID", SqlDbType.Int, -1, ParameterDirection.Input, page.PageID);
                sqlConnectionProvider.AddParameter("Name", SqlDbType.NChar, 2000, ParameterDirection.Input, page.Name);
                sqlConnectionProvider.AddParameter("DataLargeImage", SqlDbType.VarBinary, -1, ParameterDirection.Input, page.Data);
                sqlConnectionProvider.AddParameter("DataSmallImage", SqlDbType.VarBinary, -1, ParameterDirection.Input, page.Data);
                sqlConnectionProvider.AddParameter("DataThumbImage", SqlDbType.VarBinary, -1, ParameterDirection.Input, page.Data);
                sqlConnectionProvider.AddParameter("PageNotes", SqlDbType.VarChar, 250, ParameterDirection.Input, page.PageNotes);
                sqlConnectionProvider.AddParameter("AppID", SqlDbType.Int, 4, ParameterDirection.Input, page.AppID);


                sqlConnectionProvider.ExecuteCommand("spPageUpdate", System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            sqlConnectionProvider.Dispose();
            return page;

        }

        public Entities.Page UpdatePageNotes(Entities.Page page)
        {
            Convert.ToInt32(page.PageID);
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();

            try
            {
                sqlConnectionProvider.AddParameter("PageID", SqlDbType.Int, -1, ParameterDirection.Input, page.PageID);
                sqlConnectionProvider.AddParameter("PageNotes", SqlDbType.VarChar, 250, ParameterDirection.Input, page.PageNotes);
                sqlConnectionProvider.AddParameter("AppID", SqlDbType.Int, 4, ParameterDirection.Input, page.AppID);


                sqlConnectionProvider.ExecuteCommand("spPageNotesUpdate", System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            sqlConnectionProvider.Dispose();
            return page;

        }

        public Entities.Page GetPage(int pageID)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            AppViewer.Entities.Page page = new Entities.Page();

            try
            {
                sqlConnectionProvider.AddParameter("PageID", SqlDbType.Int, 4, ParameterDirection.Input, pageID);

                dt = sqlConnectionProvider.GetDataset("spPageSelect", System.Data.CommandType.StoredProcedure);

                page = (from p in dt.AsEnumerable()
                        select new AppViewer.Entities.Page
                        {
                            PageID = p.Field<int>("PageID"),
                            Name = p.Field<string>("Name"),
                            AppID = p.Field<int>("AppID"),
                            PageNotes = p.IsNull("PageNotes") ? "" : p.Field<string>("PageNotes"),
                            PageType = p.Field<Entities.Enums.PageType>("PageTypeID")

                        }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return page;
        }

        public List<Entities.Page> GetPages(Entities.App app)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            List<AppViewer.Entities.Page> pages = new List<Entities.Page>();

            try
            {
                sqlConnectionProvider.AddParameter("AppID", SqlDbType.Int, 4, ParameterDirection.Input, app.AppID);

                dt = sqlConnectionProvider.GetDataset("spPageSelectAll", System.Data.CommandType.StoredProcedure);

                pages = (from p in dt.AsEnumerable()
                         select new AppViewer.Entities.Page
                         {
                             PageID = p.Field<int>("PageID"),
                             Name = p.Field<string>("Name"),
                             Data = p.Field<byte[]>("LargeImage"),
                             AppID = p.Field<int>("AppID"),
                             PageNotes = p.IsNull("PageNotes") ? "" : p.Field<string>("PageNotes"),
                             PageType = p.Field<Entities.Enums.PageType>("PageTypeID")

                         }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return pages;
        }

        public Entities.Page GetPageImage(int pageID, AppViewer.Entities.Enums.ImageSize size)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            AppViewer.Entities.Page page = new Entities.Page();

            try
            {
                sqlConnectionProvider.AddParameter("PageID", SqlDbType.Int, 4, ParameterDirection.Input, pageID);
                sqlConnectionProvider.AddParameter("PageType", SqlDbType.Int, 4, ParameterDirection.Input, (int)size);

                dt = sqlConnectionProvider.GetDataset("spPageImageSelect", System.Data.CommandType.StoredProcedure);

                page = (from p in dt.AsEnumerable()
                        select new AppViewer.Entities.Page
                        {
                            Data = p.Field<byte[]>("Image")
                        }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return page;
        }

        public void DeletePage(Entities.Page page)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();

            try
            {
                sqlConnectionProvider.AddParameter("PageID", SqlDbType.Int, 4, ParameterDirection.Input, page.PageID);

                sqlConnectionProvider.ExecuteCommand("spPageDelete", System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();
        }

        # endregion

        #region Security Access

        public Entities.Security.Enums.AccessType GetSecurityAccessForUserForApp(Entities.App app, Entities.Security.User user)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();

            Entities.Security.Enums.AccessType accessType = Entities.Security.Enums.AccessType.NoAccess;

            try
            {
                sqlConnectionProvider.AddParameter("AppID", SqlDbType.Int, 4, ParameterDirection.Input, app.AppID);
                sqlConnectionProvider.AddParameter("UserID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, user.UserID);
                sqlConnectionProvider.AddParameter("SecurityAccessResult", SqlDbType.Int, 4, ParameterDirection.Output, 0);

                dt = sqlConnectionProvider.GetDataset("spAppGetSecurityAccessForUser", System.Data.CommandType.StoredProcedure);

                accessType = (Entities.Security.Enums.AccessType)int.Parse(sqlConnectionProvider.GetParameter("SecurityAccessResult").ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return accessType;
        }

        #endregion

        #region Team

        public Entities.Security.Team GetTeam(Guid TeamID)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            Entities.Security.Team team = new Entities.Security.Team();
            try
            {
                sqlConnectionProvider.AddParameter("TeamID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, TeamID);

                dt = sqlConnectionProvider.GetDataset("spTeamSelect", System.Data.CommandType.StoredProcedure);


                team = (from t in dt.AsEnumerable()
                        select new Entities.Security.Team
                        {
                            TeamID = t.Field<Guid>("TeamID"),
                            TeamName = t.Field<string>("TeamName"),
                            TeamTypeID = t.Field<int>("TeamTypeID")
                        }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return team;
        }

        public List<Entities.Security.Team> GetTeams()
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            List<Entities.Security.Team> teams = new List<Entities.Security.Team>();

            try
            {
                dt = sqlConnectionProvider.GetDataset("spTeamSelectAll", System.Data.CommandType.StoredProcedure);


                teams = (from t in dt.AsEnumerable()
                         select new Entities.Security.Team
                         {
                             TeamID = t.Field<Guid>("TeamID"),
                             TeamName = t.Field<string>("TeamName"),
                             TeamTypeID = t.Field<int>("TeamTypeID")

                         }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return teams;
        }


        #endregion

        # region User

        public void Add(Entities.Security.User user)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();

            try
            {
                sqlConnectionProvider.AddParameter("Username", SqlDbType.VarChar, 50, ParameterDirection.Input, user.Username);
                sqlConnectionProvider.AddParameter("Password", SqlDbType.VarChar, 50, ParameterDirection.Input, user.Password);
                sqlConnectionProvider.AddParameter("UserTypeID", SqlDbType.Int, 4, ParameterDirection.Output, (int)user.UserType);

                sqlConnectionProvider.ExecuteCommand("spUserInsert", System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();
        }

        public Entities.Security.User GetUser(Guid userID)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            Entities.Security.User user = new Entities.Security.User();

            try
            {
                sqlConnectionProvider.AddParameter("UserID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, userID);

                dt = sqlConnectionProvider.GetDataset("spUserSelect", System.Data.CommandType.StoredProcedure);


                user = (from u in dt.AsEnumerable()
                        select new Entities.Security.User
                        {
                            UserID = u.Field<Guid>("UserID"),
                            Forename = u.Field<string>("Forename"),
                            Surname = u.Field<string>("Surname"),
                            Username = u.Field<string>("Username"),
                            LastLogon = u.Field<DateTime>("LastLogon"),
                            FailedLogins = u.Field<int>("FailedLogins"),
                            LockTime = u.IsNull("LockTime") ? null : u.Field<DateTime?>("LockTime"),
                            UserType = u.Field<Entities.Security.Enums.UserType>("UserTypeID")
                        }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return user;
        }

        public List<Entities.Security.User> GetUsers()
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            List<Entities.Security.User> users = new List<Entities.Security.User>();

            try
            {
                dt = sqlConnectionProvider.GetDataset("spUserSelectAll", System.Data.CommandType.StoredProcedure);


                users = (from u in dt.AsEnumerable()
                         select new Entities.Security.User
                         {
                             UserID = u.Field<Guid>("UserID"),
                             Forename = u.Field<string>("Forename"),
                             Surname = u.Field<string>("Surname"),
                             Username = u.Field<string>("UserName"),
                             Password = u.Field<string>("Password"),
                             LastLogon = u.Field<DateTime>("LastLogon"),
                             FailedLogins = u.Field<int>("FailedLogins"),
                             LockTime = u.IsNull("LockTime") ? null : u.Field<DateTime?>("LockTime"),
                             UserType = u.Field<Entities.Security.Enums.UserType>("UserTypeID")
                         }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return users;
        }

        public Entities.Security.User Login(Entities.Security.User user)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            Guid userID = Guid.Empty;
            int userLoginResult;

            try
            {
                sqlConnectionProvider.AddParameter("Username", SqlDbType.VarChar, 50, ParameterDirection.Input, user.Username);
                sqlConnectionProvider.AddParameter("Password", SqlDbType.VarChar, 50, ParameterDirection.Input, user.Password);
                sqlConnectionProvider.AddParameter("UserID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Output, Guid.Empty);
                sqlConnectionProvider.AddParameter("UserLoginResult", SqlDbType.Int, 4, ParameterDirection.Output, 0);

                sqlConnectionProvider.ExecuteCommand("spUserLogin", CommandType.StoredProcedure);

                if (sqlConnectionProvider.GetParameter("UserID").ToString().Length > 0)
                {
                    userID = Guid.Parse(sqlConnectionProvider.GetParameter("UserID").ToString());
                }
                userLoginResult = int.Parse(sqlConnectionProvider.GetParameter("UserLoginResult").ToString());

                user.LoginResult = userLoginResult > 0 ? Entities.Enums.LoginResult.LoginPassed : (Entities.Enums.LoginResult)userLoginResult;

                switch (user.LoginResult)
                {

                    case Entities.Enums.LoginResult.LoginPassed:
                        user = GetUser(userID);
                        user.LoginResult = Entities.Enums.LoginResult.LoginPassed;
                        break;

                    case Entities.Enums.LoginResult.AccountLocked:
                    case Entities.Enums.LoginResult.InvalidPassword:
                    case Entities.Enums.LoginResult.LoginFailed:
                    case Entities.Enums.LoginResult.UsernameNotFound:
                        user.LoginResult = (Entities.Enums.LoginResult)userLoginResult;
                        break;
                }
            }
            catch (Exception ex)
            {
                user.LoginResult = Entities.Enums.LoginResult.LoginFailed;
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return user;
        }

        public Entities.Security.User UpdateUser(Entities.Security.User user)
        {
            Convert.ToInt32(user.UserID);
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();

            try
            {
                sqlConnectionProvider.AddParameter("UserID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, user.UserID);
                sqlConnectionProvider.AddParameter("Username", SqlDbType.VarChar, 50, ParameterDirection.Input, user.Username);
                sqlConnectionProvider.AddParameter("Password", SqlDbType.VarChar, 50, ParameterDirection.Input, user.Password);

                sqlConnectionProvider.ExecuteCommand("spUserUpdate", System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            sqlConnectionProvider.Dispose();
            return user;

        }

        public Entities.Security.User DeleteUser(Entities.Security.User user)
        {
            Convert.ToInt32(user.UserID);
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            try
            {
                sqlConnectionProvider.AddParameter("UserID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, user.UserID);

                sqlConnectionProvider.ExecuteCommand("spUserDelete", System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            sqlConnectionProvider.Dispose();
            return user;
        }

        public bool ResetPassword(Entities.Security.User user)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            bool userResetSuccessful = false;
            try
            {
                sqlConnectionProvider.AddParameter("UserID", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, user.UserID);
                sqlConnectionProvider.AddParameter("Password", SqlDbType.VarChar, 50, ParameterDirection.Input, user.Password);
                sqlConnectionProvider.AddParameter("NewPassword", SqlDbType.VarChar, 50, ParameterDirection.Input, user.NewPassword);
                sqlConnectionProvider.AddParameter("ResetSuccessful", SqlDbType.Bit, 1, ParameterDirection.Output, 0);

                sqlConnectionProvider.ExecuteCommand("spUserChangePassword", System.Data.CommandType.StoredProcedure);
                userResetSuccessful = bool.Parse(sqlConnectionProvider.GetParameter("ResetSuccessful").ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            sqlConnectionProvider.Dispose();
            return userResetSuccessful;
        }

        # endregion

        #region Device

        public List<Entities.Device> GetDevices()
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            List<Entities.Device> Devices = new List<Entities.Device>();

            try
            {


                dt = sqlConnectionProvider.GetDataset("spDeviceSelectAll", System.Data.CommandType.StoredProcedure);

                Devices = (from p in dt.AsEnumerable()
                           select new AppViewer.Entities.Device
                           {
                               DeviceID = p.Field<int>("DeviceID"),
                               Name = p.Field<string>("Name"),
                               Width = p.Field<int>("ImgWidth"),
                               Height = p.Field<int>("ImgHeight"),
                               FullscreenSize = p.Field<int>("ImgFullscreenSize")
                           }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return Devices;
        }

        public Entities.Device GetDevice(int DeviceID)
        {
            ConnectionProviders.SQL sqlConnectionProvider = new ConnectionProviders.SQL();
            DataTable dt = new DataTable();
            Entities.Device Devices = new Entities.Device();

            try
            {

                sqlConnectionProvider.AddParameter("DeviceID", SqlDbType.Int, 4, ParameterDirection.Input, DeviceID);
                dt = sqlConnectionProvider.GetDataset("spDeviceSelect", System.Data.CommandType.StoredProcedure);

                Devices = (from u in dt.AsEnumerable()
                           select new AppViewer.Entities.Device
                           {
                               DeviceID = u.Field<int>("DeviceID"),
                               Name = u.Field<string>("Name"),
                               Width = u.Field<int>("ImgWidth"),
                               Height = u.Field<int>("ImgHeight"),
                               FullscreenSize = u.Field<int>("ImgFullscreenSize")

                           }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sqlConnectionProvider.Dispose();

            return Devices;
        }

        #endregion
    }
}
