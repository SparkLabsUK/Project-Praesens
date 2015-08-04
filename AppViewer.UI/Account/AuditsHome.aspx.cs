using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AppViewer.UI.Account
{
    public partial class AuditsHome : System.Web.UI.Page
    {


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

        //    switch (Security.SecurityAccess.GetSecurityAccessForUserForApp())
        //    {
        //        case AppViewer.Entities.Security.Enums.AccessType.ReadOnly:
        //            txtAppName.Enabled = false;
        //            txtAppDescription.Enabled = false;
        //            txtAppUrl.Enabled = false;
        //            chkLive.Enabled = false;
        //            chkShowLinks.Enabled = false;
        //            txtLinkColour.Enabled = false;
        //            chkShowInstructions.Enabled = false;
        //            txtInstructions.Enabled = false;
        //            chkShowLinkBackground.Enabled = false;
        //            txtLinkBackgroundColour.Enabled = false;
        //            appImageSize.Enabled = false;
        //            lnkAppDelete.Visible = false;
        //            btnAddPage.Visible = false;
        //            btnSaveApp.Visible = false;
        //            break;
        //        case AppViewer.Entities.Security.Enums.AccessType.Edit:
        //            break;
        //        case AppViewer.Entities.Security.Enums.AccessType.NoAccess:
        //        default:
        //            Response.Redirect("~/AppViewerHome.aspx");

        //            break;
        //    }

            int Gauge1Val = Audit.AllAudits.GetAppCount();
            lblAppCount.Text = Gauge1Val.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction1", String.Format("CreateGauge1('{0}');", Gauge1Val), true);

            int Gauge2Val = Audit.AllAudits.GetPageCount();
            lblPageCount.Text = Gauge2Val.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction2", String.Format("CreateGauge2('{0}');", Gauge2Val), true);

            int Gauge3Val = Audit.AllAudits.GetUserCount();
            lblUserCount.Text = Gauge3Val.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction3", String.Format("CreateGauge3('{0}');", Gauge3Val), true);

            int Gauge4Val = Audit.AllAudits.GetLinkCount();
            lblLinkCount.Text = Gauge4Val.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction4", String.Format("CreateGauge4('{0}');", Gauge4Val), true);

            AuditGrid.DataSource = AppViewer.Audit.AllAudits.GetTop30Audits();
            AuditGrid.DataBind();
            
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AppViewerHome.aspx");
        }

        protected void btnApp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/AuditsOverview.aspx?Audit=App");
        }

        protected void btnPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/AuditsOverview.aspx?Audit=Page");
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/AuditsOverview.aspx?Audit=User");
        }

        protected void btnSystem_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/AuditsOverview.aspx?Audit=System");
        }



        protected void btnRefreshRecent_Click(object sender, EventArgs e)
        {
            AuditGrid.DataSource = AppViewer.Audit.AllAudits.GetTop30Audits();
            AuditGrid.DataBind();
        }





    }
}