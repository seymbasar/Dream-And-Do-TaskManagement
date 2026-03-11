using EntityLayer.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICardService
    {
        void CardAdd(Card card);
        void CardDelete(Card card);
        void CardUpdate(Card card);
        List<Card> GetLists();
        Card GetByID(int id);
    }
}
