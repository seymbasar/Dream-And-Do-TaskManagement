using DataAccessLayer.Abstract;
using DataAccessLayer.Conrrete.Repositories;
using EntityLayer.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Conrrete.EntityFramework
{
    public class EfListDal:GenericRepository<List>, IListDal
    {
    }
}
