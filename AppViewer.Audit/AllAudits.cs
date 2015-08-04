using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AppViewer.Audit
{
    public class AllAudits
    {
        private static AppViewer.Data.IRepository _repository = AppViewer.Data.RepositoryFactory.CreateInstance();

        public static DataTable GetTop30Audits()
        {
            return _repository.GetTop30Audits();
        }

        public static int GetAppCount()
        {
            return _repository.GetAppCount();
        }
        public static int GetPageCount()
        {
            return _repository.GetPageCount();
        }
        public static int GetUserCount()
        {
            return _repository.GetUserCount();
        }
        public static int GetLinkCount()
        {
            return _repository.GetLinkCount();
        }

    }
}
