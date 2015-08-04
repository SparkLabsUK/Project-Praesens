using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppViewer.UI.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtUsername.Focus();

                if (Session["User"] != null)
                {
                    Audit.SystemAudit.AddAudit(Entities.Audit.Enums.AuditType.Logout, Security.User.GetLoggedInUser());
                    FormsAuthentication.SignOut();
                    Session.Abandon();
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Entities.Security.User user = new Entities.Security.User();
            user.Username = txtUsername.Text;
            user.Password = txtPassword.Text;

            Entities.Enums.LoginResult loginResult = AppViewer.Security.User.Login(user);

            if (loginResult == Entities.Enums.LoginResult.LoginPassed)
            {
                Response.Redirect("ManageApps.aspx", false);
            }
            else
            {
                loginErrorBox.Visible = true;
                txtPassword.Focus();
                //FailedLogins = +1;
                //if (FailedLogins >= 3)
                //{
                //    Audit.SystemAudit.AddAudit("FailedLogin", txtUsername.Text);
                //}
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AppViewerHome.aspx");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/CreateNewUser.aspx");
        }

    }
}
