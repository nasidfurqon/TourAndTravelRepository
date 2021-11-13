using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcMovie.Models
{
    public class TransaksiViewModel
    {   
        public virtual SelectList Prices {get;set;}
        public virtual SelectList Places {get;set;}
        public virtual Transaction Transaksi {get;set;}
        public virtual List <Destination> Destinasi {get;set;}
    }
}