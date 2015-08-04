using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViewer.Security
{
    public static class Team
    {
        private static AppViewer.Data.IRepository _repository = AppViewer.Data.RepositoryFactory.CreateInstance();

        public static Entities.Security.Team GetTeam(Guid TeamID)
        {
            return _repository.GetTeam(TeamID);
        }
    }
}
