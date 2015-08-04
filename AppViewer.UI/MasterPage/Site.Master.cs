using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppViewer.UI.MasterPage
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack && !Page.IsCallback)
            {
                if (Session["User"] == null && Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    FormsAuthentication.SignOut();
                    Session.Abandon();
                    Response.Redirect(Request.Url.ToString());
                }

                if (Request.Browser.IsMobileDevice == true)
                {
                    LoginView1.Visible = false;

                }
                else
                {
                    bool isLoggedIn = (System.Web.HttpContext.Current.User != null) &&
                            System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

                    if (isLoggedIn)
                    {
                        ((Label)LoginView1.FindControl("lblUsersName")).Text = Security.User.GetLoggedInUser().FullName;
                        Entities.Security.User CurrentUser = Security.User.GetLoggedInUser();
                        if (CurrentUser.UserType == Entities.Security.Enums.UserType.SuperUser)
                        {
                            ((LinkButton)LoginView1.FindControl("lnkAudits")).Visible = true;
                        }
                        else
                        {
                            ((LinkButton)LoginView1.FindControl("lnkAudits")).Visible = false;
                        }
                    }
                }
            }
        }

        protected void Settings_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/AccountSettings.aspx");
        }

        protected void lnkAudits_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/AuditsHome.aspx");
        }
    }
}