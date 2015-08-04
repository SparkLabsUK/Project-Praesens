using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace AppViewer.UI.Account
{
    public partial class ManagePage : System.Web.UI.Page
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

            AuditGrid.DataSource = AppViewer.Audit.PageAudit.GetAuditPageForPage(_pageID);
            AuditGrid.DataBind();
            if (AuditGrid.Rows.Count == 0)
            {
                lblNoChanges.Visible = true;
            }

            _page = Business.Page.GetPage(_pageID);
            Entities.App _app = Business.App.GetApp(_page.AppID);

            if (!Page.IsPostBack && !Page.IsCallback)
            {
                switch (Security.SecurityAccess.GetSecurityAccessForUserForApp(_app))
                {
                    case AppViewer.Entities.Security.Enums.AccessType.ReadOnly:
                        lstLinks.Enabled = false;
                        drpTransition.Enabled = false;
                        drpTransitionToPage.Enabled = false;
                        btnSetAsThumbnail.Enabled = false;
                        btnSetAsFirstPage.Enabled = false;
                        btnSaveNotes.Visible = false;
                        btnChange.Visible = false;
                        btnDelete.Visible = false;
                        btnDeleteLink.Visible = false;
                        btnSaveLink.Visible = false;
                        lnkAdd.Visible = false;
                        txtHeight.Enabled = false;
                        txtPageNotes.Enabled = false;
                        txtWidth.Enabled = false;
                        txtX.Enabled = false;
                        txtY.Enabled = false;
                        h1PageHeader.InnerText = "View Page";
                        break;
                    case AppViewer.Entities.Security.Enums.AccessType.Edit:
                        break;
                    case AppViewer.Entities.Security.Enums.AccessType.NoAccess:
                    default:

                        break;
                }
            }

            imgContainer.Attributes.Add("style", String.Format("width: {0}px; height: {1}px; background-image: url(~/GetImage.ashx?Page={2}&Size=2); background-size:contain; background-repeat: no-repeat; position: absolute; top: {1}px; left: {0}px;", _app.ImgWidth, _app.ImgHeight, _page.PageID));
            
            lstLinks.Items.Clear();
            lstLinks.ClearSelection();
            drpTransition.DataTextField = "Name";
            drpTransition.DataValueField = "TransitionID";
            drpTransition.DataSource = Business.Link.GetLinkTransitions();
            drpTransition.DataBind();
            drpTransitionToPage.DataTextField = "Name";
            drpTransitionToPage.DataValueField = "PageID";

            List<Entities.Page> pages = Business.Page.GetPages(Business.App.GetApp(Business.Page.GetPage(_pageID).AppID));

            drpTransitionToPage.DataSource = pages.Where(i => i.PageID != _pageID).ToList();
            drpTransitionToPage.DataBind();

            if (!this.Page.IsPostBack && !this.Page.IsCallback)
            {
                PopulateLinks();
                drpTransitionToPage.SelectedIndex = 0;
                drpTransition.SelectedIndex = 0;
                txtPageNotes.Text = _page.PageNotes.ToString();
                h2PageName.InnerText = _page.Name;
                manPageSize.Text = "Image size: " + _app.ImgWidth + " x " + _app.ImgHeight;

                Entities.App app = Business.App.GetApp(Business.Page.GetPage(_pageID).AppID);
                imgSizeContainer.Attributes.Add("style", String.Format("width: {0}px; height: {1}px; overflow: hidden; border: 1px solid #aaaaaa;", app.ImgWidth, app.ImgHeight));
                imgOuterContainer.Attributes.Add("style", String.Format("width: {0}px; height: {1}px; position: relative; overflow: hidden; margin: -{2}px 0 0 -{3}px;", app.ImgWidth * 3, app.ImgHeight * 3, app.ImgHeight, app.ImgWidth));

                if (_pageID == app.ThumbPageID)
                {
                    btnSetAsThumbnail.Enabled = false;
                    btnSetAsThumbnail.Text = "Current Thumbnail";
                }
                else
                {
                    btnSetAsThumbnail.OnClientClick = String.Format("SetThumbPage({0}, this); return false;", _page.PageID);
                }

                if (_pageID == app.FirstPageID)
                {
                    btnSetAsFirstPage.Enabled = false;
                    btnSetAsFirstPage.Text = "Current First Page";
                }
                else
                {
                    btnSetAsFirstPage.OnClientClick = String.Format("SetFirstPage({0}, this); return false;", _page.PageID);
                }
            }  
        }

        protected void PopulateLinks()
        {
            List<Entities.Link> links = Business.Link.GetLinks(Business.Page.GetPage(_pageID));

            HtmlGenericControl linkDiv = new HtmlGenericControl("div");
            LinkButton btnLink = new LinkButton();

            foreach (Entities.Link link in links)
            {
                linkDiv = new HtmlGenericControl("div");
                btnLink = new LinkButton();

                linkDiv.Attributes.Add("style", "display: block; position: absolute; margin: -2px 0 0 -2px; border-width: 2px; border-style: solid; border-color: blue; " + String.Format("top: {0}px; left: {1}px; width: {2}px; height: {3}px;", link.Ycoordinate, link.Xcoordinate, link.Width, link.Height));
                btnLink.Attributes.Add("style", "display: block; width: 100%; height: 100%; background-color: #006EFF; opacity: 0;");
                btnLink.OnClientClick = String.Format("$('#lstLinks').val({0}); SelectLink({0}); return false;", link.LinkID);

                linkDiv.Attributes.Add("class", "alinkdiv");
                btnLink.CssClass = "alink";

                linkDiv.ID = "LinkDiv" + link.LinkID;
                btnLink.ID = "Link" + link.LinkID;
                btnLink.ClientIDMode = System.Web.UI.ClientIDMode.Static;

                linkDiv.Controls.Add(btnLink);
                imgContainer.Controls.Add(linkDiv);
            }

            lstLinks.DataTextField = "LinkName";
            lstLinks.DataValueField = "LinkID";
            lstLinks.DataSource = links;
            lstLinks.DataBind();

            txtX.Text = "";
            txtY.Text = "";
            txtWidth.Text = "";
            txtHeight.Text = "";

            if (drpTransitionToPage.Items.Count > 0)
            {
                hdnDrpTranstoPage.Value = drpTransitionToPage.Items[0].Value;
            }
            else
            {
                btnSaveLink.Enabled = false;
            }

            hdnTransition.Value = drpTransition.Items[0].Value;
            hdnSelectedLink.Value = "-1";
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            Entities.Link link = new Entities.Link();

            link.PageID = _pageID;
            link.Xcoordinate = int.Parse(txtX.Text);
            link.Ycoordinate = int.Parse(txtY.Text);
            link.Width = int.Parse(txtWidth.Text);
            link.Height = int.Parse(txtHeight.Text);
            link.Transition = (Entities.Enums.Transition)int.Parse(hdnTransition.Value);
            link.ToPageID = int.Parse(hdnDrpTranstoPage.Value);

            if (hdnSelectedLink.Value != "-1")
            {
                link.LinkID = int.Parse(hdnSelectedLink.Value);
                Business.Link.Save(link);
                //Audit.PageAudit.AddAudit("LinkModified", _page);
            }
            else
            {
                Business.Link.Add(link);
                //Audit.PageAudit.AddAudit("LinkAdded", _page);
            }

            PopulateLinks();
        }

        protected void btnDeleteLink_Click(object sender, EventArgs e)
        {
            Entities.Link link = new Entities.Link();
            link.LinkID = int.Parse(hdnSelectedLink.Value);
            Business.Link.Delete(link);
            PopulateLinks();
             _page = Business.Page.GetPage(_pageID);
             //Audit.PageAudit.AddAudit("LinkDelete", _page);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            _pageID = int.Parse(Request.QueryString["Page"]);
            string PrevApp =
            Business.App.GetApp(Business.Page.GetPage(_pageID).AppID).URL;
            Response.Redirect("ManageApp.aspx?App=" + PrevApp);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string PrevApp = Business.App.GetApp(Business.Page.GetPage(_pageID).AppID).URL;
            _pageID = int.Parse(Request.QueryString["Page"]);
            Entities.Page page = new Entities.Page();
            page.PageID = _pageID;
            Business.Page.Delete(page);
            Response.Redirect("ManageApp.aspx?App=" + PrevApp);

        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            _pageID = int.Parse(Request.QueryString["Page"]);
            Response.Redirect("UpdatePage.aspx?Page=" + _pageID.ToString());
        }

        protected void btnSaveNotes_Click(object sender, EventArgs e)
        {
            _page.PageNotes = txtPageNotes.Text;
            Business.Page.UpdatePageNotes(_page);
            PopulateLinks();
            //Audit.PageAudit.AddAudit("Notes", _page);
        }

        protected void btnBackToViewer_Click(object sender, EventArgs e)
        {
            _pageID = int.Parse(Request.QueryString["Page"]);
            string PrevApp =
            Business.App.GetApp(Business.Page.GetPage(_pageID).AppID).URL;
            string ViewerURL = "../Viewer.aspx?App=" + PrevApp.ToString() + "&Page=" + _pageID;
            Response.Redirect(ViewerURL);
        }

        protected void btnChanges_Click(object sender, EventArgs e)
        {

        }

    }
}


