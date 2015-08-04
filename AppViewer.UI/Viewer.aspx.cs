using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace AppViewer.UI
{
    public partial class Viewer : System.Web.UI.Page
    {
        public Entities.App app;
        private bool _isVideo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && !Page.IsCallback)
            {
                if (Request.QueryString["App"] == null)
                {
                    string strErr = "You have not selected an app!";
                    ClientScript.RegisterStartupScript(GetType(), "AppError", "javascript: alert('" + strErr + "'); ", true);
                    return;
                }
            }

            // get app
           app = Business.App.GetApp(Request.QueryString["App"]);
            List<Entities.Page> pages = Business.Page.GetPages(app);

            _isVideo = app.AppType == Entities.Enums.AppType.Application && pages.Count == 1 && pages[0].PageType == Entities.Enums.PageType.Video;

            if (!Page.IsPostBack && !Page.IsCallback)
            {
                chkShowLinks.Checked = app.ShowLinks;

                bool isLoggedIn = (System.Web.HttpContext.Current.User != null) &&
                            System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

                if (isLoggedIn)
                {
                    //divManageApp.Visible = Security.User.GetLoggedInUser() != new Entities.Security.User();
                    appImageSize.Text = "Image size: " + app.ImgWidth + " x " + app.ImgHeight;
                }
                else
                {
                    tdManApp.Visible = false;
                    tdManPage.Visible = false;
                    tdImgSize.Visible = false;
                }
                
            }

            if (_isVideo)
            {
                Entities.VideoPlayer videoPlayer = new Entities.VideoPlayer();
                videoPlayer.Mp4Url = "Video/OfficeVideo.mp4";
                videoPlayer.AutoPlay = true;

                app.ImgWidth = 960;
                app.ImgHeight = 540;

                string marginCenter = "margin: 0 auto; ";

                imgViewer.Attributes.Add("style", String.Format("width: {0}px; height: {1}px; overflow: hidden;", app.ImgWidth, app.ImgHeight));
                imgContainer.Attributes.Add("style", String.Format("width: {0}px; height: {1}px; position: relative; background-repeat: no-repeat; overflow: hidden; margin: 0 0 0 0;", app.ImgWidth, app.ImgHeight));
                imgIphone.Attributes.Add("style", String.Format("width: {0}px; height: {1}px; {2}border: 25px solid #000000; border-radius: 25px; margin-top: 35px; margin-bottom: 20px;", app.ImgWidth, app.ImgHeight, marginCenter));

                imgContainer.Controls.Add(videoPlayer);
            }
            else
            {
                AddPages(pages);
            }
        }

        private void AddPages(List<Entities.Page> pages)
        {
            string marginCenter = "margin: 0 0 20px 20px; ";

            if (app.ImgWidth < 1000)
            {
                marginCenter = "margin: 0 auto; ";
            }

            imgViewer.Attributes.Add("style", String.Format("width: {0}px; height: {1}px; overflow: hidden;", app.ImgWidth, app.ImgHeight));
            imgContainer.Attributes.Add("style", String.Format("width: {0}px; height: {1}px; position: relative; background-repeat: no-repeat; overflow: hidden; margin: -{2}px 0 0 -{3}px;", app.ImgWidth * 3, app.ImgHeight * 3, app.ImgHeight, app.ImgWidth));
            imgIphone.Attributes.Add("style", String.Format("width: {0}px; height: {1}px; {2}border: 25px solid #000000; border-radius: 25px; margin-top: 35px; margin-bottom: 20px;", app.ImgWidth, app.ImgHeight, marginCenter));

            // parse through each page

            if (pages.Count == 0)
            {
                HtmlGenericControl defaultImgDiv = new HtmlGenericControl("div");
                defaultImgDiv.Attributes.Add("style", String.Format("width: {0}px; height: {1}px; background-color: #FFF; text-align: center; position: absolute; top: {1}px; left: {0}px;", app.ImgWidth, app.ImgHeight));

                defaultImgDiv.InnerHtml = app.Instructions;

                HtmlGenericControl defaultImg = new HtmlGenericControl("div");

                defaultImg.Attributes.Add("style", String.Format("display: block; width: 200px; height: 355px; background-image: url(Image/DefaultAppImage.png); margin: {0}px 0 0 {1}px;", (app.ImgHeight / 2) - 177, (app.ImgWidth / 2) - 100));
                //btnContinueLink.OnClientClick = String.Format("doTransition('{0}', {1}, {2}); setPageNotes({3}); $('#hdnPageID').val({3}); return false;", insDiv.ID, firstPage.PageID, 6, firstPage.PageID);
                //btnContinueLink.CssClass = "buttongrey";
                //btnContinueLink.Text = "Continue";
                defaultImgDiv.Controls.Add(defaultImg);

                imgContainer.Controls.Add(defaultImgDiv);

                lnkManagePage.Enabled = false;
                return;
            }
            else
            {
                HtmlGenericControl overlayDiv = new HtmlGenericControl("div");
                overlayDiv.Attributes.Add("style", String.Format("width: {0}px; height: {1}px; position: absolute; top: {2}px; left: {3}px; display: none; z-index: 4;", app.ImgWidth, app.ImgHeight, app.ImgHeight, app.ImgWidth * 2));

                overlayDiv.ID = "OverlayDiv";
                overlayDiv.ClientIDMode = System.Web.UI.ClientIDMode.Static;

                imgContainer.Controls.Add(overlayDiv);
            }

            Entities.Page firstPage = app.FirstPageID == -1 ? pages.First() : pages.Where(p => p.PageID == app.FirstPageID).First();

            if (Request.QueryString["Page"] != null)
            {
                if (pages.Any(p => p.PageID == int.Parse(Request.QueryString["Page"])))
                {
                    firstPage = pages.First(p => p.PageID == int.Parse(Request.QueryString["Page"]));
                }
            }

            if (!Page.IsPostBack && !Page.IsCallback)
            {
                if (hdnPageID != null)
                {
                    hdnPageID.Value = firstPage.PageID.ToString();
                }

            }

            if (app.ShowInstructions)
            {
                HtmlGenericControl insDiv = new HtmlGenericControl("div");
                insDiv.Attributes.Add("style", String.Format("width: {0}px; height: {1}px; background-color: #efefef; text-align: center; padding: 20px; position: absolute; top: {2}px; left: {3}px; word-wrap: break-word;", app.ImgWidth - 40, app.ImgHeight - 40, app.ImgHeight, app.ImgWidth));

                insDiv.InnerHtml = app.Instructions;

                insDiv.ID = "InsDiv";
                insDiv.ClientIDMode = System.Web.UI.ClientIDMode.Static;

                LinkButton btnContinueLink = new LinkButton();

                btnContinueLink.Attributes.Add("style", String.Format("display: block; position: absolute; top: {0}px; left: {1}px;", app.ImgHeight - 100, (app.ImgWidth / 2) - 35));
                btnContinueLink.OnClientClick = String.Format("doTransition('{0}', {1}, {2}); setPageNotes({3}); $('#hdnPageID').val({3}); return false;", insDiv.ID, firstPage.PageID, 6, firstPage.PageID);
                btnContinueLink.CssClass = "buttongrey";
                btnContinueLink.Text = "Continue";
                insDiv.Controls.Add(btnContinueLink);

                imgContainer.Controls.Add(insDiv);

            }

            foreach (Entities.Page page in pages)
            {
                HtmlGenericControl pageDiv = new HtmlGenericControl("div");
                pageDiv.Attributes.Add("class", "pagedivclass");

                // get links for page
                List<Entities.Link> links = Business.Link.GetLinks(page);


                if (firstPage == page && app.ShowInstructions == false)
                {
                    pageDiv.Attributes.Add("style", String.Format("width: {0}px; height: {1}px; background-image: url(~/GetImage.ashx?Page={2}&Size=2); background-size:contain; background-repeat: no-repeat; position: absolute; top: {1}px; left: {0}px;", app.ImgWidth, app.ImgHeight, page.PageID));
                    if (page.PageNotes != "")
                    {
                        txtPageNotes.Text = page.PageNotes.ToString();
                    }
                    else
                    {

                        txtPageNotes.Visible = false;
                    }
                }
                else
                {
                    pageDiv.Attributes.Add("style", String.Format("width: {0}px; height: {1}px; overflow: hidden; background-image: url(~/GetImage.ashx?Page={2}&Size=2); background-size:contain; background-repeat: no-repeat; position: absolute; top: {1}px; left: {3}px; display: none;", app.ImgWidth, app.ImgHeight, page.PageID, app.ImgWidth * 2));
                }

                pageDiv.ID = "Page" + page.PageID;
                pageDiv.ClientIDMode = System.Web.UI.ClientIDMode.Static;

                AddLinksToPage(ref pageDiv, links, app);

                imgContainer.Controls.Add(pageDiv);

            }
        }

        private void AddLinksToPage(ref HtmlGenericControl pageDiv, List<Entities.Link> links, Entities.App app)
        {
            LinkButton btnLink = new LinkButton();

            foreach (Entities.Link link in links)
            {
                btnLink = new LinkButton();

                if (app.ShowLinks)
                {
                    string backgroundColour = "";
                    
                    if (app.ShowLinkBackground)
                    {
                        backgroundColour = String.Format(" background-color: #{0}; opacity: 0.2;", app.LinkBackgroundColour);
                    }

                    btnLink.Attributes.Add("style", "display: block; position: absolute; " + String.Format("top: {0}px; left: {1}px; width: {2}px; height: {3}px; border: 1px solid #{4};{5}", link.Ycoordinate, link.Xcoordinate, link.Width, link.Height, app.LinkColour, backgroundColour));
                }
                else 
                { 
                btnLink.Attributes.Add("style", "display: block; position: absolute; " + String.Format("top: {0}px; left: {1}px; width: {2}px; height: {3}px;", link.Ycoordinate, link.Xcoordinate, link.Width, link.Height));
                }

                btnLink.OnClientClick = String.Format("doTransition('{0}', {1}, {2}); setPageNotes({3}); $('#hdnPageID').val({3}); return false;", pageDiv.ID, link.ToPageID, (int)link.Transition, link.ToPageID);
                btnLink.CssClass = "alink";

                pageDiv.Controls.Add(btnLink);
            }
        }

        protected void lnkManageApp_Click(object sender, EventArgs e)
        {
            Response.Redirect("Account/ManageApp.aspx?App=" + Request.QueryString["App"]);
        }

        protected void lnkBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AppViewerHome.aspx");
        }

        public string GetPageNotes()
        {
            List<PageNote> pageNotes = new List<PageNote>();

            // get app
            Entities.App app = Business.App.GetApp(Request.QueryString["App"]);

            // parse through each page
            List<Entities.Page> pages = Business.Page.GetPages(app);

            foreach (Entities.Page page in pages)
            {
                PageNote pn = new PageNote();
                pn.ID = page.PageID;
                pn.Note = page.PageNotes;
                pageNotes.Add(pn);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(pageNotes);
        }

        public string GetApp()
        {
            // get app
            Entities.App app = Business.App.GetApp(Request.QueryString["App"]);
            Entities.App jsApp = new Entities.App();

            jsApp.ImgWidth = app.ImgWidth;
            jsApp.ImgHeight = app.ImgHeight;
            jsApp.FullscreenSize = app.FullscreenSize;
            jsApp.LinkColour = app.LinkColour;
            jsApp.LinkBackgroundColour = app.LinkBackgroundColour;

            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(jsApp);
        }

        protected void lnkManagePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Account/ManagePage.aspx?Page=" + hdnPageID.Value);
        }

        protected void lnkMobile_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Response.Redirect("~/mViewer.aspx?App=" + Request.QueryString["App"]);
            }
        }
    }

    public class PageNote
    {
        public int ID;
        public string Note;
    }
}




