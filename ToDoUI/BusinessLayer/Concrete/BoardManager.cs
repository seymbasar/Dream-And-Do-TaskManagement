using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using System.Data.Entity;
using DataAccessLayer.Conrrete.EntityFramework;
using DataAccessLayer.Conrrete.Repositories;
using EntityLayer.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete


{
        // 1. Mutlaka IBoardService arayüzünden miras almalısın (İlerde hata almamak için)
        public class BoardManager : IBoardService
        {
        // 2. Sadece IBoardDal kullanıyoruz, GenericRepository nesnesini siliyoruz
        IBoardDal _boardDal;
        IListDal _listDal; // Liste eklemek için bu şart!

        public BoardManager(IBoardDal boardDal, IListDal listDal)
        {
            _boardDal = boardDal;
            _listDal = listDal; // Yukarıda IListDal _listDal; tanımlamayı unutma
        }

        // 3. Controller'da 'GetList' olarak çağırdığın için ismi 'GetList' yapıyoruz
        public List<Board> GetLists()
        {
            // Context sınıfının tam yolunu belirterek (Namespace) hata ihtimalini bitiriyoruz
            using (DataAccessLayer.Conrrete.Context c = new DataAccessLayer.Conrrete.Context())
            {
                return c.Boards
                        .Include(x => x.Lists.Select(y => y.Cards))
                        .ToList();
            }
        }

        // 4. Ekleme metodu (Derslerdeki standart isimlendirme)
        public void BoardAdd(Board p)
        {
            if (!string.IsNullOrEmpty(p.BoardName) && p.BoardName.Length > 2)
            {
                p.BoardStatus = true;
                _boardDal.Insert(p); // Panoyu ekler

                // BURASI DEĞİŞTİ: ListManager yerine doğrudan _listDal kullanıyoruz
                _listDal.Insert(new List
                {
                    ListName = "Genel",
                    BoardID = p.BoardID
                });
            }
        }

        // 5. Diğer zorunlu metodlar (Interface'den gelen boş şablonlar)
        public void BoardDelete(Board board)
            {
                _boardDal.Delete(board);
            }

            public void BoardUpdate(Board board)
            {
                _boardDal.Update(board);
            }

            public Board GetByID(int id)
            {
                return _boardDal.Get(x => x.BoardID == id);
            }

    }
}
