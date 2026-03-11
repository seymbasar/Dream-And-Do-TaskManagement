using EntityLayer.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IListService
    {
        void ListAdd(List list);
        void ListDelete(List list);
        void ListUpdate(List list);
        List<List> GetLists();
        List GetByID(int id);
    }
}
