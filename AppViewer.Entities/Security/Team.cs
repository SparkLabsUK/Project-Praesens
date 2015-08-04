using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViewer.Entities.Security
{
    public class Team
    {
        public Guid TeamID { get; set; }
        public string TeamName { get; set; }
        public int TeamTypeID { get; set; }
    }
}
