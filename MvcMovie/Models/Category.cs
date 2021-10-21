using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tempat {get ;set;}
    }
}