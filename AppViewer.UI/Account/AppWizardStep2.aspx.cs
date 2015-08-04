using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppViewer.UI.Account
{
    public partial class AppWizardStep2 : System.Web.UI.Page
    {
        
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageApps.aspx");
        }

        protected void btnImage_Click(object sender, EventArgs e)
        {
            fileImageUploader.Visible = true;
            btnImageUpload.Visible = true;
            lnkImage.Visible = true;
        }

        protected void btnVideo_Click(object sender, EventArgs e)
        {
            fileVideoUploader.Visible = true;
            btnVideoUpload.Visible = true;
            lnkVideo.Visible = true;
        }

        protected void btnPowerpoint_Click(object sender, EventArgs e)
        {
            filePowerpointUploader.Visible = true;
            btnPowerpointUpload.Visible = true;
            lnkPowerpoint.Visible = true;
        }

        protected void lnkImage_Click(object sender, EventArgs e)
        {
            fileImageUploader.Visible = false;
            btnImageUpload.Visible = false;
            lnkImage.Visible = false;
        }

        protected void lnkVideo_Click(object sender, EventArgs e)
        {
            fileVideoUploader.Visible = false;
            btnVideoUpload.Visible = false;
            lnkVideo.Visible = false;
        }

        protected void lnkPowerpoint_Click(object sender, EventArgs e)
        {
            filePowerpointUploader.Visible = false;
            btnPowerpointUpload.Visible = false;
            lnkPowerpoint.Visible = false;
        }
    }
}
