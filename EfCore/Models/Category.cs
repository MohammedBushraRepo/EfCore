using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Models
{
    public class Category
    {
        //How to Add primary key default value
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Byte Id { get; set; }

        public string  Name { get; set; }
    }
}
