using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViewer.Data
{
    public static class RepositoryFactory
    {
        private static Enums.DataSourceType _dataSourceType = Enums.DataSourceType.SQL;

        public static IRepository CreateInstance()
        {
            IRepository repository = null;

            switch (_dataSourceType)
            {
                case Enums.DataSourceType.SQL:
                    repository = new RepositorySQL();
                    break;
            }

            return repository;
        }

       
    }
}
