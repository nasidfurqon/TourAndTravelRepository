using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcMovie.Models
{
    public class CreateViewModel
    {   
        public virtual SelectList Names {get;set;}
        public virtual Destination Destinasi {get;set;}
        public virtual List <Category> Kategori {get;set;}
    }
}