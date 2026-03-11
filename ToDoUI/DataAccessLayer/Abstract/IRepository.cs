using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T> where T : class
    {
        List<T> List();
        void Insert(T p);
        void Update(T p);
        void Delete(T p);

        //Şartlı listeleme
        List<T> List(Expression<Func<T, bool>> filter); // filtreli listeleme
        T Get(Expression<Func<T, bool>> filter); // tek bir kayıt getirme
    }
}
