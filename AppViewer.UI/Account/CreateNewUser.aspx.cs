using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppViewer.UI.Account
{
    public partial class CreateNewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
       
           
        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            Entities.Security.User user = new Entities.Security.User();
            user.Username = txtNewUsername.Text;
            user.Password = txtNewPassword.Text;
            Security.User.Add(user);
            //Audit.SystemAudit.AddAudit("NewUser", txtNewUsername.Text);
            Response.Redirect("Settings.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Settings.aspx");
        }

    }
}
