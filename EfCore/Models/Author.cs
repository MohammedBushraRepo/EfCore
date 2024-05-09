﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required , MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MaxLength(20)]
        public string LastName { get; set; }
        [MaxLength(20)]

        public string DisplayName { get; set; }


    }
}
