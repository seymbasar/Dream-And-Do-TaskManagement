using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Conrete
{
    //Panolar Tablosu Trello’nun en üst çatısıdır. (Örn: "Ders Çalışma Programı", "Yazılım Projesi")
    public class Board
    {
        [Key]
        public int BoardID { get; set; }

        [StringLength(50)]
        public string BoardName { get; set; }
        public bool BoardStatus { get; set; }

        public virtual ICollection<List> Lists { get; set; }
    }
}
