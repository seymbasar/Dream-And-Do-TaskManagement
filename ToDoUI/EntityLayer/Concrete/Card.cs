using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Conrete
{
    //Kartlar / Tasklar Tablosu her bir "satır" burasıdır.İşin kalbi burada atar.
    public class Card
    {
        [Key]
        public int CardID {  get; set; }

        [StringLength(50)]
        public string CardName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
        public DateTime CardDate { get; set; }
        public bool CardStatus { get; set; }

        //ListID
        public int ListID { get; set; }
        public virtual List List { get; set; }
    }
}
