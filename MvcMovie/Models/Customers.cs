using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MvcMovie.Models
{
    public class Customers:IdentityUser
    {   
        public string Avatar {get;set;}
        public virtual List <Transaction> transactions{get;set;}
    }
}