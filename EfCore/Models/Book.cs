using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Models
{
    public  class Book
    {
        // How to mention the Primary Key 
       [Key]
        public int BookKey { get; set; }
        public string  Name { get; set; }
        public string Author { get; set; }
    }
}
