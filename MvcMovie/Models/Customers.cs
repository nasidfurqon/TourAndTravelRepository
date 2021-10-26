using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MvcMovie.Models
{
    public class Customers:IdentityUser
    {   
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(50)]
        public string Address{get;set;}
        public virtual List <Transaction> transactions{get;set;}
    }
}