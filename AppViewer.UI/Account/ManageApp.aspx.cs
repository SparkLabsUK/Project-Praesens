using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AppViewer.UI.Account
{
    public partial class EditApp : System.Web.UI.Page
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

           //AuditGrid.DataSource = AppViewer.Audit.AppAudit.GetAuditAppForApp(_app.AppID);
            //AuditGrid.DataBind();
            //if (AuditGrid.Rows.Count == 0)
            //{
            //    lblNoChanges.Visible = true;
            //}

            if (!Page.IsPostBack && !Page.IsCallback)
            {
                txtAppName.Text = _app.Name;
                txtAppDescription.Text = _app.Description;
                txtAppUrl.Text = _app.URL;
                chkLive.Checked = _app.IsActive;
                chkShowLinks.Checked = _app.ShowLinks;
                txtLinkColour.Text = _app.LinkColour;
                chkShowInstructions.Checked = _app.ShowInstructions;
                txtInstructions.Text = _app.Instructions;
                chkShowLinkBackground.Checked = _app.ShowLinkBackground;
                txtLinkBackgroundColour.Text = _app.LinkBackgroundColour;
                appImageSize.Text = _app.ImgWidth + " x " + _app.ImgHeight;

                {
                    switch (Security.SecurityAccess.GetSecurityAccessForUserForApp(_app))
                    {
                        case AppViewer.Entities.Security.Enums.AccessType.ReadOnly:
                            txtAppName.Enabled = false;
                            txtAppDescription.Enabled = false;
                            txtAppUrl.Enabled = false;
                            chkLive.Enabled = false;
                            chkShowLinks.Enabled = false;
                            txtLinkColour.Enabled = false;
                            chkShowInstructions.Enabled = false;
                            txtInstructions.Enabled = false;
                            chkShowLinkBackground.Enabled = false;
                            txtLinkBackgroundColour.Enabled = false;
                            appImageSize.Enabled = false;
                            lnkAppDelete.Visible = false;
                            btnAddPage.Visible = false;
                            btnSaveApp.Visible = false;
                            h1PageHeader.InnerText = "View App";
                            pPageInstructions.InnerText = "";
                            break;
                        case AppViewer.Entities.Security.Enums.AccessType.Edit:
                            break;
                        case AppViewer.Entities.Security.Enums.AccessType.NoAccess:
                        default:
                            Response.Redirect("~/AppViewerHome.aspx");

                            break;
                    }
                }
            }

            PopulatePages();
        }

        private void PopulatePages()
        {
            List<Entities.Page> pages = Business.Page.GetPages(_app);

            btnPreview.Enabled = pages.Count > 0;

            foreach (Entities.Page page in pages)
            {
                HyperLink lnkApp = new HyperLink();
                lnkApp.CssClass = "pageSelector";
                lnkApp.NavigateUrl = String.Format("ManagePage.aspx?Page={0}", page.PageID);

                HtmlGenericControl h3 = new HtmlGenericControl("h3");
                h3.InnerText = page.Name;
                lnkApp.Controls.Add(h3);

                Image img = new Image();
                img.ImageUrl = String.Format("~/GetImage.ashx?Page={0}&size=2", page.PageID);
                img.CssClass = "pageSelectorThumb";
                lnkApp.Controls.Add(img);

                pageContainer.Controls.Add(lnkApp);
            }
        }

        protected void btnSaveApp_Click(object sender, EventArgs e)
        {
            // User Privilages Check ---
            Entities.Security.User CurrentUser = new Entities.Security.User();
            Entities.App app = new Entities.App();
            app.AppID = _app.AppID;
            app.Name = txtAppName.Text;
            app.Description = txtAppDescription.Text;
            app.URL = txtAppUrl.Text;
            app.IsActive = chkLive.Checked;
            app.ShowLinks = chkShowLinks.Checked;
            app.LinkColour = txtLinkColour.Text;
            app.ShowInstructions = chkShowInstructions.Checked;
            app.Instructions = txtInstructions.Text;
            app.ShowLinkBackground = chkShowLinkBackground.Checked;
            app.LinkBackgroundColour = txtLinkBackgroundColour.Text;
            app.ThumbPageID = _app.ThumbPageID;
            app.FirstPageID = _app.FirstPageID;

            Business.App.SaveApp(app);
            
            Response.Redirect("ManageApps.aspx");


        }

        protected void btnAddPage_Click(object sender, EventArgs e)
        {

            Response.Redirect("AddPage.aspx?App=" + _app.URL);



        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Viewer.aspx?App=" + _app.URL);
        }
        protected void btnDeleteApp_Click(object sender, EventArgs e)
        {
            Business.App.DeleteApp(_app);
            Response.Redirect("ManageApps.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageApps.aspx");
        }

        protected void btnDemoCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageDemo.aspx?App=" + _app.URL);
        }

        protected void btnPopup_Click(object sender, EventArgs e)
        {
            
        }
    }
}
