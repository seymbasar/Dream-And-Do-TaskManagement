using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Conrete
{
    //Kullanıcılar Tablosu Giriş yapmak için gerekecek.
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(10)]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
