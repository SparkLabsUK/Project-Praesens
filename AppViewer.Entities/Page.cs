using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViewer.Entities
{
    public class Page
    {
        public int PageID { get; set; }
        public Entities.Enums.PageType PageType { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
        public int AppID { get; set; }
        public string PageNotes { get; set; }
    }
}
