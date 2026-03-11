using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CardManager : ICardService
    {

        ICardDal _cardDal;
         public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }

        public void CardAdd(Card card)
        {
            _cardDal.Insert(card);
        }

        public void CardDelete(Card card)
        {
            _cardDal.Delete(card);
        }

        public void CardUpdate(Card card)
        {
            _cardDal.Update(card);
        }

        public Card GetByID(int id)
        {
            return _cardDal.Get(x => x.CardID == id);
        }   

        public List<Card> GetLists()
        {
            return _cardDal.List();
        }
        public List<Card> GetListByListID(int id)
        {
            // ListID kullanmalısın çünkü Card, List'e bağlıdır.
            return _cardDal.List(x => x.ListID == id);
        }
    }
}

