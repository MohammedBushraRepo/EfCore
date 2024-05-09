using EfCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Models
{
    public class Blog
    {
        public int Id { get; set; }

        //To Chane Property Name Using Data Anotation
        [Column("WebUrl")]
        //To Change the MaxLenght to the Proprty using Data Annotation
        [MaxLength(200)]
        public string  Url { get; set; }
        //To Exclude Property from the migration using Data Annotation
        [NotMapped]
        public DateTime CreatedOn { get; set; }

        //How to change Data Type Using Data Annotaion 
        [Column(TypeName = "decimal(50)")]
        //How to Add Comment to the property using data Annotation
        [Comment("this is the rating of the post")]
        public int rating { get; set; }


        //Add new table to the db without adding  A DB Set
        public List<Post> Posts { get; set; }
    }
}

//******** this how to ignore using data anotation

//[NotMapped]
//public List<Post> Posts { get; set; }