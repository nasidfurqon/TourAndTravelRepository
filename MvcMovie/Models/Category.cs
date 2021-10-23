using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List <Destination> Destinations{get;set;}
    }
}