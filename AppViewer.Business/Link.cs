using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViewer.Business
{
    public static class Link
    {
        private static AppViewer.Data.IRepository _repository = AppViewer.Data.RepositoryFactory.CreateInstance();

        public static void Add(AppViewer.Entities.Link link)
        {
            _repository.AddLink(link);
        }

        public static void Save(AppViewer.Entities.Link link)
        {
            _repository.SaveLink(link);
        }

        public static void Delete(AppViewer.Entities.Link link)
        {
            _repository.DeleteLink(link);
        }

        public static AppViewer.Entities.Link GetLink(int linkID)
        {
            return _repository.GetLink(linkID);
        }

        public static List<AppViewer.Entities.Link> GetLinks(Entities.Page page)
        {
            return _repository.GetLinks(page);
        }

        public static List<AppViewer.Entities.Transition> GetLinkTransitions()
        {
            return _repository.GetLinkTransitions();
        }

    }
}

