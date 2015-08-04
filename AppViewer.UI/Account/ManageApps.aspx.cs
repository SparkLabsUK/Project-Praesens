using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AppViewer.UI.Account
{
    public partial class ManageApps : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            List<Entities.App> apps = AppViewer.Business.App.GetAppsForUser();

            HtmlGenericControl divWrap = new HtmlGenericControl("div");
            int appCounter = 1;

            foreach (AppViewer.Entities.App app in apps)
            {
                if (appCounter == 1)
                {
                    divWrap = new HtmlGenericControl("div");
                    divWrap.Attributes.Add("style", "width: 1000px;");
                }

                HyperLink lnkApp = new HyperLink();
                lnkApp.CssClass = "appSelector";
                lnkApp.NavigateUrl = String.Format("ManageApp.aspx?App={0}", app.URL);


                if (app.IsActive == true)
                {
                    Image isactive = new Image();
                    isactive.ImageUrl = "~/Image/ActiveStatus.png";
                    isactive.CssClass = "isActive";
                    lnkApp.Controls.Add(isactive);
                }
                else
                {
                }

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
                img.ImageUrl = app.ThumbPageID == -1 ? "~/Image/DefaultAppImage.png" : String.Format("~/GetImage.ashx?Page={0}&size=2", app.ThumbPageID);
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AppViewerHome.aspx");
        }

        protected void lnkManageUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/ManageUsers.aspx");
        }

        protected void lnkManageTeams_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/ManageTeams.aspx");
        }
    }
}