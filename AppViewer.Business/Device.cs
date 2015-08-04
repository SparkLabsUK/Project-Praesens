using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace AppViewer.Business
{
   public static class Device
    {
       private static AppViewer.Data.IRepository _repository = AppViewer.Data.RepositoryFactory.CreateInstance();
        
       public static List<AppViewer.Entities.Device> GetDevices()
        {
            return _repository.GetDevices();
        }

        public static AppViewer.Entities.Device GetDevice(int DeviceID)
        {
            return _repository.GetDevice(DeviceID);
        }
    }
}
