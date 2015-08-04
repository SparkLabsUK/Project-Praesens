using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViewer.Entities.Audit
{
    public class AuditApp
    {
        public Guid AuditID { get; set; }
        public Enums.AuditType AuditType { get; set; }
        public DateTime AuditDate { get; set; }
        public Guid UserID { get; set; }
        public int AppID {get;set;}
        public string Description { get; set; }
    }
}
