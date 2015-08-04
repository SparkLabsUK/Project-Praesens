using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.IO;


namespace AppViewer.UI.Account
{
    public partial class AddPage : System.Web.UI.Page
    {
        Entities.App _app;

        protected void Page_Load(object sender, EventArgs e)
        {
            _app = Business.App.GetApp(Request.QueryString["App"]);
            appImageSize.Text = _app.ImgWidth + " x " + _app.ImgHeight;
        }

        protected void btnAddPage_Click(object sender, EventArgs e)
        {
            // validation

            if (!updImage.HasFile)
            {
                // show error messgae
                lblPageImage.Visible = true;

                return;
            }

            Entities.Page page = new Entities.Page();
            page.Name = txtPageName.Text;
            page.Data = updImage.FileBytes;
            page.PageNotes = txtPageNotes.Text;
            //QUICK FIX
            page.PageType = Entities.Enums.PageType.Image;
            // page.AppID = int.Parse(Request.QueryString["App"]);

            _app = Business.App.GetApp(Request.QueryString["App"]);
            page.AppID = _app.AppID;
            page = Business.Page.Add(page);
            int NewPageID = page.PageID;
            try
            {
                HyperLink lnkApp = new HyperLink();
                lnkApp.CssClass = "pageSelector";
                Response.Clear();
                Response.Redirect("ManagePage.aspx?Page=" + NewPageID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            string PrevApp = Request.QueryString["App"];
            Response.Redirect("ManageApp.aspx?App=" + PrevApp);
        }

    }
}