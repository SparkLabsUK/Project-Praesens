using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViewer.Entities.Security
{
    public class SecurityAccess
    {
        public Guid AccessID { get; set; }
        public int AppID { get; set; }
        public int accessTypeID { get; set; }
    }
}
