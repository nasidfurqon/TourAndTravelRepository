using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public int CategoryId{get;set;}
        public string Place{get;set;}
        public decimal Price{get;set;}

    }
}