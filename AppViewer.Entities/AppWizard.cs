using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViewer.Entities
{
    public class AppWizard
    {
        public Guid AppWizardID { get; set; }
        public Entities.App App { get; set; }
    }
}
