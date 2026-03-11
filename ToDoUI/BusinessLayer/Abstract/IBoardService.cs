using EntityLayer.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBoardService
    {
        void BoardAdd(Board board);
        void BoardDelete(Board board);
        void BoardUpdate(Board board);
        List<Board> GetLists();
        Board GetByID(int id);
    }
}
