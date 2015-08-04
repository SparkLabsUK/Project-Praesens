using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViewer.Entities.Audit.Enums                                                        
{
    public enum AuditType
    {
        LoginFailed = 1,
        LoginPassed = 2,
        AppInsert = 3,
        AppUpdate = 4,
        AppDelete = 5,
        PageInsert = 6,
        PageUpdate = 7,
        PageDelete = 8,
        LinkInsert = 9,
        LinkUpdate = 10,
        LinkDelete = 11,
        Logout = 12
    }
}
