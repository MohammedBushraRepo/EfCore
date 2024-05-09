using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Models
{

    //How to change Table Name using data Anotation
    [Table("Posts")]

    //How to Change Table Schema
    [Table("Postsss", Schema = "Posting")]
    public class Post
    {
        public int  Id { get; set; }
        public string title { get; set; }

        public string content { get; set; }

        //Add new table to the db without adding  A DB Set
        public Blog  Blog { get; set; } 
    }
}
