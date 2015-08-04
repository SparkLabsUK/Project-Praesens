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
    public partial class AuditsOverview : System.Web.UI.Page
    {
        String SelectedAuditType = null;
        String AuditID;

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
            DataTable AuditData = null;
            SelectedAuditType = Request.QueryString["Audit"];
            switch (SelectedAuditType)
            {
                case "System":
                    this.Title = "System Audits";
                    lblTitle.Text = "<h1>Audits Overview - System Audits</h1>";
                    AuditGrid.DataSource = Audit.SystemAudit.GetAudits();
                    AuditGrid.DataBind();
                    AuditGrid.Columns[2].Visible = false;
                    AuditGrid.Columns[3].Visible = false;
                    break;
                case "App":
                    this.Title = "App Audits";
                    lblTitle.Text = "<h1>Audits Overview - App Audits</h1>";
                    AuditGrid.DataSource = Audit.AppAudit.GetAudits();
                    AuditGrid.DataBind();
                    AuditGrid.Columns[3].Visible = false;
                    break;
                case "Page":
                    this.Title = "Page Audits";
                    lblTitle.Text = "<h1>Audits Overview - Page Audits</h1>";
                    //AuditData.Clear();

                    AuditGrid.DataSource = AppViewer.Audit.PageAudit.GetAudits();
                    AuditGrid.DataBind();


                    break;
                case "User":
                    this.Title = "User Audits";
                    lblTitle.Text = "<h1>Audits Overview - User Audits</h1>";
                    //AuditData.Clear();

                    AuditGrid.DataSource = AppViewer.Audit.UserAudit.GetAudits();
                    AuditGrid.DataBind();
                    AuditGrid.Columns[2].Visible = false;
                    AuditGrid.Columns[3].Visible = false;
                    break;

            }

        }



        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/AuditsHome.aspx");
        }

        protected void AuditGrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.backgroundColor='#0066a1';this.style.color='#FFFFFF';";
                if ((e.Row.RowIndex % 2) == 0)
                {
                    e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='#FFFFFF'; this.style.color='#555555';";
                }
                else
                {
                    e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='#EFEFEF'; this.style.color='#555555';";
                }

                e.Row.ToolTip = "Click to select row";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(AuditGrid, "Select$" + e.Row.RowIndex);

            }
        }


        protected void AuditGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string index = AuditGrid.SelectedRow.RowIndex.ToString();
            int rowindex =AuditGrid.SelectedRow.RowIndex;
            GridViewRow CurrentRow;
            CurrentRow = AuditGrid.Rows[rowindex]; 
            //AuditID = AuditGrid.SelectedRow.Cells[0].Text;
            //AuditID = AuditGrid.SelectedDataKey.Value.ToString();



            if (AuditGrid.Rows.Count != null && AuditGrid.Rows.Count != 0)
            {
                if (AuditGrid.SelectedRow != null)
                {
                    HiddenField hidden = (HiddenField)AuditGrid.SelectedRow.Cells[0].FindControl("AuditID");
                    AuditID = hidden.Value.ToString();
                    String AuditCat = Request.QueryString["Audit"];
                    Guid CurrAudit = new Guid(AuditID);
                    switch (AuditCat)
                    {
                        case "Page":

                            AppViewer.Entities.Audit.AuditPage PageAudit = AppViewer.Audit.PageAudit.GetAudit(CurrAudit); 
                            Username.Text = Security.User.GetUser(PageAudit.UserID).Username;
                            AppViewer.Entities.App App = Business.App.GetApp(PageAudit.AppID);
                            AppName.Text = CurrentRow.Cells[2].Text;
                            //PageID.Text = PageAudit.PageID.ToString();
                            PageName.Text = CurrentRow.Cells[3].Text;
                            AuditType.Text = PageAudit.AuditType.ToString();
                            Description.Text = PageAudit.Description.ToString();
                            DateTime.Text = PageAudit.AuditDate.ToString();
                            break;
                        case "App":
                            
                            Table1.Rows[2].Visible = false;
                            AppViewer.Entities.Audit.AuditApp AppAudit = new Entities.Audit.AuditApp();
                            AppAudit = AppViewer.Audit.AppAudit.GetAudit(CurrAudit);
                            AppViewer.Entities.App CurrApp = Business.App.GetApp(AppAudit.AppID);
                            
                            Username.Text = Security.User.GetUser(AppAudit.UserID).Username;
                            AppName.Text = CurrentRow.Cells[2].Text;
                           
                            PageName.Visible = false;
                            AuditType.Text = AppAudit.AuditType.ToString();
                            Description.Text = AppAudit.Description.ToString();
                            DateTime.Text = AppAudit.AuditDate.ToString();
                            break;
                        case "System":
                            Table1.Rows[1].Visible = false;
                            Table1.Rows[2].Visible = false;
                            AppViewer.Entities.Audit.AuditSystem SystemAudit = new Entities.Audit.AuditSystem();
                            SystemAudit = AppViewer.Audit.SystemAudit.GetAudit(CurrAudit);
                            //AuditID.Text = SystemAudit.AuditID.ToString();
                            Username.Text = SystemAudit.AuditType == Entities.Audit.Enums.AuditType.LoginFailed ? "" : Security.User.GetUser(SystemAudit.UserID).Username;
                            AppName.Visible = false;
                            //PageID.Visible = false;
                            PageName.Visible = false;
                            AuditType.Text = SystemAudit.AuditType.ToString();
                            Description.Text = SystemAudit.Description.ToString();
                            DateTime.Text = SystemAudit.AuditDate.ToString();
                            break;
                        case "User":
                            Table1.Rows[3].Visible = false;
                            Table1.Rows[4].Visible = false;
                            AppViewer.Entities.Audit.AuditUser UserAudit = new Entities.Audit.AuditUser();
                            UserAudit = AppViewer.Audit.UserAudit.GetAudit(CurrAudit);
                            //AuditID.Text = SystemAudit.AuditID.ToString();
                            Username.Text = UserAudit.AuditType == Entities.Audit.Enums.AuditType.LoginFailed ? "" : Security.User.GetUser(UserAudit.UserID).Username;
                            AppName.Visible = false;
                            //PageID.Visible = false;
                            PageName.Visible = false;
                            AuditType.Text = UserAudit.AuditType.ToString();
                            Description.Text = UserAudit.Description.ToString();
                            DateTime.Text = UserAudit.AuditDate.ToString();
                            break;
                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "DialogBox()", true);
                    
                    //Response.Redirect("~/Account/AuditDetails.aspx?AuditID=" + AuditID + "&AuditCat=" + SelectedAuditType);
                }
            }
            else
            {
            }
        }

        protected void btnViewAudit_Click(object sender, EventArgs e)
        {


        }





    }
}