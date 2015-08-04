using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppViewer.UI
{
    /// <summary>
    /// Summary description for GetImage
    /// </summary>
    public class GetImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int pageID;
            AppViewer.Entities.Enums.ImageSize size;

            if (context.Request.QueryString["Page"] != null)
                pageID = int.Parse(context.Request.QueryString["Page"]);
            else
                throw new ArgumentException("No parameter specified");

            if (context.Request.QueryString["Size"] != null)
                size = (AppViewer.Entities.Enums.ImageSize)int.Parse(context.Request.QueryString["Size"]);
            else
                throw new ArgumentException("No parameter specified");

            AppViewer.Entities.Page page = AppViewer.Business.Page.GetPageImage(pageID, size);

            if (page != null && page.Data.Length > 0)
            {
                context.Response.ContentType = "image/png";
                context.Response.BinaryWrite(page.Data);
            }

        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}