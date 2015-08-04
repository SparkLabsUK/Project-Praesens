using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppViewer.UI.Account
{
    public partial class AppWizardStep1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateAppType();
            if (!Page.IsPostBack && !Page.IsCallback)
            {
                hdnAppType.Value = "-1";
            }
        }

        private void PopulateAppType()
        {
            drpAppType.DataSource = Business.App.GetAppTypes();
            drpAppType.DataTextField = "Description";
            drpAppType.DataValueField = "AppTypeID";
            drpAppType.DataBind();
            drpAppType.Items.Insert(0, new ListItem("Select App Type...", "-1"));
        }

        protected void btnAddAppWizard_Click(object sender, EventArgs e)
        {
            Entities.AppWizard appWizard = new Entities.AppWizard();
            Entities.App app = new Entities.App();

            app.Name = txtName.Text;
            app.Description = txtDescription.Text;
            app.URL = txtURL.Text;

                app.AppType = (Entities.Enums.AppType)int.Parse(hdnAppType.Value);

            appWizard.App = app;

            appWizard = Business.App.AddAppWizard(appWizard);



            Response.Redirect("AppWizardStep2.aspx?AppWizardID=" + appWizard.AppWizardID);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageApps.aspx");
        }
    }
}
