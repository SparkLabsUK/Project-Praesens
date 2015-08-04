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
    public partial class UpdatePage : System.Web.UI.Page
    {
        int _pageID;
        Entities.Page _page;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["Page"] != null)
            {
                try
                {
                    _pageID = int.Parse(Request.QueryString["Page"]);
                }
                catch (Exception)
                {
                    Response.Redirect("ManageApps.aspx");
                }
            }
            else
            {
                Response.Redirect("ManageApps.aspx");
            }

            _page = Business.Page.GetPage(_pageID);
            Entities.App _app = Business.App.GetApp(_page.AppID);

            if (!Page.IsPostBack && !Page.IsCallback)
            {

                appImageSize.Text = _app.ImgWidth + " x " + _app.ImgHeight;
                
            }
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
            Entities.Page _app = new Entities.Page();
            
        
            int _pageID = int.Parse(Request.QueryString["Page"]);
            page.PageID = int.Parse(Request.QueryString["Page"]);
            page = Business.Page.GetPage(_pageID);
            page.Data = updImage.FileBytes;
           

           
           
            page = Business.Page.UpdatePage(page);
            int NewPageID = page.PageID;
            //Audit.PageAudit.AddAudit("Image", page);
            //int NewPageID = page.ThumbPageID;
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
            Entities.Page page = new Entities.Page();
            Entities.App _app = new Entities.App();
            int _pageID = int.Parse(Request.QueryString["Page"]);
            page.PageID = int.Parse(Request.QueryString["Page"]);
            page = Business.Page.GetPage(_pageID);
            int _AppID = page.AppID;
            _app = Business.App.GetApp(_AppID);


            string PrevApp = _app.Name;
            Response.Redirect("ManagePage.aspx?Page=" + page.PageID);
        }

    }
}
