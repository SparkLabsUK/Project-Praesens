using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace AppViewer.UI.Account.Service
{
    /// <summary>
    /// Summary description for ManagePage
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ManagePage : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetLink(int linkID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(Business.Link.GetLink(linkID));
        }
        [WebMethod]
        public string GetDevice(int deviceID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(Business.Device.GetDevice(deviceID));
        }
        [WebMethod]
        public string SetThumbPage(int pageID)
        {
            Entities.App app = Business.App.GetApp(Business.Page.GetPage(pageID).AppID);
            app.ThumbPageID = pageID;

            Business.App.SetThumbPage(app);

            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(pageID);
        }
        [WebMethod]
        public string SetFirstPage(int pageID)
        {
            Entities.App app = Business.App.GetApp(Business.Page.GetPage(pageID).AppID);
            app.FirstPageID = pageID;

            Business.App.SetFirstPage(app);

            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(pageID);
        }
    }
}
