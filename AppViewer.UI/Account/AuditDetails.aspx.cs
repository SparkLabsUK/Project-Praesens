using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;

namespace AppViewer.UI.Account
{
    public partial class AuditsDetails : System.Web.UI.Page
    {

      
        Guid AuditPassed;
        String AuditCat;

        protected void Page_Load(object sender, EventArgs e)
        {
            Entities.Security.User CurrentUser = Security.User.GetLoggedInUser();
            if (CurrentUser.UserType == Entities.Security.Enums.UserType.SuperUser)
            {
            }
            else
            {
                Response.Redirect("../AppViewerHome.aspx");
            }
            AuditCat = Request.QueryString["AuditCat"];
            AuditPassed = new Guid(Request.QueryString["AuditID"]);
            this.Title = "Audit Details";
            if (AuditID == null)
            {
                lblTitle.Text = "<h1> Error No Audit Selected! </h1>";
            }
            else
            {
                switch (AuditCat)
                {
                    case "Page":
                        AppViewer.Entities.Audit.AuditPage PageAudit = AppViewer.Audit.PageAudit.GetAudit(AuditPassed);
                        AuditID.Text = PageAudit.AuditID.ToString();
                        Username.Text = Security.User.GetUser(PageAudit.UserID).Username;
                        AppName.Text = Business.App.GetApp(PageAudit.AppID).Name;
                        PageID.Text = PageAudit.PageID.ToString();
                        PageName.Text = Business.Page.GetPage(PageAudit.PageID).Name;
                        AuditType.Text = PageAudit.AuditType.ToString();
                        Description.Text = PageAudit.Description.ToString();
                        DateTime.Text = PageAudit.AuditDate.ToString();
                        break;
                    case "App":
                        Table1.Rows[3].Visible = false;
                        Table1.Rows[4].Visible = false;
                        AppViewer.Entities.Audit.AuditApp AppAudit = new Entities.Audit.AuditApp();
                        AppAudit = AppViewer.Audit.AppAudit.GetAudit(AuditPassed);
                        AuditID.Text = AppAudit.AuditID.ToString();
                        Username.Text = Security.User.GetUser(AppAudit.UserID).Username;
                        AppName.Text = Business.App.GetApp(AppAudit.AppID).Name;
                        PageID.Visible = false;
                        PageName.Visible = false;
                        AuditType.Text = AppAudit.AuditType.ToString();
                        Description.Text = AppAudit.Description.ToString();
                        DateTime.Text = AppAudit.AuditDate.ToString();
                        break;
                    case "System":
                        Table1.Rows[3].Visible = false;
                        Table1.Rows[4].Visible = false;
                        AppViewer.Entities.Audit.AuditApp SystemAudit = new Entities.Audit.AuditApp();
                        SystemAudit = AppViewer.Audit.AppAudit.GetAudit(AuditPassed);
                        AuditID.Text = SystemAudit.AuditID.ToString();
                        Username.Text = SystemAudit.AuditType == Entities.Audit.Enums.AuditType.LoginFailed ? "" : Security.User.GetUser(SystemAudit.UserID).Username;
                        AppName.Visible = false;
                        PageID.Visible = false;
                        PageName.Visible = false;
                        AuditType.Text = SystemAudit.AuditType.ToString();
                        Description.Text = SystemAudit.Description.ToString();
                        DateTime.Text = SystemAudit.AuditDate.ToString();
                        break;
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/AuditsOverview.aspx?Audit=" + AuditCat);
        }
    }
}