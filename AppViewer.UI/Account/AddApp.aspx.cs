using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppViewer.UI.Account
{
    public partial class AddApp : System.Web.UI.Page
    {
        public static Entities.Device SelectedItem = new Entities.Device();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateDevices();
        }

        private void PopulateDevices()
        {
            drpDevices.DataSource = Business.Device.GetDevices();
            drpDevices.DataTextField = "Name";
            drpDevices.DataValueField = "DeviceID";
            drpDevices.DataBind();
            drpDevices.Items.Insert(0, new ListItem("Select Device...", "-1"));
        }

        protected void btnAddApp_Click(object sender, EventArgs e)
        {
            Entities.App app = new Entities.App();
            app.Name = txtAppName.Text;
            app.Description = txtAppDescription.Text;
            app.URL = txtAppUrl.Text;
            app.FullscreenSize = int.Parse(txtFull.Text);
            app.ImgHeight = int.Parse(txtDeviceHeight.Text);
            app.ImgWidth = int.Parse(txtDeviceWidth.Text);
            //QUICK FIX
            app.AppType = Entities.Enums.AppType.Application;

            Business.App.AddApp(app);
            
            Response.Redirect("ManageApp.aspx?App=" + txtAppUrl.Text);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageApps.aspx");
        }
    }
}
