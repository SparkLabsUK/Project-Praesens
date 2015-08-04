using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace AppViewer.UI
{
    public partial class AppViewerHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            List<Entities.App> apps = AppViewer.Business.App.GetActiveApps();

            HtmlGenericControl divWrap = new HtmlGenericControl("div");
            int appCounter = 1;

            foreach (AppViewer.Entities.App app in apps)
            {
                if (appCounter == 1)
                {
                    divWrap = new HtmlGenericControl("div");
                    divWrap.Attributes.Add("class", "divWrap");
                }

                HyperLink lnkApp = new HyperLink();
                lnkApp.CssClass = "appSelector";
                lnkApp.NavigateUrl = String.Format("Viewer.aspx?App={0}", app.URL);

                HtmlGenericControl h3 = new HtmlGenericControl("h3");
                h3.InnerText = app.Name;
                lnkApp.Controls.Add(h3);

                if (app.ThumbPageID == -1)
                {
                    List<Entities.Page> pages = Business.Page.GetPages(app);

                    if (pages.Count > 0)
                    {
                        app.ThumbPageID = pages[0].PageID;
                    }
                }

                Image img = new Image();
                img.ImageUrl = app.ThumbPageID == -1 ? "~/Image/DefaultAppImage.png" : String.Format("~/GetImage.ashx?Page={0}&Size=2", app.ThumbPageID);
                img.CssClass = "appSelectorThumb";
                lnkApp.Controls.Add(img);

                HtmlGenericControl pAppDescription = new HtmlGenericControl("p");
                pAppDescription.InnerText = app.Description;
                lnkApp.Controls.Add(pAppDescription);

                divWrap.Controls.Add(lnkApp);

                if (appCounter == 3 || app == apps.Last())
                {
                    HtmlGenericControl divClear = new HtmlGenericControl("div");
                    divClear.Attributes.Add("style", "clear: both;");
                    divWrap.Controls.Add(divClear);
                    divApps.Controls.Add(divWrap);
                    appCounter = 1;
                }
                else
                {
                    appCounter++;
                }
            }
        }
        
    }
}