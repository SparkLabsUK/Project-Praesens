using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViewer.Entities
{
    public class Audit
    {
        public int AuditID { get; set; }
        public Enums.AuditType AuditType { get; set; }
        public DateTime AuditTime { get; set; }
        public string AuditDetails { get; set; }
        public int UserID { get; set; }
    }
}
