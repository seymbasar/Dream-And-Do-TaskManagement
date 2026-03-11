using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Conrrete.EntityFramework;
using EntityLayer.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ListManager : IListService
    {

        IListDal _listDal;
        public ListManager(IListDal listDal)
        {
            _listDal = listDal;
        }
        public List GetByID(int id)
        {
            return _listDal.Get(x => x.ListID == id);
        }

        public List<List> GetLists()
        {
            return _listDal.List();
        }

        public void ListAdd(List list)
        {
            _listDal.Insert(list);
        }

        public void ListDelete(List list)
        {
            _listDal.Delete(list);
        }

        public void ListUpdate(List list)
        {
            _listDal.Update(list);
        }
    }
}
