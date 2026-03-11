using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Conrete
{
    //Listeler Tablosu Her panonun içinde sütunlar olur. (Örn: "Yapılacaklar", "Devam Edenler", "Tamamlananlar")
    public class List
    {
        [Key]
        public int ListID { get; set; }

        [StringLength(50)]
        public string ListName { get; set; }

        //BoardID
        public int BoardID { get; set; } 
        public virtual Board Board { get; set; }


        public virtual ICollection<Card> Cards { get; set; }
    }
}
