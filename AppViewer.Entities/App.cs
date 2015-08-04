using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViewer.Entities
{
    public class App
    {
        public int AppID { get; set; }
        public Entities.Enums.AppType AppType { get; set; }
        public int AppTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public bool IsActive { get; set; }
        public int ThumbPageID { get; set; }
        public int FirstPageID { get; set; }
        public List<Page> Pages { get; set; }
        public bool ShowLinks { get; set; }
        public string LinkColour { get; set; }
        public bool ShowInstructions { get; set; }
        public string Instructions { get; set; }
        public bool ShowLinkBackground { get; set; }
        public string LinkBackgroundColour { get; set; }
        public int ImgWidth { get; set; }
        public int ImgHeight { get; set; }
        public int FullscreenSize { get; set; }
    }
}
