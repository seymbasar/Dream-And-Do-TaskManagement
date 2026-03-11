using BusinessLayer.Concrete;
using DataAccessLayer.Conrrete.EntityFramework;
using EntityLayer.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToDoUI.Controllers
{
    public class BoardController : Controller
    {
        // Constructor bağımlılıklarını eksiksiz geçiyoruz
        BoardManager bm = new BoardManager(new EfBoardDal(), new EfListDal());
        CardManager cm = new CardManager(new EfCardDal());
        ListManager lm = new ListManager(new EfListDal());

        public ActionResult Index()
        {
            var values = bm.GetLists();
            return View(values);
        }

        [HttpPost]
        public ActionResult AddBoard(string BoardName)
        {
            if (!string.IsNullOrEmpty(BoardName))
            {
                Board b = new Board();
                b.BoardName = BoardName;
                // BoardStatus vb. diğer gerekli alanları set et
                bm.BoardAdd(b);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddCard(string cardName, int boardId)
        {
            // Bu panoya ait otomatik oluşturduğumuz o listeyi buluyoruz
            var targetList = lm.GetLists().FirstOrDefault(x => x.BoardID == boardId);
            if (targetList != null && !string.IsNullOrEmpty(cardName))
            {
                Card c = new Card
                {
                    CardName = cardName,
                    ListID = targetList.ListID,
                    CardStatus = true,
                    CardDate = DateTime.Now
                };
                cm.CardAdd(c);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ToggleCardStatus(int id)
        {
            var value = cm.GetByID(id);
            if (value != null)
            {
                // Status true ise false yapar, false ise true yapar (Toggle)
                value.CardStatus = !value.CardStatus;
                cm.CardUpdate(value); // Manager içindeki güncelleme metodun
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult UpdateCardOrder(int cardId, int newListId)
        {
            var card = cm.GetByID(cardId);
            if (card != null)
            {
                card.ListID = newListId; // Kartın artık yeni listesine ait olduğunu söylüyoruz
                cm.CardUpdate(card);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        public ActionResult DeleteBoard(int id)
        {
            var value = bm.GetByID(id);
            bm.BoardDelete(value);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCard(int id)
        {
            var value = cm.GetByID(id); // CardManager kullanarak kartı bulur
            cm.CardDelete(value);
            return RedirectToAction("Index");
        }
    }
}