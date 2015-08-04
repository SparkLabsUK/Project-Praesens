using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppViewer.UI.Account
{
    public partial class ManageDemo : System.Web.UI.Page
    {
        Entities.App _app;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _app = Business.App.GetApp(Request.QueryString["App"]);

            }
            catch (Exception)
            {

                Response.Redirect("ManageApps.aspx");
            }
        }

        protected void btnBacktoManageApp_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageApp.aspx?App=" + Request.QueryString["App"]);
        }
    }
}