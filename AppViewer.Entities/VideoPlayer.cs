using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppViewer.Entities
{
    //[ToolboxData("<{0}:VideoPlayer runat=server></{0}:VideoPlayer>")]
    public class VideoPlayer : WebControl 
    {
        private string _Mp4Url;
        public string Mp4Url
        {
            get { return _Mp4Url; }
            set { _Mp4Url = value; }
        }

        private string _OggUrl = null;
        public string OggUrl
        {
            get { return _OggUrl; }
            set { _OggUrl = value; }
        }

        private string _Poster = null;
        public string PosterUrl
        {
            get { return _Poster; }
            set { _Poster = value; }
        }

        private bool _AutoPlay = false;
        public bool AutoPlay
        {
            get { return _AutoPlay; }
            set { _AutoPlay = value; }
        }

        private bool _Controls = true;
        public bool DisplayControlButtons
        {
            get { return _Controls; }
            set { _Controls = value; }
        }

        private bool _Loop = false;
        public bool Loop
        {
            get { return _Loop; }
            set { _Loop = value; }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.AddAttribute(HtmlTextWriterAttribute.Id, this.ID);
            output.AddAttribute(HtmlTextWriterAttribute.Width, this.Width.ToString());
            output.AddAttribute(HtmlTextWriterAttribute.Height, this.Height.ToString());
            if (DisplayControlButtons == true)
            {
                output.AddAttribute("controls", "controls");
            }
            
            if (PosterUrl != null)
            {
                output.AddAttribute("poster", PosterUrl);
            }
            
            if (AutoPlay == true)
            {
                output.AddAttribute("autoplay", "autoplay");
            }
            
            if (Loop == true)
            {
                output.AddAttribute("loop", "loop");
            }
            
            output.RenderBeginTag("video");
            if (OggUrl != null)
            {
                output.AddAttribute("src", OggUrl);
                output.AddAttribute("type", "video/ogg");
                output.RenderBeginTag("source");
                output.RenderEndTag();
            }

            if (Mp4Url != null)
            {
                output.AddAttribute("src", Mp4Url);
                output.AddAttribute("type", "video/mp4");
                output.RenderBeginTag("source");
                output.RenderEndTag();
            }
            output.RenderEndTag();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            this.RenderContents(writer);
        }
    }
}
