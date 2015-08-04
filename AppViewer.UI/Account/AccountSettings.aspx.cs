using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AppViewer.UI.Account
{
    public partial class AccountSettings : System.Web.UI.Page
    {
   
        Entities.Security.User CurrentUser = new Entities.Security.User();
        protected void Page_Load(object sender, EventArgs e)
        {
           
   


        }
            
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AppViewerHome.aspx");
        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            Entities.Security.User user = Security.User.GetLoggedInUser();
            user.Password = txtOldPass.Text;
            user.NewPassword = txtNewPass.Text;

            if (Security.User.ResetPassword(user))
            {
                lblSuccess.Visible = true;
                lblFail.Visible = false;
            }
            else
            {
                lblFail.Visible = true;
                lblSuccess.Visible = false;
            }

        }
        
    }
}